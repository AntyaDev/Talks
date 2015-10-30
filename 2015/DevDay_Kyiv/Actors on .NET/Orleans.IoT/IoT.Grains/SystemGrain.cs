using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orleans;
using IoT.Interfaces;

namespace IoT.Grains
{
    public class SystemGrain : Grain, ISystemGrain
    {
        Dictionary<string, double> _temperatures = new Dictionary<string, double>();        

        public Task SetTemperature(double value, string deviceId)
        {
            if (_temperatures.ContainsKey(deviceId))            
                _temperatures[deviceId] = value;            
            else            
                _temperatures.Add(deviceId, value);
            
            if (_temperatures.Values.Average() > 100)            
                Console.WriteLine("System temperature is hight!!!");
            
            return TaskDone.Done;
        }
    }
}
