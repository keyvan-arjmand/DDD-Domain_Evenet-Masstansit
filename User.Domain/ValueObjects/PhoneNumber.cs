using DotLiquid.Util;
using System.Text.RegularExpressions;

namespace User.Domain.ValueObjects;

public class PhoneNumber : Domain.Common.ValueObject
{
    public string PoNumber { get; private set; }

    public PhoneNumber()
    {
        
    }

    public PhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new Exception();
        }
        const string pattern = @"^09[0|1|2|3][0-9]{8}$";
        Regex reg = new Regex(pattern);
        if (!reg.IsMatch(phoneNumber))
        {
            throw new Exception();
        }
        PoNumber = phoneNumber;
    }
    public static PhoneNumber Create(string title)
    {
        var phoneNumber = new PhoneNumber(title);
        return phoneNumber;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PoNumber;
    }
}