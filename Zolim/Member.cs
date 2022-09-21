using System;
namespace Zolim
{
    public class Member: Client
    {
        private double _price;
        const double _MAX_DISCOUNT =20000;
        public Member(string firstName, string lastName, int id, Address address): base(firstName,  lastName,  id,  address)
        {
            _price = 0;
        }
        public Member(Client client) : base(client.GetFirstName(), client.GetLastName(), client.GetId(), client.GetAddress())
        {
            _price = 0;
        }
        public double GetPrice()
        {
            return _price;
        }
        public void UpdatePrice(double priceToAdd)
        {
            _price += priceToAdd;
        }

        public double GetDiscount()
        {
            double finalDiscount = 0;
            double[] PricesArray = { 1000, 5000, _MAX_DISCOUNT };
            double[] discountArray = { 2.5, 5, 8 };
            for (int i = 0; i < PricesArray.Length; i++)
            {
                if (_price > PricesArray[i])
                    finalDiscount = discountArray[i];
            }
            return finalDiscount != 0 ? finalDiscount : 0;
        }
    }
}
