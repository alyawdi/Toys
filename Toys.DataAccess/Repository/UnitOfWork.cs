using Toys.DataAccess.Data;
using Toys.DataAccess.Repository.IRepository;

namespace Toys.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IFeedbackRepository Feedback { get; private set; }
        public IMessageRequestRepository MessageRequest { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Feedback = new FeedbackRepository(_db);
            MessageRequest = new MessageRequestRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
