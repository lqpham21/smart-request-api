using SmartRequest.Models;
using SmartRequest.Repositories;

namespace SmartRequest.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;

        public RequestService(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Request>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Request?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<Request> CreateAsync(Request request)
{
    request.CreatedAt = DateTime.UtcNow; // <-- Set timestamp before saving
    return await _repository.CreateAsync(request);
}


        public async Task<Request?> UpdateAsync(int id, Request request) =>
            await _repository.UpdateAsync(id, request);

        public async Task<bool> DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);

        public async Task<IEnumerable<Request>> GetByStatusAsync(string status) =>
            await _repository.GetByStatusAsync(status);
    }
}
