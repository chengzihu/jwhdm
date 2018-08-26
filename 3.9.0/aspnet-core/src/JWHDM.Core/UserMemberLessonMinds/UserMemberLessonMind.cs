using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JWHDM.LessonMinds;
using JWHDM.UserMembers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JWHDM.UserMemberLessonMinds
{
    public class UserMemberLessonMind : Entity<long>, IMayHaveTenant, IHasCreationTime,ICreationAudited
    {
        public long UserMemberId { get; set; }
        [ForeignKey("UserMemberId")]
        public UserMember UserMember { get; set; }
        public int LessonMindId { get; set; }
        [ForeignKey("LessonMindId")]
        public LessonMind LessonMind { get; set; }
        public int? TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
