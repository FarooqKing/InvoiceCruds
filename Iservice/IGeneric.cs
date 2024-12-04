using InvoiceCruds.Models;

namespace Invoice_Cruds.Iservice
{
    public interface IGeneric<T>where T : class
    {
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
