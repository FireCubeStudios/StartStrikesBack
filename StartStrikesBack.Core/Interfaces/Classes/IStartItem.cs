using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Classes
{
    public interface IStartItem : INotifyPropertyChanged
    {
        public string DisplayName { get; protected set; }
        public object Icon { get; protected set; }

        public Task LaunchAsync();
    }
}
