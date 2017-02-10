using Nancy;
using Contacts.Objects;
using System.Collections.Generic;


namespace Contacts
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
// displays index with all contacts including new ones
      Get["/"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
// displays the new contact page
      Get["/contact/new"] = _ => {
        return View["new_contact.cshtml"];
      };
// posts the new contact information on the index page
      Post["/"] = _ =>{
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-address"], Request.Form["new-number"]);
        List<Contact> allContacts = Contacts.GetAll();
        return View["index.cshtml", allContacts];
      };
// display each individual contact when name is clicked
      Get["/contact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["contact.cshtml", contact];
      };

// uses form button to clear all contacts
      Post["/tamagotchis/cleared"] = _ => {
      Contact.ClearAll();
      return View["contacts_cleared.cshtml"];
    };
    }
  }
}
