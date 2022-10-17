using DYRQO6_HFT_2021222.Models;
using DYRQO6_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2021222.Logic
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
