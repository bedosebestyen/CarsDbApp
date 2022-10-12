using CarsDbApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDbApp.Repository
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
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
