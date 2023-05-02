namespace Payroll.API.Entities.Common;

public class Period
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public Period(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }
}