using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JWHDM.MultiTenancy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace JWHDM.TenantAgencys
{
    /// <summary>
    /// 租户代理人--租户详细
    /// </summary>
    public class TenantAgency : Entity,IMayHaveTenant,IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        public  string Code { get; set; }

        public  string Name { get; set; }

        public  string Address { get; set; }

        public  string CallNumber { get; set; }

        public  string PhoneNumber { get; set; }
        /// <summary>
        /// logo
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessLicence { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public string CoverImage { get; set; }

        /// <summary>
        /// 服务开始时间
        /// </summary>
        public DateTime ServiceBegin { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
        public DateTime? ServiceEnd { get; set; }
        
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublic { get; set; }
        public int? TenantId { get; set; }
    }
}
