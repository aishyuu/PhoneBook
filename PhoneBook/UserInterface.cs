using Spectre.Console;

namespace PhoneBook;

internal class UserInterface
{
    internal static void ShowAllContacts(List<Contact> contacts)
    {
        var table = new Table();

        table.AddColumns(new[] { "Id", "Name", "Email", "Phone Number" });

        foreach (var contact in contacts)
        {
            table.AddRow(contact.Id.ToString(), contact.Name, contact.Email, contact.PhoneNumber);
        }

        AnsiConsole.Write(table);
    }
}
