using DYRQO6_HFT_2022231.Models;
using DYRQO6_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Logic
{

    public class ManagerLogic : IManagerLogic
    {
        IRepository<Manager> manrepo;
        public ManagerLogic(IRepository<Manager> mrepo)
        {
            manrepo = mrepo;
        }
        public void Create(Manager item)
        {
            manrepo.Create(item);
        }

        public void Delete(int id)
        {
            manrepo.Delete(id);
        }

        public Manager Read(int id)
        {
            return manrepo.Read(id);
        }

        public IQueryable<Manager> ReadAll()
        {
            return manrepo.ReadAll();
        }

        public void Update(Manager item)
        {
            manrepo.Update(item);
        }
    }
}
