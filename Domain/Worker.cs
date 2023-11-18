using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Worker
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
    }
}
