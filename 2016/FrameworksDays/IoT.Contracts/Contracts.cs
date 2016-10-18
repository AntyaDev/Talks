﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace IoT.Contracts
{
    public interface IGeminiDeviceGrain : IGrainWithStringKey
    {
        Task StartRun(string locationName);
        Task HandleMetrics(Metrics message);
        Task HandleBattery(BatteryCapacity message);
    }

    public interface IUserGrain : IGrainWithStringKey
    {
        Task<bool> AddNewDevice(string deviceId);
        Task HandleWarning(Warning message);
    }

    public interface IViewAggregator : IGrainWithStringKey
    {
        IEnumerable<UserInfo> GetCurrentView();
        Task<bool> UpdateUserInfo(UserInfo userInfo);
    }
}
