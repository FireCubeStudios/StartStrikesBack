using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using StartStrikesBack.Core.Interfaces.Classes;
using StartStrikesBack.Core.Interfaces.Services;
using StartStrikesBack.Core.Messages;
using StartStrikesBack.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.ViewModels
{
    public partial class StartMenuViewModel : ObservableObject
    {
        public IAppService AppService { get; }
        public IPanelService PanelsService { get; }
        public IProfileService ProfileService { get; }
        private IPowerService PowerService;

        public StartMenuViewModel(IAppService appService, IPanelService panelsService, IPowerService powerService, IProfileService profileService) 
        {
            AppService = appService;
            PanelsService = panelsService;
            PowerService = powerService;
            ProfileService = profileService;
        }

        [RelayCommand]
        public void AddGroup() => PanelsService.Panels.Add(new StartStrikesBack.Core.Classes.Group("New group"));

        [RelayCommand]
        public async Task ExitAsync()
        {
            await PanelsService.SaveAsync();
            WeakReferenceMessenger.Default.Send(new AppExitRequestMessage());
        }

        [RelayCommand]
        public async Task ShutdownAsync() => await PowerService.ShutdownAsync();

        [RelayCommand]
        public async Task SleepAsync() => await PowerService.SleepAsync();

        [RelayCommand]
        public async Task RestartAsync() => await PowerService.RestartAsync();

        [RelayCommand]
        public async Task PowerSettingsAsync() => await PowerService.OpenSignInOptionsAsync();

        [RelayCommand]
        public async Task LockAsync() => await ProfileService.LockAsync();

        [RelayCommand]
        public async Task SignOutAsync() => await ProfileService.SignOutAsync();

        [RelayCommand]
        public async Task ProfileSettingsAsync() => await ProfileService.OpenAccountSettingsAsync();
    }
}
