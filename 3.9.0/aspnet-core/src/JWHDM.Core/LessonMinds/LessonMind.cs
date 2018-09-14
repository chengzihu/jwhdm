using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JWHDM.UserMemberLessonMinds;
using JWHDM.UserMembers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JWHDM.LessonMinds
{
    public class LessonMind : Entity<int>, IMayHaveTenant, IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        public string MindName { get; set; }
        //[ForeignKey("RelationUserMemberId")]
        //public UserMember RelationUserMember { get; set; }
        //public long RelationUserMemberId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? TenantId { get; set; }
        public virtual ICollection<UserMemberLessonMind> UserMemberLessonMinds { get; set; }
    }
}
