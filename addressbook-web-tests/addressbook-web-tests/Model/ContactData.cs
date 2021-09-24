using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        public ContactData(string firstname, string lastname, string company, string address)
        {
            Firstname = firstname;
            Lastname = lastname;
            Company = company;
            Address = address;
        }


        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }


        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
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
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }


        public string AllContactInfo
        { get; set;}

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return phone.Replace(" ", "").Replace("-", "").Replace(")", "").Replace("(", "").Replace("-","") + "\r\n";

        }

        public string Id { get; set; }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            //int i = Firstname.CompareTo(other.Firstname);
            //if (i != 0) return i;

            //i = Lastname.CompareTo(other.Lastname);
            //if (i != 0) return i;

            return Id.CompareTo(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return "id=" + Id +"firstname=" +Firstname + "lastname"+ Lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Id == other.Id;// && Firstname == other.Firstname && Lastname == other.Lastname;
        }
    }
}
