# ConfigurationSample
Das Projekt zeigt eine alternative möglichen für den StartUp einer Konsolenanwendung mit C# und .NET Core 5.

### Intention
In der Regel wird zumeist eine statische Main Methode für den Start bzw. Einstiegspunkt einer Anwendung verwendet. Dies wird so auch im Template von 
Visual Studio umgesetzt. Weiter erfolgt dann irgendwie ein "Sprung" in die Anwendungsausführun. Dies findet analog mehr oder minder auch in 
Desptopanwendungen häufig Anwendung.

Bei der hier gezeigten Variation handelt sich um keine neue Idee und lässt sich an vielen Stellen im Internet finden. Leider sind die dort 
verwendeten Beispiele zumeißt eher komplex und daher für den absoluten Einstieg etwas ungeeignet. Zudem erschwerrt die englische Sprache ebenso 
den Zugang.

### Umfag
In der hier umgesetzten Variation wird stattdessen eine StartUp Methode als gehosteter Service verwendet. Der Name kann frei gewählt werden, bietet 
sich jedoch auf Grund der Verwendung innerhalb anderer Templates an. 

Das hier umgesetzte Vorgehen hat mehrere Vorteile, u.a. 

* Es findet zum einen ein klarer Übergang vom StartUp hin zur Ausführung statt
* Die Anwendung nach dem Start als Task gekapselt
* Interessante Aspekt wie Dependency Injection (DI) oder aber der Zugriff auf die Konfiguration werden nativ verfügbar

### Umsetzung
Bei der Umsetzung wurde primär auf eine gute Nachvollziehbarkeit, Dokumentation und Einfachheit geachtet, so dass das Projekt gut nachvollzogen und 
als Ausgangspunkt für andere Projekte dienen kann. Daraus folgt natürlich, dass der Code nicht eins zu eins weiterverwendet werden sollte.

