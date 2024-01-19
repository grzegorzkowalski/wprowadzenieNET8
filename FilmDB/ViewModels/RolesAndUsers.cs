using Microsoft.AspNetCore.Identity;

namespace FilmDB.ViewModels
{
    public class RolesAndUsers
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
    }
}
