/*

Il principio di Liskov Substitution (LSP) afferma che gli oggetti di una classe derivata devono essere utilizzabili al posto degli oggetti della classe base senza introdurre errori 
o comportamenti inaspettati. 
In C#, questo principio può essere applicato attraverso l'ereditarietà e la sostituzione di metodi. Ecco un esempio:

*/


public class Rectangle
{
    public virtual double Width { get; set; }
    public virtual double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public virtual double Area()
    {
        return Width * Height;
    }
}

public class Square : Rectangle
{
    public override double Width 
    {
        get { return base.Width; }
        set { base.Width = base.Height = value; }
    }

    public override double Height 
    {
        get { return base.Height; }
        set { base.Width = base.Height = value; }
    }

    public Square(double sideLength) : base(sideLength, sideLength) { }
}

public class AreaCalculator
{
    public double CalculateArea(Rectangle rectangle)
    {
        return rectangle.Area();
    }
}


/*

In questo esempio, la classe Rectangle rappresenta un rettangolo e implementa il metodo Area(). 
La classe Square eredita da Rectangle e ridefinisce i metodi Width e Height per garantire che siano sempre uguali. 
La classe AreaCalculator accetta un oggetto Rectangle come parametro per il metodo CalculateArea().
 Poiché Square eredita da Rectangle, un oggetto Square può essere passato al posto di un oggetto Rectangle senza introdurre errori o comportamenti inaspettati.
*/