using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingModelLibrary
{
    public class Customer : IEquatable<Customer>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }


        public Customer()
        {
            
        }

        public Customer(int id, string name, string phone, int age)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Age = age;
        }


        public override string ToString()
        {
            return "Id : " + Id +
                ", Name : " + Name +
                ", Phone : " + Phone +
                ", Age : " + Age;
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }

        public int CompareTo(Customer? other)
        {
            if (this.Age == other.Age)
                return 0;
            else if (this.Age < other.Age)
                return -1;
            else
                return 1;
            //return this.Age.CompareTo(other.Age);
        }

        public class SortCustomerByName : IComparer<Customer>
        {
            public int Compare(Customer? x, Customer? y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}