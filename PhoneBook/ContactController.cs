using System.Net.Http.Headers;

namespace PhoneBook;

internal class ContactController
{
    internal static void AddContact(Contact newContact)
    {
        using var db = new ContactContext();
        db.Add(new Contact { Name = newContact.Name, Email = newContact.Email, PhoneNumber = newContact.PhoneNumber });
        db.SaveChanges();
    }

    internal static void DeleteContact()
    {
        using var db = new ContactContext();
        Contact contactToDelete = ContactServices.GetContact();

        db.Remove(contactToDelete);
        db.SaveChanges();
    }

    internal static void UpdateContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Update(contact);
        db.SaveChanges();
    }

    internal static List<Contact> ViewAllContacts()
    {
        using var db = new ContactContext();
        var contacts = db.Contacts.ToList<Contact>();

        return contacts;
    }

    internal static void ViewContact()
    {
        Contact chosenContact = ContactServices.GetContact();
        UserInterface.ShowContact(chosenContact);
    }
}
