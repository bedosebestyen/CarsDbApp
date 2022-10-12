using CarsDbApp.Models;
using CarsDbApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarsDbApp.Logic
{
    public class CarsLogic : ICarsLogic
    {
        IRepository<Cars> repo;

        public CarsLogic(IRepository<Cars> repo)
        {
            this.repo = repo;
        }

        public void Create(Cars item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Cars Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Cars> ReadAll()
        {
            return this.repo.ReadAll(); ;
        }

        public void Update(Cars item)
        {
            this.repo.Create(item);
        }
    }
}
