namespace OrchestratorWebApi.Application.UseCases.GetTransactions; 
public class GetTransactionsQueryResponse
{
    public string TransactionId { get; init; }
    public string BenefitName { get; init; }
    public Address Address { get; init; }
    public string Type { get; init; }
    public DateTime Datetime { get; init; }
    public float Amount { get; init; }
    public string Currency { get; set; }
}

public record Address
{
    public string Street { get; init; }
    public string PostCode { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
}


