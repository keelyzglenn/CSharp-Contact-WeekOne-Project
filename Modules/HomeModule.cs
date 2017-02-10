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
// posts the new contact information on its on confirmation page
      Post["/created/contact"] = _ =>{
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-address"], Request.Form["new-number"]);
        return View["created_contact.cshtml", newContact];
      };
// display each individual contact when name is clicked
      Get["/contact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["contact.cshtml", contact];
      };
// uses form button to clear all contacts
      Post["/contacts/cleared"] = _ => {
        Contact.ClearAll();
        return View["contacts_cleared.cshtml"];
      };
// adds search functionality
      Get["/search/contacts"] = _ => {
        return View["search_contacts.cshtml"];
      };
// posts results of search
      Post["/search/result"] = _ => {
        Contact foundContact = Contact.SearchContact(Request.Form["search-contact"]);
        return View["search_results.cshtml", foundContact];
      };
    }
  }
}
