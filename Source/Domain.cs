using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Contact
    {
        public string Nom { get; }

        public Option<string> Email { get; }

        public Contact(string nom, Option<string> email)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new Exception("Un contact doit avoir un nom !");
            }

            Nom = nom;
            Email = email;
        }
    }

    public class CarnetDAdresse
    {
        private static readonly IDictionary<string, Contact> Contacts = new Dictionary<string, Contact> {
            { "Tim", new Contact("Tim Cook", Option<string>.Some("tcook@apple.com")) }
          , { "Satya", new Contact("Satya Nadella", Option<string>.Some("s.nadella@microsoft.com")) }
          , { "Denis", new Contact("Denis Ritchie", Option<string>.None()) }
        };

        public static Option<Contact> TrouverContact(string nom)
        {
            Contact contact;
            if (Contacts.TryGetValue(nom, out contact))
            {
                return Option<Contact>.Some(contact);
            }

            return Option<Contact>.None();
        }
    }
}












































/*
public class Contact
    {
        public string Nom { get; }

        public Option<string> Email { get; }

        public Contact(string nom, Option<string> email)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new Exception("Un contact doit avoir un nom !");
            }

            Nom = nom;
            Email = email;
        }
    }

    public class CarnetDAdresse
    {
        private static readonly IDictionary<string, Contact> Contacts = new Dictionary<string, Contact> {
            { "Tim", new Contact("Tim Cook", Option<string>.Some("tcook@apple.com")) }
          , { "Satya", new Contact("Satya Nadella", Option<string>.Some("s.nadella@microsoft.com")) }
          , { "Denis", new Contact("Denis Ritchie", Option<string>.None()) }
        };

        public static Option<Contact> TrouverContact(string nom)
        {
            Contact contact;
            if (Contacts.TryGetValue(nom, out contact))
            {
                return Option<Contact>.Some(contact);
            }

            return Option<Contact>.None();
        }
    }
    */