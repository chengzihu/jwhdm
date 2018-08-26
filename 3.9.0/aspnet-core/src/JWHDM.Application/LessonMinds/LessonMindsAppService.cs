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
        private IAbpSession _abpSession { get; set; }
        public LessonMindsAppService(
            IRepository<LessonMind,int> repository,
            IUnitOfWorkManager unitOfWorkManager
            )
            :base(repository)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

        public override Task<PagedResultDto<LessonMindDto>> GetAll(QueryLessonMindDto input)
        {
            return base.GetAll(input);
        }

        public override Task<LessonMindDto> Create(CreateLessonMindDto input)
        {
            if (_abpSession.TenantId.HasValue)
            {
                input.TenantId = _abpSession.TenantId.Value;
            }
            return base.Create(input);
        }

        public override Task<LessonMindDto> Update(UpdateLessonMindDto input)
        {
            if (_abpSession.TenantId.HasValue)
            {
                input.TenantId = _abpSession.TenantId.Value;
            }
            return base.Update(input);
        }

        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
