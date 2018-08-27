using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.UserMemberLessonMinds.Dto
{
    [AutoMapTo(typeof(UserMemberLessonMind))]
    public class CreateUserMemberLessonMindInput
    {
        public long UserMemberId { get; set; }
        public int LessonMindId { get; set; }
        public int? TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
