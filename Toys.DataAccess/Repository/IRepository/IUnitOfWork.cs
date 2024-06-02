using System;

namespace Toys.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IFeedbackRepository Feedback { get; }
        IMessageRequestRepository MessageRequest { get; }
        void Save();
    }
}

