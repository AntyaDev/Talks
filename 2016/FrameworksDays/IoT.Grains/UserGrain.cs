using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IoT.Contracts;

namespace IoT.Grains
{
    public class UserGrain : IUserGrain
    {
        readonly UserState _state = new UserState();

        public Task<bool> AddNewDevice(string deviceId)
        {
            if (_state.Devices.Contains(deviceId))
                return Task.FromResult(false);

            _state.Devices.AddLast(deviceId);
            return Task.FromResult(true);
        }

        public Task HandleWarning(Warning message)
        {
            throw new NotImplementedException();
        }
    }

    class UserState
    {
        public LinkedList<string> Devices { get; private set; } = new LinkedList<string>();
    }
}
