using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JWHDM.Authorization.Users;
using JWHDM.MultiTenancy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JWHDM.UserMembers
{
    public class UserMember : Entity<long>, IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        [Required]
        [MaxLength(20)]
        public string Number { get; set; }
        [DefaultValue("")]
        [MaxLength(200)]
        public string Photo { get; set; }
        [DefaultValue("")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DefaultValue("")]
        [MaxLength(20)]
        public string IDCard { get; set; }
        [ForeignKey("RelationUserId")]
        public User RelationUser { get; set; }
        public long? RelationUserId { get; set; }
        [DefaultValue(0)]
        public double Height { get; set; }
        [DefaultValue(0)]
        public double Weight { get; set; }
        [DefaultValue(0)]
        public double Armspan { get; set; }
        [DefaultValue(true)]
        public bool Gender { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        [DefaultValue(0)]
        public int? MaritalStatus{get;set;}
        [DefaultValue("")]
        [MaxLength(200)]
        public string Address { get; set; }
        [DefaultValue("")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [DefaultValue("1970-1-1")]
        public DateTime? Birthdate { get; set; }
        [DefaultValue("1970-1-1")]
        public DateTime JoinTime { get; set; }
        [DefaultValue("")]
        public string JoinAddress { get; set; }
        [DefaultValue("1970-1-1")]
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? JoinExpiry{ get; set; }

        [DefaultValue(0)]
        /// <summary>
        /// 会员类型，0：大课会员，1：私教会员
        /// </summary>
        public int? Type { get; set; }
        [DefaultValue(0)]
        /// <summary>
        /// 会员费
        /// </summary>
        public double Fee { get; set; }
        [DefaultValue(0)]
        /// <summary>
        /// 出勤课时
        /// </summary>
        public double AttendanceLesson { get; set; }
        [DefaultValue(0)]
        /// <summary>
        /// 总课时
        /// </summary>
        public double TotalLesson { get; set; }
        /// <summary>
        /// 出勤地点
        /// </summary>
        [DefaultValue("")]
        [MaxLength(200)]
        public string AttendanceAddress { get; set; }

        [DefaultValue("")]
        [MaxLength(200)]
        /// <summary>
        /// 简介
        /// </summary>
        public string Abstract { get; set; }
        [DefaultValue("")]
        [MaxLength(200)]
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        [DefaultValue("1970-1-1")]
        public DateTime CreationTime { get; set; }
        [DefaultValue("1970-1-1")]
        public DateTime? DeletionTime { get; set; }
        [DefaultValue(0)]
        public bool IsDeleted { get; set; }
        [DefaultValue("1970-1-1")]
        public DateTime? LastModificationTime { get; set; }
        [Required]
        public long? CreatorUserId { get; set; }

        [ForeignKey("RelationTenantId")]
        public Tenant RelationTenant { get; set; }
        public int? RelationTenantId { get; set; }
    }
}
