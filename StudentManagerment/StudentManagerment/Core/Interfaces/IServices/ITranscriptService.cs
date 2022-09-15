using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Core.Interfaces.IServices
{
    public interface ITranscriptService : IBasicService<Transcript>
    {
        void showInfo(Student student, Transcript transcript, IStudentService studentService);
        void showResult(Transcript transcript);
        void upScores(string maMonHoc, Transcript transcript);
    }
}
