using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.LessonMinds
{
    public interface ILessonMindManager : IDomainService, ITransientDependency
    {

    }

}
