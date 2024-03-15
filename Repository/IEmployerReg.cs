using JobPortalAPI.ViewModel;

namespace JobPortalAPI.Repository
{
    public interface IEmployerReg
    {
        int AddCompanyDetails(EmployerDetails employerDetails);
        bool AddEmployer(EmployerDetails employerDetails);
    }
}
