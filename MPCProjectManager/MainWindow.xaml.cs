using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MPCProjectManager.BO;
using MPCProjectManager.Models;


namespace MPCProjectManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region private properties
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private MPCProjectImporter RightImporter { get; set; }
        private MPCProjectImporter LeftImporter { get; set; }
        private string LeftPathChosen { get; set; }
        private string RightPathChosen { get; set; }
        #endregion

        #region public properties
        public ObservableCollection<Sequence> LeftSequenceList { get; set; }
        public ObservableCollection<Sequence> RightSequenceList { get; set; }
        public ObservableCollection<BoProgram> LeftUsedPrograms { get; set; }
        public ObservableCollection<BoProgram> RightUsedPrograms { get; set; }
        #endregion

        #region propdp
        public string LeftProjectName
        {
            get => (string)GetValue(LeftProjectNameProperty);
            set => SetValue(LeftProjectNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LeftProjectName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftProjectNameProperty = DependencyProperty.Register("LeftProjectName", typeof(string), typeof(MainWindow), new PropertyMetadata(""));

        public string RightProjectName
        {
            get => (string)GetValue(RightProjectNameProperty);
            set => SetValue(RightProjectNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for RightProjectName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightProjectNameProperty = DependencyProperty.Register("RightProjectName", typeof(string), typeof(MainWindow), new PropertyMetadata(""));
        #endregion
        
        #region CTOR
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            log.Info("Application started.");

            InitializeComponent();
            LeftSequenceList = new ObservableCollection<Sequence>();
            RightSequenceList = new ObservableCollection<Sequence>();
            LeftUsedPrograms = new ObservableCollection<BoProgram>();
            RightUsedPrograms = new ObservableCollection<BoProgram>();
            LeftProjectName = "ProjectName:";
            RightProjectName = "ProjectName:";
            DataContext = this;

            log.Info("CTOR completed.");
        }
        #endregion

        #region private methods
        private void BtnOpenLeftProject_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                log.Info("BtnOpenLeftProject_OnClick entered.");
                LeftImporter = new MPCProjectImporter();

                #region cleanup of workspace folder
                //clear list from old entries
                LeftSequenceList.Clear();

                //create workspace folder
                Directory.CreateDirectory("Temp");

                //delete old content
                EmptyTempFolder("temp");
                #endregion

                log.Info("cleanup left done.");

                #region open file dialog
                //let user choose the project
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "xpj files |*.xpj*"
                };
                if (openFileDialog.ShowDialog(this) == false) return;
                LeftPathChosen = openFileDialog.FileNames[0];
    
                #endregion

                log.Info($"User chose {LeftPathChosen}");

                CopyLeftProjectToWorkSpace(LeftPathChosen);

                //import the files
                LeftImporter.ProjectFileFullPath = Path.Combine("temp", Path.GetFileName(LeftPathChosen));
                LeftProjectName = "ProjectName: " + LeftImporter.ProjectName;

                LeftImporter.ParseFile();

                //fill the sequence list to have always 128 sequences
                for (int i = 1; i < 129; i++)
                {
                    LeftSequenceList.Add(new Sequence() {Active = "false", Name = "-Empty-", Number = i.ToString()});
                }

                //overwrite the list with empty entries with the ones that where imported
                foreach (var seq in LeftImporter.MpcvObject.AllSequencesAndSongs.Sequences.SequenceList)
                {
                    LeftSequenceList[Convert.ToInt32(seq.Number) - 1].Name = seq.Name;

                }

                log.Info("BtnOpenLeftProject_OnClick finished");
            }
            catch (Exception ex)
            {
                log.Error("Error during importing left project",ex);
            }
            
        }

        private void BtnOpenRightProject_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                log.Info("BtnOpenRightProject_OnClick entered.");
                RightImporter = new MPCProjectImporter();

                //clear list from old entries
                RightSequenceList.Clear();

                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "xpj files |*.xpj*"
                };

                if (openFileDialog.ShowDialog(this) == false) return;
                var filePath = openFileDialog.FileNames[0] ?? throw new ArgumentNullException("openFileDialog.FileNames[0]");

                RightImporter.ProjectFileFullPath = filePath;
                RightProjectName = "ProjectName: " + RightImporter.ProjectName;
                RightImporter.ParseFile();

                //fill ALL sequences with readable content all sequences disabled
                for (int i = 1; i < 129; i++)
                {
                    RightSequenceList.Add(new Sequence() {Active = "false", Name = "-Empty-", Number = i.ToString()});
                }

                //overwrite with importe used sequences
                foreach (var seq in RightImporter.MpcvObject.AllSequencesAndSongs.Sequences.SequenceList)
                {
                    RightSequenceList[Convert.ToInt32(seq.Number) - 1].Name = seq.Name;

                }

                log.Info("BtnOpenRightProject_OnClick finished");
            }
            catch (Exception ex)
            {
                log.Error("Error during importing right project", ex);
            }
        }

        private void BtnCopyL2R_OnClick(object sender, RoutedEventArgs e)
        {
            //decide source number
            //decide target number
            
            //check if target is empty


        }

        private void BtnCopyR2L_OnClick(object sender, RoutedEventArgs e)
        {
            log.Info("BtnCopyR2L_OnClick entered.");
            int sourceIndex = ComboBoxRightTarget.SelectedIndex;
            int destIndex = CmbLeftTarget.SelectedIndex;
            //copy all programs of source sequence
           foreach (var p in RightImporter.GetBoSequenceFromSequenceIndex(sourceIndex).UsedBoPrograms)
           {

               // copy the *.xpm file
               if(!File.Exists(Path.Combine("temp", LeftImporter.ProjectFileContentFolderName, p.ProgramFileName)))
                {
                    File.Copy(p.ProgramFullPath, Path.Combine("temp", LeftImporter.ProjectFileContentFolderName, p.ProgramFileName));
                }

               //check if it has wav files and copy them as well
               foreach (BoSampleFile sampleFileName in p.SampleFileNames)
               {
                   if (!File.Exists(Path.Combine("temp", LeftImporter.ProjectFileContentFolderName, sampleFileName.SampleFile)))
                   {
                       File.Copy(Path.Combine(RightImporter.ProjectFileContentFolderFullPath, sampleFileName.SampleFile),Path.Combine("temp", LeftImporter.ProjectFileContentFolderName, sampleFileName.SampleFile));
                   }
               }
            }

            //copy sequence itself
            File.Copy(RightImporter.GetBoSequenceFromSequenceIndex(sourceIndex).SxqFileFullPath,Path.Combine("temp", LeftImporter.ProjectFileContentFolderName, (destIndex+1).ToString()+".sxq"));
            log.Info("BtnCopyR2L_OnClick finished");
        }
        
        private void BtnSaveLeftPRoject_OnClick(object sender, RoutedEventArgs e)
        {
            //check if name exists there
            
            //create project xml file

            //crate project data folder

            //copy all programs (including wav files)

            //copy all sequences

        }

        private void CmbLeftTarget_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BoSequence result = new BoSequence();

            foreach (var s in LeftImporter.BOSequences)
            {
                if(s.SequenceNumber.Equals(((Sequence)e.AddedItems[0]).Number))
                {
                    result = s;
                }
            }

            LeftUsedPrograms.Clear();

            foreach (var resultUsedBoProgram in result.UsedBoPrograms)
            {
                LeftUsedPrograms.Add(resultUsedBoProgram);
            }
        }

        private void ComboBoxRightTarget_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BoSequence result = new BoSequence();

            foreach (var s in RightImporter.BOSequences)
            {
                if (s.SequenceNumber.Equals(((Sequence)e.AddedItems[0]).Number))
                {
                    result = s;
                }
            }

            RightUsedPrograms.Clear();

            foreach (var resultUsedBoProgram in result.UsedBoPrograms)
            {
                RightUsedPrograms.Add(resultUsedBoProgram);
            }
        }

        private void EmptyTempFolder(string path)
        {
            try
            {
                log.Info($"Cleaning folder: {path}");
                foreach (string f in Directory.GetFiles(path))
                {
                    File.Delete(f);
                }

                foreach (var d in Directory.GetDirectories(path))
                {
                        EmptyTempFolder(d);
                        Directory.Delete(d);
                }

                log.Info($"Cleaning folder: {path} done.");

            }
            catch (Exception ex)
            {
                log.Error("Error during cleaning folder",ex);
            }

        }

        private void CopyLeftProjectToWorkSpace(string pathToProjectFile)
        {
            string destFilename = Path.Combine("Temp", Path.GetFileNameWithoutExtension(pathToProjectFile) + ".xpj");
            //copy target to temp directory
            File.Copy(pathToProjectFile, destFilename);
            Directory.CreateDirectory(Path.Combine("Temp", Path.GetFileNameWithoutExtension(pathToProjectFile) + "_[ProjectData]"));
            var test = Path.Combine("Temp", Path.GetDirectoryName(pathToProjectFile), (Path.GetFileNameWithoutExtension(pathToProjectFile) + "_[ProjectData]"));
            foreach (var f in Directory.EnumerateFiles(test))
            {
                string dest = Path.Combine(Path.GetFileNameWithoutExtension(pathToProjectFile) + "_[ProjectData]", Path.GetFileName(f));                
                File.Copy(f, Path.Combine("Temp", dest));
            }
        }
        #endregion
    }
}
