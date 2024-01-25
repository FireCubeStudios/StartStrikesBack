using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using StartStrikesBack.Core.Attributes;
using StartStrikesBack.Core.Interfaces.Classes;
using StartStrikesBack.Core.Interfaces.Services;
using StartStrikesBack.Core.Services;
using StartStrikesBack.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Classes
{
    public partial class DefaultStartSettings : ObservableObject, IStartSettings
    {
        private static ISettingsService settingsService = ServiceContainer.Services.GetService<ISettingsService>();

        private bool isListLeftAligned = settingsService.GetValue<bool>("default-isListLeftAligned", true);
        [SettingsMetadata("Align the App list to left", "If enabled the app list is shown in the left side of the start menu, otherwise it is shown in the right side")]
        public bool IsListLeftAligned
        {
            get => isListLeftAligned;
            set
            {
                settingsService.SetValue("default-isListLeftAligned", value);
                SetProperty(ref isListLeftAligned, value);
            }
        }

        private bool isPowerLeftAligned = settingsService.GetValue<bool>("default-isPowerLeftAligned", true);
        [SettingsMetadata("Align the power button to left", "If enabled the power button is shown on the left side, otherwise it is shown in the right side")]
        public bool IsPowerLeftAligned
        {
            get => isPowerLeftAligned;
            set
            {
                settingsService.SetValue("default-isPowerLeftAligned", value);
                SetProperty(ref isPowerLeftAligned, value);
            }
        }
    }
}
