using System.Text.RegularExpressions;
using MechanicShop.Domain.Common;
using MechanicShop.Domain.Common.Results;
using MechanicShop.Domain.Customers.Vehicles;

namespace MechanicShop.Domain.Customers;

public sealed class Customer : AuditableEntity
{
    public string? Name { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Email { get; private set; }

    private readonly List<Vehicle> _vehicles = [];
    public IEnumerable<Vehicle> Vehicles => _vehicles.AsReadOnly();

    private Customer() { }

    private Customer(Guid id, string name, string phoneNumber, string email,List<Vehicle> vehicles)
                    : base(id)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        _vehicles = vehicles;
    }

    public static Result<Customer> Create(Guid id, string name, string phoneNumber, string email, List<Vehicle> vehicles)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return CustomerErrors.NameRequired;
        }

        if (string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^\+?\d{7,15}$"))
        {
            return CustomerErrors.InvalidPhoneNumber;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            return CustomerErrors.EmailRequired;
        }

        try
        {
            _ = new System.Net.Mail.MailAddress(email);
        }
        catch
        {
            return CustomerErrors.EmailInvalid;
        }
        
        return new Customer(id, name, phoneNumber, email, vehicles);
    }

    public Result<Updated> Update(string name, string phoneNumber, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return CustomerErrors.NameRequired;
        }

        if (string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^\+?\d{7,15}$"))
        {
            return CustomerErrors.PhoneNumberRequired;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            return CustomerErrors.EmailRequired;
        }

        try
        {
            _ = new System.Net.Mail.MailAddress(email);
        }
        catch
        {
            return CustomerErrors.EmailInvalid;
        }


        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;

        return Result.Updated;
    }
}