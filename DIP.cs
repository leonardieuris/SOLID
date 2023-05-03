/*

Il principio di Dependency Inversion (DIP) afferma che le classi di alto livello non dovrebbero dipendere dalle classi di basso livello, 
ma entrambe dovrebbero dipendere da astrazioni. In C#, questo può essere realizzato attraverso l'uso di interfacce e l'inversione del controllo.

Ecco un esempio di codice in C# che segue il principio DIP:

*/

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class FileLogger : ILogger
{
    private string _logFilePath;

    public FileLogger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void Log(string message)
    {
        // logica per scrivere su file
    }
}

public class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void RegisterUser(string username, string password)
    {
        try
        {
            // logica per registrare l'utente
        }
        catch (Exception ex)
        {
            _logger.Log($"Errore durante la registrazione dell'utente: {ex.Message}");
        }
    }
}


/*

In questo esempio, l'interfaccia ILogger rappresenta un logger generico che ha un metodo Log() per registrare i messaggi. 
La classe ConsoleLogger implementa l'interfaccia ILogger e scrive i messaggi sulla console, mentre la classe FileLogger scrive i messaggi su un file. 
La classe UserService ha bisogno di un logger per registrare eventuali errori durante la registrazione di un utente. 
Tuttavia, invece di dipendere direttamente da una classe di logger specifica, accetta un'istanza di ILogger tramite il costruttore.
 Questo significa che il logger può essere facilmente sostituito con una classe diversa che implementa l'interfaccia ILogger senza modificare la classe UserService. 
In questo modo, la dipendenza tra le classi è invertita e la classe di alto livello UserService non dipende dalle classi di basso livello ConsoleLogger o FileLogger.

*/