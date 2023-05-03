/*
Il principio di Open/Closed (OCP) afferma che una classe dovrebbe essere aperta per l'estensione ma chiusa per la modifica. 
In C#, questo principio può essere applicato in diversi modi, ad esempio:

Utilizzare l'ereditarietà per estendere il comportamento della classe: 
Una classe base può essere progettata per essere estesa attraverso l'ereditarietà. In questo modo, 
nuove funzionalità possono essere aggiunte senza dover modificare la classe base. Ecco un esempio:


*/

public abstract class Shape : IShape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area()
    {
        return Width * Height;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

/*
In questo esempio, la classe Shape è progettata per essere estesa attraverso l'ereditarietà. 
La classe Rectangle e la classe Circle ereditano da Shape e implementano il metodo Area(). 
In questo modo, è possibile aggiungere nuove forme geometriche senza dover modificare la classe Shape.
*/

public interface IShipping
{
    double CalculateShippingCost(double weight);
}

public class Product
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public Product(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
}

public class ShippingCalculator
{
    private readonly IShipping _shipping;

    public ShippingCalculator(IShipping shipping)
    {
        _shipping = shipping;
    }

    public double CalculateShippingCost(Product product)
    {
        return _shipping.CalculateShippingCost(product.Weight);
    }
}

public class StandardShipping : IShipping
{
    public double CalculateShippingCost(double weight)
    {
        return weight * 0.05;
    }
}

public class ExpressShipping : IShipping
{
    public double CalculateShippingCost(double weight)
    {
        return weight * 0.1;
    }
}

/*

In questo esempio, la classe ShippingCalculator è progettata per essere estesa attraverso l'implementazione di nuove interfacce. 
La classe StandardShipping e la classe ExpressShipping implementano entrambe l'interfaccia IShipping. 
In questo modo, è possibile aggiungere nuovi metodi di calcolo del costo di spedizione senza dover modificare la classe ShippingCalculator.

*/