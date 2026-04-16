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

        public bool Submit (int requestId)
        {
            var request = _context.Requests.Find(requestId);
            if (request == null) return false;
            if (request.Status != "Draft") return false;
            request.Status = "Submitted";
            _context.SaveChanges();
            return true;
        }

        public bool Approval(int requestId)
        {
            var request = _context.Requests.Find(requestId);
            if (request == null) return false;
            if (request.Status != "Submitted") return false;
            request.Status = "Approved";
            _context.SaveChanges();
            return true;
        }

        public bool Reject(int requestId)
        {
            var request = _context.Requests.Find(requestId);
            if (request == null) return false;
            if (request.Status != "Submitted") return false;
            request.Status = "Rejected";
            _context.SaveChanges();
            return true;
        }
    }
}
