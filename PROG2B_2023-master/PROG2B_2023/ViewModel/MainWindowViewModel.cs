using Prism.Commands;
using PROG2B_2023.Model;
using PROG2B_2023.MVVM;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System;
using Library;

namespace PROG2B_2023.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        //constructor
        IDialogService DialogService = new DialogService();

        private DelegateCommand showDialog;
        public DelegateCommand ShowDialog =>
            showDialog ?? (showDialog = new DelegateCommand(OpenModuleDialog));
        
        private DelegateCommand showDialog2;
        public DelegateCommand ShowDialog2 =>
            showDialog2 ?? (showDialog2 = new DelegateCommand(OpenSemesterDialog));

        //public ObservableCollection<Semester> Semester { get; set; }
        //public ObservableCollection<Module> Module { get; set; }
        public ObservableCollection<Record> Record { get; set; }
        public RelayCommand AddCommand => new RelayCommand(execute => AddRecord());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteRecord(), canExecute => SelectedRecord != null);

        int self, credits, weeks, classhours;
        public MainWindowViewModel()
        {
            //Module = new ObservableCollection<Module>();
            //Semester = new ObservableCollection<Semester>();
            Record = new ObservableCollection<Record>();
        }
        private Record selectedRecord;


        public Record SelectedRecord
        {
            get { 
                return selectedRecord;
            }
            set
            {
                selectedRecord = value;
                Calc();
                selectedRecord.week_study_hours = self;
                OnPropertyChanged();
            }
        }

        private void AddRecord()
        {
            Record.Add(new Record
            {
                //Adds dummy data
                ModuleName2 = "Module Name",
                Credits2 = 10,
                Classhours2 = 4,
                NumWeeks2 = 12,
                week_study_hours = 0,
                Num_of_hours_studied = 0
            });
        }

        private void DeleteRecord()
        {
            //Displays message box to user
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //If the result is yes remove record, if no, do nothing
            if (result == MessageBoxResult.Yes)
            {
                //Removes the selected record
                Record.Remove(SelectedRecord);
            }
        }
        //Method to open the Modules view
        private void OpenModuleDialog()
        {
            DialogService.ShowDialog("Modules");
        }
        //Method for opening the semester view
        private void OpenSemesterDialog()
        {
            DialogService.ShowDialog("Semesters");
        }
        //Method to calculate the number of hours the student needs to self study
        public void Calc()
        {
            try
            {
                //code for the calculation of the number hours needed for self study
                
                credits = selectedRecord.Credits2;
                weeks = selectedRecord.NumWeeks2;
                classhours = selectedRecord.Classhours2;
                self = (credits * 10 / weeks) - classhours;
                
            }
            catch(Exception ex)
            {
                
            }
        }
    } 
}
