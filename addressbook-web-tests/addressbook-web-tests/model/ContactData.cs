﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allEmails;


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

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Trim() + "\r\n";
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}