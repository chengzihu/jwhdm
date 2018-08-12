using System.Collections.Generic;
using JWHDM.Roles.Dto;
using JWHDM.Users.Dto;

namespace JWHDM.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
