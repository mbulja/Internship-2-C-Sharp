// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
using System;
using System.Threading;
using System.ComponentModel.Design;



List<(int id, DateTime datumIzdavanja, List<(string ime, int kolicina)> proizvodi)> racuni = new List<(int id, DateTime datumIzdavanja, List<(string ime, int kkolicina)> proizvodi)>();
var radnici = new List<(string ime, DateTime datumRodenja)>
           {
               ("Mate Matic",new DateTime(1999,5,1)),
               ("Jure Juric",new DateTime(1958,11,11)),
               ("Ivan Ivic",new DateTime(1985,6,28))
           };





var artikli = new List<(string naziv, int kolicina, double cijena, DateTime rokTrajanja)>
           {
               ("Gusti sok",15,2.5,new DateTime(2023,12,12)),
               ("Cedevita",16,2.6,new DateTime(2024,1,11)),
               ("Coca cola",12,3.0,new DateTime(2024,4,23))
           };






while (true)
{
    Console.WriteLine("1 - Artikli\n2 - Radnici\n3 - Računi\n4 - Statistika\n0 - Izlaz iz aplikacije");
    var izbor = Console.ReadLine();
    switch (izbor)
    {
        case "1":
            Console.WriteLine("1 Artikli\n\t1. Unos artikla\n\t2. Brisanje artikla\n\t3. Uređivanje artikla\n\t4.Ispis\n\t0. Povratak na glavni izbornik");
            var opcija1=Console.ReadLine();
            
            if(opcija1=="1")
            {
                Console.WriteLine("Unesite naziv artikla kojeg želite dodati: ");
                string name = Console.ReadLine();
                Console.WriteLine("Unesite količinu artikla kojeg želite dodati: ");
                int amount = int.Parse(Console.ReadLine());
                Console.WriteLine("Unesite cijenu artikla kojeg želite dodati: ");
                double price = double.Parse(Console.ReadLine());
                Console.WriteLine("Unesite datum isteka (MM/DD/YYYY):");
                DateTime expiryDate;
                DateTime.TryParse(Console.ReadLine(), out expiryDate);

                Console.WriteLine("Zelite li pohraniti promjene? (d/n)?");
                var option = Console.ReadLine();
                do
                {
                    if (option == "d")
                    {
                        var tempTuple = (name, amount, price, expiryDate);
                        artikli.Add(tempTuple);
                        break;
                    }
                    else if (option == "n") 
                    {
                        Console.WriteLine("Odustali ste od promjene");
                        break;
                    }
                        
                    else
                        Console.WriteLine("Pogrešan odabir slova");
                } while (true);
              
            }






            if (opcija1 == "2")
            {
                Console.WriteLine("Odaberite opciju:\n a - Izbrisite element\n Izbrisite sve artikle kojima je prosao rok trajanja - b.\n c- Povratak u glavni izbornik");
                var option = Console.ReadLine();
                if (option == "a")
                {
                    Console.WriteLine("Unesite naziv artikla kojeg želite izbrisati: ");
                    var name = Console.ReadLine();
                    int temp = -1;
                    for (int i = 0; i < artikli.Count; i++)
                    {
                        if (artikli[i].naziv == name)
                        {
                            temp = i;
                            break;
                        }

                    }
                    if (temp == -1)
                    {
                        Console.WriteLine("Taj artikal nije pronaden.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Zelite li spremiti promjene?(d/n)");
                        var option1 = Console.ReadLine();
                        do
                        {
                            if (option1 == "d")
                            {
                                artikli.RemoveAt(temp);
                                Console.WriteLine("Izbrisali ste artikal");
                                break;
                            }
                            else if (option1 == "n")
                            {
                                Console.WriteLine("Odustali ste od brisanja artikala.");
                                break;

                            }
                            else
                                Console.WriteLine("Pogrešan unos slova");
                        } while (true);
                    }

                }
                if (option == "b")
                {
                    Console.WriteLine("Jeste li sigurni da zelite obrisati sve artikle kojima je prosao rok? (d/n)");
                    var option2 = Console.ReadLine();
                    do
                    { 
                    if (option == "d")
                    {
                        for (int i = 0; i < artikli.Count; i++)
                        {
                            TimeSpan DaniDoRoka = artikli[i].rokTrajanja.Subtract(DateTime.Now);
                            if (DaniDoRoka.Days < 0)
                            {
                                artikli.RemoveAt(i);
                            }

                        }
                        Console.WriteLine("Uspješno ste obrisali artikle.");

                        break;

                    }
                    else if (option == "n")
                    {
                        Console.WriteLine("Odustali ste od brisanja artikla.");

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogrešan unos slova.");
                    }
                } while (true) ;
            }
                if (option == "c") 
                { 
                            Console.WriteLine("Povratak u glavni izbornik!");
                Thread.Sleep(1000);
                break;
                }
            }






            if (opcija1 == "3")
            {
                Console.Clear();
                Console.WriteLine("Odaberite opciju:\n a - Uređivanje proizvoda zasebno\n b - poskupljenje ili popust\n c - Povratak u glavni izbornik");
                var opcija3 = Console.ReadLine();
                if (opcija3 == "a")
                {
                    UredivanjeArtikla(artikli);
                    break;
                }
                if (opcija3 == "b")
                {
                    UredivanjeCijene(artikli);
                }
                if (opcija3 == "c")
                { 
                    Console.WriteLine("Povratak u glavni izbornik!");
                Thread.Sleep(1000);
                    
                }


                }


            if(opcija1== "4")
            {
                /*Console.Clear();*/
                Console.WriteLine("1 - Artikli\n\t4. Ispis\n\t\ta. Svih artikala kako su spremljeni\n\t\tb. Svih artikala po nazivu\n\t\tc. Svih artikala po datumu (silazno)\n\t\td. Svih artikala po datumu (uzlazno)");
                var option = Console.ReadLine();
                if(option=="a")
                {
                    Console.WriteLine("Lista svih artikala po redoslijedu spremanja: ");
                    foreach (var item in artikli)
                    {
                        TimeSpan daysUntilExpiry = item.rokTrajanja.Subtract(DateTime.Now);
                        Console.WriteLine($"{item.naziv} ({item.kolicina}) - {item.cijena} - {daysUntilExpiry.Days}");
                    }
                   
                    Thread.Sleep(2000);
                }

                if(option=="b")
                {
                    Console.WriteLine("Lista svih artikala raspoređena po nazivu:");
                    var listSortedByName = artikli.OrderBy(x => x.naziv).ToList();
                    foreach (var item in listSortedByName)
                    {
                        TimeSpan daysUntilExpiry = item.rokTrajanja.Subtract(DateTime.Now);
                        Console.WriteLine($"{item.naziv} ({item.kolicina}) - {item.cijena} - {daysUntilExpiry.Days}");
                    }
                    Thread.Sleep(2000);
                }

                if(option=="c")
                {
                    Console.WriteLine("Lista svih artikala raspoređena po datumu silazno:");
                    List<(string Name, int Amount, double Price, DateTime DateOfExpiry)> listSortedByDescendingDates = artikli;
                    listSortedByDescendingDates.Sort((t1, t2) => t2.DateOfExpiry.CompareTo(t1.DateOfExpiry));
                    foreach (var item in listSortedByDescendingDates)
                    {
                        TimeSpan daysUntilExpiry = item.DateOfExpiry.Subtract(DateTime.Now);
                        Console.WriteLine($"{item.Name} ({item.Amount}) - {item.Price} - {daysUntilExpiry.Days}");
                    }
                    Thread.Sleep(2000);
                }

                if(option=="d")
                {
                    Console.WriteLine("Lista svih artikala raspoređena po datumu uzlazno:");
                    List<(string Name, int Amount, double Price, DateTime DateOfExpiry)> listSortedByAscendingDates = artikli;
                    listSortedByAscendingDates.Sort((t1, t2) => t1.DateOfExpiry.CompareTo(t2.DateOfExpiry));
                    foreach (var item in listSortedByAscendingDates)
                    {
                        TimeSpan daysUntilExpiry = item.DateOfExpiry.Subtract(DateTime.Now);
                        Console.WriteLine($"{item.Name} ({item.Amount}) - {item.Price} - {daysUntilExpiry.Days}");
                    }
                    Console.WriteLine("Pritisnite tipku ENTER za nastavak...");
                    Console.ReadLine();
                }
                if(option=="e")
                {
                    Console.WriteLine("Lista svih artikala raspoređena po količini artikala:");
                    List<(string Name, int Amount, double Price, DateTime DateOfExpiry)> listSortedByAmount = artikli;
                    listSortedByAmount.OrderBy(t1 => t1.Amount);
                    foreach (var item in listSortedByAmount)
                    {
                        TimeSpan daysUntilExpiry = item.DateOfExpiry.Subtract(DateTime.Now);
                        Console.WriteLine($"{item.Name} ({item.Amount}) - {item.Price} - {daysUntilExpiry.Days}");
                    }
                    Console.WriteLine("Pritisnite tipku ENTER za nastavak...");
                    Console.ReadLine();
                }
                if(option=="f")
                {
                    Console.WriteLine("Povratak u glavni izbornik!");
                    Thread.Sleep(1000);
                }
            }
            if (opcija1 == "0")
            {
                Console.WriteLine("Povratak u glavni izbornik!");
                Thread.Sleep(1000);
            }




















            Thread.Sleep(2000);
            Console.Clear();
            continue;







            case "2":
            //Console.Clear();
            Console.WriteLine("2 - Radnici\n\t1. Unos radnika\n\t2. Brisanje radnika\n\t3. Uređivanje radnika\n\t4. Ispis\n\t0. Povratak na glavni izbornik");
            var option4 = Console.ReadLine();


            if (option4 == "1")
            {
                Console.WriteLine("Unesite ime novog radnika:");
                string novoIme = Console.ReadLine();

                Console.WriteLine("Unesite datum rođenja novog radnika (MM/DD/YYYY):");



                if (DateTime.TryParse(Console.ReadLine(), out DateTime datumRodenja))
                {
                    do {
                        Console.WriteLine("Jeste li sigurni da želite dodati novog radnika?(d/n)");
                        var dopustenje = Console.ReadLine();
                        if (dopustenje == "d")
                        {
                            radnici.Add((novoIme, datumRodenja));
                            Console.WriteLine("Novi radnik dodan u listu.");
                            break;
                        }
                        else if ( dopustenje == "n")
                        {
                            Console.WriteLine("Odustali ste od dodavanja novog radnika");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Odabrali ste krivo slovo.");
                        }
                    }while (true) ;
                }

                else
                {
                    Console.WriteLine("Neispravan format datuma. Radnik nije dodan.");
                }
                
               
            }
            if (option4 == "2")
            { 
              // Console.Clear();
            Console.WriteLine("2 - Radnici\n\t2. Brisanje radnika\n\t\ta. Po imenu\n\t\tb. Svi stariji od 65 godina");
            var izbor5 = Console.ReadLine();
 
                if (izbor5 == "a")
                {
                    Console.WriteLine("Unesite ime radnika kojeg želite izbrisati:");
                    string imeZaBrisanje = Console.ReadLine();

                    var radnikZaBrisanje = radnici.FirstOrDefault(r => r.ime.Equals(imeZaBrisanje, StringComparison.OrdinalIgnoreCase));

                    if (radnikZaBrisanje != default)
                    {
                        do
                        {
                            Console.WriteLine("Jeste li sigurni da želite izbrisati radnika?(d/n)");
                            var dopustenje = Console.ReadLine();
                            if (dopustenje == "d")
                            {
                                radnici.Remove(radnikZaBrisanje);
                                Console.WriteLine($"Radnik {imeZaBrisanje} je uspješno izbrisan.");
                                break;
                            }
                            else if (dopustenje == "n")
                            {
                                Console.WriteLine("Odustali ste od brisanja radnika.");
                                break;
                            }
                            else
                                Console.WriteLine("Kriv odabir slova.");

                        } while (true);
                    }
                    else
                    {
                        Console.WriteLine("Nema radnika s unesenim imenom.");
                    }
                }
                else if (izbor5 == "b")
                {
                    var starijiOd65 = radnici.Where(r => DateTime.Now.Year - r.datumRodenja.Year > 65).ToList();

                    if (starijiOd65.Any())
                    {
                        do
                        {
                            Console.WriteLine("Jeste li sigurni da želite izbrisati sve radnike starije od 65 godina?(d/n)");
                            var dopustenje = Console.ReadLine();
                            if (dopustenje == "d")
                            {
                                foreach (var radnik in starijiOd65)
                                {
                                    radnici.Remove(radnik);
                                }
                                Console.WriteLine($"Uspješno izbrisano {starijiOd65.Count} radnika starijih od 65 godina.");
                                break;
                            }
                            else if (dopustenje == "n")
                            {
                                Console.WriteLine("Odustali ste od brisanja svih starijih od 65 godina.");
                                break;
                            }
                            else
                                Console.WriteLine("Kriv odabir slova");
                        } while (true);
                    }

                    else
                    {
                        Console.WriteLine("Nema radnika starijih od 65 godina.");
                    }
                }
                else
                {
                    Console.WriteLine("Nepostojeća opcija.");
                }



            }

            if(option4=="3")
            {

                Console.WriteLine("Unesite ime radnika kojeg želite urediti:");
                string imeZaUrediti = Console.ReadLine();

                var radnikZaUrediti = radnici.FirstOrDefault(r => r.ime.Equals(imeZaUrediti, StringComparison.OrdinalIgnoreCase));

                if (radnikZaUrediti != default)
                {
                    Console.WriteLine("Izaberite opciju za uređivanje za radnika:");
                    Console.WriteLine("a. Promjena imena");
                    Console.WriteLine("b. Promjena datuma rođenja");

                    string odabranaOpcija = Console.ReadLine();

                    if (odabranaOpcija == "a")
                    {
                        Console.WriteLine("Unesite novo ime:");
                        string novoIme = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Jeste li sigurni da želite promijeniti ime radnika?(d\n)");
                            var dopustenje = Console.ReadLine();
                            if (dopustenje == "d")
                            {
                                radnici[radnici.IndexOf(radnikZaUrediti)] = (novoIme, radnikZaUrediti.datumRodenja);
                                Console.WriteLine($"Ime radnika {imeZaUrediti} uspješno promijenjeno u {novoIme}.");
                                break;
                            }
                            else if (dopustenje == "n")
                            {
                                Console.WriteLine("Odustali ste od promjene imena.");
                                break;
                            }
                            else
                                Console.WriteLine("Krivi odabir slova.");

                        } while (true);
                    }
                    else if (odabranaOpcija == "b")
                    {
                        Console.WriteLine("Unesite novi datum rođenja (MM/DD/YYYY):");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime noviDatumRodenja))
                        {
                            do
                            {
                                Console.WriteLine("Jeste li sigurni da želite promijeniti datum rođenja?(d/n)");
                                var dopustenje = Console.ReadLine();
                                if (dopustenje == "d")
                                {
                                    radnici[radnici.IndexOf(radnikZaUrediti)] = (radnikZaUrediti.ime, noviDatumRodenja);
                                    Console.WriteLine($"Datum rođenja za radnika {imeZaUrediti} uspješno promijenjen.");
                                    break;

                                }
                                else if (dopustenje == "n")
                                {
                                    Console.WriteLine("Odustali ste od promijene datuma rođenja.");
                                    break;
                                }
                                else
                                    Console.WriteLine("Kriv unos slova");
                                
                            } while (true);
                        }
                        else
                        {
                            Console.WriteLine("Neispravan format datuma. Promjena nije izvršena.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nepostojeća opcija za uređivanje.");
                    }
                }
                else
                {
                    Console.WriteLine("Nema radnika s unesenim imenom.");
                }

            }
            if (option4 == "4")
            {

                Console.WriteLine("Odaberite opciju za ispis:");
                Console.WriteLine("a) Ispis svih radnika (format: ime - godine)");
                Console.WriteLine("b) Ispis radnika kojima je rođendan u tekućem mjesecu");

                string opcija4 = Console.ReadLine();

                if (opcija4 == "a")
                {
                    Console.WriteLine("Ispis svih radnika (format: ime - godine)");
                    foreach (var radnik in radnici)
                    {
                        int godine = DateTime.Now.Year - radnik.datumRodenja.Year;
                        Console.WriteLine($"{radnik.ime} - {godine} godina");
                    }
                }
                else if (opcija4 == "b")
                {
                    Console.WriteLine("Ispis radnika kojima je rođendan u tekućem mjesecu:");
                    var radniciRodjendan = radnici.Where(r => r.datumRodenja.Month == DateTime.Now.Month);
                    foreach (var radnik in radniciRodjendan)
                    {
                        Console.WriteLine($"{radnik.ime} - {radnik.datumRodenja.Day}.{radnik.datumRodenja.Month}");
                    }
                }
                else
                {
                    Console.WriteLine("Neispravan odabir opcije.");
                }
            }
            Thread.Sleep(2000);
            Console.Clear();
            continue;






        case "3":
           
            int idRacuna = racuni.Count + 1;

            Console.WriteLine("Unos novog računa:");
            var noviRacunProizvodi = new List<(string ime, int kolicina)>();
            double ukupniIznos = 0;

            Console.WriteLine("Dostupni proizvodi:");
            foreach (var artikal in artikli)
            {
                Console.WriteLine($"{artikal.naziv} - Stanje: {artikal.kolicina} - Cijena: {artikal.cijena}");
            }

            while (true)
            {
                Console.WriteLine("Unesite ime proizvoda (ili 'kraj' za završetak unosa):");
                string imeProizvoda = Console.ReadLine();

                if (imeProizvoda.ToLower() == "kraj")
                {
                    break;
                }

                Console.WriteLine("Unesite količinu:");
                int kolicinaProizvoda;
                int.TryParse(Console.ReadLine(), out kolicinaProizvoda);

                var odabraniArtikal = artikli.FirstOrDefault(a => a.naziv.Equals(imeProizvoda, StringComparison.OrdinalIgnoreCase));

                if (odabraniArtikal != default && odabraniArtikal.kolicina >= kolicinaProizvoda)
                {
                    ukupniIznos += odabraniArtikal.cijena * kolicinaProizvoda;
                    noviRacunProizvodi.Add((odabraniArtikal.naziv, kolicinaProizvoda));
                    odabraniArtikal.kolicina -= kolicinaProizvoda;
                }
                else
                {
                    Console.WriteLine("Proizvod nije dostupan ili nema dovoljno na stanju.");
                }
            }

            Console.WriteLine("Želite li potvrditi račun? (d/n)");
            string potvrda = Console.ReadLine();

            if (potvrda.ToLower() == "d")
            {
                var noviRacun = (idRacuna, DateTime.Now, noviRacunProizvodi);
                racuni.Add(noviRacun);

                Console.WriteLine($"Račun {idRacuna} - Datum i vrijeme: {noviRacun.Item2} - Ukupni iznos: {ukupniIznos}");

                idRacuna++;
            }
            else
            {
                Console.WriteLine("Račun nije potvrđen. Vraćanje artikala na stanje.");
                foreach (var proizvod in noviRacunProizvodi)
                {
                    var povratniProizvod = artikli.FirstOrDefault(a => a.naziv.Equals(proizvod.ime, StringComparison.OrdinalIgnoreCase));
                    if (povratniProizvod != default)
                    {
                        povratniProizvod.kolicina += proizvod.kolicina;
                    }
                }
            }

            Console.WriteLine("Odaberite račun po ID-u za prikaz detalja:");
            int odabraniID;
            int.TryParse(Console.ReadLine(), out odabraniID);

            var odabraniRacun = racuni.FirstOrDefault(r => r.id == odabraniID);

            if (odabraniRacun != default)
            {
                Console.WriteLine($"Račun {odabraniRacun.id} - Datum i vrijeme: {odabraniRacun.Item2} - Ukupni iznos: {ukupniIznos}");
                foreach (var proizvod in odabraniRacun.Item3)
                {
                    Console.WriteLine($"{proizvod.ime} - {proizvod.kolicina}");
                }
            }
            else
            {
                Console.WriteLine("Račun nije pronađen.");
            }
           Thread.Sleep(2000);
           Console.Clear();
            continue;







        case "4":
            var sifra = "123"; 
            Console.WriteLine("Unesite šifru za pristup statistici:");
            string unesenaSifra = Console.ReadLine();

            if (unesenaSifra == sifra)
            {
                Console.WriteLine("Odaberite opciju:\n\t1.Ukupan broj artikala u trgovini\n\t2.Vrijednost artikala koji nisu još prodani\n\t\n\t3.Vrijednost svih artikala koji su prodani\n\t4.Stanje po mjesecima");
                var option6 = Console.ReadLine();
                if (option6 == "1")
                {


                    int ukupanBrojArtikala = artikli.Sum(a => a.kolicina);
                    Console.WriteLine($"Ukupan broj artikala u trgovini: {ukupanBrojArtikala}");

                    Thread.Sleep(2000);


                }
                if (option6 == "2")
                {
                    
                    double vrijednostNeprodanihArtikala = artikli.Sum(a => a.kolicina * a.cijena);
                    Console.WriteLine($"Vrijednost artikala koji nisu još prodani: {vrijednostNeprodanihArtikala}");
                    Thread.Sleep(2000);
                }
                if(option6=="3")
                { 
                
                double vrijednostProdanihArtikala = racuni.Sum(r => r.proizvodi.Sum(p => artikli.FirstOrDefault(a => a.naziv.Equals(p.ime, StringComparison.OrdinalIgnoreCase)).cijena * p.kolicina));
                Console.WriteLine($"Vrijednost svih artikala koji su prodani: {vrijednostProdanihArtikala}");
                    Thread.Sleep(2000);
                }
                if(option6=="4")
                {
                    
            Console.WriteLine("Unesite datum i godinu za koji želite izračunati stanje (MM/YYYY):");
                    string unosDatuma = Console.ReadLine();
                    DateTime trazeniDatum;

                    if (DateTime.TryParseExact(unosDatuma, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out trazeniDatum))
                    {
                        
                        var racuniZaMjesec = racuni.Where(r => r.datumIzdavanja.Month == trazeniDatum.Month && r.datumIzdavanja.Year == trazeniDatum.Year).ToList();

                        if (racuniZaMjesec.Any())
                        {
                           
                            double ukupniTroskovi = 0; 
                            double ukupnaZarada = racuniZaMjesec.Sum(r => r.proizvodi.Sum(p => artikli.FirstOrDefault(a => a.naziv.Equals(p.ime, StringComparison.OrdinalIgnoreCase)).cijena * p.kolicina));

                            double netoZarada = ukupnaZarada * (1.0 / 3.0) - ukupniTroskovi; // Formula za izračun neto zarade

                            Console.WriteLine($"Za {trazeniDatum.ToString("MM/yyyy")}:");
                            Console.WriteLine($"Ukupna zarada: {ukupnaZarada}");
                            Console.WriteLine($"Neto zarada: {netoZarada}");
                            Thread.Sleep(2000);
                            
                        }
                        else
                        {
                            Console.WriteLine("Nema računa za taj mjesec.");
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Neispravan unos datuma.");
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("Pogrešna šifra za pristup statistici.");
            }


            Console.Clear();
            continue;







        case "0":
            Console.WriteLine("Izlaz");
            break;


        default:
            Console.WriteLine("Pogresan unos.");
            Thread.Sleep(1000);
            Console.Clear();
            continue;

            
    }
    break;

}

static void UredivanjeArtikla(List<(string naziv, int kolicina, double cijena, DateTime rokTrajanja)> artikli)
{
    Console.WriteLine("Unesite ime proizvode kojeg zelite urediti: ");
    var ime = Console.ReadLine();
    int temp = -1;
    for (int i = 0; i < artikli.Count; i++)
    {
        if (artikli[i].naziv == ime)
        {
            temp = i;
            break;
        }

    }
    if (temp == -1)
    {
        Console.WriteLine("Ne postoji taj proizvod u trgovini.");
        Thread.Sleep(1000);

    }
    else
    {
        Console.WriteLine("Što želite izmjeniti:\n\t1 - Ime artikla\n\t2 - Količina\n\t3 - Cijena\n\t4 - Rok trajanja");
        var option = Console.ReadLine();

        if(option=="1")
        {
            Console.WriteLine("Unesite novi naziv artikla: ");
            var NoviNazivArtikla = Console.ReadLine();
            Console.WriteLine("Želite li pohraniti svoje podatke?(d/n)");
            do
            {
                var izbor = Console.ReadLine();
                if (izbor == "d")
                {
                    (string, int, double, DateTime) tempName = (NoviNazivArtikla, artikli[temp].kolicina, artikli[temp].cijena, artikli[temp].rokTrajanja);
                    artikli[temp] = tempName;
                    Console.WriteLine("Uspješno ste izmijenili ime.");
                    Thread.Sleep(1000);
                    break;

                }
                else if (izbor == "n")
                {
                    Console.WriteLine("Odustali ste od brisanja artikla.");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos slova.");
                }
            } while (true);
            

        }


        if(option=="2")
        {
            Console.WriteLine("Unesite novu kolicinu artikla:");
            int NovaKolicina=int.Parse(Console.ReadLine());
            Console.WriteLine("Želite li spremiti promjene?(d/n)");
            do
            {
                var izbor = Console.ReadLine();
                if(izbor=="d")
                {
                    (string, int, double, DateTime) tempAmount = (artikli[temp].naziv, NovaKolicina, artikli[temp].cijena, artikli[temp].rokTrajanja);
                    artikli[temp] = tempAmount;
                    Console.WriteLine("Uspješno ste izmijenili količinu.");
                    Thread.Sleep(1000);
                    break;
                }
                else if (izbor == "n")
                {
                    Console.WriteLine("Odustali ste od promjene artikla.");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos slova.");
                }

            } while (true);
            
        }




        if(option=="3")
        {
            Console.WriteLine("Unesite novu cijenu artikla:");
            double NovaCijena=double.Parse(Console.ReadLine());
            Console.WriteLine("Želite li spremiti promjene? (d/n)");
            do
            {
                var izbor = Console.ReadLine();
                if (izbor == "d")
                {
                    (string, int, double, DateTime) tempCijena = (artikli[temp].naziv, artikli[temp].kolicina, NovaCijena, artikli[temp].rokTrajanja);
                    artikli[temp] = tempCijena;
                    Console.WriteLine("Uspješno ste izmijenili količinu.");
                    Thread.Sleep(1000);
                    break;
                }
                else if (izbor == "n")
                {
                    Console.WriteLine("Odustali ste od promjene artikla.");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos slova.");
                }

            } while (true);
        }

        if(option=="4")
        {
            Console.WriteLine("Unesite novi datum isteka roka (dd/mm/gggg): ");
            string datum = "dd/MM/yyyy";
            DateTime NoviDatum = DateTime.ParseExact(Console.ReadLine(), datum, null);
            Console.WriteLine("Želite li spremiti promjene? (d/n)");
            do
            {
                var izbor = Console.ReadLine();
                if (izbor == "d")
                {
                    (string, int, double, DateTime) tempDate = (artikli[temp].naziv, artikli[temp].kolicina, artikli[temp].cijena, NoviDatum);
                    artikli[temp] = tempDate;
                    Console.WriteLine("Uspješno ste izmijenili datum roka trajanja.");
                    Thread.Sleep(1000);
                    break;

                }
                else if (izbor == "n")
                {
                    Console.WriteLine("Odustali ste od promjene artikla.");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos slova.");
                }
            } while (true);
        }




    }


}

static void UredivanjeCijene( List<(string naziv, int kolicina, double cijena, DateTime rokTrajanja)> artikli)
{
    Console.WriteLine("Unesite postotak poskupljenja/sniženja cijene (pozitivan broj za poskupljenje, negativan za sniženje):");
    double percentage;
    double.TryParse(Console.ReadLine(), out percentage);
    Console.WriteLine();
    Console.WriteLine("Želite li spremiti promjene? (d/n)");

    do
    {
        var izbor = Console.ReadLine();
        if (izbor == "d")
        {
            if (percentage == 0)
            {
                Console.WriteLine("Nema promjene u cijeni.");
                Thread.Sleep(1000);
            }
            else if (percentage > 0)
            {
                for (int i = 0; i < artikli.Count; i++)
                {
                    double newArticlePrice;
                    newArticlePrice = artikli[i].cijena + artikli[i].cijena * percentage / 100;
                    (string, int, double, DateTime) temp = (artikli[i].naziv, artikli[i].kolicina, newArticlePrice, artikli[i].rokTrajanja);
                    artikli[i] = temp;
                }
                Console.WriteLine($"Cijena je uspješno podignuta za {percentage}%.");
                Thread.Sleep(1000);
            }
            else
            {
                for (int i = 0; i < artikli.Count; i++)
                {
                    double newArticlePrice;
                    newArticlePrice =artikli [i].cijena - artikli[i].cijena * percentage / 100;
                    (string, int, double, DateTime) temp = (artikli[i].naziv, artikli[i].kolicina, newArticlePrice, artikli[i].rokTrajanja);
                    artikli[i] = temp;
                }
                Console.WriteLine($"Cijena je uspješno snižena za {percentage}%.");
                Thread.Sleep(1000);

            }
            break;

        }
        else if (izbor == "n")
        {
            Console.WriteLine("Odustali ste od promjene artikla.");
            Thread.Sleep(1000);
            break;
        }
        else
        {
            Console.WriteLine("Pogrešan unos slova.");
        }
    } while (true);
}




