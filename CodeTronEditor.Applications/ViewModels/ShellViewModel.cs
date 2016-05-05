using CodeTronEditor.Applications.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;
using System.Windows.Input;
using System.Windows;

namespace CodeTronEditor.Applications.ViewModels
{
    [Export]
    public class ShellViewModel : ViewModel<IShellView>
    {
        private ICommand _showCommand;
        private bool _showPicture = true;

        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {

        }

        public void Show()
        {
            this.ViewCore.Show();
        }

        public void Close()
        {
            this.ViewCore.Close();
        }

        public bool ShowPicture
        {
            get { return _showPicture; }
            set { SetProperty(ref _showPicture, value); }
        }


        public ICommand ShowCommand
        {
            get { return _showCommand; }
            set { SetProperty(ref _showCommand, value); }
        }
    }
}
