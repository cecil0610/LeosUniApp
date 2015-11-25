using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ConsotoUniApi.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public class ConsotoUniApiContext : DbContext
    {

        public class MyConfiguration : DbMigrationsConfiguration<ConsotoUniApiContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
                this.AutomaticMigrationDataLossAllowed = true;
            }

            protected override void Seed(ConsotoUniApiContext context)
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        FirstName = "Carson", LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2010-09-01")
                    },
                    new Student
                    {
                        FirstName = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        FirstName = "Arturo", LastName = "Anand",
                        EnrollmentDate = DateTime.Parse("2011-09-01")
                    },
                    new Student
                    {
                        FirstName = "Yan", LastName = "Li",
                        EnrollmentDate = DateTime.Parse("2014-09-01")
                    },
                    new Student
                    {
                        FirstName = "Bob", LastName = "Katana",
                        EnrollmentDate = DateTime.Parse("2013-09-01")
                    }
                };
                students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
                context.SaveChanges();

                var courses = new List<Course>
                {
                    new Course
                    {
                        CourseID = 1001,
                        Title = "LogicalThinking",
                        Credits = 10,
                        CoursePercentage = 0,
                        CompletionStatus = CompletionStatus.InProgress
                    },
                    new Course
                    {
                        CourseID = 2002,
                        Title = "NetworkFundamentals",
                        Credits = 20,
                        CoursePercentage = 0,
                        CompletionStatus = CompletionStatus.InProgress
                    },
                    new Course
                    {
                        CourseID = 3003,
                        Title = "DataMining",
                        Credits = 30,
                        CoursePercentage = 0,
                        CompletionStatus = CompletionStatus.InProgress
                    },
                    new Course
                    {
                        CourseID = 4004,
                        Title = "Algorithms",
                        Credits = 40,
                        CoursePercentage = 0,
                        CompletionStatus = CompletionStatus.InProgress
                    },
                    new Course
                    {
                        CourseID = 5005,
                        Title = "CloudSecurity",
                        Credits = 50,
                        CoursePercentage = 0,
                        CompletionStatus = CompletionStatus.InProgress
                    }
                };
                courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
                context.SaveChanges();

                var courseworks = new List<CourseWork>
                {
                    new CourseWork
                    {
                        CourseWorkID = 101,
                        Title = "LogicalThinking1",
                        WorkType = WorkType.Assignment,
                        DueDate = DateTime.Parse("2016-01-01"),
                        Grade = Grade.A
                    },
                    new CourseWork
                    {
                        CourseWorkID = 102,
                        Title = "LogicalThinking2",
                        WorkType = WorkType.Assignment,
                        DueDate = DateTime.Parse("2016-02-02"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 201,
                        Title = "NetworkFundamentals1",
                        WorkType = WorkType.Test,
                        DueDate = DateTime.Parse("2015-03-04"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 202,
                        Title = "NetworkFundamentals2",
                        WorkType = WorkType.Test,
                        DueDate = DateTime.Parse("2015-05-04"),
                        Grade = Grade.C
                    },
                    new CourseWork
                    {
                        CourseWorkID = 301,
                        Title = "DataMining1",
                        WorkType = WorkType.Test,
                        DueDate = DateTime.Parse("2016-03-04"),
                        Grade = Grade.C
                    },
                    new CourseWork
                    {
                        CourseWorkID = 302,
                        Title = "DataMining2",
                        WorkType = WorkType.Assignment,
                        DueDate = DateTime.Parse("2016-09-04"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 303,
                        Title = "DataMining3",
                        WorkType = WorkType.Assignment,
                        DueDate = DateTime.Parse("2016-10-04"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 401,
                        Title = "Algorithms1",
                        WorkType = WorkType.Assignment,
                        DueDate = DateTime.Parse("2016-05-04"),
                        Grade = Grade.A
                    },
                    new CourseWork
                    {
                        CourseWorkID = 501,
                        Title = "CloudSecurity1",
                        WorkType = WorkType.Test,
                        DueDate = DateTime.Parse("2016-01-04"),
                        Grade = Grade.D
                    }
                };
                courseworks.ForEach(s => context.CourseWorks.AddOrUpdate(p => p.CourseWorkID, s));
                context.SaveChanges();

                var enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        CourseID = courses.Single(c => c.Title == "LogicalThinking").CourseID
                    },
                    new Enrollment
                    {
                        StudentID = students.Single(s => s.LastName == "Alonso").ID,
                        CourseID = courses.Single(c => c.Title == "LogicalThinking").CourseID
                    },
                    new Enrollment
                    {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        CourseID = courses.Single(c => c.Title == "NetworkFundamentals").CourseID
                    },
                    new Enrollment
                    {
                        StudentID = students.Single(s => s.LastName == "Li").ID,
                        CourseID = courses.Single(c => c.Title == "NetworkFundamentals").CourseID
                    }
                };
                foreach (Enrollment e in enrollments)
                {
                    var enrollmentInDatabase = context.Enrollments.Where(
                        s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                    if (enrollmentInDatabase == null)
                    {
                        context.Enrollments.Add(e);
                    }
                }
                context.SaveChanges();

                var correlations = new List<Correlation>
                 {
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "LogicalThinking").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "LogicalThinking1").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "LogicalThinking").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "LogicalThinking2").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "NetworkFundamentals").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "NetworkFundamentals1").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "NetworkFundamentals").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "NetworkFundamentals2").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "DataMining").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "DataMining1").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "DataMining").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "DataMining2").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "DataMining").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "DataMining3").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "Algorithms").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "Algorithms1").CourseWorkID
                     },
                     new Correlation
                     {
                         CourseID = courses.Single(c => c.Title == "CloudSecurity").CourseID,
                         CourseWorkID = courseworks.Single(a => a.Title == "CloudSecurity1").CourseWorkID
                     },

                 };
                 foreach (Correlation e in correlations)
                 {
                     var correlationInDatabase = context.Correlations.Where(
                         s =>
                             s.Course.CourseID == e.CourseID &&
                             s.CourseWork.CourseWorkID == e.CourseWorkID).SingleOrDefault();
                     if (correlationInDatabase == null)
                     {
                         context.Correlations.Add(e);
                     }
                 }
                 context.SaveChanges();
            }
        }

        public ConsotoUniApiContext() : base("name=ConsotoUniApiContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConsotoUniApiContext, MyConfiguration>());         
        }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.Correlation> Correlations { get; set; }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.CourseWork> CourseWorks { get; set; }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.Enrollment> Enrollments { get; set; }
    }
}
