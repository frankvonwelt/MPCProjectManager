using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MPCProjectManager.BO;
using MPCProjectManager.Models;

namespace MPCProjectManager
{
    public class MPCProjectImporter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region paths
        public string ProjectFileFullPath { get; set; }
        public string ProjectFileContentFolderFullPath
        {
            get { return Path.Combine(Path.GetDirectoryName(ProjectFileFullPath), ProjectName + "_[ProjectData]"); }
        }

        public string ProjectFileContentFolderName
        {
            get { return ProjectName + "_[ProjectData]"; }
        }
        public string ProjectName
        {
            get { return Path.GetFileNameWithoutExtension(ProjectFileFullPath); }
        }
        public string AllSequencesAndSongsFullPath
        {
            get { return Path.Combine(ProjectFileContentFolderFullPath, "All Sequences & Songs.xal"); }
        }
        public string SequencePath
        {
            get { return ProjectFileContentFolderFullPath; }
        }

        public List<BoProgram> Programs { get; set; }

        public MPCProjectImporter()
        {
            sqxList = new List<Melanchall.DryWetMidi.Core.MidiFile>();
            BOSequences = new List<BoSequence>();
            Programs = new List<BoProgram>();
        }
        #endregion

        #region public properties

        public Project Project { get; set; }
        public MPCVObject MpcvObject { get; set; }
        public List<Melanchall.DryWetMidi.Core.MidiFile> sqxList { get; set; }
        public List<BoSequence> BOSequences { get; set; }
        #endregion

        #region public methods
        public void ParseFile()
        {
            #region project file
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Project));

                using (var stream = File.Open(ProjectFileFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    reader.MoveToContent();
                    Project = (Project) serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            #endregion 
                
            #region all Sequences and songs file
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MPCVObject));

                using (var stream = File.Open(AllSequencesAndSongsFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    reader.MoveToContent();
                    MpcvObject = (MPCVObject)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            #endregion

            #region programs
            //get a list of all program names first.
            var programResult = Directory.GetFiles(ProjectFileContentFolderFullPath, "*.xpm");

            foreach (string res in programResult)
            {
                //read name , type and path
                BoProgram p = new BoProgram();
                p.ProgramFullPath = res;
                var v = p.ProgramName.Split('.');

                if (v[1] == "Drum") { p.ProgramType = MPCProgramTypes.Drum; }
                else if (v[1] == "Clip") { p.ProgramType = MPCProgramTypes.Clip; }
                else if (v[1] == "Keygroup") { p.ProgramType = MPCProgramTypes.Keygroup; }
                else if (v[1] == "Audio") { p.ProgramType = MPCProgramTypes.Audio; }
                else if (v[1] == "Midi") { p.ProgramType = MPCProgramTypes.Midi; }
                else if (v[1] == "CV") { p.ProgramType = MPCProgramTypes.CV; }
                else if (v[1] == "Plugin") { p.ProgramType = MPCProgramTypes.CV; }
                else
                {
                    throw new NotImplementedException();
                }

                //read xml content (Deserialize)
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MPCVObjectProgram));
                    using (var stream = File.Open(p.ProgramFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        reader.MoveToContent();
                        p.MpcvObjectProgram = (MPCVObjectProgram) serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {

                }

                //add all samples names used in this program
                //only do this for program types that contain samples
                if(p.ProgramType == MPCProgramTypes.Drum 
                   || p.ProgramType == MPCProgramTypes.Clip 
                   || p.ProgramType == MPCProgramTypes.Keygroup)
                { 
                    foreach (Instrument i in p.MpcvObjectProgram.Program.Instruments.Instrument)
                    {
                        foreach (Layer l in i.Layers.Layer)
                        {
                            if(!string.IsNullOrEmpty(l.SampleName))
                            {
                                p.SampleFileNames.Add(new BoSampleFile(){SampleFileName = l.SampleName, SampleFileExtension = "WAV"});
                            }
                        }
                    }
                }
                Programs.Add(p);

            }
            #endregion

            #region SequenceFiles

            foreach (Sequence s in MpcvObject.AllSequencesAndSongs.Sequences.SequenceList)
            {
                BoSequence bos = new BoSequence();
                string sxFilename = s.Number.ToString() + ".sxq";
                bos.SequenceNumber = s.Number;
                bos.SxqFileFullPath = Path.Combine(ProjectFileContentFolderFullPath, sxFilename);
                bos.SxqFile = Melanchall.DryWetMidi.Core.MidiFile.Read(bos.SxqFileFullPath);
                bos.ParsePrograms(Programs);
                BOSequences.Add(bos);
            }
            //trying to read via melanchall lib

            #endregion

        }
        public void CopyProgram(BoProgram programToCopy, string targetProgramFPath)
        {
            //Copy the Program XML file
            File.Copy(programToCopy.ProgramFullPath,Path.Combine(targetProgramFPath,programToCopy.ProgramName));

            //copy all wav files
            
        }
        public BoSequence GetBoSequenceFromSequenceIndex(int idx)
        {
            foreach (var boSeq in BOSequences)
            {
                if(boSeq.SequenceNumber.Equals(idx.ToString()))
                {
                    return boSeq;
                }
            }

            return null;
        }
        #endregion
    }
}
