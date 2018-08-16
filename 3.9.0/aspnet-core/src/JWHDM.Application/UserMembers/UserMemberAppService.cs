using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JWHDM.UserMembers.Dto;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMembers
{
    public class UserMemberAppService : AsyncCrudAppService<UserMember, UserMemberDto, long, GetUserMembersPagedResultRequestDto, CreateUserDto, UserMemberDto>,IUserMemberAppService
    {
        public UserMemberAppService(
            IRepository<UserMember,long> repository
            
            )
            :base(repository)
        {

        }

        public override Task<PagedResultDto<UserMemberDto>> GetAll(GetUserMembersPagedResultRequestDto input)
        {
            return base.GetAll(input);
        }

        public Task<UserMemberDto> Create(CreateUserMemberDto input)
        {
            throw new NotImplementedException();
        }
    }
}
