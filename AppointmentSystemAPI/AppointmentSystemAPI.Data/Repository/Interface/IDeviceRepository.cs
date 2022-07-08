namespace AppointmentSystemAPI.Data.Repository.Interface
{
    using AppointmentSystemAPI.Data.Model;
    using System.Collections.Generic;

    public interface IDeviceRepository
    {
        List<Device> GetAllDevices();
        Device? GetDeviceById(int deviceId);
        Device AddNewDevice(Device device);
        List<Device> AddNewDevices(List<Device> devices);
        void RemoveDevice(Device device);
    }
}
