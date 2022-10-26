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
        IRepository<CarShop> repo;

        public CarShopLogic(IRepository<CarShop> repo)
        {
            this.repo = repo;
        }

        public void Create(CarShop item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public int? GetYearlyIncome(int year)
        {
            throw new NotImplementedException();  
        }

        public CarShop Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<CarShop> ReadAll()
        {
            return this.repo.ReadAll(); ;
        }

        public void Update(CarShop item)
        {
            this.repo.Create(item);
        }
    }
}
