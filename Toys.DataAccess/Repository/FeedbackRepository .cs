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
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository 
    {

        private ApplicationDbContext _db;
        public FeedbackRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
      

        public void Update(Feedback obj)
        {
            _db.Feedbacks.Update(obj);
        }
    }
}
