using ManagerAggregator.Extensions;
using ManagerAggregator.Models;

namespace ManagerAggregator.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly HttpClient _client;

        public PayrollService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<SalaryModel>> GetSalaries(string employeeName)
        {
            var response = await _client.GetAsync($"api/v1/payroll/{employeeName}");
            return await response.ReadContentAs<List<SalaryModel>>();
        }
    }
}
