﻿using System.Net.Http.Headers;

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
        throw new NotImplementedException();
    }

    internal static void UpdateContact()
    {
        throw new NotImplementedException();
    }

    internal static void ViewAllContacts()
    {
        throw new NotImplementedException();
    }

    internal static void ViewContact()
    {
        throw new NotImplementedException();
    }
}
