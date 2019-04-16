using Light.GuardClauses;
using Light.ViewModels;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Support.MainMenu
{
    public sealed class MainMenuViewModel : BaseNotifyPropertyChanged
    {
        private readonly Uri _TicketSystem;
        private readonly Uri _atlasUri;
        private readonly Uri _supportMailUri;
        private readonly Uri _HomepageUri;

        public MainMenuViewModel(Uri ticketsystemuri,
                                 Uri HomepageUri)
        {
            _TicketSystem = ticketsystemuri.MustNotBeNull(nameof(ticketsystemuri));
            _HomepageUri = HomepageUri.MustNotBeNull(nameof(HomepageUri));
            
            StartTicketSystem = new DelegateCommand(StartTeamSpeak);
            OpenBrowserHomepage = new DelegateCommand(OpenBrowserToHomepage);
        }

        public ICommand StartTicketSystem { get; }

        public ICommand NavigateToMapCommand { get; }

        public ICommand StartAtlasCommand { get; }

        public ICommand OpenSupportMailCommand { get; }

        public ICommand NavigateToTwitchCommand { get; }

        public ICommand OpenBrowserHomepage { get; }

        private void StartTeamSpeak() => 
            Process.Start(new ProcessStartInfo(_TicketSystem.AbsoluteUri));

        private void StartAtlas() => 
            Process.Start(new ProcessStartInfo(_atlasUri.AbsoluteUri));

        private void OpenSupportMail() => 
            Process.Start(new ProcessStartInfo(_supportMailUri.AbsoluteUri));

        private void OpenBrowserToHomepage() =>
            Process.Start(new ProcessStartInfo(_HomepageUri.AbsoluteUri));
    }
}
