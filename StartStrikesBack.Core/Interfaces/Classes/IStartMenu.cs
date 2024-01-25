using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Classes
{
    public interface IStartMenu
    {
        bool IsFullScreen { get; set; }
        int RequestedWidth { get; set; }
        int RequestedHeight { get; set; }
        IStartSettings Settings { get; }
    }
}
