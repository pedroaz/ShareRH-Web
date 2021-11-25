using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetBook.Domain.ReportsDomain;
using PetBook.Infrastructure.Database;
using PetBook.Infrastructure.Repository;

namespace PetBook.Services.ReportsServices
{
    public class ReportsService : IReportsService
    {
        private readonly IPetBookDatabaseContext _petBookDatabaseContext;
        private readonly IRepository _repository;

        public ReportsService(IPetBookDatabaseContext petBookDatabaseContext, IRepository repository)
        {
            _petBookDatabaseContext = petBookDatabaseContext;
            _repository = repository;
        }

        public async Task<Report> GenerateReport()
        {
            var report = new Report();
            
            _repository.SaveFile(report.Content, report.ReportName);

            return report;
        }

    }
}
