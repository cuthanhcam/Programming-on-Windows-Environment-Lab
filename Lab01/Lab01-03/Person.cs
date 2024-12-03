// 2280600285 Cu Thanh Cam
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Person
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        public Person()
        {
            Id = string.Empty;
            FullName = string.Empty;
        }
        public Person(string id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
        
        public Person(Person other)
        {
            Id = other.Id;
            FullName = other.FullName;
        }
        public virtual void Input()
        {
            Console.Write("Import Id: ");
            Id = Console.ReadLine();
            Console.Write("Import Fullname: ");
            FullName = Console.ReadLine();
        }
        public virtual void Show()
        {
            Console.Write($"Id: {this.Id}, FullName: {this.FullName}, ");
        }
    }
}
