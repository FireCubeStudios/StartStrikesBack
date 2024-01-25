using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Services
{
    public interface ISettingsService
    {
        T GetValue<T>(string key);
        T GetValue<T>(string key, T defaultValue); // If the key does not exist then return the default value specified
        void SetValue<T>(string key, T value);
    }
}
