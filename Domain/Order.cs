using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public User Customer { get; set; }
        public Worker Worker { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string State { get; set; }

        public List<Category> categories { get; } = new List<Category>();

    }
}
