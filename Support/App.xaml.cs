using Support.AppComposition;
using Support.MainMenu;
using LightInject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Support
{
    public partial class App : Application
    {
        private readonly ServiceContainer _container;
        private readonly Uri _TicketSystem = new Uri("https://support.valeo-it.de");
        private readonly Uri _atlasUri = new Uri("steam://connect/176.57.181.109:29615");
        private readonly Uri _supportMailUri = new Uri("mailto:support@ded-chaotentruppe.de?subject=[SUPPORT]Ich brauche Hilfe");
        private readonly Uri _HomepageUri = new Uri("https://valeo-it.de");

        public App()
        {
            _container = new ServiceContainer(new ContainerOptions()
                                                  {
                                                      EnablePropertyInjection = false
                                                  });
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container.RegisterApplicationShell()
                      .RegisterMainMenu(_TicketSystem,
                                        _HomepageUri);

            MainWindow = _container.GetInstance<MainWindow>();
            MainWindow.Show();

            await Task.Delay(200);

            _container.GetInstance<INavigator>().NavigateTo(_container.GetInstance<MainMenuView>());
        }
    }
}
