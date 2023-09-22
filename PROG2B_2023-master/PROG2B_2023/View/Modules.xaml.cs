using System.Windows.Controls;
using PROG2B_2023.ViewModel;

namespace PROG2B_2023.View
{
    /// <summary>
    /// Interaction logic for Modules.xaml
    /// </summary>
    public partial class Modules : UserControl
    {
        public Modules()
        {
            InitializeComponent();
            // sets the data context of the view to the correct viewmodel
            ModuleViewModel vm = new ModuleViewModel();
            DataContext = vm;
        }
    }
}
