using JobPortalAPI.Model;

namespace JobPortalAPI.Repository
{
    public interface IJobReg
    {
        bool InsertJobseekers(Jobseekers jobseekers);
    }
}
