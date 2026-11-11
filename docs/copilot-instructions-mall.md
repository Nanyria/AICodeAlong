# Mall: instruktionsfil för Copilot

Copilot läser filen `.github/copilot-instructions.md` i ert repo och följer reglerna i den när den föreslår kod. Det är ett sätt för gruppen att bestämma ramarna för AI:n, på samma sätt som ni bestämmer ramarna för samarbetet i gruppkontraktet.

Kopiera mallen nedan till `.github/copilot-instructions.md` i ert projekt och anpassa den. Jämför sedan svaren från Copilot med och utan filen.

```markdown
# Instruktioner för Copilot

## Projektet
- Blazor-app i .NET med en molnhostad SQL-databas i Azure.
- Vi följer onion-modellen: Domain, Application, Infrastructure och webbprojektet.
- Affärslogik ligger i Application. Databasåtkomst ligger i Infrastructure.
- Razor-komponenter innehåller ingen databaslogik.

## Nivå
- Vi är nybörjare. Håll lösningarna på den nivå vi har gått igenom i kursen.
- Föreslå inga nya bibliotek, mönster eller ramverk utan att fråga först.
- Förklara gärna kort varför du föreslår en lösning.

## Säkerhet
- Skriv aldrig lösenord, nycklar eller connection strings i koden.
- Använd parametrar i alla databasfrågor.

## Stil
- Namn på klasser, metoder och variabler skrivs på engelska.
- Kommentarer och text i gränssnittet skrivs på svenska.
```
