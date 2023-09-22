using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROG2B_2023.View;
using PROG2B_2023.Model;
using PROG2B_2023.MVVM;
using System.Collections.ObjectModel;
using System.Windows;

namespace PROG2B_2023.ViewModel
{
    class SemesterViewModel : ViewModelBase
    {
        //Declaration of the observable collection
        public ObservableCollection<Semester> Semester { get; set; }
        //Command to execute AddSemester method
        public RelayCommand AddCommand => new RelayCommand(execute => AddSemester());
        //Command to check if an object can be deleted, if true the object is deleted, if false button cannot be clicked
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteSemester(), canExecute => SelectedSemester != null);
        public SemesterViewModel()
        {
            //constructor
            Semester = new ObservableCollection<Semester>();
        }
        private Semester selectedSemester;


        public Semester SelectedSemester
        {
            // gets the value of the selected item
            get { return selectedSemester; }
            //sets the value of the selected item
            set
            {
                selectedSemester = value;
                //updates the observable collection when the properties are edited
                OnPropertyChanged();
            }
        }

        private void AddSemester()
        {
            Semester.Add(new Semester
            {
                //Add dummy data to the observable collection
                SemesterDate = new DateTime(2023, 1, 1),
                NumWeeks = 12
            });
        }

        private void DeleteSemester()
        {
            //Displays messagebox to user
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // if the result is yes removes object from collection
            if (result == MessageBoxResult.Yes)
            {
                //Removes object from the observable collection
                Semester.Remove(SelectedSemester);
            }
            // if the result is no, do nothing
        }
    }
}
