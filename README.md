# Tentamen i Clean code och testbar kod

- Datum: 2021-01-21
- Program: C#-utvecklare
- Student: Tommy Karlsson

## Redovisning

- Vad du valt att testa och varför?
Jag valde att testa controllerns returer i form av att listorna sorteras på rätt sätt och att den returnerar ett felmeddelande när den inte kan få tag på en lista.
Detta för att säkerställa funktion ut till användaren.

- Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt?
Jag har valt att dependency injecta en ListSource samt en HttpClient, detta för koden ska vara lite mer löst kopplad och att det i framtiden ska vara enkelt att implementera andra typer av sources i programmet.

- Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?
Den största vinsten är enhetstestningen vilken jag implementerade först.
Jag skrev om så att vi använder oss av linq för det mesta samt implementerade felmeddelande ut till användaren. 
Jag hade också velat lägga in länkarna till de olika listorna som vi hämtar från i appsettings.json. Men tiden räckte tyvärr inte till för detta.
