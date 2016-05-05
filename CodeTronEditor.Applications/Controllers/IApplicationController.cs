using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTronEditor.Applications.Controllers
{
    public interface IApplicationController
    {
        void Initialize();
        void Run();
        void Shutdown();
    }
}
