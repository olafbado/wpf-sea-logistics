# Aplikacja do zarz?dzania logistyk? morsk?

Aplikacja stworzona jest dla firmy dzia?aj?cej w bran?y logistyki morskiej, której struktura organizacyjna dzieli si? na nast?puj?ce dzia?y:

## 1. Zarz?dzanie flot?
Dzia? odpowiedzialny za organizacj? floty oraz zawieranie kontraktów z klientami. Ma dost?p do wszystkich tabel w systemie, ale najwa?niejsze z nich to:
- **Ships** – dane o poszczególnych statkach w flocie,
- **ShipTypes** – klasyfikacja statków wed?ug ich typu i przeznaczenia,
- **Contracts** – informacje o zawieranych kontraktach z klientami dotycz?cymi przewozu towarów.

## 2. Logistyka
Dzia? odpowiedzialny za planowanie tras morskich, zarz?dzanie ?adunkami oraz optymalizacj? tras przewozów. Tabele, do których dzia? ma dost?p, to:
- **Ships** – informacje o statkach, które realizuj? transporty,
- **ShipTypes** – klasyfikacja statków w celu optymalizacji transportu,
- **Ports** – dane o portach, z których statki wyp?ywaj? i do których przybijaj?,
- **Cargos** – szczegó?y dotycz?ce przewo?onych towarów,
- **CargoTypes** – klasyfikacja towarów pod k?tem typu,
- **ShipRoutes** – informacje o trasach morskich, które statki pokonuj?,
- **ShipCargo** – przypisanie towarów do konkretnych statków.

## 3. Dzia? HR
Dzia? odpowiedzialny za rekrutacj?, zarz?dzanie za?og? oraz przypisywanie cz?onków za?ogi do odpowiednich rejsów. Tabele, do których dzia? HR ma dost?p, to:
- **CrewMembers** – dane cz?onków za?ogi (imi?, nazwisko, stopie?, do?wiadczenie),
- **Ranks** – stopnie i stanowiska cz?onków za?ogi,
- **ShipRoutes** – przypisanie za?ogi do odpowiednich tras.

## 4. Dzia? serwisu statków
Dzia? odpowiedzialny za utrzymanie floty w dobrym stanie technicznym, przeprowadzanie konserwacji i napraw statków oraz inspekcji technicznych. Tabele, do których maj? dost?p, to:
- **ShipInspections** – dane dotycz?ce przeprowadzanych inspekcji technicznych statków,
- **ShipMaintenance** – informacje o naprawach i konserwacjach statków,
- **FuelLogs** – rejestracja zu?ycia paliwa przez statki.

## Podsumowanie
Aplikacja umo?liwia efektywne zarz?dzanie flot? statków oraz wszystkimi procesami z ni? zwi?zanymi, takimi jak transport towarów, planowanie tras, rekrutacja za?ogi, a tak?e utrzymanie techniczne statków. Dzi?ki podzia?owi na odpowiednie dzia?y, ka?dy u?ytkownik aplikacji ma dost?p tylko do tych danych, które s? niezb?dne do wykonania jego obowi?zków.
