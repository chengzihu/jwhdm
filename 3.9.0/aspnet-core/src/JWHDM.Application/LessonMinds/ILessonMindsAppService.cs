using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using JWHDM.LessonMinds.Dto;
using JWHDM.UserMembers.Dto;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.LessonMinds
{
    public interface ILessonMindsAppService : IAsyncCrudAppService<LessonMindDto,int, QueryLessonMindDto, CreateLessonMindDto, UpdateLessonMindDto>
    {
        //Task<ListResultDto<RoleDto>> GetRoles();

        //Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
