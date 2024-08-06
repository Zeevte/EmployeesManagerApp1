using DAL.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DAL
{
    public class DBConnection
    {
        public InterviewsManagerContext Context = new InterviewsManagerContext();

        public List<Employee> GetAllEmployees()
        {
            return Context.Employees.ToList();
        }
        public List<Candidate> GetAllCandidates()
        {
            return Context.Candidates.ToList();
        }
        public List<Interview> GetAllInterviews()
        {
            return Context.Interviews.ToList();
        }

 

        // פונקציה להוספת עובד חדש
        public bool AddEmployee(Employee newEmployee)
        {
            //int res = connection.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Employees ON");

            try
            {
                Context.Employees.Add(newEmployee);

                Context.SaveChanges();
            }
            catch (Exception) { return false; }
            return true;
            //connection.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Employees OFF");
        }
    }
}