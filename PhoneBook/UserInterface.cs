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

    internal static void ShowContact(Contact contact)
    {
        var panel = new Panel($@"Id: {contact.Id}
Name: {contact.Name}
Email: {contact.Email}
Phone Number: {contact.PhoneNumber}");
        panel.Header = new PanelHeader("Contact Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press Any Key to Continue");
        Console.ReadKey();
    }
}
