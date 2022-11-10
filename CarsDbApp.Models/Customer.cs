using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cars> Cars { get; set; }
        [JsonIgnore]
        public virtual ICollection<CarShop> Shop { get; set; }
        public Customer()
        {

        }
        public Customer(string line)
        {
            string[] split = line.Split('#');
            CustomerId = int.Parse(split[0]);
            Age = int.Parse(split[1]);
            Name = split[2];
            Address = split[3];
        }
    }
}
