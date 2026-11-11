# Rumsbokning: AI code along

En liten Blazor-app för att boka rum. Den används i passet **AI i systemutveckling: du äger koden**, där vi övar på att använda GitHub Copilot och att granska koden den skriver.

Instruktionerna för passet finns i [docs/CODE-ALONG.md](docs/CODE-ALONG.md).

## Kom igång

Du behöver:

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio eller VS Code med C# Dev Kit
- GitHub Copilot, inloggad i din editor

Klona repot och starta appen:

```bash
git clone https://github.com/Nanyria/AICodeAlong.git
cd AICodeAlong
dotnet run --project AICodeAlong
```

I Visual Studio: öppna `AICodeAlong.slnx`, välj projektet `AICodeAlong` som startprojekt och tryck F5.

Kör testerna:

```bash
dotnet test
```

## Struktur

Appen följer onion-modellen. De inre lagren vet ingenting om de yttre.

| Projekt | Lager | Innehåll |
|---|---|---|
| `AICodeAlong.Domain` | Domän | Entiteterna `Room` och `Booking` |
| `AICodeAlong.Application` | Applikation | Affärslogik (`BookingService`, `RoomService`) och interfaces för repositories |
| `AICodeAlong.Infrastructure` | Infrastruktur | Repositories som sparar datan i minnet, plus exempeldata |
| `AICodeAlong` | Presentation | Blazor-sidorna |
| `AICodeAlong.Tests` | Tester | xUnit-tester för affärslogiken |

Datan sparas i minnet och nollställs när appen startas om. I kursprojektet använder ni en Azure SQL-databas istället, men lagren ser likadana ut.

## Grenar

- `master`: startläget för code along.
- `solution`: ett löst exempel, med en commit per steg. Använd den om du hamnar efter.
