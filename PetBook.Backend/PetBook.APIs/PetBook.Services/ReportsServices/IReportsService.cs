using System.Threading.Tasks;
using PetBook.Domain.ReportsDomain;

namespace PetBook.Services.ReportsServices
{
    public interface IReportsService
    {
        Task<Report> GenerateReport();
    }
}