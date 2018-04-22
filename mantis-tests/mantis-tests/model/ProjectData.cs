using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{   
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        private string name;
        private string description;

        public ProjectData(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public ProjectData()
        {
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }           
            return (Name == other.Name) && (Description == other.Description);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name = {Name}, Description = {Description}";
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int firstCompare = Name.CompareTo(other.Name);
            if (firstCompare != 0)
            {
                return firstCompare;
            }


            return Description.CompareTo(other.Description);
        }

        public string Name
        {
            get
            {               
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }    
        
        public string Id
        {
            get;
            set;
        }    
    }
}
