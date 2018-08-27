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
        public UserMemberDto UserMember { get; set; }
        public IReadOnlyList<LessonMindDto> LessonMinds { get; set; }

        public bool IsLessonMindSelected(LessonMindDto lessonMindDto)
        {
            var has = UserMember != null && UserMember.UserMemberLessonMinds.Any(p => p.LessonMindId == lessonMindDto.Id);
            return has;
        }
    }
}
