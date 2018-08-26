using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using JWHDM.LessonMinds;
using JWHDM.LessonMinds.Dto;
using JWHDM.UserMembers.Dto;
using JWHDM.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMembers
{
    public class UserMemberAppService : AsyncCrudAppService<UserMember, UserMemberDto,long, GetUserMembersPagedResultRequestDto, CreateUserMemberDto, UpdateUserMemberDto>,IUserMemberAppService
    {
        //private readonly UserMemberManager _userMemberManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<UserMember, long> _userMemberRepository;
        private readonly IRepository<LessonMind,int> _lessonMindRepository;
        //private readonly IIocResolver _iocResolver;
        private IAbpSession _abpSession { get; set; }
        public UserMemberAppService(
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserMember,long> userMemberRepository,
            IRepository<LessonMind,int> lessonMindRepository
            //IIocResolver iocResolver,
            //UserMemberManager userMemberManager
            )
            :base(userMemberRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _userMemberRepository = userMemberRepository;
            //_iocResolver = iocResolver;
            _lessonMindRepository = lessonMindRepository;
            //_userMemberManager = userMemberManager;
        }

        public override Task<PagedResultDto<UserMemberDto>> GetAll(GetUserMembersPagedResultRequestDto input)
        {
            var result = base.GetAll(input);
            return result;
        }

        public async Task<PagedResultDto<UserMemberDto>> GetAllIncluding(GetUserMembersPagedResultRequestDto input)
        {
            var queryLessonMindsDomain =await _lessonMindRepository.GetAll().ToListAsync();
            var lessonMindDtoList = queryLessonMindsDomain.MapTo<List<LessonMindDto>>();

            var queryUserMembers = _userMemberRepository.GetAllIncluding(u => u.UserMemberLessonMinds);//.Skip(Convert.ToInt32(input.Number)*input.SkipCount).Take(input.SkipCount);
            queryUserMembers = !string.IsNullOrEmpty(input.name) ? queryUserMembers.Where(x => x.Name.Contains(input.name)):queryUserMembers;
            queryUserMembers = !string.IsNullOrEmpty(input.maxweight) ? queryUserMembers.Where(x=> Convert.ToDouble(x.Weight) <=Convert.ToDouble(input.maxweight)):queryUserMembers;
            queryUserMembers = !string.IsNullOrEmpty(input.minweight) ? queryUserMembers.Where(x => Convert.ToDouble(x.Weight) >= Convert.ToDouble(input.minweight)) : queryUserMembers;
            var total=queryUserMembers.Count();
            var resultDomain =await queryUserMembers.PageBy(input).ToListAsync();
            var userMemberDtoList = resultDomain.MapTo<List<UserMemberDto>>();
            foreach (var userMemberDto in userMemberDtoList)
            {
                var lessonIds=userMemberDto.UserMemberLessonMinds.Select(x => x.LessonMindId).ToList();
                userMemberDto.SelectedLessonMinds = lessonMindDtoList.Where(x=>lessonIds.Contains(x.Id)).ToList();
            }
            var resultDto = new PagedResultDto<UserMemberDto>(total,userMemberDtoList);
            return resultDto;
        }

        public override Task<UserMemberDto> Create(CreateUserMemberDto input)
        {
            if (_abpSession.TenantId.HasValue)
            {
                input.TenantId = _abpSession.TenantId.Value;
            }
            return base.Create(input);
        }

        public override Task<UserMemberDto> Update(UpdateUserMemberDto input)
        {
            if (_abpSession.TenantId.HasValue)
            {
                input.TenantId = _abpSession.TenantId.Value;
            }
            return base.Update(input);
        }

        public override Task Delete(EntityDto<long> input)
        {
            return base.Delete(input);
        }

        //[UnitOfWork]
        //public virtual List<Product> GetProducts(int tenantId)
        //{
        //    using (_unitOfWorkManager.Current.SetTenantId(tenantId))
        //    {
        //        return _productRepository.GetAllList();
        //    }
        //}
    }
}
