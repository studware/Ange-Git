using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T18to19.StudentsByGroup
{
    class Student
    {
        public Student(string fullName, string groupName)
        {
            this.FullName = fullName;
            this.GroupName = groupName;
        }
        public string FullName { get; private set; }
        public string GroupName { get; private set; }
    }
}
