using System;
using System.Collections.Generic;

namespace Zolim
{
    public class Parcel
    {
        private readonly Product _product;
        private readonly double _boxSize;
        private readonly Address _sour;
        private readonly Address _dest;
        private readonly int _id;
        private readonly Client _client;
        const double _MAX_PARCEL_SIZE = 100;
        static int countOfParcels = 0;


        public Parcel(Product product, double boxSize, Address sour, Address dest,Client client)
        {
            _product = product;
            _boxSize = ChooseBox(boxSize);
            _sour = sour;
            _dest = dest;
            _id = countOfParcels++;
            if (IsMember())
                ((Member)client).UpdatePrice(GetPrice());       
        }

        public double ChooseBox(double boxSize)
        {
            double finalSize = 0;
            double[] boxSizes = { 10, 25, _MAX_PARCEL_SIZE };
            for (int i = 0; i < boxSizes.Length; i++)
            {
                if (boxSize < boxSizes[i])
                {
                    finalSize = boxSizes[i];
                    break;
                }
            }
            return finalSize != 0? finalSize : boxSize;
        }

        public int ChooseZone()
        {
            char firstLetter = _dest.GetCountry()[0];
            const int reduceValue = 'A' - 1;
            return ((int)firstLetter) - reduceValue;
        }

        public double GetPrice()
        {
            double[] boxSizes = { 10, 25, 100 };
            const double multiplerPrice = 0.1;
            double boxSize = ChooseBox(_product.GetSize());
            double finalprice = _product.GetProductPrice()+ boxSize * multiplerPrice;
            if (boxSize > _MAX_PARCEL_SIZE)
                finalprice += 5;

            if (IsMember())
            {
                double discount = ((Member)_client).GetDiscount();
                if (discount != 0) {
                    finalprice *= 1-(discount * 0.01);
                }
            }
            return finalprice;
        }

        public bool IsMember()
        {
            return _client.GetType() == typeof(Member);
        }

        public override string ToString()
        {
            return $"name: {_product.GetName()}" +
                $"country from: {_sour.GetCountry()}" +
                $"country to: {_dest.GetCountry()}" +
                $"Final Price: {GetPrice()}";
        }
        public override bool Equals(object obj)
        {
            Parcel other = (Parcel)obj;
            return _product == other._product &&
                   _boxSize == other._boxSize &&
                   _dest == other._dest &&
                   _sour == other._sour;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_product, _boxSize, _sour, _dest);
        }
    }
}
