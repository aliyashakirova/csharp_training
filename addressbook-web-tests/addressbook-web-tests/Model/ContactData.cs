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
        private string allContacInfo;

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
        {
            get
            {
                if (allContacInfo != null)
                {
                    return allContacInfo;
                }
                else
                {
                    return (CleanUpFLN(Firstname, Lastname) + CleanUpAddr(Address) + AllPhonesBlock(CleanUpHPh(HomePhone), CleanUpMPh(MobilePhone), CleanUpWPh(WorkPhone)) + AllPhonesBlock(CleanUp2(Email1),CleanUp2(Email2),CleanUp2(Email3))).Trim(new char[] { '\r', '\n' });
                }
            }
            set
            {
                allContacInfo = value;
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace(")", "").Replace("(", "").Replace("-", "") + "\r\n";

        }

        public string CleanUpFLN(string fn, string ln)
        {
            if (fn == null || fn == "")
            {
                if (ln == null || ln == "")
                {
                    return "";
                }
                else
                {
                    return ln + "\r\n";
                }
            }
            else
            {
                if (ln == null || ln == "")
                {
                    return fn + "\r\n";
                }
                else
                {
                    return fn + " " + ln + "\r\n";
                }
            }

        }


        public string CleanUpAddr(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return address + "\r\n";

        }

        public string CleanUpHPh(string hph)
        {
            if (hph == null || hph == "")
            {
                return "";
            }
            return "H: " + hph + "\r\n";

        }

        public string CleanUpMPh(string mph)
        {
            if (mph == null || mph == "")
            {
                return "";
            }
            return "M: " + mph + "\r\n";

        }

        public string CleanUpWPh(string wph)
        {
            if (wph == null || wph == "")
            {
                return "";
            }
            return "W: " + wph + "\r\n";

        }

        public string AllPhonesBlock(string newhph,string newmph, string newwph)
        {
            string allPhonesBlock = newhph + newmph + newwph;
                if (allPhonesBlock == null || allPhonesBlock == "")
                {
                    return "";
                }
                else
                {
                    return "\r\n" + allPhonesBlock;
}
        }

        public string CleanUp2(string em)
        {
            if (em == null || em == "")
            {
                return "";
            }
            return em + "\r\n";
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
            return "id=" + Id +"firstname=" +Firstname + "lastname="+ Lastname +"Address=" + Address + "Company=" + Company;
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
