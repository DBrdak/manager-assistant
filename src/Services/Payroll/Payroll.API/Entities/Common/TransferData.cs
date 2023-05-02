namespace Payroll.API.Entities.Common;

public class TransferData
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string IBAN { get; set; }
    public string SWIFT { get; set; }

    public TransferData(string email, string phone, string iban, string swift)
    {
        Email = email;
        Phone = phone;
        IBAN = iban;
        SWIFT = swift;
    }
}