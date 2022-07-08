using System;
namespace AppointmentSystemAPI.Data.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using AppointmentSystemAPI.Data.DBContext;
    using AppointmentSystemAPI.Data.Model;
    using AppointmentSystemAPI.Data.Repository.Interface;

    public class DeviceRepository : IDeviceRepository
    {
        private readonly DeviceContext _deviceContext;

        public DeviceRepository(DeviceContext ctx)
        {
            _deviceContext = ctx;
        }

        public List<Device> GetAllDevices()
        {
            return _deviceContext.Devices.ToList();
        }

        public Device? GetDeviceById(int deviceId)
        {
            return _deviceContext.Devices.Find(deviceId);
        }

        public Device AddNewDevice(Device device)
        {
            var newDevice = _deviceContext.Add(device).Entity;
            _deviceContext.SaveChanges();
            return newDevice;
        }

        public List<Device> AddNewDevices(List<Device> devices)
        {
            var newDevices = new List<Device>();
            foreach (var device in devices)
            {
                _deviceContext.Add(device);
                newDevices.Add(device);
            }

            _deviceContext.SaveChanges();
            return newDevices;
        }

        public void RemoveDevice(Device device)
        {
            _deviceContext.Devices.Remove(device);
            _deviceContext.SaveChanges();
        }
    }
}
