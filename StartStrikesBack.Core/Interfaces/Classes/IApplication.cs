using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Classes
{
    public interface IApplication : IStartItem, INotifyPropertyChanged
    {
        public string Id { get; set; }

        public Task LaunchAdminAsync();
        public Task LaunchAppSettingsAsync();
        public Task UninstallAsync();
    }
}
