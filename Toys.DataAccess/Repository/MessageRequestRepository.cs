using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toys.DataAccess.Data;
using Toys.DataAccess.Repository.IRepository;
using Toys.Models;

namespace Toys.DataAccess.Repository
{
    public class MessageRequestRepository : Repository<MessageRequest>, IMessageRequestRepository 
    {

        private ApplicationDbContext _db;
        public MessageRequestRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
      

        public void Update(MessageRequest obj)
        {
            _db.MessageRequests.Update(obj);
        }
    }
}
