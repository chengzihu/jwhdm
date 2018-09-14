using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.LessonMinds.Dto
{
    [AutoMapTo(typeof(LessonMind))]
    public class CreateLessonMindDto
    {
        public string MindName { get; set; }
        //public LessonMind RelationUserMember { get; set; }
        public long RelationUserMemberId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? TenantId { get; set; }
    }
}
