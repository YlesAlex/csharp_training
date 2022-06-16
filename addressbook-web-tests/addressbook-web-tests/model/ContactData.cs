using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == (other.Firstname) && Lastname == (other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + "lastname=" + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if 
                (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            else return Firstname.CompareTo(other.Firstname);
        }

        public string Firstname { get; set; }
       
        public string Lastname { get; set; }

        public string Id { get; set; }
    }
}