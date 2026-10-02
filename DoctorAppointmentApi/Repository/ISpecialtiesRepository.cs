using DoctorAppointmentApi.Models;

namespace DoctorAppointmentApi.Repository
{
    public interface ISpecialtiesRepository
    {
        Task<IEnumerable<Patients>> Get();

        Task<Patients> GetById(int id);

        Task<int> Post(Spectialties spec);

        Task<int> Put(int id, Spectialties spec);

        Task<int> Delete(int id);
    }
}
