using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JWHDM.LessonMinds.Dto;
using JWHDM.UserMembers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.UserMemberLessonMinds.Dto
{
    [Serializable]
    [AutoMap(typeof(UserMemberLessonMind))]
    public class UserMemberLessonMindDto : EntityDto<long>
    {
        public long UserMemberId { get; set; }
        public UserMemberDto UserMember { get; set; }
        public int LessonMindId { get; set; }
        public LessonMindDto LessonMind { get; set; }
        public int? TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
