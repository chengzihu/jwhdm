using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JWHDM.UserMemberLessonMinds;
using JWHDM.UserMemberLessonMinds.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.LessonMinds.Dto
{
    [Serializable]
    [AutoMap(typeof(LessonMind))]
    public class LessonMindDto : EntityDto<int>
    {
        public string MindName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? TenantId { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        [JsonIgnore]
        public virtual ICollection<UserMemberLessonMindDto> UserMemberLessonMinds { get; set; }
    }
}
