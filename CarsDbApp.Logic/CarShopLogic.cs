using DYRQO6_HFT_2022231.Models;
using DYRQO6_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Logic
{
    public class CarShopLogic : ICarShopLogic
    {
        IRepository<CarShop> shoprepo;
        IRepository<Manager> manrepo;
        public CarShopLogic(IRepository<CarShop> repo, IRepository<Manager> mrepo)
        {
            shoprepo = repo;
            manrepo = mrepo;
        }

        public void Create(CarShop item)
        {
            shoprepo.Create(item);
        }

        public void Delete(int id)
        {
            shoprepo.Delete(id);
        }
        public CarShop Read(int id)
        {
            return shoprepo.Read(id);
        }

        public IQueryable<CarShop> ReadAll()
        {
            return shoprepo.ReadAll(); ;
        }

        public void Update(CarShop item)
        {
            shoprepo.Create(item);
        }
        public IEnumerable<object> GetHighestPaidManager()
        {
            var query = from x in shoprepo.ReadAll()
                        from y in manrepo.ReadAll()
                        let highest_salary = manrepo.ReadAll().Max(t => t.Salary)
                        where highest_salary == y.Salary && y.ManagerId == x.ManagerId
                        select new
                        {
                            Name = y.Name,
                            Salary = y.Salary,
                            Shop = x.Name
                        };
            return query;
        }
    }
}
