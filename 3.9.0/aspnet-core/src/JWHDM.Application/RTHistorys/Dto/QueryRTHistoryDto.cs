﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JWHDM.RTHistorys.Dto
{
    public class QueryRTHistoryDto
    {
        [Required]
        public string tenantid { get; set; }
        [Required]
        public string pointid { get; set; }
        [Required]
        public long beginTimestamp { get; set; }
        [Required]
        public long endTimestamp { get; set; }
    }
}
