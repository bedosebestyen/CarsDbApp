using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDbApp.Models
{
    public class CarShop
    {
        [Key]
        public int ShopId { get; set; }
        public string Name { get; set; }
        public int AvailableCarsCount { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Cars> Cars { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public CarShop()
        {

        }
        public CarShop(string line)
        {
            string[] split = line.Split('#');
            ShopId = int.Parse(split[0]);
            Name = split[1];
            AvailableCarsCount = int.Parse(split[2]);
            Address = split[3];
        }
    }
}
