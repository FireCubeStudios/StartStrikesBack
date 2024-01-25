using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Classes
{
    public interface ITaskbarItem
    {
        //public bool IsPinned { get; protected set; }

        public Task PinToTaskbarAsync();
        public Task UnpinFromTaskbarAsync();
    }
}
