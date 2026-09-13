using System.ComponentModel.DataAnnotations;
using Digital_Services_BD.Models;

namespace Digital_Services_BD.ViewModels;

public sealed class PaymentRequest
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    public BillingAddressInput BillingAddress { get; set; } = new();
}

public sealed class BillingAddressInput
{
    [StringLength(100)] public string? FirstName { get; set; }
    [StringLength(100)] public string? LastName { get; set; }
    [StringLength(250)] public string? AddressLineOne { get; set; }
    [StringLength(250)] public string? AddressLineTwo { get; set; }
    [StringLength(50)] public string? Mobile { get; set; }
    [StringLength(30)] public string? Zip { get; set; }
    [StringLength(100)] public string? State { get; set; }
    [StringLength(100)] public string? City { get; set; }
    [StringLength(100)] public string? Country { get; set; }
    public Address ToAddress() => new() { FirstName = FirstName, LastName = LastName, AddressLineOne = AddressLineOne, AddressLineTwo = AddressLineTwo,
        Mobile = Mobile, Zip = Zip, State = State, City = City, Country = Country };
}
