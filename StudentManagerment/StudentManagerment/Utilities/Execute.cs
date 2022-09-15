using StudentManagerment.Core.Interfaces.IServices;
using StudentManagerment.Core.Services;
using StudentManagerment.Data;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using StudentManagerment.Core.Interfaces.IData;

namespace StudentManagerment.Utilities
{
    public class Execute
    {
        public void runMain()
        {
            try
            {
                Console.SetWindowSize(150, 40);
                Title title = new Title();
                var container = new WindsorContainer();
                container.Register(
                    Component.For<IStudentData>().ImplementedBy<NHibernateData>().Named("StudentData"),
                    Component.For<ISubjectData>().ImplementedBy<NHibernateData>().Named("SubjectData"),
                    Component.For<ITranscriptData>().ImplementedBy<NHibernateData>().Named("TranscriptData"),
                    Component.For<IStudentService>().ImplementedBy<StudentService>().DependsOn(Dependency.OnComponent("data","StudentData")),
                    Component.For<ISubjectService>().ImplementedBy<SubjectService>().DependsOn(Dependency.OnComponent("data", "SubjectData")),
                    Component.For<ITranscriptService>().ImplementedBy<TranscriptService>().DependsOn(Dependency.OnComponent("data", "TranscriptData"))
                    );

                var studentService = container.Resolve<IStudentService>();
                List<Student> dssv = studentService.getAll();

                var subjectService = container.Resolve<ISubjectService>();
                List<Subject> dsmh = subjectService.getAll();

                var transcriptService = container.Resolve<ITranscriptService>();
                List<Transcript> dsbd = transcriptService.getAll();
                
                int ttChucNang;
                menu();
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n\tNhập chức năng: ");

                    bool ktNhap = int.TryParse(Console.ReadLine(), out ttChucNang);
                    if (!ktNhap)
                        throw new Exception("nhập sai thứ tự chức năng!");
                    Console.ResetColor();


                    if (ttChucNang == 0)
                        break;
                    else if (ttChucNang == 1)
                    {
                        title.showTitleStudent();
                        dssv.ForEach(t => studentService.showInfo(t));
                    }
                    else if (ttChucNang == 2)
                    {
                        string maSV;
                        Console.Write("\tNhập mã sinh viên để xem thông tin: ");
                        maSV = Console.ReadLine();
                        Student f = dssv.Find(t => t.MaSinhVien == maSV);
                        if (f == null)
                        {
                            showFail();
                        }
                        else
                        {
                            showSuccessful();
                            studentService.showInfoDetail(f);
                        }
                    }
                    else if (ttChucNang == 3)
                    {
                        title.showTitleSubject();
                        List<string> dsMH_DaXuat = new List<string>();
                        foreach (Transcript bd in dsbd)
                        {
                            foreach (Result k in bd.bangDiem)
                            {
                                if (dsMH_DaXuat.Find(t => t == k.MonHoc.MaMonHoc) == null)
                                {
                                    subjectService.showInfo(k.MonHoc);
                                    dsMH_DaXuat.Add(k.MonHoc.MaMonHoc);
                                }
                            }
                        }
                    }
                    else if (ttChucNang == 4)
                    {
                        string masv;
                        Console.Write("\tNhập mã sinh viên để xem điểm: ");
                        masv = Console.ReadLine();
                        Transcript bdsv = dsbd.Find(t => t.MaSinhVien == masv);
                        if (bdsv == null)
                        {
                            showFail();
                        }
                        else
                        {
                            showSuccessful();
                            transcriptService.showInfo(dssv.Find(t => t.MaSinhVien == masv), bdsv, studentService);
                        }
                    }
                    else if (ttChucNang == 5)
                    {
                        string masv;
                        Console.Write("\tNhập mã sinh viên để nhập điểm: ");
                        masv = Console.ReadLine();
                        Transcript bdsv = dsbd.Find(t => t.MaSinhVien == masv);
                        if (bdsv == null)
                        {
                            showFail();
                        }
                        else
                        {
                            showSuccessful();
                            transcriptService.showInfo(dssv.Find(t => t.MaSinhVien == masv), bdsv, studentService);
                            Console.Write("\tNhập mã môn học: ");
                            string mamh = Console.ReadLine();
                            transcriptService.upScores(mamh, bdsv);
                        }
                    }
                    else if (ttChucNang == 6)
                    {
                        string masv;
                        Console.Write("\tNhập mã sinh viên để xem kết quả: ");
                        masv = Console.ReadLine();
                        Transcript bdsv = dsbd.Find(t => t.MaSinhVien == masv);
                        if (bdsv == null)
                        {
                            showFail();
                        }
                        else
                        {
                            showSuccessful();
                            studentService.showInfo(dssv.Find(t => t.MaSinhVien == masv));
                            transcriptService.showResult(bdsv);
                        }
                    }
                    //// Thử
                    //else if (ttChucNang == 7)
                    //{

                    //    //string masv;
                    //    //Console.Write("\tNhập mã sinh viên để xóa: ");
                    //    //masv = Console.ReadLine();

                    //    //studentService.detete(dssv, masv);
                    //    //dsbd = transcriptService.getAll();

                    //    string mamh;
                    //    Console.Write("\tNhập mã môn học để xóa: ");
                    //    mamh = Console.ReadLine().ToUpper();

                    //    transcriptService.detete(dsbd, mamh);
                    //}
                    else throw new Exception("nhập sai thứ tự chức năng!");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Lỗi: " + e);//.Message);
                Console.ReadLine();
            }
        }

        void showSuccessful()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t[>]Tìm thấy");
            Console.ResetColor();
        }
        void showFail()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tKhông tìm thấy sinh viên trong danh sách hiện tại!");
            Console.ResetColor();
        }
        private void menu()
        {
            Console.Clear();
            Console.WriteLine("\t\t----------------- CHỨC NĂNG -----------------");
            Console.WriteLine("\t\t1. Xem danh sách sinh viên.");
            Console.WriteLine("\t\t2. Xem chi tiết sinh viên.");
            Console.WriteLine("\t\t3. Xem số môn học sinh viên đăng ký.");
            Console.WriteLine("\t\t4. Xem điểm môn học của sinh viên.");
            Console.WriteLine("\t\t5. Nhập điểm của sinh viên.");
            Console.WriteLine("\t\t6. Xem kết quả trượt đỗ của sinh viên.");
            Console.WriteLine("\t\t0. Thoát.");
            Console.Write("\t\t---------------------------------------------");
        }
    }
}
