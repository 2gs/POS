using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Receipt:Product
    {
        private string name;
        private double price;
        private double quantity;
        private double total;
       
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

        public Receipt()
        {
            this.name = "";
            this.price = 0;
            this.quantity = 0;
            this.total = 0;
        }
        public Receipt(string name,double price,double quantity,double total)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.total = total;
        }

    }
}
