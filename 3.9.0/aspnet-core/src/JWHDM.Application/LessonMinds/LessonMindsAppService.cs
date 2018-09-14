using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using JWHDM.LessonMinds.Dto;
using JWHDM.UserMembers.Dto;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.LessonMinds
{
    public class LessonMindsAppService : AsyncCrudAppService<LessonMind, LessonMindDto,int, QueryLessonMindDto, CreateLessonMindDto, UpdateLessonMindDto>, ILessonMindsAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<LessonMind, int> _lessonMindRepository;
        private IAbpSession _abpSession { get; set; }
        public LessonMindsAppService(
            IRepository<LessonMind,int> repository,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<LessonMind, int> lessonMindRepository
            )
            :base(repository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _lessonMindRepository = lessonMindRepository;
        }

        public override Task<PagedResultDto<LessonMindDto>> GetAll(QueryLessonMindDto input)
        {
            return base.GetAll(input);
        }

        public override Task<LessonMindDto> Create(CreateLessonMindDto input)
        {
            if (AbpSession.TenantId.HasValue)
            {
                input.TenantId = AbpSession.TenantId.Value;
            }
            return base.Create(input);
        }

        public override Task<LessonMindDto> Update(UpdateLessonMindDto input)
        {
            if (AbpSession.TenantId.HasValue)
            {
                input.TenantId = _abpSession.TenantId.Value;
            }
            return base.Update(input);
        }

        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }

        public void SeedData()
        {
            #region 初始化课程类型表 数据
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
            var lessonMindDtos =_lessonMindRepository.GetAllList();
            if (lessonMindDtos == null || lessonMindDtos.Count == 0)
            {
                _lessonMindRepository.InsertOrUpdate(new LessonMind { MindName = "大课", CreatorUserId = currentUserId, TenantId = currentTenantId });
                _lessonMindRepository.InsertOrUpdate(new LessonMind { MindName = "私教", CreatorUserId = currentUserId, TenantId = currentTenantId });
                CurrentUnitOfWork.SaveChanges();
            }
            #endregion
        }
    }
}
