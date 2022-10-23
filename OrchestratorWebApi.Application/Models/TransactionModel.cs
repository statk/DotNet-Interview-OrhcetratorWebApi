namespace OrchestratorWebApi.Application.Models;

public record TransactionModel
{
    public string TransactionId { get; init; }
    public string BenefitName { get; init; }
    public AddressModel Address { get; init; }
    public string Type { get; init; }
    public DateTime Datetime { get; init; }
    public float Amount { get; init; }
}

public class AddressModel
{
    public string Street { get; init; }
    public string PostCode { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
}