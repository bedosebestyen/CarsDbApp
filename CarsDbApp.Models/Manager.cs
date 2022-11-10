using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        [ForeignKey("CarShopId")]
        public int CarshopId { get; set; }
        [JsonIgnore]
        public virtual CarShop CarShop { get; set; }
        public Manager()
        {

        }
        public Manager(string line)
        {
            string[] split = line.Split('#');
            ManagerId = int.Parse(split[0]);
            Name = split[1];
            Salary = int.Parse(split[2]);
            Age = int.Parse(split[3]);
            CarshopId = int.Parse(split[4]);
        }
    }
}
