using SmartRequest.Models;

namespace SmartRequest.Services
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetAllAsync();
        Task<Request?> GetByIdAsync(int id);
        Task<Request> CreateAsync(Request request);
        Task<Request?> UpdateAsync(int id, Request request);
        Task<bool> DeleteAsync(int id);
    }
}

