﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JWHDM.Authorization.Users;
using JWHDM.MultiTenancy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JWHDM.UserEmployees
{
    public class UserEmployee : Entity<long>,IMayHaveTenant,IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        [Required]
        [MaxLength(20)]
        public string Number { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string IDCard { get; set; }
        [ForeignKey("RelationUserId")]
        public User RelationUser { get; set; }
        public long? RelationUserId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Armspan { get; set; }
        public bool Gender { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int? MaritalStatus { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime JoinTime { get; set; }
        public string JoinAddress { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? JoinExpiry { get; set; }

        /// <summary>
        /// 会员类型，0：大课会员，1：私教会员
        /// </summary>
        public int? Type { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Abstract { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? TenantId { get; set; }
    }
}
