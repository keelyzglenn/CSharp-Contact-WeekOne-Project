using Sytems.Collections.Generic;


namespace Contacts.Objects
{
  public class Contact{
    private string _name;
    private string _address;
    private int _number;
    private int _id;
    private static List<Contact> _instances = new List<Contact>{};

    public Contact(string contactName, string contactAddress, int contactNumber)
    {
      _name = contactName;
      _address = contactAddress;
      _number = contactNumber;
      _instances.Add(this);
      _id = _instances.Count;
    }
// name
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
// address
    public string GetAddress()
    {
      return _address;
    }
    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }
// number
    public int GetNumber()
    {
      return _number;
    }
    public void SetNumber(int newNumber)
    {
      _number = newNumber;
    }
// id
    public int GetId()
    {
      return _id;
    }
// instances
    public static List<Contact> GetAll()
      {
        return _instances;
      }

      public static void ClearAll()
      {
        _instances.Clear();
      }

      public static Contact Find(int searchId)
      {
        return _instances[searchId-1];
      }
  }
}
