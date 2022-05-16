using System.Collections.Generic;
using System.Linq;
using AppointmentSystemAPI.Data.DBContext;
using AppointmentSystemAPI.Data.Model;
using AppointmentSystemAPI.Data.Repository.Interface;

namespace AppointmentSystemAPI.Data.Repository
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly ProblemContext _problemContext;

        public ProblemRepository(ProblemContext ctx)
        {
            _problemContext = ctx;
        }

        public List<Problem> GetAllProblems()
        {
            return _problemContext.Problems.ToList();
        }

        public Problem? GetProblemById(int problemId)
        {
            return _problemContext.Problems.Find(problemId);
        }

        public Problem AddNewProblem(Problem problem)
        {
            var newProblem = _problemContext.Add(problem).Entity;
            _problemContext.SaveChanges();
            return newProblem;
        }

        public List<Problem> AddNewProblems(List<Problem> problems)
        {
            var newProblems = new List<Problem>();
            foreach (var problem in problems)
            {
                _problemContext.Add(problem);
                newProblems.Add(problem);
            }

            _problemContext.SaveChanges();
            return newProblems;
        }

        public void RemoveProblem(Problem problem)
        {
            _problemContext.Problems.Remove(problem);
            _problemContext.SaveChanges();
        }
    }
}