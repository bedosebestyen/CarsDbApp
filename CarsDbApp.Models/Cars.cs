using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDbApp.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }
        public int CustomerId { get; set; }
        public int ShopId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CarShop Shop { get; set; }
        public Cars()
        {

        }
        public Cars(string line)
        {
            string[] split = line.Split('#');
            CarId = int.Parse(split[0]);
            CarType = split[1];
            CarColor = split[2];
            CustomerId = int.Parse(split[3]);
            ShopId = int.Parse(split[4]);
            PurchaseDate = DateTime.Parse(split[5].Replace('*', '.'));
        }
    }
}
