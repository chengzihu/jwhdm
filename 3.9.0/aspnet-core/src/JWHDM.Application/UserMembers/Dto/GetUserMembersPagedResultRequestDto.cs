using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JWHDM.UserMembers.Dto
{
    public class GetUserMembersPagedResultRequestDto: PagedResultRequestDto
    {
        [Required]
        public int offset { get; set; }
        [Required]
        public int limit { get; set; }
        public string name { get; set; }
        public string minweight { get; set; }
        public string maxweight { get; set; }
    }
}
