using DoctorAppointmentApi.Models;

namespace DoctorAppointmentApi.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointments>> Get();

        Task<Appointments> GetById(int id);

        Task<int> Post(Appointments createDto);

        Task<int> Put(int id, Appointments updateDto);

        Task<int> Delete(int id);
    }
}
