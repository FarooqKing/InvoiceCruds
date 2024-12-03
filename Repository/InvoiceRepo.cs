using Dapper;
using InvoiceCruds.DbContext;
using InvoiceCruds.Iservice;
using InvoiceCruds.Models;
using System.Data;

namespace InvoiceCruds.Repository
{
    public class InvoiceRepo : IInvoiceDetail
    {
        private readonly DapperDbContext _context;

        public InvoiceRepo(DapperDbContext context)
        {
            _context = context;
        }

        // Add a new InvoiceDetail
        public async Task<int> AddAsync(InvoiceDetail invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerName", invoice.CustomerName);
            parameters.Add("@Address", invoice.Address);
            parameters.Add("@Description", invoice.Description);
            parameters.Add("@Quantity", invoice.Quantity);
            parameters.Add("@Discount1", invoice.Discount1);
            parameters.Add("@Discount2", invoice.Discount2);
            parameters.Add("@AddTax", invoice.AddTax);
            parameters.Add("@Date", invoice.Date);
            parameters.Add("@AreaId", invoice.AreaId);
            parameters.Add("@BatchNo", invoice.BatchNo);
            parameters.Add("@Price", invoice.Price);
            parameters.Add("@ExpiryDate", invoice.ExpiryDate);
            parameters.Add("@mDelete", invoice.MDelete);

            using (var conn = _context.CreateConnection())
            {
                return await conn.ExecuteAsync("spInvoiceDetail_Add", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // Get all InvoiceDetails
        public async Task<IEnumerable<InvoiceDetail>> GetAllAsync()
        {
            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryAsync<InvoiceDetail>("spInvoiceDetail_GetAll", commandType: CommandType.StoredProcedure);
            }
        }

        // Get InvoiceDetail by ID
        public async Task<InvoiceDetail> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InvoiceNo", id);

            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<InvoiceDetail>("spInvoiceDetail_GetById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // Update an existing InvoiceDetail
        public async Task<bool> UpdateAsync(InvoiceDetail invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InvoiceNo", invoice.InvoiceNo);
            parameters.Add("@CustomerName", invoice.CustomerName);
            parameters.Add("@Address", invoice.Address);
            parameters.Add("@Description", invoice.Description);
            parameters.Add("@Quantity", invoice.Quantity);
            parameters.Add("@Discount1", invoice.Discount1);
            parameters.Add("@Discount2", invoice.Discount2);
            parameters.Add("@AddTax", invoice.AddTax);
            parameters.Add("@Date", invoice.Date);
            parameters.Add("@AreaId", invoice.AreaId);
            parameters.Add("@BatchNo", invoice.BatchNo);
            parameters.Add("@Price", invoice.Price);
            parameters.Add("@ExpiryDate", invoice.ExpiryDate);
            parameters.Add("@mDelete", invoice.MDelete);

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync("spInvoiceDetail_Update", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        // Delete an InvoiceDetail by setting mDelete = 1
        public async Task<bool> DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InvoiceNo", id);

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync("spInvoiceDetail_Delete", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
