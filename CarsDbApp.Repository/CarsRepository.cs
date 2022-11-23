using DYRQO6_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Repository
{
    public class CarsRepository : Repository<Cars>, IRepository<Cars>
    {
        public CarsRepository(CarsDbContext ctx) : base(ctx)
        {

        }
        public override Cars Read(int id)
        {
            return ctx.Cars.FirstOrDefault(x => x.CarId == id);
        }

        public override void Update(Cars item)
        {
            var old = Read(item.CarId);
            old.CarType = item.CarType;
            old.PurchaseDate = item.PurchaseDate;
            old.Price = item.Price;
            old.CarColor = item.CarColor;
            old.Customer = item.Customer;
            old.CustomerId = item.CustomerId;
            old.Shop = item.Shop;
            old.ShopId = item.ShopId;
            ctx.SaveChanges();
        }
    }
}
