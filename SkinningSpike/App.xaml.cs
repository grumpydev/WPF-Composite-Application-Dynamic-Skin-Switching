using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace SkinningSpike
{
    using Infrastructure;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<IModule> modules;

        protected override void OnStartup(StartupEventArgs e)
        {
            this.modules = new List<IModule>();
            var container = TinyIoC.TinyIoCContainer.Current;

            container.Register<IResourceManager, ResourceManager>();
            container.Register<ISkinSwitcher, SkinSwitcher>();
            container.RegisterMultiple<IModule>(new[] { typeof(ControlLibrary.Module) });
            
            this.modules.AddRange(container.ResolveAll<IModule>());

            foreach (var module in this.modules)
            {
                module.Initialise();
            }

            container.Resolve<MainWindow>().Show();
        }
    }
}
