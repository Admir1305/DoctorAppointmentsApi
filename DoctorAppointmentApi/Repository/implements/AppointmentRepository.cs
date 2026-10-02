using Dapper;
using DoctorAppointmentApi.Models;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace DoctorAppointmentApi.Repository.implements
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DBSettings _dbSettings;
        public AppointmentRepository(IOptions<DBSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }
        public async Task<int> Delete(int id)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"DELETE FROM Appointments WHERE Id=@id";

                var results = await conn.ExecuteAsync(sql, new {id});

                return results;
            }
        }

        public async Task<IEnumerable<Appointments>> Get()
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"select a.id, a.doctorid, a.patientid, a.appointmenttime, a.notes, a.status_id, s.name as status_name
                                from appointments a
                                join statuses s on s.id = a.status_id";

                var results = await conn.QueryAsync<Appointments>(sql);

                return results;
            }
        }

        public async Task<Appointments> GetById(int id)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"SELECT * FROM Appointments WHERER Id=@id";

                var results = await conn.QueryFirstOrDefault(sql, new {id});

                return results;
            }
        }

        public async Task<int> Post(Appointments createDto)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"INSERT INTO Appointments (DoctorId,PatientId,AppointmentTime,Status_id,Notes) 
                               values (@DoctorId, @PatientId, @AppointmentTime, @Status, @Notes)";

                var result = await conn.ExecuteAsync(sql, new
                {
                    AppointmentTime = createDto.AppointmentTime,
                    Status = createDto.Status_id,
                    Notes = createDto.Notes,
                    DoctorId = createDto.DoctorId,
                    PatientId = createDto.PatientId,
                });

                return result;
            }
        }

        public async Task<int> Put(int id, Appointments updateDto)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"UPDATE Appointments 
                                SET DoctorId = @DoctorId,
                                    PatientId = @PatientId,
                                    AppointmentTime = @AppointmentTime,
                                    Status_id = @Status,
                                    Notes = @Notes
                                where id = @id";

                var result = await conn.ExecuteAsync(sql, new
                {
                    id,
                    AppointmentTime = updateDto.AppointmentTime,
                    Status = updateDto.Status_id,
                    Notes = updateDto.Notes,
                    DoctorId = updateDto.DoctorId,
                    PatientId = updateDto.PatientId,
                });

                return result;
            }
        }
    }
}
