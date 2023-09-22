using PROG2B_2023.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PROG2B_2023.Model;

namespace PROG2B_2023.ViewModel
{
    class ModuleViewModel : ViewModelBase
    {
        //Declares the observable collection
        
        public ObservableCollection<Module> Module { get; set; }
        public RelayCommand AddCommand => new RelayCommand(execute => AddModule());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteModule(), canExecute => SelectedModule != null);
        public ModuleViewModel()
        {

            Module = new ObservableCollection<Module>();
        }
        private Module selectedModule;


        public Module SelectedModule
        {
            // gets the value of the selected item
            get { return selectedModule; }
            //sets the value of the selected item
            set
            {
                selectedModule = value;
                //updates the observable collection when the properties are edited
                OnPropertyChanged();
            }
        }

        private void AddModule()
        {
            Module.Add(new Module
            {
                //Add dummy data to the observable collection
                ModuleCode = "Code",
                ModuleName = "Name",
                Credits = 0,
                Classhours = 0
            });
        }

        private void DeleteModule()
        {
            //Displays messagebox to user
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // if the result is yes removes object from collection
            if (result == MessageBoxResult.Yes)
            {
                //Removes object from the observable collection
                Module.Remove(SelectedModule);
            }
            // if the result is no, do nothing 
        }
    }
}
