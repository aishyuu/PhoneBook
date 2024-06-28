using PhoneBook;
using Spectre.Console;

var programRunning = true;

while (programRunning)
{
    var mainMenuResponse = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
        .Title("Select an Action")
        .AddChoices(
            MenuOptions.AddContact,
            MenuOptions.DeleteContact,
            MenuOptions.UpdateContact,
            MenuOptions.ViewAllContacts,
            MenuOptions.ViewContact));

    switch(mainMenuResponse)
    {
        case MenuOptions.AddContact:
            Contact newContact = ContactServices.CreateNewContact();
            ContactController.AddContact(newContact);
            break;
        case MenuOptions.DeleteContact:
            ContactController.DeleteContact();
            break;
        case MenuOptions.UpdateContact:
            ContactController.UpdateContact();
            break;
        case MenuOptions.ViewAllContacts:
            List<Contact> allContacts = ContactController.ViewAllContacts();
            UserInterface.ShowAllContacts(allContacts);
            break;
        case MenuOptions.ViewContact:
            Contact chosenContact = ContactServices.GetContact();
            UserInterface.ShowContact(chosenContact);
            break;
    }
}

enum MenuOptions
{
    AddContact,
    DeleteContact,
    UpdateContact,
    ViewAllContacts,
    ViewContact
}