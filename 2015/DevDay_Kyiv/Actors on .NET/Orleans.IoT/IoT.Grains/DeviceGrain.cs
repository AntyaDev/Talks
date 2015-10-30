using System;
using System.Threading.Tasks;
using Orleans;
using IoT.Interfaces;

namespace IoT.Grains
{
    public class DeviceGrain : Grain, IDeviceGrain
    {
        State _state;
        const double MAX_TEMP = 100;

        public override Task OnActivateAsync()
        {            
            var id = this.GetPrimaryKeyString();
            // _state = await _stateStorage.LoadStateAsync(id);
            _state = new State { SystemName = "", Temp = 0, Id = id };
            return base.OnActivateAsync();
        }

        public async Task SetTemperature(double value)
        {            
            _state.Temp = value;
            var systemGrain = GrainFactory.GetGrain<ISystemGrain>(_state.SystemName);
            await systemGrain.SetTemperature(value, _state.Id);            
        }

        public Task<double> GetTemperature()
        {
            return Task.FromResult<double>(_state.Temp);
        }

        public Task JoinSystem(string name)
        {
            _state.SystemName = name; 
            // await _stateStorage.SaveStateAsync(_state);
            return TaskDone.Done;
        }

        class State
        {
            public string Id { get; set; }
            public double Temp { get; set; }
            public string SystemName { get; set; }
        }
    }
}
