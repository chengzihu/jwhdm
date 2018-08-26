using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JWHDM.UserMemberLessonMinds.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMemberLessonMinds
{
    public interface IUserMemberLessonMindAppService:IAsyncCrudAppService<UserMemberLessonMindDto, long, GetUserMemberLessonMindsPagedResultRequestInput, CreateUserMemberLessonMindInput, UpdateUserMemberLessonMindInput>
    {
        Task<PagedResultDto<UserMemberLessonMindDto>> GetAllIncluding(GetUserMemberLessonMindsPagedResultRequestInput input);
    }
}
