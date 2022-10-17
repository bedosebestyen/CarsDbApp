using DYRQO6_HFT_2021222.Models;
using System.Linq;

namespace DYRQO6_HFT_2021222.Logic
{
    public interface ICarsLogic
    {
        void Create(Cars item);
        void Delete(int id);
        Cars Read(int id);
        IQueryable<Cars> ReadAll();
        void Update(Cars item);
    }
}