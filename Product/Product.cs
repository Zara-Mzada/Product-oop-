using System.Collections;

namespace Product;

public class Product
{
    string brand, model, category;
    decimal price;
    int quantity;

    ArrayList products;
    
    public Product()
    {
        products = new ArrayList();
    }

    public void Add(string category, string brand, string model, decimal price, int quantity)
    {
        ArrayList product = (new ArrayList() {category, brand, model, price, quantity});
        products.Add(product);
    }

    public ArrayList GetAllProducts()
    {
        return products;
    }

    public void ShowAllProducts()
    {
        int counter = 1;
        foreach (var allProduct in products)
        {
            Console.WriteLine($"PRODUCT {counter}:");
            foreach (var item in (ArrayList)allProduct)
            {
                Console.WriteLine(item);
            }

            counter++;
        }
    }

    public void RemoveProduct(int index)
    {
        products.RemoveAt(index-1);
    }

    public void UpdateProduct(
        int index, 
        string category, string brand, string model,
        decimal price, int quantity)
    {
        products[index - 1] = new ArrayList() {category, brand, model, price, quantity};
    }

    public void UpdateProductByProperty(
        int productID, int propertyID, string newValue)
    {
        ArrayList product = (ArrayList)products[productID - 1];
        var oldValue = product[productID - 1];

        if (oldValue is string)
        {
            product[productID - 1] = newValue;
        }
        else if (oldValue is decimal)
        {
            product[propertyID - 1] = Convert.ToDecimal(newValue);
        }
        else if (oldValue is int)
        {
            product[propertyID - 1] = Convert.ToInt32(newValue);
        }
    }
}


        // [
        //         [category brand model price quantity]
        //         [category brand model price quantity]
        // ]