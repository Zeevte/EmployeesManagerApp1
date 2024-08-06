using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BL
{
    public class BLConnection
    {
        public DBConnection connection { get; set; }
        public List<Employee> Listemployees { get; set; }
        public List<Candidate> listCandidate { get; set; }
        public List<Interview> listInterview { get; set; }
        public Dictionary<string, List<int>> DikCandidet { get; set; }
        public List<string> Skills { get; set; }
        public BLConnection()
        {
            connection = new DBConnection();
            Listemployees = connection.GetAllEmployees().ToList();
            listCandidate = connection.GetAllCandidates().ToList();
            listInterview = connection.GetAllInterviews().ToList();
            Skills = new List<string> { "City", "StartOfWorkYear", "Age", "RoleInCompany" };

        }

        public List<Employee> GetAllEmployees()
        {
            return connection.GetAllEmployees().ToList();
        }

        public List<string> GetFilterBy()
        {
            return Skills;
        }

        public List<string> GetJobs()
        {
            List<string> listJobs = Listemployees.Select(e => e.RoleInCompany).Distinct().ToList();
            return listJobs;
        }

        public List<Candidate> GetAllCandidates()
        {
            return listCandidate;
        }
        public List<string> GetNameCandidate()
        {
            List<string> listNames = listCandidate.Select(e => e.FirstName+" "+e.LastName).Distinct().ToList();
            return listNames;
        }
        public List<Interview> GetAllInterviews()
        {
            return listInterview;
        }

        // פונקציה להוספת עובד חדש
        public bool AddEmployee(Employee newEmployee)
        {
            return connection.AddEmployee(newEmployee);

        }


    }
}