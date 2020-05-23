using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniAuthMasterFX.Identity
{
    public class Profile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Profile()
        {

        }

        public Profile(ApplicationUser user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        public static IEnumerable<Profile> GetUserProfiles(IEnumerable<ApplicationUser> users)
        {
            var profiles = new List<Profile>() { };
            foreach (ApplicationUser user in users)
            {
                profiles.Add(new Profile(user));
            }

            return profiles;
        }
    }
}
