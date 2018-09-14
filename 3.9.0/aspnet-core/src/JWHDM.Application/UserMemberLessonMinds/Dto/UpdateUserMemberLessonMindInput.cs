using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.UserMemberLessonMinds.Dto
{
    [AutoMapTo(typeof(UserMemberLessonMind))]
    public class UpdateUserMemberLessonMindInput : CreateUserMemberLessonMindInput, IEntityDto<long>
    {
        public long Id { get; set; }
    }
}
