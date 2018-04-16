using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string detailedInformation;
        private string firstName;
        private string lastName;

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
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
            return (FirstName == other.FirstName) && (LastName == other.LastName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return $"First Name = {FirstName}, Last Name = {LastName}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int firstCompare = FirstName.CompareTo(other.FirstName);
            if (firstCompare != 0)
            {
                return firstCompare;
            }

            return LastName.CompareTo(other.LastName);
        }

        [Column(Name = "firstname")]
        public string FirstName
        {
            get
            {
                if (firstName == null || firstName == "")
                {
                    return "";
                }
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        [Column(Name = "lastname")]
        public string LastName
        {
            get
            {
                if (lastName == null || lastName == "")
                {
                    return "";
                }
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        public static List<ContactData> GetContactsWithoutGroup()
        {
            using (AddressBookDB db = new AddressBookDB())
            {               
                return db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00" && !db.GCR.Select(y => y.ContactId).Contains(x.Id)).ToList();
            }           
        }

        public static List<ContactData> GetContactsWithGroup()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00" && db.GCR.Select(y => y.ContactId).Contains(x.Id)).ToList();
            }
        }

        public string Address {get; set;}
        public string HomePhone {get; set;}
        public string MobilePhone {get; set;}
        public string WorkPhone {get; set; }    
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
                    return $"{fromatRNforString(Email)}{fromatRNforString(Email2)}{fromatRNforString(Email3)}".Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }        

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string DetailedInformation
        {
            get
            {
                if (detailedInformation != null)
                {
                    return detailedInformation;
                }
                else
                {
                    return $"{getDetailedName(FirstName, LastName)}{getDetailedAddress(Address)}{getDetailedPhone(HomePhone, MobilePhone, WorkPhone)}{getDetailedMail(Email, Email2, Email3)}".Trim();                         
                }
            }

            set
            {
                detailedInformation = value;
            }           
        }

        string fromatRNforString(string thisString)
        {
            if (thisString == null || thisString == "")
            {
                return "";
            }
            return thisString + "\r\n";
        }

        string getDetailedName(string firstName, string lastName)
        {
            if (lastName == null || lastName == "")
            {
                return $"{firstName}\r\n";
            }
         
            return $"{firstName} {lastName}\r\n";
        }

        string getDetailedAddress(string address)
        {
            address = fromatRNforString(address);

            if (address == "")
            {
                return "";
            }
          
            return $"{address}\r\n";
        }

        string getDetailedPhone(string homePhone, string mobilePhone, string workPhone)
        {
            homePhone = fromatRNforString(homePhone);
            mobilePhone = fromatRNforString(mobilePhone);
            workPhone = fromatRNforString(workPhone);

            if (homePhone == "" & mobilePhone == "" & workPhone == "")
            {
                return "";
            }

            if (homePhone != "")
            {
                homePhone = $"H: {homePhone}";
            }

            if (mobilePhone != "")
            {
                mobilePhone = $"M: {mobilePhone}";
            }

            if (workPhone != "")
            {
                workPhone = $"W: {WorkPhone}";
            }          

            return $"{homePhone}{mobilePhone}{workPhone}\r\n";
        }

        string getDetailedMail(string email, string email2, string email3)
        {
            email = fromatRNforString(email);
            email2 = fromatRNforString(email2);
            email3 = fromatRNforString(email3);

            if (email == "" & Email2 == "" & email3 == "")
            {
                return "";
            }

            return $"{email}{email2}{email3}\r\n";
        }
    }
}
