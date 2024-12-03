// 2280600285 Cu Thanh Cam
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher() : base()
        {
            Address = string.Empty;
        }

        public Teacher(string id, string fullName, string address) : base()
        {
            Address = address;
        }
        
        public Teacher(Teacher other) : base(other)
        {
            Address = other.Address;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Import Address: ");
            Address = Console.ReadLine();
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Address: {this.Address}");
        }
    }
}
