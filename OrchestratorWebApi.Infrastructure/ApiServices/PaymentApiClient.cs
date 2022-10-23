using OrchestratorWebApi.Application.Models;

namespace OrchestratorWebApi.Infrastructure.ApiServices;

/// <summary>
/// Do not change this class it represents the call to the external API
/// </summary>
public class PaymentApiClient
{
    public async Task<ICollection<TransactionModel>?> GetTransactionsAsync(string userId, DateOnly fromDate, DateOnly toDate,
        CancellationToken cancellationToken)
    {
        await Task.Delay(5000, cancellationToken);
        var rnd = new Random();
        var transactions = new List<TransactionModel>
        {
            new()
            {
                Amount = 42f,
                Type = "debit",
                BenefitName = Faker.Company.Name(),
                Datetime = GetRandomDate(fromDate.ToDateTime(TimeOnly.MinValue), toDate.ToDateTime(TimeOnly.MinValue), rnd),
                TransactionId = Faker.RandomNumber.Next().ToString(),
                Address = new AddressModel
                {
                    City = Faker.Address.City(),
                    Country = Faker.Address.Country(),
                    Street = Faker.Address.StreetName(),
                    PostCode = Faker.Address.ZipCode()
                }
            },
            new()
            {
                Amount = 24f,
                Type = "debit",
                BenefitName = Faker.Company.Name(),
                Datetime = GetRandomDate(fromDate.ToDateTime(TimeOnly.MinValue), toDate.ToDateTime(TimeOnly.MinValue), rnd),
                TransactionId = Faker.RandomNumber.Next().ToString(),
                Address = new AddressModel
                {
                    City = Faker.Address.City(),
                    Country = Faker.Address.Country(),
                    Street = Faker.Address.StreetName(),
                    PostCode = Faker.Address.ZipCode()
                }
            },
            new()
            {
                Amount = 24.42f,
                Type = "debit",
                BenefitName = Faker.Company.Name(),
                Datetime = GetRandomDate(fromDate.ToDateTime(TimeOnly.MinValue), toDate.ToDateTime(TimeOnly.MinValue), rnd),
                TransactionId = Faker.RandomNumber.Next().ToString(),
                Address = new AddressModel
                {
                    City = Faker.Address.City(),
                    Country = Faker.Address.Country(),
                    Street = Faker.Address.StreetName(),
                    PostCode = Faker.Address.ZipCode()
                }
            },
            new()
            {
                Amount = 42.24f,
                Type = "debit",
                BenefitName = Faker.Company.Name(),
                Datetime = GetRandomDate(fromDate.ToDateTime(TimeOnly.MinValue), toDate.ToDateTime(TimeOnly.MinValue), rnd),
                TransactionId = Faker.RandomNumber.Next().ToString(),
                Address = new AddressModel
                {
                    City = Faker.Address.City(),
                    Country = Faker.Address.Country(),
                    Street = Faker.Address.StreetName(),
                    PostCode = Faker.Address.ZipCode()
                }
            },
            new()
            {
                Amount = 10f,
                Type = "debit",
                BenefitName = Faker.Company.Name(),
                Datetime = GetRandomDate(fromDate.ToDateTime(TimeOnly.MinValue), toDate.ToDateTime(TimeOnly.MinValue), rnd),
                TransactionId = Faker.RandomNumber.Next().ToString(),
                Address = new AddressModel
                {
                    City = Faker.Address.City(),
                    Country = Faker.Address.Country(),
                    Street = Faker.Address.StreetName(),
                    PostCode = Faker.Address.ZipCode()
                }
            }
        };
        
        var shuffleTransactions = transactions.OrderBy(x => rnd.Next()).ToList();
        return shuffleTransactions;
    }
    
    
    private static DateTime GetRandomDate(DateTime from, DateTime to, Random rnd)
    {
        var range = to - from;
        var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));
        return from + randTimeSpan;
    }
}