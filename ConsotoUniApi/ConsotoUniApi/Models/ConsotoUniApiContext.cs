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
            }

            protected override void Seed(ConsotoUniApiContext context)
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        Firstname = "Carson", LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2010-09-01")
                    },
                    new Student
                    {
                        Firstname = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        Firstname = "Arturo", LastName = "Anand",
                        EnrollmentDate = DateTime.Parse("2011-09-01")
                    },
                    new Student
                    {
                        Firstname = "Yan", LastName = "Li",
                        EnrollmentDate = DateTime.Parse("2014-09-01")
                    },
                    new Student
                    {
                        Firstname = "Bob", LastName = "Katana",
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
                        Credits = 10
                    },
                    new Course
                    {
                        CourseID = 2002,
                        Title = "NetworkFundamentals",
                        Credits = 20
                    },
                    new Course
                    {
                        CourseID = 3003,
                        Title = "DataMining",
                        Credits = 30
                    },
                    new Course
                    {
                        CourseID = 4004,
                        Title = "Algorithms",
                        Credits = 40
                    },
                    new Course
                    {
                        CourseID = 5005,
                        Title = "CloudSecurity",
                        Credits = 50
                    }
                };
                courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
                context.SaveChanges();

                var courseworks = new List<CourseWork>
                {
                    new CourseWork
                    {
                        CourseWorkID = 100,
                        WorkType = WorkType.Assignment,
                        WorkNumber = 1,
                        DueDate = DateTime.Parse("2016-01-01"),
                        Grade = Grade.A
                    },
                    new CourseWork
                    {
                        CourseWorkID = 101,
                        WorkType = WorkType.Assignment,
                        WorkNumber = 2,
                        DueDate = DateTime.Parse("2016-02-02"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 202,
                        WorkType = WorkType.Test,
                        WorkNumber = 1,
                        DueDate = DateTime.Parse("2015-03-04"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 203,
                        WorkType = WorkType.Test,
                        WorkNumber = 2,
                        DueDate = DateTime.Parse("2015-05-04"),
                        Grade = Grade.C
                    },
                    new CourseWork
                    {
                        CourseWorkID = 301,
                        WorkType = WorkType.Test,
                        WorkNumber = 1,
                        DueDate = DateTime.Parse("2016-03-04"),
                        Grade = Grade.C
                    },
                    new CourseWork
                    {
                        CourseWorkID = 303,
                        WorkType = WorkType.Assignment,
                        WorkNumber = 2,
                        DueDate = DateTime.Parse("2016-09-04"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 304,
                        WorkType = WorkType.Assignment,
                        WorkNumber = 3,
                        DueDate = DateTime.Parse("2016-10-04"),
                        Grade = Grade.B
                    },
                    new CourseWork
                    {
                        CourseWorkID = 401,
                        WorkType = WorkType.Assignment,
                        WorkNumber = 1,
                        DueDate = DateTime.Parse("2016-05-04"),
                        Grade = Grade.A
                    },
                    new CourseWork
                    {
                        CourseWorkID = 501,
                        WorkType = WorkType.Test,
                        WorkNumber = 1,
                        DueDate = DateTime.Parse("2016-01-04"),
                        Grade = Grade.D
                    }
                };
                courseworks.ForEach(s => context.CourseWorks.AddOrUpdate(p => p.CourseWorkID, s));
                context.SaveChanges();

                var enrollments = new List<Enrollment>
                {

                };


            }
        }

      

        public ConsotoUniApiContext() : base("name=ConsotoUniApiContext")
        {
            if (!Database.Exists("ConsotoUniApiContext"))
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConsotoUniApiContext, MyConfiguration>());
            }
        }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<ConsotoUniApi.Models.CourseWork> CourseWorks { get; set; }
    }
}
