using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Product
    {
        private string name;
        private double price;

        private double quantity; 
        private double total; 

        private string category;
        private string description;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public double Price
        {
            set { price = value; }
            get { return price; }
        }
        public string Category
        {
            set { category = value; }
            get { return category; }
        }
        public string Description
        {
            set { description = value; }
            get { return description; }
        }
        public double Quantity
        {
            set { quantity = value; }
            get { return quantity; }
        }
        public double Total
        {
            set { total = value; }
            get { return total; }
        }
        public Product()
        {
            this.name = " ";
            this.price = 0;
            this.category = " ";
            this.description = " "; 
        }
        public Product(string category, string name, string description, double price)
        {
            this.name = name;
            this.category = category;
            this.description = description;
            this.price = price;
        }

        public Product(string name, double price, double quantity, double total)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.total= total;
        }


        public override string ToString()
        {
            return (Name + " " + Category + " " + Description + " " + Price);
        }
    }
}
