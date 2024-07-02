using Spectre.Console;

namespace PhoneBook;

internal class ContactServices
{
    internal static Contact CreateNewContact()
    {
        Contact newContact = new Contact();
        var verificationLoop = true;

        string newName = AnsiConsole.Ask<string>("What's the contacts [green]Name[/]?");
        newContact.Name = newName;

        string newEmail = AnsiConsole.Ask<string>("What's the contacts [green]Email[/]?");
        while (verificationLoop)
        {
            if (Validation.EmailValidation(newEmail))
            {
                newContact.Email = newEmail;
                break;
            }
            newEmail = AnsiConsole.Ask<string>("[red]Wrong Format![/] Try again!");
        }

        string newPhone = AnsiConsole.Ask<string>("What's the contacts [green]Phone Number[/]? [red]Format: +1234567890[/]");

        while (verificationLoop)
        {
            if (Validation.PhoneValidation(newPhone))
            {
                newContact.PhoneNumber = newPhone;
                break;
            }
            newPhone = AnsiConsole.Ask<string>("[red]Wrong Format![/] Try again!");
        }

        return newContact;
    }

    internal static Contact GetContact()
    {
        List<Contact> allContacts = ContactController.ViewAllContacts();
        string[] allChoice = new string[allContacts.Count];
        int count = 0;

        foreach(Contact choice in allContacts)
        {
            allChoice[count] = choice.Name;
            count++;
        }

        var userChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose the contact you want to see.")
                .AddChoices(allChoice));

        var contact = allContacts.SingleOrDefault(x => x.Name == userChoice);
        return contact;
    }

    internal static Contact AlterContact(Contact contact)
    {
        AnsiConsole.MarkupInterpolated($"Current Contact Information\n");
        UserInterface.ShowContact(contact);

        var verificationLoop = true;

        string newName = AnsiConsole.Prompt(
            new TextPrompt<string>("What's the new name? Don't enter anything if you want to keep the current name.").AllowEmpty<string>());
        if (newName.Trim() != "")
        {
            contact.Name = newName;
        }

        string newEmail = AnsiConsole.Prompt(
            new TextPrompt<string>("What's the new Email? Don't enter anything if you want to keep the current Email.").AllowEmpty<string>());
        while (verificationLoop)
        {
            if(newEmail.Trim() == "")
            {
                break;
            }

            if (Validation.EmailValidation(newEmail))
            {
                contact.Email = newEmail;
                break;
            }
            newEmail = AnsiConsole.Prompt(
                new TextPrompt<string>("[red]Wrong Format![/] Try again!").AllowEmpty<string>());
        }

        string newPhone = AnsiConsole.Prompt(
            new TextPrompt<string>("What's the new Phone? Don't enter anything if you want to keep the current Phone.").AllowEmpty<string>());
        while (verificationLoop)
        {
            if (newPhone.Trim() == "")
            {
                break;
            }
            if (Validation.PhoneValidation(newPhone))
            {
                contact.PhoneNumber = newPhone;
                break;
            }
            newPhone = AnsiConsole.Prompt(
                new TextPrompt<string>("[red]Wrong Format![/] Try again!").AllowEmpty<string>());
        }

        return contact;
    }
}
