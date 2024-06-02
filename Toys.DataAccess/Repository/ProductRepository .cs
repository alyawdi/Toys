using System;
using System.Linq;
using Toys.DataAccess.Data;
using Toys.DataAccess.Repository.IRepository;
using Toys.Models;

namespace Toys.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Product Get(int id)
        {
            return _db.Products.FirstOrDefault(u => u.Id == id);
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.SKU = obj.SKU;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Manufacturer = obj.Manufacturer;
                objFromDb.Price50 = obj.Price50;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
