using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROG2B_2023.View;

namespace PROG2B_2023.MVVM
{
    //Contains an interface for opening dialog windows
    public interface IDialogService
    {
        void ShowDialog(string name);
    }
    class DialogService : IDialogService
    {
         public void ShowDialog(string name)
        {
            //
            var dialog = new DialogWindow();
            // gets the name of the specific view that needs to be open.
            var type = Type.GetType($"PROG2B_2023.View.{name}");
            dialog.Content = Activator.CreateInstance(type);
            // Displays a dialog window of the selected view
            dialog.ShowDialog();
        }
    }
}
