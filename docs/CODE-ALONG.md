# Code along: fem steg i Copilot

**Dagens regel: kan du inte förklara koden, committar du den inte.**

Vi gör stegen tillsammans. Läraren visar först, sedan gör alla samma sak. Vid varje **Stopp** förklarar du för grannen innan vi går vidare.

## Innan vi börjar

1. Klona repot och starta appen (se [README](../README.md)).
2. Kolla att Copilot är inloggat och att Chat fungerar.
3. Klicka runt i appen: Hem, Bokningar och Ny bokning.

---

## Steg 1. Förstå kodbasen (15 min)

På LIA kommer du in i en kodbas som någon annan har skrivit. Copilot kan hjälpa dig att hitta rätt, men du kontrollerar svaret själv.

Öppna Copilot Chat och fråga om hela projektet. I VS Code skriver du `@workspace` först i frågan. I Visual Studio har Chat tillgång till lösningen du har öppen.

Prova till exempel:

- "Vilka projekt finns i lösningen och hur beror de på varandra?"
- "Var hämtas bokningarna som visas på sidan /bookings?"
- "Varför ligger `IBookingRepository` i Application och inte i Infrastructure?"

**Kontrollera:** öppna filerna Copilot pekar på. Stämmer svaret med koden?

> **Stopp:** förklara för grannen vägen från sidan `/bookings` till datan. Vilka filer passerar den?

---

## Steg 2. Fråga och bygg (20 min)

Nu ska du bygga något själv, med Copilot som lärare. Använd **Ask-läget**, inte Agent.

**Uppgift:** på sidan Bokningar ska man kunna välja ett rum och bara se bokningarna för det rummet.

Gör så här:

1. **Be om en plan, inte kod.** Till exempel: "Hur bygger jag en filtrering per rum på bokningssidan, med lagren vi har? Ge mig stegen, inte färdig kod."
2. **Granska planen.** Hamnar logiken i rätt lager? Är det på kursens nivå, eller överkurs?
3. **Gör ett steg i taget själv.** Fråga när du fastnar.
4. **Fråga varför.** "Varför gör vi så här? Vilka alternativ finns?"
5. **Kolla dokumentationen** för minst en sak, till exempel `InputSelect` på Microsoft Learn.

> **Stopp:** är det överkurs? Kan alla i gruppen förklara varje rad?

### Bra frågor att ställa till Copilot

- "Ge mig stegen, inte koden."
- "Förklara det som för en nybörjare."
- "Vilka alternativ finns, och varför väljer du det här?"
- "Är det här vanligt i Blazor, eller överkurs?"
- "Vad kan gå fel med den här lösningen?"

---

## Steg 3. Felsök (15 min)

Gå till **Ny bokning**, fyll i ett namn och tryck **Boka** utan att ändra rummet. Appen kraschar.

1. **Hitta felmeddelandet.** Det står i terminalen (eller fönstret Output i Visual Studio) där appen körs. Vilken typ av fel är det, och på vilken rad?
2. **Läs det själv först.** Vad tror du att det betyder? Visar Visual Studio någon varning på samma rad?
3. **Be Copilot förklara felet.** Klistra in felmeddelandet, men be om en förklaring, inte en lösning.
4. **Rätta felet** när du förstår orsaken. Tips: felet syns i en fil, men orsaken finns i en annan.
5. Kör testerna med `dotnet test` och kontrollera att de går igenom.

> **Stopp:** vad var orsaken? Var kraschade det, och varför hände det just där? Hur hade du kunnat hitta felet utan AI?

---

## Steg 4. Agent och diffen (15 min)

Nu får Copilot skriva koden åt dig. Jämför med steg 2: när AI skriver koden måste du granska noggrannare.

**Uppgift:** man ska kunna avboka en bokning med en knapp i bokningslistan.

Byt till **Agent-läget** och skriv till exempel:

> "Lägg till möjlighet att avboka en bokning. Det ska finnas en knapp på varje rad på bokningssidan. Följ lagren i projektet och lägg till ett test för avbokningen."

Acceptera inget direkt. **Granska diffen** fil för fil:

- Vilka filer ändrades? Varför just de?
- Hamnar koden i rätt lager?
- Förstår du varje rad?
- Finns det ett test, och testar det rätt sak?
- Gjorde Copilot mer än du bad om?

> **Stopp:** hamnar koden i rätt lager? Skulle du kunna förklara ändringen på en sprint review?

---

## Steg 5. Checklista och commit (10 min)

Gå igenom checklistan innan du committar:

- [ ] Kan alla i gruppen förklara koden?
- [ ] Är det på kursens nivå, eller är det överkurs?
- [ ] Har vi testat koden?
- [ ] Hamnar koden i rätt lager?
- [ ] Finns några nycklar eller connection strings i koden eller prompten?

Skriv commit-meddelandet **själv** först. Jämför sedan med det Copilot föreslår. Vilket är bäst, och varför?

---

## Hela tiden

Completions dyker upp när du skriver. **Läs förslaget innan du trycker Tab.**

## Bonus

Det finns en bugg till i bokningslogiken. Prova att boka två olika rum samma dag. Vad händer?

Skriv ett test som visar felet **innan** du rättar det.

## Om du hamnar efter

Grenen `solution` har ett löst exempel med en commit per steg:

```bash
git log --oneline origin/solution
git checkout solution
```
