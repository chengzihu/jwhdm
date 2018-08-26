using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JWHDM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JWHDM.UserMembers.Dto
{
    [AutoMapTo(typeof(UserMember))]
    public class UpdateUserMemberDto:CreateUserMemberDto,IEntityDto<long> //EntityDto<long>
    {
        public long Id { get; set; }
    }
}
