using ManagerAggregator.Extensions;
using ManagerAggregator.Models;

namespace ManagerAggregator.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _client;

        public EmployeeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<EmployeeModel> GetEmployeePersonalData(string employeeName)
        {
            var response = await _client.GetAsync("api/v1/employee");
            var result = await response.ReadContentAs<List<EmployeeModel>>();

            return result.SingleOrDefault(e => e.UniqueName == employeeName);
        }
    }
}
