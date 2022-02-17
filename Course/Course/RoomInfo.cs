using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course {
    internal class RoomInfo {

        public string Name { get; set; }
        public string Email { get; set; }
        public int Room { get; set; }

        public override string ToString() {
            return $"{Room}: {Name}, {Email}";
        }
    }
}

/*
 Console.Write("How many rooms will be rented? ");
            int n = int.Parse(Console.ReadLine());

            RoomInfo[] rooms = new RoomInfo[10];

            for (int i = 0; i < n; i++) {
            Console.WriteLine();
                Console.WriteLine($"Rent #{i}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Room: ");
                int roomNumber = int.Parse(Console.ReadLine());

                rooms[roomNumber] = new RoomInfo { Name = name, Email = email, Room = roomNumber };
            }

            Console.WriteLine();
            Console.WriteLine("Busy Rooms:");
            for (int i = 0; i < 10; i++) {
                if (rooms[i] != null)
                    Console.WriteLine(rooms[i]);
            }
 
 */