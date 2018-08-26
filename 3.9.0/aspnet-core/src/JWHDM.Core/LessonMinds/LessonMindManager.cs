using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.LessonMinds
{
    public class LessonMindManager : ILessonMindManager
    {
        private readonly IRepository<LessonMind, int> _lessonMindRepository;
        public LessonMindManager(IRepository<LessonMind, int> lessonMindRepository)
        {
            this._lessonMindRepository = lessonMindRepository;
        }
    }

}
