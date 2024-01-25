using StartStrikesBack.Core.Classes;
using StartStrikesBack.Core.Interfaces.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Services
{
    public interface IPanelService : INotifyPropertyChanged
    {
        public ObservableCollection<IStartPanelItem> Panels { get; set; }

        ObservableCollection<T> GetItems<T>() where T : IStartPanelItem;
        Task SaveAsync();
    }
}
