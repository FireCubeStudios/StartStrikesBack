using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Classes
{
    public interface IStartMenuWindow
    {
        public IStartMenu Start { get; }
        void ShowStartMenu();
        void HideStartMenu();
    }
}
