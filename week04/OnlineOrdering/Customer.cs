using System;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    // Properties (encapsulation requirement)
    public string Name { get { return _name; } set { _name = value; } }
    public Address Address { get { return _address; } set { _address = value; } }
}
