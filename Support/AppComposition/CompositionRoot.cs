using Support.MainMenu;
using LightInject;
using System;
using System.Linq;
using System.Net.Http;

namespace Support.AppComposition
{
    public static class CompositionRoot
    {
        public static ServiceContainer RegisterApplicationShell(this ServiceContainer container)
        {
            container.Register<MainWindow>(new PerContainerLifetime())
                     .Register<MainWindowViewModel>(new PerContainerLifetime())
                     .Register<INavigator>(f => f.GetInstance<MainWindowViewModel>());

            return container;
        }

        public static ServiceContainer RegisterMainMenu(this ServiceContainer container, 
                                                        Uri ticketsystemuri, 
                                                        Uri homepageUri)
        {
            container.Register<MainMenuView>(new PerContainerLifetime())
                     .Register<MainMenuViewModel>(c => new MainMenuViewModel(
                                                                             ticketsystemuri,
                                                                             homepageUri)); 

            return container;
        }
    }
}
