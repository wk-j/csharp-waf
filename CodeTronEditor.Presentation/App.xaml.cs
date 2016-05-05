using CodeTronEditor.Applications.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Waf.Applications;
using System.Windows;

namespace CodeTronEditor.Presentation
{
    public partial class App : Application
    {

        private AggregateCatalog catalog;
        private CompositionContainer container;
        private IApplicationController controller;


        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ViewModel).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IApplicationController).Assembly));

            container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
            CompositionBatch batch = new CompositionBatch();
            //batch.AddExport(container);
            container.Compose(batch);
            
            controller = container.GetExportedValue<IApplicationController>();
            controller.Initialize();
            controller.Run();
        }
    }
}
