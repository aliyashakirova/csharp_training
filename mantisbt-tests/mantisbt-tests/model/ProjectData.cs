using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        private string projectName;


        
        public ProjectData(string projectName)
        {
            this.projectName = projectName;
        }

        public ProjectData()
        {
        }

        public string ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                projectName = value;
            }
        }
        public string Id { get; set; }
        public string Name { get;set; }

        public override string ToString()
        {
            return "projectname=" + ProjectName;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Id.CompareTo(other.Id);
        }

       // public int CompareTo(ProjectData other)
        //{
         //   if (Object.ReferenceEquals(other, null))
          //  {
           //     return 1;
            //}

            //return ProjectName.CompareTo(other.ProjectName);
        //}


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
            return Id == other.Id;
        }
    }


}
