using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.Contracts;

namespace IoT.Grains
{
    public class UserGrain : IUserGrain
    {
        public Task<bool> AddNewDevice(string deviceId)
        {
            throw new NotImplementedException();
        }

        public Task HandleWarning(Warning message)
        {
            throw new NotImplementedException();
        }
    }
}
