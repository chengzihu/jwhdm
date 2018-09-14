using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JWHDM.UserMembers.Dto
{
    public class GetUserMembersPagedResultRequestDto: PagedResultRequestDto
    {
        [Required]
        public int offset { get; set; }
        [Required]
        public int limit { get; set; }
        /// <summary>
        /// 排序字段 weight
        /// </summary>
        public string sort{ get; set; }
        /// <summary>
        /// 排序顺序 升 asc  降 desc
        /// </summary>
        public string order { get; set; }
        public string name { get; set; }
        public string minweight { get; set; }
        public string maxweight { get; set; }
    }
}
