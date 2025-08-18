using Microsoft.EntityFrameworkCore;
using SmartRequest.Data;
using SmartRequest.Models;
using Microsoft.Data.SqlClient;


namespace SmartRequest.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;

        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Request>> GetAllAsync() =>
            await _context.Requests.ToListAsync();

        public async Task<Request?> GetByIdAsync(int id) =>
            await _context.Requests.FindAsync(id);

        public async Task<Request> CreateAsync(Request request)
        {
            var sql = @"
            INSERT INTO Requests (Title, Description, Category, Status, CreatedAt)
            VALUES (@Title, @Description, @Category, @Status, @CreatedAt);
            ";

            var parameters = new[]
            {
                new SqlParameter("@Title", request.Title ?? (object)DBNull.Value),
                new SqlParameter("@Description", request.Description ?? (object)DBNull.Value),
                new SqlParameter("@Category", request.Category ?? (object)DBNull.Value),
                new SqlParameter("@Status", request.Status ?? (object)DBNull.Value),
                new SqlParameter("@CreatedAt", request.CreatedAt)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
            return request;
        }


        public async Task<Request?> UpdateAsync(int id, Request request)
        {
            var existing = await _context.Requests.FindAsync(id);
            if (existing == null) return null;

            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.Status = request.Status;
            existing.Category = request.Category;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null) return false;

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Request>> GetByStatusAsync(string status)
        {
            var statusParam = new SqlParameter("@Status", status);
            return await _context.Requests
            .FromSqlRaw("EXECUTE dbo.sp_GetRequestsByStatus @Status", statusParam)
            .ToListAsync();
        }
        
        public async Task<IEnumerable<Request>> GetRecentAsync(int daysAgo)
        {
            var param = new SqlParameter("@DaysAgo", daysAgo);
            return await _context.Requests
            .FromSqlRaw("SELECT * FROM fn_GetRecentRequests(@DaysAgo)", param)
            .ToListAsync();
        }
    }
}
