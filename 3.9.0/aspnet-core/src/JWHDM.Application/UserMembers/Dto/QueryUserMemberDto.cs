﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JWHDM.UserMembers.Dto
{
    public class QueryUserMemberDto
    {
        [Required]
        public int offset { get; set; }
        [Required]
        public int limit { get; set; }
        public string departmentname { get; set; }
        public string statu { get; set; }
    }
}