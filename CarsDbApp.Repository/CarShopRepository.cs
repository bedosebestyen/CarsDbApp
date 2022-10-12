using CarsDbApp.Models;
using Castle.DynamicProxy.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarsDbApp.Repository
{
    public class CarShopRepository : Repository<CarShop>, IRepository<CarShop>
    {
        public CarShopRepository(CarsDbContext ctx) : base(ctx) 
        {
        }

        public override CarShop Read(int id)
        {
            return ctx.Carshop.FirstOrDefault(x => x.ShopId == id);
        }
        public override void Update(CarShop item)
        {
            var old = Read(item.ShopId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
