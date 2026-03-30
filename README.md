# EntrioX - Sistem za online rezervaciju i prodaju ulaznica

## Uvod

EntrioX je moderna web platforma namijenjena online rezervaciji ulaznica za kulturne, sportske i zabavne manifestacije.  
Cilj projekta je omogućiti korisnicima jednostavniju i bržu rezervaciju ulaznica bez potrebe za fizičkim odlaskom na prodajna mjesta, čime se eliminišu dugi redovi i ograničenja radnog vremena blagajni.  
Sistem je zasnovan na digitalnom principu, gdje se nakon uspješne rezervacije i simulacije plaćanja automatski generiše validna digitalna ulaznica.

## Osnovne funkcionalnosti

Sistem EntrioX omogućava sljedeće ključne funkcionalnosti:

- Pretraga i pregled dostupnih manifestacija (koncerti, utakmice, predstave)
- Detaljan prikaz informacija o svakom događaju
- Interaktivna rezervacija mjesta na tribinama uz uvid u trenutnu zauzetost
- Sistem lojalnosti: Automatski popust od 10% nakon svakih 10 kupljenih karata
- Korištenje kupona za dodatne pogodnosti prilikom kupovine
- Simulacija procesa plaćanja (testnog karaktera za demonstraciju toka)
- Generisanje digitalnih ulaznica nakon potvrđene kupovine
- Korisnički profil s historijom rezervacija, kupljenim kartama i ostvarenim popustima
- Administratorski panel za upravljanje manifestacijama, korisnicima i rezervacijama
- Mogućnost administrativnog otkazivanja rezervacija

## Arhitektura

EntrioX je razvijen kao full-stack aplikacija koristeći moderne tehnologije za osiguranje brzine i sigurnosti.

Tehnologije:

- **.NET 8 / C#** (Backend razvoj - Web API)
- **React** (Frontend razvoj - Korisnički interfejs)
- **Tailwind CSS** 
- **Microsoft SQL Server (MSSQL)** 
- **Entity Framework Core** 
- **JWT (JSON Web Tokens)** (Sigurna autentifikacija i autorizacija po ulogama)

## Grupe korisnika i ovlaštenja

Aplikacija definiše jasna pravila pristupa kroz četiri grupe korisnika:

### Neregistrovani korisnik
- Pregled dostupnih manifestacija i detalja o događajima
- Registracija i prijava na sistem

### Registrovani korisnik (Kupac)
- Rezervacija mjesta na tribinama
- Pregled vlastite historije rezervacija i profila
- Iskorištavanje kupona i ostvarivanje popusta lojalnosti
- Simulacija plaćanja

### Registrovani korisnik (Organizator)
- Kreiranje i uređivanje vlastitih manifestacija
- Pregled rezervacija korisnika za događaje koje organizuje

### Administrator (Admin)
- Potpuni nadzor nad sistemom
- Upravljanje svim korisnicima i svim manifestacijama
- Administrativno otkazivanje bilo koje rezervacije

## Postavljanje i pokretanje

### Preduslovi

Prije pokretanja aplikacije potrebno je imati instalirano:

- .NET SDK (verzija 8.0+)
- Node.js i npm (za React frontend)
- Microsoft SQL Server
- Visual Studio ili VS Code
