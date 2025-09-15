using System;
using System.Collections.Generic;
using System.Linq;

class Contatto
{
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{Nome} | Tel: {Telefono} | Email: {Email}";
    }
}

class Program
{
    static List<Contatto> rubrica = new();

    static void Main()
    {
        bool esci = false;
        while (!esci)
        {
            Console.Clear();
            Console.WriteLine(" RUBRICA ");
            Console.WriteLine("1) Aggiungi contatto");
            Console.WriteLine("2) Visualizza tutti i contatti");
            Console.WriteLine("3) Cerca contatto per nome");
            Console.WriteLine("4) Elimina contatto");
            Console.WriteLine("5) Esci");
            Console.Write("Scelta: ");

            switch (Console.ReadLine())
            {
                case "1": AggiungiContatto(); break;
                case "2": VisualizzaContatti(); break;
                case "3": CercaContatto(); break;
                case "4": EliminaContatto(); break;
                case "5": esci = true; break;
                default: Console.WriteLine("Scelta non valida! Premi un tasto"); Console.ReadKey(); break;
            }
        }
    }

    static void AggiungiContatto()
    {
        Console.Clear();
        Console.WriteLine(" Aggiungi Contatto ");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Telefono: ");
        string telefono = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        rubrica.Add(new Contatto { Nome = nome, Telefono = telefono, Email = email });

        Console.WriteLine("Contatto aggiunto! Premi un tasto per continuare...");
        Console.ReadKey();
    }

    static void VisualizzaContatti()
    {
        Console.Clear();
        Console.WriteLine(" Lista Contatti ");
        if (rubrica.Count == 0)
        {
            Console.WriteLine("Rubrica vuota!");
        }
        else
        {
            foreach (var c in rubrica)
                Console.WriteLine(c);
        }
        Console.ReadKey();
    }

    static void CercaContatto()
    {
        Console.Clear();
        Console.WriteLine(" Cerca Contatto ");
        Console.Write("Inserisci nome da cercare: ");
        string nome = Console.ReadLine();

        //Cerca nella rubrica un contatto con il nome inserito ignorando le lettere maiuscole convertendo la variabile in una lista
        var risultati = rubrica.Where(c => c.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList(); 

        if (risultati.Count == 0)
            Console.WriteLine("Nessun contatto trovato");
        else
            risultati.ForEach(c => Console.WriteLine(c)); 
        Console.ReadKey();
    }

    static void EliminaContatto()
    {
        Console.Clear();
        Console.WriteLine("Elimina Contatto");
        Console.Write("Inserisci nome del contatto da eliminare: ");
        string nome = Console.ReadLine();

        //Cerca nella rubrica il nome del contatto da eliminare ignorando le lettere maiuscole
        var daEliminare = rubrica.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (daEliminare == null)
        {
            Console.WriteLine("Contatto non trovato!");
        }
        else
        {
            rubrica.Remove(daEliminare);
            Console.WriteLine("Contatto eliminato!");
        }

        Console.ReadKey();
    }
}
