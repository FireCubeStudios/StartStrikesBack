using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Classes
{
    public interface IStartPanelItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
