using System;
using System.Collections.Generic;

namespace Zolim
{
    public class Client
    {
        protected readonly string _firstName;
        protected readonly string _lastName;
        protected readonly int _id;
        protected readonly Address _address;

        public Client(string firstName, string lastName, int id, Address address)
        {
            _firstName = firstName;
            _lastName = lastName;
            _id = id;
            _address = address;
        }
        public string GetFirstName()
        {
            return _firstName;
        }
        public string GetLastName()
        {
            return _lastName;
        }
        public int GetId()
        {
            return _id;
        }
        public Address GetAddress()
        {
            return _address;
        }
        public override bool Equals(Object obj)
        {
            Client other = (Client)obj;
            return _firstName == other._firstName &&
                   _lastName == other._lastName &&
                   _id == other._id &&
                   _address.Equals(other._address);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_firstName, _lastName, _id, _address);
        }
    }
}
