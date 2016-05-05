using CodeTronEditor.Applications.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;

namespace CodeTronEditor.Applications.Controllers
{
    [Export(typeof(IApplicationController))]
    internal class ApplicationController : IApplicationController
    {
        private readonly ShellViewModel shellViewModel;

        [ImportingConstructor]
        public ApplicationController(Lazy<ShellViewModel> shellViewModel)
        {
            this.shellViewModel = shellViewModel.Value;
            this.shellViewModel.ShowCommand = new DelegateCommand(ShowPicture);
        }

        private void ShowPicture()
        {
            shellViewModel.ShowPicture = !shellViewModel.ShowPicture;
        }

        public void Initialize()
        {

        }

        public void Run()
        {
            this.shellViewModel.Show();
        }

        public void Shutdown()
        {

        }
    }
}
