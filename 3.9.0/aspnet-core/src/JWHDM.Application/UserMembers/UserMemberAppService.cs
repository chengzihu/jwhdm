using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using JWHDM.Authorization;
using JWHDM.LessonMinds;
using JWHDM.LessonMinds.Dto;
using JWHDM.UserMemberLessonMinds;
using JWHDM.UserMembers.Dto;
using JWHDM.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMembers
{
    [AbpAuthorize(PermissionNames.Pages_UserMembers)]
    public class UserMemberAppService : AsyncCrudAppService<UserMember, UserMemberDto,long, GetUserMembersPagedResultRequestDto, CreateUserMemberDto, UpdateUserMemberDto>,IUserMemberAppService
    {
        private readonly UserMemberManager _userMemberManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<UserMember, long> _userMemberRepository;
        private readonly IRepository<LessonMind,int> _lessonMindRepository;
        private readonly IRepository<UserMemberLessonMind, long> _userMemberLessonMindRepository;
        //private readonly IUserMemberLessonMindAppService _userMemberLessonMindAppService;
        //private readonly IIocResolver _iocResolver;
        private IAbpSession _abpSession { get; set; }
        public UserMemberAppService(
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserMember,long> userMemberRepository,
            IRepository<LessonMind,int> lessonMindRepository,
            IRepository<UserMemberLessonMind, long> userMemberLessonMindRepository,
            UserMemberManager userMemberManager
            )
            :base(userMemberRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _userMemberRepository = userMemberRepository;
            //_iocResolver = iocResolver;
            _lessonMindRepository = lessonMindRepository;
            _userMemberManager = userMemberManager;
            _userMemberLessonMindRepository = userMemberLessonMindRepository;
        }

        public override Task<PagedResultDto<UserMemberDto>> GetAll(GetUserMembersPagedResultRequestDto input)
        {
            var result = base.GetAll(input);
            return result;
        }

        public async Task<UserMemberDto> GetIncluding(long userMemberId)
        {
            var queryUserMembers =await _userMemberRepository.GetAllIncluding(u => u.UserMemberLessonMinds).Where(x=>x.Id==userMemberId).ToListAsync();
            return queryUserMembers.First().MapTo<UserMemberDto>();
        }

        public async Task<PagedResultDto<UserMemberDto>> GetAllIncluding(GetUserMembersPagedResultRequestDto input)
        {
            

            var queryLessonMindsDomain =await _lessonMindRepository.GetAll().ToListAsync();
            var lessonMindDtoList = queryLessonMindsDomain.MapTo<List<LessonMindDto>>();

            var queryUserMembers = _userMemberRepository.GetAllIncluding(u => u.UserMemberLessonMinds);//.Skip(Convert.ToInt32(input.Number)*input.SkipCount).Take(input.SkipCount);
            queryUserMembers = !string.IsNullOrEmpty(input.name) ? queryUserMembers.Where(x => x.UserName.Contains(input.name)|| x.Name.Contains(input.name)) :queryUserMembers;
            queryUserMembers = !string.IsNullOrEmpty(input.maxweight) ? queryUserMembers.Where(x=> Convert.ToDouble(x.Weight) <=Convert.ToDouble(input.maxweight)):queryUserMembers;
            queryUserMembers = !string.IsNullOrEmpty(input.minweight) ? queryUserMembers.Where(x => Convert.ToDouble(x.Weight) >= Convert.ToDouble(input.minweight)) : queryUserMembers;

            if ("asc".Equals(input.order.ToLower()))
            {
                queryUserMembers = !string.IsNullOrEmpty(input.sort) ? queryUserMembers.OrderBy(input.sort.FirstCharToUpper()) : queryUserMembers.OrderBy(t => t.Id);
            }
            else if ("desc".Equals(input.order.ToLower()))
            {
                queryUserMembers = !string.IsNullOrEmpty(input.sort) ? queryUserMembers.OrderByDescending(input.sort.FirstCharToUpper()) : queryUserMembers.OrderByDescending(t => t.Id);
            }
            var total = queryUserMembers.Count();
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

        //[AbpAuthorize(PermissionNames.Pages_UserMembers_Create)]
        public override async Task<UserMemberDto> Create(CreateUserMemberDto input)
        {
            int? currentTenantId = null;
            long? currentUserId = null;
            if (AbpSession.TenantId.HasValue)
            {
                currentTenantId = AbpSession.TenantId.Value;
            }
            if (AbpSession.UserId.HasValue)
            {
                currentUserId = AbpSession.UserId.Value;
            }

            var queryUserMembers = _userMemberRepository.GetAllIncluding();
            queryUserMembers = !string.IsNullOrEmpty(input.UserName) ? queryUserMembers.Where(x => x.UserName.Contains(input.UserName)) : queryUserMembers;
            var resultDomain = await queryUserMembers.FirstOrDefaultAsync();
            if (resultDomain != null)
            {
                throw new UserFriendlyException($"登录名：{ input.UserName }，已存在！");
            }

            var userMember=input.MapTo<UserMember>();
            userMember.TenantId = currentTenantId;
            userMember.CreatorUserId = currentUserId;
           
            var userMemberIdInserted =await _userMemberRepository.InsertOrUpdateAndGetIdAsync(userMember);

            var userMemberReturn = await _userMemberManager.SetLessonMindsToUserMemberAsync(userMemberIdInserted, input.LessonMindIds, currentTenantId, currentUserId);
            CurrentUnitOfWork.SaveChanges();
            //return base.Create(input);
            var userMemberInserted = _userMemberRepository.Get(userMemberIdInserted);
            var userMemberDtoReturn = userMemberInserted.MapTo<UserMemberDto>();
            return userMemberDtoReturn;
        }

        public override async Task<UserMemberDto> Update(UpdateUserMemberDto input)
        {
            int? currentTenantId = null;
            long? currentUserId = null;
            if (AbpSession.TenantId.HasValue)
            {
                currentTenantId = AbpSession.TenantId.Value;
            }
            if (AbpSession.UserId.HasValue)
            {
                currentUserId = AbpSession.UserId.Value;
            }
            input.TenantId = currentTenantId;
            input.CreatorUserId = currentUserId;
            var userMemberDto=await base.Update(input);
            var userMember = _userMemberRepository.GetAllIncluding(x=>x.UserMemberLessonMinds).Where(x=>x.Id==input.Id).First();
            var userMemberLessonMinds = userMember.UserMemberLessonMinds;
            foreach (var userMemberLessonMind in userMemberLessonMinds)
            {
                _userMemberLessonMindRepository.Delete(userMemberLessonMind);
            }
            var userMemberReturn = await _userMemberManager.SetLessonMindsToUserMemberAsync(userMember.Id, input.LessonMindIds, currentTenantId, currentUserId);
            CurrentUnitOfWork.SaveChanges();
            return userMemberDto;
        }

        public override Task Delete(EntityDto<long> input)
        {
            int? currentTenantId = null;
            long? currentUserId = null;
            if (AbpSession.TenantId.HasValue)
            {
                currentTenantId = AbpSession.TenantId.Value;
            }
            if (AbpSession.UserId.HasValue)
            {
                currentUserId = AbpSession.UserId.Value;
            }
            var userMember = _userMemberRepository.GetAllIncluding(x => x.UserMemberLessonMinds).Where(x => x.Id == input.Id).First();
            var userMemberLessonMinds = userMember.UserMemberLessonMinds;
            foreach (var userMemberLessonMind in userMemberLessonMinds)
            {
                _userMemberLessonMindRepository.Delete(userMemberLessonMind);
            }
            var returnValue = base.Delete(input);
            CurrentUnitOfWork.SaveChanges();
            return returnValue;
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
