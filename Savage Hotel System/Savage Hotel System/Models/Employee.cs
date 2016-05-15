using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savage_Hotel_System.Models
{
    public class Employee
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public double Salary { get; set; }

        public int IsManager { get; set; }
    }
}
