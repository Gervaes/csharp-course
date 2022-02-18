using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_123.Entities
{
    internal class Client {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Client() { }
        public Client(string name, string email, DateTime date) { 
            Name = name;
            Email = email;
            BirthDate = date;
        }

        public override string ToString() {
            return $"{Name} ({BirthDate.Date}) - {Email}";
        }
    }
}
