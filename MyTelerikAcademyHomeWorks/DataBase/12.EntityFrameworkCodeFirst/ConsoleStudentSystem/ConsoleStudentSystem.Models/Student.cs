namespace ConsoleStudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        private ICollection<UserProfile> userProfiles;

        public User()
        {
            this.userProfiles = new HashSet<UserProfile>();
        }

        public virtual ICollection<UserProfile> UserProfiles
        {
            get { return userProfiles; }
            set { userProfiles = value; }
        }
    }
}



