using AppointmentSystemAPI.Data.Model;

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