using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Core.Interfaces.IData
{
    public interface ISubjectData
    {
        List<Subject> GetSubjects();
    }
}
