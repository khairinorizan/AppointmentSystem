using AppointmentSystemAPI.Data.Model;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface IProblemRepository
    {
        List<Problem> GetAllProblems();
        Problem? GetProblemById(int problemId);
        Problem AddNewProblem(Problem problem);
        List<Problem> AddNewProblems(List<Problem> problems);
        void RemoveProblem(Problem problem);
    }
}