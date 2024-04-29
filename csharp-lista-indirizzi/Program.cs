using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Indirizzo> indirizzi = new List<Indirizzo>();

        // Percorso del file CSV
        string filePath = "addresses.csv";

        try
        {
            // Leggi tutte le righe dal file CSV
            string[] lines = File.ReadAllLines(filePath);

            // Ignora l'intestazione
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                // Dividi la riga in colonne utilizzando il separatore tab
                string[] columns = line.Split('\t');

                // Ignora le righe con un numero errato di colonne
                if (columns.Length != 6)
                {
                    Console.WriteLine($"La riga {i + 1} non ha il numero corretto di colonne.");
                    continue;
                }

                // Esegui il trim su ciascuna colonna per rimuovere spazi vuoti
                string name = columns[0].Trim();
                string surname = columns[1].Trim();
                string street = columns[2].Trim();
                string city = columns[3].Trim();
                string province = columns[4].Trim();
                string zip = columns[5].Trim();

                // Ignora le righe con campi vuoti
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                    string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) ||
                    string.IsNullOrWhiteSpace(province) || string.IsNullOrWhiteSpace(zip))
                {
                    Console.WriteLine($"La riga {i + 1} contiene campi vuoti.");
                    continue;
                }

                // Crea un nuovo oggetto Indirizzo e aggiungilo alla lista
                Indirizzo address = new Indirizzo(name, surname, street, city, province, zip);
                indirizzi.Add(address);
            }

            // Stampa gli indirizzi letti dal file
            foreach (Indirizzo address in indirizzi)
            {
                Console.WriteLine(address);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
        }
    }
}

class Indirizzo
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Zip { get; set; }

    public Indirizzo(string name, string surname, string street, string city, string province, string zip)
    {
        Name = name;
        Surname = surname;
        Street = street;
        City = city;
        Province = province;
        Zip = zip;
    }

    public override string ToString()
    {
        return $"{Name} {Surname}, {Street}, {City}, {Province}, {Zip}";
    }
}