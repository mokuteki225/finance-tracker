namespace FinanceTracker.Api.Responses.Customers;

public sealed class CustomerBalanceResponse
{
    public int Netto { get; set; }
    
    public int Brutto { get; set; }
    
    public int MoneyLeft { get; set; }
}