using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Services
{
    public interface IPowerService
    {
        public Task ShutdownAsync();
        public Task SleepAsync();
        public Task RestartAsync();
        public Task OpenSignInOptionsAsync();
    }
}
