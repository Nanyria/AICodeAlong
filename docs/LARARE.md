# Lärarhandledning

Den här filen finns bara på grenen `solution`. Den beskriver vad varje steg ska leda fram till, var felen finns och vad som är bra att lyfta.

Varje steg har en egen commit på `solution`, så du kan visa diffen för ett steg med till exempel `git show <commit>`.

## Innan passet

- Kör igenom alla steg själv dagen innan. Copilot svarar olika varje gång, så öva på vad du gör när den föreslår något oväntat.
- Kontrollera att `dotnet test` går igenom på `master` (ett test).
- Förbered en kort live-demo för steg 1, gärna i VS Code med `@workspace`.

## Steg 1. Förstå kodbasen

Inget ska ändras. Målet är att de hittar vägen:

`Bookings.razor` → `BookingService.GetUpcoming` → `IBookingRepository` → `InMemoryBookingRepository` → `SeedData`

Bra att lyfta:

- Interfacen ligger i Application så att applikationslagret inte beror på infrastrukturen. Det är kärnan i onion-modellen.
- Kontrollerade de svaret i koden, eller litade de på Copilot?

## Steg 2. Fråga och bygg (filtrera per rum)

Lösning: commit "Step 2: filter bookings by room".

- `BookingService.GetUpcoming(int? roomId = null)` filtrerar på rum.
- `Bookings.razor` får en rullista med rum (`RoomService`) som laddar om listan när den ändras.

Bra att lyfta:

- Filtreringen hör hemma i `BookingService`, inte i Razor-komponenten.
- Copilot föreslår ibland LINQ direkt i komponenten, `@bind:after`, eller en helt ny tjänst. Diskutera vad som är överkurs och vad som är rimligt.

## Steg 3. Felsök

Felet uppstår när man bokar utan att ändra rummet i rullistan.

**Symptom:** `NullReferenceException` i `BookingService.Create`, på raden `if (booking.Guests > room.Capacity)`. Visual Studio visar också varningen CS8602 på samma rad.

**Två orsaker:**

1. **I BookingService** kontrolleras kapaciteten innan man kontrollerar att rummet finns. Med ett okänt rum blir `room` null.
2. **I NewBooking.razor** sätts inget förvalt rum. Rullistan *visar* första rummet, men det bundna värdet är fortfarande 0 tills användaren väljer något. Därför blir `RoomId` 0 och rummet hittas inte.

Lösning: commit "Step 3: fix crash when booking without choosing a room". Null-kontrollen flyttas först, sidan förväljer första rummet, och ett test läggs till.

Bra att lyfta:

- Felet syns i en fil, men orsaken finns i en annan. Det är vanligt i riktiga projekt.
- Varningen CS8602 pekade på problemet innan appen ens kördes. Varningar är ledtrådar.
- Om Copilot bara föreslår att flytta null-kontrollen kraschar appen inte längre, men användaren får "Rummet finns inte." trots att ett rum syns i listan. Fråga: är felet löst nu?

## Steg 4. Agent och diffen (avboka)

Lösning: commit "Step 4: cancel a booking".

- `IBookingRepository.Remove` och implementationen i `InMemoryBookingRepository`
- `BookingService.Cancel`
- en knapp per rad i `Bookings.razor`
- två tester, och `Remove` i `FakeBookingRepository`

Agenten gör ofta det här på lite olika sätt. Saker att leta efter i diffen:

- Lade den logik direkt i komponenten och hoppade över tjänsten?
- Ändrade den interfacet men glömde test-fakes, så att testprojektet inte bygger?
- Lade den till saker som ingen bad om, till exempel en bekräftelsedialog, ny styling eller ett nytt paket?
- Testar testet verkligen att bokningen försvann?

## Bonus: dubbelbokning

Kontrollen mot dubbelbokning jämför bara datum, inte rum. Därför går det inte att boka två olika rum samma dag.

Lösning: commit "Bonus: allow different rooms to be booked on the same day". Testerna `Create_SameRoomSameDate_ReturnsError` och `Create_OtherRoomSameDate_Succeeds` skrevs först. Det andra testet misslyckas innan rättningen.

Bra att lyfta: skriv testet som visar felet innan du rättar det. Då vet du att testet faktiskt fångar felet.

## Om någon hamnar efter

De kan checka ut `solution`, eller en commit mitt i, till exempel efter steg 2:

```bash
git log --oneline origin/solution
git checkout <commit>
```
