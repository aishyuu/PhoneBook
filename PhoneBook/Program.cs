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
}

enum MenuOptions
{
    AddContact,
    DeleteContact,
    UpdateContact,
    ViewAllContacts,
    ViewContact
}