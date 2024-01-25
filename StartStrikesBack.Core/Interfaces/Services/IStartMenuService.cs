using StartStrikesBack.Core.Interfaces.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Services
{
    public interface IStartMenuService
    {
        public bool IsStartVisible { get; set; }
        void LaunchStartMenu();
    }
}
