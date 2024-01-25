using StartStrikesBack.Core.Interfaces.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Services
{
    public interface IAppService
    {
        public ObservableCollection<IApplication> Apps { get; protected set; }

        public IApplication GetAppFromID(string Id);
    }
}
