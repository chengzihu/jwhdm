using JWHDM.LessonMinds.Dto;
using JWHDM.UserMembers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWHDM.Web.Models.UserMembers
{
    public class EditUserMemberModalViewModel
    {
        public IReadOnlyList<UserMemberDto> UserMembers { get; set; }
        public IReadOnlyList<LessonMindDto> LessonMindDtos { get; set; }
    }
}
