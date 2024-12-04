using Dapper;
using Invoice_Cruds.Iservice;
using InvoiceCruds.DbContext;
using InvoiceCruds.Models;
using System.Data;

namespace Invoice_Cruds.Repository
{
    public class CityRepository:ICity
    {
        private readonly DapperDbContext _context;

        public CityRepository(DapperDbContext context)
        {
            _context = context;
        }

        // Add a new InvoiceDetail
        public async Task<int> AddAsync(City invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AreaId", invoice.AreaId);
            parameters.Add("@AreaName", invoice.AreaName);

            using (var conn = _context.CreateConnection())
            {
                return await conn.ExecuteAsync("spAddCity", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // Get all InvoiceDetails
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryAsync<City>("spGetAllCities", commandType: CommandType.StoredProcedure);
            }
        }

        // Get InvoiceDetail by ID
        public async Task<City> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AreadId", id);

            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<City>("spGetCitybyId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        // Get Report InvoiceDetail by ID
        public async Task<City> GetReportByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AreaId", id);

            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<City>("spAddCity", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // Update an existing InvoiceDetail
        public async Task<bool> UpdateAsync(City invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AreaId", invoice.AreaId);
            parameters.Add("@AreaName", invoice.AreaName);

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync("spUpdateCity", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        // Delete an InvoiceDetail by setting mDelete = 1
        public async Task<bool> DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AreaId", id);

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync("spDeleteCity", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

     
    }
}
