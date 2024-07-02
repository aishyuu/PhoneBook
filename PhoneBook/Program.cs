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
            Contact contactToUpdate = ContactServices.GetContact();
            contactToUpdate = ContactServices.AlterContact(contactToUpdate);
            ContactController.UpdateContact(contactToUpdate);
            break;
        case MenuOptions.ViewAllContacts:
            List<Contact> allContacts = ContactController.ViewAllContacts();
            UserInterface.ShowAllContacts(allContacts);
            break;
        case MenuOptions.ViewContact:
            ContactController.ViewContact();
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