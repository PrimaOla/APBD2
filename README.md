# APBD2 – System wypożyczania sprzętu

## Opis projektu
Projekt reprezentuje prosty system wypożyczalni sprzętu (laptopy, kamery, projektory) dla użytkowników (studenci, pracownicy).  
Umożliwia rejestrowanie sprzętu, tworzenie wypożyczeń, obsługę zwrotów i naliczanie kar za przetrzymanie sprzętu.

## Instrukcja uruchomienia
1. Skopiuj repozytorium:
   ```bash
   git clone https://github.com/PrimaOla/APBD2.git
2. Przejdź do katalogu projektu:
   cd APBD2/APBD2
3. Zbuduj projekt:
   dotnet build
4. Uruchom projekt:
   dotnet run
5. Program uruchomi konsolowe menu z przykładowymi danymi.

###Decyzje projektowe
Podział klas i plików:
Models – klasy reprezentujące dane: Equipment, User, Rental.
Models/EquipmentTypes – podklasy sprzętu: Laptop, Camera, Projector.
Models/Users – hierarchia użytkowników: Student, Employee.
Services – logika biznesowa: obsługa wypożyczeń, sprzętu, generowanie raportów i ID, polityka kar.
UI – interfejs konsolowy.
Exceptions – własne wyjątki dla reguł biznesowych (np. sprzęt niedostępny).

Kohezja i odpowiedzialność klas
Każda klasa odpowiada za jedną główną funkcjonalność: np. RentalService zarządza tylko wypożyczeniami, EquipmentService tylko sprzętem.
User, Equipment, Rental przechowują tylko dane i podstawowe metody związane z tymi obiektami.
Własne wyjątki (EquipmentNotAvailableException, BusinessRuleException) pozwalają oddzielić logikę błędów od logiki biznesowej.

Coupling i modularność
Moduły komunikują się przez interfejsy publiczne i metody, nie zaglądając do wewnętrznych szczegółów innych klas.
Dzięki podziałowi na Models, Services i UI zmiana w logice wypożyczeń nie wymaga zmian w konsoli ani w modelach danych.

Uzasadnienie podziału
Wybrałam podział na warstwy (Models, Services, UI) aby:
ułatwić rozszerzalność (np. dodanie nowych typów sprzętu lub użytkowników),
zachować czytelność kodu i separację odpowiedzialności,
umożliwić testowanie logiki bez uruchamiania konsoli.
Struktura folderów odpowiada strukturze klas, co ułatwia orientację w projekcie i minimalizuje sprzężenie między modułami.

#### Autor

PrimaOla / Aleksandra Olszewska



