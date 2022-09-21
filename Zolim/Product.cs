using System;
namespace Zolim
{
    public class Product
    {
        private readonly string _name;
        private readonly string _company;
        private readonly double _size;
        private readonly double _price;

        public Product(string name,double size, string company, double price)
        {
            _name = name;
            _size = size;
            _company = company;
            _price = price;
        }

        #region Get
        public string GetName()
        {
            return _name;
        }
        public double GetProductPrice()
        {
            return _price;
        }
        public double GetSize()
        {
            return _size;
        }
        #endregion
    }
}
