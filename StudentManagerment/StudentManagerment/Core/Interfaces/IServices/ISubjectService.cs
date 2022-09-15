using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Core.Interfaces.IServices
{
    interface ISubjectService : IBasicService<Subject>
    {
        void showInfo(Subject subject);
    }
}
