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

- "Which projects are in the solution, and how do they depend on each other?"
- "Where does the data shown on the /bookings page come from?"
- "Why is `IBookingRepository` in Application and not in Infrastructure?"

**Kontrollera:** öppna filerna Copilot pekar på. Stämmer svaret med koden?

> **Stopp:** förklara för grannen vägen från sidan `/bookings` till datan. Vilka filer passerar den?

---

## Steg 2. Fråga och bygg (20 min)

Nu ska du bygga något själv, med Copilot som lärare. Använd **Ask-läget**, inte Agent.

**Uppgift:** på sidan Bokningar ska man kunna välja ett rum och bara se bokningarna för det rummet.

Gör så här:

1. **Be om en plan, inte kod.** Till exempel: "How do I build a room filter on the bookings page, following the layers we have? Give me the steps, not finished code."
2. **Granska planen.** Hamnar logiken i rätt lager? Är det på kursens nivå, eller överkurs?
3. **Gör ett steg i taget själv.** Fråga när du fastnar.
4. **Fråga varför.** "Why do we do it this way? What are the alternatives?"
5. **Kolla dokumentationen** för minst en sak, till exempel `InputSelect` på Microsoft Learn.

> **Stopp:** är det överkurs? Kan alla i gruppen förklara varje rad?

### Bra frågor att ställa till Copilot

- "Give me the steps, not the code."
- "Explain it like I'm a beginner."
- "What are the alternatives, and why did you choose this one?"
- "Is this a common way to do it in Blazor, or too advanced for a beginner?"
- "What could go wrong with this solution?"

---

## Steg 3. Felsök (15 min)

Starta appen med **F5** i Visual Studio. Gå till **Ny bokning**, fyll i ett namn och tryck **Boka** utan att ändra rummet. Appen kraschar och debuggern stannar på raden med felet.

1. **Läs felet själv först, utan Copilot.** Vilken typ av fel är det, och på vilken rad? Visar Visual Studio någon varning på samma rad?
2. **Skriv ner en gissning tillsammans med grannen.** Vilket värde är null, och varför?
3. **Fråga Copilot.** Klicka på **Analyze with Copilot** i rutan med felet. Jämför svaret med er gissning.
4. **Kontrollera det Copilot påstår.** Håll musen över värdena i debuggern. Stämmer det Copilot säger?
5. **Välj rättning.** Copilot kan föreslå flera sätt att rätta felet. Välj inte direkt. Diskutera vad som händer med varje alternativ, och om ett räcker eller om det behövs fler.
6. Kör testerna med `dotnet test` och kontrollera att de går igenom.

Tips: felet syns i en fil, men orsaken finns i en annan.

> **Stopp:** var kraschade det, och varför hände det just där? Vilken rättning valde ni, och varför räcker inte bara en av dem?

Kör du appen med `dotnet run` istället för F5 står felet i terminalen. Klistra då in felmeddelandet i Copilot Chat och be om en förklaring, inte en lösning.

---

## Steg 4. Agent och diffen (15 min)

Nu får Copilot skriva koden åt dig. Jämför med steg 2: när AI skriver koden måste du granska noggrannare.

**Uppgift:** man ska kunna avboka en bokning med en knapp i bokningslistan.

Byt till **Agent-läget** och skriv till exempel:

> "Add a way to cancel a booking. There should be a button on each row of the bookings page. Follow the layers in the project and add a test for cancelling."

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
