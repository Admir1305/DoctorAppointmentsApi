using Dapper;
using DoctorAppointmentApi.Models;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Options;

namespace DoctorAppointmentApi.Repository.implements
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DBSettings _dbSettings;

        public PatientRepository (IOptions<DBSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }
        public async Task<int> Delete(int id)
        {
            using(FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"DELETE FROM Patients WHERE d=@id";

                int result = await conn.ExecuteAsync(sql, new {id});

                return result;
            }
        }

        public async Task<IEnumerable<Patients>> Get()
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"SELECT * FROM Patients";

                var result = await conn.QueryAsync<Patients>(sql);

                return result;

            }
        }

        public async Task<Patients> GetById(int id)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"SELECT * FROM Patients WHERE id = @id";

                var result = await conn.QueryFirstOrDefaultAsync<Patients>(sql, new {Id = id});

                return result;
            }
        }

        public async Task<int> Post(Patients patient)
        {
           using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"INSERT INTO Patients (FirstName,LastName,EMBG,Phone,Email) 
                               values (@FirstName,@LastName,@EMBG,@Phone,@Email)";

                var result = await conn.ExecuteAsync(sql, new
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    EMBG = patient.EMBG,
                    Phone = patient.Phone,
                    Email = patient.Email,
                });

                return result;
            }
        }

        public async Task<int> Put(int id, Patients patient)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"UPDATE Patients d 
                             set 
                             d.FirstName = @FirstName,
                             d.LastName = @LastName,
                             d.EMBG = @EMBG,
                             d.Phone = @Phone,
                             d.Email = @Email";

                var result = await conn.ExecuteAsync(sql, new
                {
                    Id = id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    EMBG = patient.EMBG,
                    Phone = patient.Phone,
                    Email = patient.Email,
                });

                return result;
            }

        }
    }
}
