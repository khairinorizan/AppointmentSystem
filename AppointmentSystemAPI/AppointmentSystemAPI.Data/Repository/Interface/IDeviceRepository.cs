using AppointmentSystemAPI.Data.Model;
using System.Collections.Generic;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface IDeviceRepository
    {
        List<Device> GetAllDevices();
        Device? GetDeviceById(int deviceId);
        Device AddNewDevice(Device device);
        List<Device> AddNewDevices(List<Device> devices);
        void RemoveDevice(Device device);
    }
}