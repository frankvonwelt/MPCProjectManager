using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MPCProjectManager.BO;
using MPCProjectManager.BusinessObjects;
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

        private List<CopyJob> CopyJobs { get; set; }
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

        public bool btCopyR2LEnabled
        {
            get { return (bool)GetValue(btCopyR2LEnabledProperty); }
            set { SetValue(btCopyR2LEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for btCopyR2LEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty btCopyR2LEnabledProperty =
            DependencyProperty.Register("btCopyR2LEnabled", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));


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

                //clear list from old entries
                LeftSequenceList.Clear();

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

                //import the files
                LeftImporter.ProjectFileFullPath = LeftPathChosen;
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

                #region open file dialog
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "xpj files |*.xpj*"
                };

                if (openFileDialog.ShowDialog(this) == false) return;
                RightPathChosen = openFileDialog.FileNames[0] ?? throw new ArgumentNullException("openFileDialog.FileNames[0]");
                #endregion

                log.Info($"User chose {RightPathChosen}");
                
                RightImporter.ProjectFileFullPath = RightPathChosen;
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

            #region check input data
            if (ComboBoxRightTarget.SelectedItem == null)
            {
                MessageBox.Show("No source sequence chosen.","Error", MessageBoxButton.OK); 
                return;
            }

            if (CmbLeftTarget.SelectedItem == null)
            {
                MessageBox.Show("No destination sequence chosen.", "Error", MessageBoxButton.OK);
                return;
            }
            #endregion
            
            int sourceIndex = ComboBoxRightTarget.SelectedIndex+1;
            int destIndex = CmbLeftTarget.SelectedIndex+1;
            log.Info($"copy Sequence {sourceIndex} ({RightSequenceList[sourceIndex-1].Name}) to {destIndex} ({LeftSequenceList[destIndex].Name})");
            CopyJobs = new List<CopyJob>();
            try
            {
                //copy all programs of source sequence
                foreach (var p in RightImporter.GetBoSequenceFromSequenceIndex(sourceIndex).UsedBoPrograms)
                {
                    try
                    {
                        //copy the *.xpm file
                        var t = Path.Combine(LeftImporter.ProjectFileContentFolderFullPath, p.ProgramFileName);
                        if (!File.Exists(t))
                        {
                            CopyJobs.Add(new CopyJob(p.ProgramFullPath, t));
                        }

                        //check if it has wav files and copy them as well
                        foreach (BoSampleFile sampleFileName in p.SampleFileNames)
                        {
                            var wavet = Path.Combine(LeftImporter.ProjectFileContentFolderFullPath, sampleFileName.SampleFile);

                            if (!File.Exists(wavet))
                            {
                                CopyJobs.Add(new CopyJob(Path.Combine(RightImporter.ProjectFileContentFolderFullPath, sampleFileName.SampleFile), wavet));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Error processing used programs");
                    }
                }

                ////copy sequence itself
                CopyJobs.Add(new CopyJob(RightImporter.GetBoSequenceFromSequenceIndex(sourceIndex).SxqFileFullPath, Path.Combine(LeftImporter.ProjectFileContentFolderFullPath, (destIndex).ToString() + ".sxq")));

                //add a sequence object to the all senquences and songs object
                Sequence sequenceToAdd = new Sequence();
                sequenceToAdd.Name = ((Sequence) ComboBoxRightTarget.SelectedItem).Name;
                sequenceToAdd.Number = (destIndex).ToString();
                sequenceToAdd.Active = true.ToString();

                LeftImporter.MpcvObject.AllSequencesAndSongs.Sequences.SequenceList.Add(sequenceToAdd);
                //TODO Sort sequencelist before serializing:
                //LeftImporter.MpcvObject.AllSequencesAndSongs.Sequences.SequenceList.Sort()
                LeftImporter.MpcvObject.SaveToFile(LeftImporter.AllSequencesAndSongsFullPath);
                log.Info($"AllSequences file saved to {LeftImporter.AllSequencesAndSongsFullPath}");
                
                foreach (var cjob in CopyJobs)
                {
                    try
                    {
                        string fileEntry = $"./{LeftImporter.ProjectFileContentFolderName}/{Path.GetFileName(cjob.DestinationFullPath)}";
                        if (!LeftImporter.Project.FileList.File.Contains(fileEntry))
                        {
                            if(!fileEntry.EndsWith(".sxq"))
                            { 
                                LeftImporter.Project.FileList.File.Add(fileEntry);
                            }
                        }
                        log.Info($"Executing file copy job: {cjob.SourceFullPath} to {cjob.DestinationFullPath}");
                        File.Copy(cjob.SourceFullPath, cjob.DestinationFullPath);
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Error during file copy job.",ex);
                    }
                }
                //save project including filelist
                LeftImporter.Project.SaveToFile(LeftImporter.ProjectFileFullPath);
            }
            catch (Exception ex)
            {
                log.Error("General error copying sequence content",ex);
            }

            #region UI Update
            log.Info("Updating the UI"); 
            //overwrite the list with empty entries with the ones that where imported
            LeftSequenceList[destIndex].Name = RightSequenceList[sourceIndex].Name;

            //clear list from old entries
            LeftSequenceList.Clear();

            //fill the sequence list to have always 128 sequences
            for (int i = 1; i < 129; i++)
            {
                LeftSequenceList.Add(new Sequence() { Active = "false", Name = "-Empty-", Number = i.ToString() });
            }

            //overwrite the list with empty entries with the ones that where imported
            foreach (var seq in LeftImporter.MpcvObject.AllSequencesAndSongs.Sequences.SequenceList)
            {
                LeftSequenceList[Convert.ToInt32(seq.Number) - 1].Name = seq.Name;
            }
            #endregion

            log.Info("BtnCopyR2L_OnClick finished");
        }
        
        private void BtnSaveLeftProject_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void CmbLeftTarget_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            log.Info($"CmbLeftTarget_OnSelectionChanged with added items count:{e.AddedItems.Count} ");
            btCopyR2LEnabled = false;
            if (e.AddedItems.Count == 0)
            {
                log.Error("nothing choosen.. returning..");                
                return;
            }
            btCopyR2LEnabled = true;
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

        #endregion
    }
}
