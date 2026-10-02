using Dapper;
using DoctorAppointmentApi.Models;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Options;
using System.Data.Common;

namespace DoctorAppointmentApi.Repository.implements
{
    public class SpecialtiesRepository : ISpecialtiesRepository
    {
        private readonly DBSettings _dbSettings;

        public SpecialtiesRepository(IOptions<DBSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }
        public async Task<int> Delete(int id)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"DELETE FROM Specialties WHERE Id=@id";

                var results = await conn.ExecuteAsync(sql, new {id});

                return results;
            } 
        }

        public async Task<IEnumerable<Patients>> Get()
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"SELECT * FROM Patients";

                var results = await conn.QueryAsync<Patients>(sql);

                return results;
            }
        }

        public async Task<Patients> GetById(int id)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"SELECT * FROM Patients WHERE id=@id";

                var results = await conn.QueryFirstOrDefaultAsync<Patients>(sql, new { id });

                return results;
            }
        }

        public async Task<int> Post(Spectialties spec)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"INSERT INTO Specialties (Name) values(@Name)";

                var results = await conn.ExecuteAsync(sql, new
                {
                    Name = spec.Name
                });

                return results;
            }
        }

        public async Task<int> Put(int id, Spectialties spec)
        {
            using (FbConnection conn = new(_dbSettings.DbConnectionString))
            {
                string sql = @"UPDATE Specialties s set s.Name= @Name";

                var results = await conn.ExecuteAsync(sql, new
                {
                    id = id,
                    Name = spec.Name
                });
                return results;
            }
        }
    }
}
