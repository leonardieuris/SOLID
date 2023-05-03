/*
Il principio di Single Responsibility (SRP) afferma che una classe deve avere una sola responsabilità e dovrebbe essere progettata per avere un solo motivo per essere modificata.
 In C#, questo principio può essere applicato in diversi modi, ad esempio:

Separare la logica di business dalla logica di presentazione:
 Una classe che gestisce la presentazione dell'interfaccia utente non dovrebbe contenere anche la logica di business. 
 Invece, la logica di business dovrebbe essere gestita in una classe separata e richiamata dalla classe di presentazione dell'interfaccia utente.

Suddividere le funzionalità complesse in classi separate: Se una classe gestisce molte funzionalità diverse, 
può essere utile suddividere queste funzionalità in classi separate. Ad esempio, una classe che gestisce il salvataggio dei dati su un database 
potrebbe suddividere queste funzionalità in una classe di connessione al database e una classe di salvataggio dei dati.

Limitare il numero di responsabilità della classe: Una classe dovrebbe essere progettata per gestire solo le funzionalità specifiche per cui è stata creata.
 Ad esempio, una classe che gestisce la gestione degli account utente non dovrebbe contenere anche la logica per la gestione delle sessioni utente o l'accesso ai dati.

Separare le funzionalità di accesso ai dati: Una classe che gestisce l'accesso ai dati dovrebbe essere progettata per avere una sola responsabilità. 
Ad esempio, una classe che gestisce l'accesso ai dati non dovrebbe contenere anche la logica per l'elaborazione dei dati.

Utilizzare l'ereditarietà: In alcuni casi, è possibile utilizzare l'ereditarietà per suddividere le responsabilità di una classe.
 Ad esempio, una classe di connessione al database potrebbe essere ereditata da una classe di salvataggio dei dati per gestire la connessione
  e il salvataggio dei dati in modo separato.
*/


// Classe che gestisce la logica di business per la creazione di un nuovo account utente
public class AccountCreator
{
    private IDataAccess _dataAccess;

    public AccountCreator(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public void CreateAccount(string username, string password)
    {
        // Validazione dei dati dell'account
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Username e password sono obbligatori");
        }

        // Crea un nuovo account
        Account newAccount = new Account(username, password);

        // Salva il nuovo account
        _dataAccess.SaveAccount(newAccount);
    }
}

// Interfaccia che definisce il metodo per l'accesso ai dati
public interface IDataAccess
{
    void SaveAccount(Account account);
}

// Classe che gestisce l'accesso ai dati per l'account utente
public class DataAccess : IDataAccess
{
    public void SaveAccount(Account account)
    {
        // Salva l'account nel database
        // ...
    }
}

// Classe che rappresenta un account utente
public class Account
{
    public string Username { get; set; }
    public string Password { get; set; }

    public Account(string username, string password)
    {
        Username = username;
        Password = password;
    }
}


/*
In questo esempio, la classe AccountCreator gestisce solo la logica di business per la creazione di un nuovo account utente. 
La classe DataAccess gestisce solo l'accesso ai dati per l'account utente e implementa l'interfaccia IDataAccess. 
In questo modo, le responsabilità sono separate tra le due classi e ognuna di esse ha una sola responsabilità.
*/