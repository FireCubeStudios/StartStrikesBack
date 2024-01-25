using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Services
{
    public interface IProfileService
    {
        public object Icon { get; }
        public string Name { get; }

        public Task SignOutAsync();
        public Task LockAsync();
        public Task OpenAccountSettingsAsync();
    }
}
