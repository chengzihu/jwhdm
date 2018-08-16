using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.UserMembers.Dto
{
    public class GetUserMembersPagedResultRequestDto: PagedResultRequestDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
