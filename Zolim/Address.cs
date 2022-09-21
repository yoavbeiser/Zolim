using System;
namespace Zolim
{
    public class Address
    {
        private readonly string _country;
        private readonly string _city;
        private readonly int _houseNumber;
        private readonly int _floor;
        private readonly int _apartment;
        private readonly bool _isPrivateHouse;

        public Address(string country, string city, int houseNumber, int floor, int apartment, bool isPrivateHouse)
        {
            _country = country;
            _city = city;
            _houseNumber = houseNumber;
            if (!isPrivateHouse)
            {
                _floor = floor;
                _apartment = apartment;
            }
            _isPrivateHouse = isPrivateHouse;
        }
        public string GetCountry()
        {
            return _country;
        }
        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   _country == address._country &&
                   _city == address._city &&
                   _houseNumber == address._houseNumber &&
                   _floor == address._floor &&
                   _apartment == address._apartment &&
                   _isPrivateHouse == address._isPrivateHouse;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_country, _city, _houseNumber, _floor, _apartment, _isPrivateHouse);
        }
    }
}
