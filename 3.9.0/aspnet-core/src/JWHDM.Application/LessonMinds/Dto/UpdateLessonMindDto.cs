using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JWHDM.LessonMinds;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.LessonMinds.Dto
{
    [AutoMapTo(typeof(LessonMind))]
    public class UpdateLessonMindDto : CreateLessonMindDto,IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
