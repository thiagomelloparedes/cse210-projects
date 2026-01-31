using System;

public class Product
{
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    // Properties (encapsulation requirement)
    public string Name { get { return _name; } set { _name = value; } }
    public string ProductId { get { return _productId; } set { _productId = value; } }
    public double PricePerUnit { get { return _pricePerUnit; } set { _pricePerUnit = value; } }
    public int Quantity { get { return _quantity; } set { _quantity = value; } }
}
