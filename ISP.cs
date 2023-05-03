/*


Il principio di Interface Segregation (ISP) afferma che le interfacce dovrebbero essere specifiche del contesto e 
separare le responsabilità in modo che le classi che le implementano non siano costrette a implementare metodi che non utilizzano.

Ecco un esempio di codice in C# che segue il principio ISP:

*/

public interface IAnimal
{
    void Eat();
    void Sleep();
}

public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}

public class Dog : IAnimal
{
    public void Eat()
    {
        // logica per mangiare
    }

    public void Sleep()
    {
        // logica per dormire
    }
}

public class Bird : IAnimal, IFlyable
{
    public void Eat()
    {
        // logica per mangiare
    }

    public void Sleep()
    {
        // logica per dormire
    }

    public void Fly()
    {
        // logica per volare
    }
}

public class Fish : IAnimal, ISwimmable
{
    public void Eat()
    {
        // logica per mangiare
    }

    public void Sleep()
    {
        // logica per dormire
    }

    public void Swim()
    {
        // logica per nuotare
    }
}


/*

In questo esempio, ci sono tre interfacce: IAnimal, IFlyable, ISwimmable. 
La classe Dog implementa solo l'interfaccia IAnimal, poiché non ha la capacità di volare o nuotare.
 La classe Bird implementa sia l'interfaccia IAnimal che IFlyable, mentre la classe Fish implementa sia l'interfaccia IAnimal che ISwimmable. 
 In questo modo, ogni classe implementa solo i metodi che sono pertinenti alle sue responsabilità e non viene costretta ad implementare metodi inutili o non pertinenti.

*/