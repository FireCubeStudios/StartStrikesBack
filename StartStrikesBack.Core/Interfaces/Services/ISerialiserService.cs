using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Interfaces.Services
{
    public interface ISerialiserService
    {
        public Task<T> DeserialiseAsync<T>(string data);
        public Task<string> SerialiseAsync<T>(T data);
    }
}
