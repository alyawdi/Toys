using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toys.Models;

namespace Toys.DataAccess.Repository.IRepository
{
    public interface IMessageRequestRepository : IRepository<MessageRequest>
    {
        void Update(MessageRequest obj);
       
    }
}
