using Nancy;
using Contacts.Objects;
using System.Collections.Generic;


namespace Contacts
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };

      Get["/contact/new"] = _ => {
        return View["new_contact.cshtml"];
      };
// uses form button to clear all contacts
      Post["/tamagotchis/cleared"] = _ => {
      Contact.ClearAll();
      return View["contacts_cleared.cshtml"];
    };
    }
  }
}
