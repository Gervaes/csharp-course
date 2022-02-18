using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio_123.Entities;
using exercicio_123.Entities.Enums;

namespace exercicio_123.Entities
{
    internal class Order {
        public DateTime Moment { get; set; }
        public OrderStatus status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(Client client, OrderStatus orderStatus) { 
            Client = client;
            status = orderStatus;
            Moment = DateTime.Now;
        }

        public void AddItem(OrderItem item) { 
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item) { 
            Items.Remove(item);
        }

        public double Total() {
            double sum = 0;
            foreach (OrderItem item in Items) {
                sum += item.SubTotal();
            }

            return sum;
        }
    }
}
