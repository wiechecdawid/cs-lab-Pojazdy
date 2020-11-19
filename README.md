# Lab. Pojazdy - złożona hierarchia klas i interfejsów

* Autor: _Krzysztof Molenda_
* Wersja: 1.1 (2019.11.02)

## Opis problemu

Celem zadania jest powtórka materiału z zakresu modelowania i programowania obiektowego.

Wykonując to zadanie musisz podjąć samodzielnie decyzje projektowe i implementacyjne. Jeśli coś nie zostało sprecyzowane, przyjmij własne założenia.

---

Rozważ system o następujących własnościach i funkcjonalnościach:

1. Pojazd
    * Pojazd - pojęcie ogólne, immanentną cechą pojazdu jest to, iż się on porusza.
    * Pojazd może być w dwóch stanach - poruszać się lub stać.
    * Jeśli pojazd porusza się, to z ustaloną szybkością, w zakresie _min_ ... _max_ dla danego środowiska.

2. Pojazd porusza się w określonym środowisku: lądowym, wodnym lub w powietrzu.
    * Poruszając się po lądzie, szybkość mierzymy w km/h. Minimalna szybkość wynosi 1 km/h, maksymalna nieprzekraczalna wynosi 350 km/h.
    * Poruszając się po wodzie, szybkość zwyczajowo mierzymy w węzłach (knot) (1 knot = mila morska na godzinę). Minimalna szybkość wynosi 1 węzeł, maksymalna 40 węzłów.
    * Poruszając się w powietrzu, szybkość podajemy w metrach na sekundę. Przyjmijmy, że minimalna szybkość w tym środowisku wynosi 20 m/s, a maksymalna 200 m/s.
    * Niektóre pojazdy mogą poruszać się różnych środowiskach - oczywiście w danym momencie tylko w jednym (np. amfibia - po wodzie i po lądzie, np. samolot - w chwili startu lub kołowania - po lądzie, później w powietrzu).

3. W danym momencie pojazd porusza się z aktualną szybkością. Pojazd można uruchomić lub zatrzymać, można przyspieszyć o zadaną wartość lub zmniejszyć aktualną szybkość o zadaną wartość (oczywiście skokowo). Ale nie można przekroczyć wartości granicznych. Wartości zwiększenia/zmniejszenia szybkości podawane są w natywnych jednostkach dla określonego typu pojazdu.

4. Pojazd może być silnikowy. Silnik ma parametry: moc wyrażoną w koniach mechanicznych (KM) oraz typ paliwa (benzyna, olej, LPG, prąd, ...).

5. Przykłady pojazdów:
    * samochód, motocykl, rower, hulajnoga, amfibia, deska elektryczna, poduszkowiec, ...
    * amfibia, statek, łódź podwodna, motorówka, kajak, poduszkowiec, ...
    * samolot, helikopter lotnia, szybowiec, ...

6. Przyjmujemy, że pojazd poruszający się po lądzie wyposażony jest w koła. Parametrem pojazdu lądowego jest liczba kół.

7. Przyjmujemy, że cechą charakterystyczną pojazdu wodnego jest jego wyporność.

8. Przyjmujemy, że pojazd silnikowy poruszający się po wodzie jest zawsze napędzany olejem.

9. Przyjmujemy, że dla pojazdów poruszających się w różnych środowiskach:
    * nie można zatrzymać pojazdu powietrznego, jeśli jest w powietrzu. Można go zatrzymać, gdy jest na lądzie (nie zakładamy katastrofy),
    * pojazd powietrzny z środowiska lądowego do powietrznego przechodzi przy aktualnej szybkości nie mniejszej niż minimalna dla środowiska powietrznego (bierzemy pod uwagę przyspieszanie),
    * pojazd powietrzny z środowiska powietrznego do lądowego przechodzi przy aktualnej szybkości równej minimalnej dla środowiska powietrznego (bierzemy pod uwagę zwalnianie),
    * pojazdy lądowe i wodne można zatrzymać przy dowolnej aktualnej szybkości,
    * pojazd wodny ze środowiska wodnego przechodzi do środowiska lądowego płynnie - i na odwrót również.

## Zalecenia projektowe

1. Zaimplementuj system wzajemnie powiązanych klas i interfejsów spełniających podane założenia, ale tak, aby system był 'maksymalnie otwarty' na przyszłą rozbudowę (dziedziczenie, implementacje interfejsów) oraz maksymalnie hermetyczny (udostępniamy tylko to, co należy i wtedy, kiedy należy). Zastosuj mechanizmy C# 8 w zakresie interfejsów z domyślnymi implementacjami metod.

2. Do dyspozycji masz mechanizmy programowania obiektowego: klasa, klasa abstrakcyjna, interfejs, enkapsulacja (private, protected, public), properties (również autoproperties), dziedziczenie, polimorfizm, przesłanianie, przeciążanie, ...

    * Zadanie zrealizuj tak, aby maksymalnie wykorzystać mechanizmy obiektowości i zminimalizować ilość kodu. Spróbuj wykonać zadanie, używając nowych konstrukcji języka C# 8 (domyślna implementacja metod interfejsu).

    * Przy realizacji zadania możesz posłużyć się wizualizacją graficzną w Visual Studio 2017/2019 Enterprise ([Class Diagram](https://msdn.microsoft.com/en-us/library/hyxd8c85.aspx)).

3. W klasach zaimplementuj przeciążoną metodę `ToString()` wypisującą wszystkie parametry danego obiektu:
    * aktualny typ obiektu (w sensie typu danych) i rodzaj (lądowy, wodny, powietrzny, a może wielorodzajowy),
    * aktualne środowisko, w którym się porusza,
    * aktualny stan: czy porusza się czy nie,
    * minimalna i maksymalna szybkość w tym stanie,
    * aktualna szybkość poruszania się,
    * dodatkowe informacje, jeśli są przypisane do obiektu (tzn. czy silnikowy; liczba kół, jeśli pojazd lądowy; wyporność, jeśli pojazd wodny, ...).

4. Przetestuj działanie swojego systemu klas w aplikacji konsolowej, w funkcji `Main`. Utwórz konkretne klasy (samochód, motorówka, amfibia, samolot, rower, ...) i instancje tych klas. Wywołaj `ToString` - zobacz, jakie informacje są wyświetlane na ich temat.

5. W klasie reprezentującej pojazd dostarcz statyczną metodę konwertującą szybkości z jednego systemu zapisu na inny.

6. Utwórz listę pojazdów (różnego typu). Zasymuluj ich poruszanie się w różnych środowiskach i z różnymi szybkościami.
    * Wypisz jej zawartość w kolejności oryginalnej (dodawania do listy).
    * Wypisz tylko pojazdy lądowe.
    * Posortuj listę rosnąco ze względu na aktualną szybkość poruszania się (uwaga: musisz przeliczyć jednostki).
    * Wypisz pojazdy poruszające się aktualnie w środowisku lądowym, od aktualnie najszybciej poruszającego się do najwolniejszego.
