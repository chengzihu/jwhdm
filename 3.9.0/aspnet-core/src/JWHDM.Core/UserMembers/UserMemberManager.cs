using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using JWHDM.LessonMinds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMembers
{
    public class UserMemberManager: IDomainService,ITransientDependency
    {
        private readonly IRepository<UserMember, long> _userMemberRepository;
        
        private readonly IIocResolver _iocResolver;
        private ILessonMindManager _lessonMindManager;
        public UserMemberManager(IRepository<UserMember, long> userMemberRepository, IIocResolver iocResolver, ILessonMindManager lessonMindManager)
        {
            _userMemberRepository = userMemberRepository;
            _iocResolver = iocResolver;
            //var personService1 = _iocResolver.Resolve<IRepository<LessonMind>>();
            _lessonMindManager = lessonMindManager;
        }

        public async Task SetGrantedPermissionsAsync(UserMember userMember,LessonMind lessonMind)
        {
            
        }
    }
}
