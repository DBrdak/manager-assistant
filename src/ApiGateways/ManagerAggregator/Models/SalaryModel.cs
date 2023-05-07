namespace ManagerAggregator.Models
{
    public class SalaryModel
    {
        public string Id { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal Hours { get; set; }
        public decimal Additions { get; set; }
        public decimal Wage { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime PaidFrom { get; set; }
        public DateTime PaidTo { get; set; }
        public bool IsPaid { get; set; }
    }
}
