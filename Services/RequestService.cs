using TaskFlow.API.Data;
using TaskFlow.API.Models;

namespace TaskFlow.API.Services
{
    public class RequestService
    {
        private readonly AppDbContext _context;

        public RequestService(AppDbContext context)
        {
            _context = context;
        }

        public List<Request> GetAll()
        {
            return _context.Requests.ToList();
        }

        public Request Create(Request request)
        {
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }
    }
}
