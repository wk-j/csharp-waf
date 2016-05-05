using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;

namespace CodeTronEditor.Applications.Views
{
    public interface IShellView : IView
    {
        event CancelEventHandler Closing;
        event EventHandler Closed;

        void Show();
        void Close();
    }
}
