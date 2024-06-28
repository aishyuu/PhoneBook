using System.Text.RegularExpressions;

namespace PhoneBook;

internal class Validation
{
    internal static bool EmailValidation(string email)
    {
        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

        return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
    }

    internal static bool PhoneValidation(string phone)
    {
        string regex = @"^(\+[0-9]{10})$";

        return Regex.IsMatch(phone, regex, RegexOptions.IgnoreCase);
    }
}
