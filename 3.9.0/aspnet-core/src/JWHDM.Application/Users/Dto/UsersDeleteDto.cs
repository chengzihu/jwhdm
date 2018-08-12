using Abp.Authorization.Users;
using Abp.AutoMapper;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWHDM.Users.Dto
{
    [AutoMap(typeof(UserDto))]
    public class UsersDeleteDto
    {
        [Required]
        public long Id { get; set; }
    }
}
