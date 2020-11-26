
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Windows;
using UIFrameworkCore;
using UIFrameworkCore.DependencyInjectionExtension;

namespace UI框架
{
    class Program
    {
        [STAThread]
        private static int Main(string[] args)
        {

            var startupContainer = new MsiContainer();
            var _container = startupContainer.BuildServiceProvider();

            ServiceLocator.Instance.SetServiceProvider(_container);

            //container.Initialize();

            try
            {
                var warpFactory = _container.GetRequiredService<ILoggerWarpFactory>();
                //var _logger = warpFactory.GetLogger();
                var logger = warpFactory.GetLogger("AssemblyError");

                //_logger.Error("Hello");
                //logger.Error("Hello");


                var mainWindow = _container.GetRequiredService<MainWindow>();
                mainWindow.ShowDialog();
                return 0;
            }
            catch (Exception ex)
            {
                UIFrameworkCore.Helper.FileHelper.Appand系统日志Info(ex.ToString(), "Error");
                SystemManager.Restart();
             //   MessageBox.Show("系统错误:"+ex.ToString());
                return -1;
            }
        }


        internal class MsiContainer : Container
        {
            public MsiContainer()
            {
            }

            protected override void ConfigService(IServiceCollection services)
            {
                services.ScannerFile($"{AppDomain.CurrentDomain.BaseDirectory}UIFrameworkCore.dll");
                services.Scanner(Assembly.GetExecutingAssembly());


                services.Scanner(AppDomain.CurrentDomain.BaseDirectory, "Plugins.*.dll");

                //services.Scanner($"{AppDomain.CurrentDomain.BaseDirectory}\\DownloadPlugs", "Plugs.Extension*.dll");
                //services.AddSingleton<IDispatcherFactory, DispatcherFactory>();
                //services.AddSingleton(typeof(Dispatcher), serviceProvider => serviceProvider.GetRequiredService<IDispatcherFactory>().Get());

                //services.AddSingleton(typeof(IServiceProvider), serviceProvider=>{ return serviceProvider; });
            }

        }
    }
}
