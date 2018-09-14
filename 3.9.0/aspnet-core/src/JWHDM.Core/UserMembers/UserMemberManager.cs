using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using JWHDM.LessonMinds;
using JWHDM.UserMemberLessonMinds;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMembers
{
    public class UserMemberManager: IDomainService,ITransientDependency
    {
        private readonly IRepository<UserMember, long> _userMemberRepository;
        private readonly IRepository<UserMemberLessonMind, long> _userMemberLessonMindRepository;
        private readonly IIocResolver _iocResolver;
        public UserMemberManager(IRepository<UserMember, long> userMemberRepository, IIocResolver iocResolver,IRepository<UserMemberLessonMind, long> userMemberLessonMindRepository)
        {
            _userMemberRepository = userMemberRepository;
            _iocResolver = iocResolver;
            //var personService1 = _iocResolver.Resolve<IRepository<LessonMind>>();
            _userMemberLessonMindRepository=userMemberLessonMindRepository;
        }

        public async Task<List<UserMemberLessonMind>> SetLessonMindsToUserMemberAsync(long userMemberId,IList<int> lessonMindIds,int? currentTenantId,long? currentUserId)
        {
            var userMemberLessonMinds = new List<UserMemberLessonMind>();
            foreach (var lessonMindId in lessonMindIds)
            {
                var userMemberLessonMindReturn =await _userMemberLessonMindRepository.InsertOrUpdateAsync(
                    new UserMemberLessonMind
                    {
                        TenantId =currentTenantId,
                        CreatorUserId =currentUserId,
                        UserMemberId = userMemberId,
                        LessonMindId = lessonMindId
                    });
                userMemberLessonMinds.Add(userMemberLessonMindReturn);
            }
            return userMemberLessonMinds;
        }
    }
}
