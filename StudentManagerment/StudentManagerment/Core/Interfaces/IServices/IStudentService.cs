using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Core.Interfaces.IServices
{
    public interface IStudentService : IBasicService<Student>
    {
        public void showInfoDetail(Student student);
        public void showInfo(Student student);
    }
}
