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
            ProductController.AddContact();
            break;
        case MenuOptions.DeleteContact:
            ProductController.DeleteContact();
            break;
        case MenuOptions.UpdateContact:
            ProductController.UpdateContact();
            break;
        case MenuOptions.ViewAllContacts:
            ProductController.ViewAllContacts();
            break;
        case MenuOptions.ViewContact:
            ProductController.ViewContact();
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