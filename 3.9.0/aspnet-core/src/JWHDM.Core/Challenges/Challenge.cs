using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JWHDM.Authorization.Users;
using JWHDM.MultiTenancy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JWHDM.Challenges
{
    public class Challenge : Entity, IMayHaveTenant,IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        [ForeignKey("ChallengerId")]
        public User Challenger { get; set; }
        public long ChallengerId { get; set; }
        [ForeignKey("ToChallengerId")]
        public User ToChallenger { get; set; }
        public long ToChallengerId { get; set; }
        public string ChallengeDeclaration { get; set; }
        public string ToChallengeDeclaration { get; set; }
        /// <summary>
        /// 挑战时间
        /// </summary>
        public DateTime? ChallengeTime { get; set; }
        public User ConfirmUser{ get; set; }
        public long ConfirmUserId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublic { get; set; }
        public int? TenantId { get; set; }
    }
}
