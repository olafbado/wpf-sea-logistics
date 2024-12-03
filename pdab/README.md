# Aplikacja do zarz?dzania logistyk? morsk?

Aplikacja stworzona jest dla firmy dzia?aj?cej w bran?y logistyki morskiej, kt�rej struktura organizacyjna dzieli si? na nast?puj?ce dzia?y:

## 1. Zarz?dzanie flot?
Dzia? odpowiedzialny za organizacj? floty oraz zawieranie kontrakt�w z klientami. Ma dost?p do wszystkich tabel w systemie, ale najwa?niejsze z nich to:
- **Ships** � dane o poszczeg�lnych statkach w flocie,
- **ShipTypes** � klasyfikacja statk�w wed?ug ich typu i przeznaczenia,
- **Contracts** � informacje o zawieranych kontraktach z klientami dotycz?cymi przewozu towar�w.

## 2. Logistyka
Dzia? odpowiedzialny za planowanie tras morskich, zarz?dzanie ?adunkami oraz optymalizacj? tras przewoz�w. Tabele, do kt�rych dzia? ma dost?p, to:
- **Ships** � informacje o statkach, kt�re realizuj? transporty,
- **ShipTypes** � klasyfikacja statk�w w celu optymalizacji transportu,
- **Ports** � dane o portach, z kt�rych statki wyp?ywaj? i do kt�rych przybijaj?,
- **Cargos** � szczeg�?y dotycz?ce przewo?onych towar�w,
- **CargoTypes** � klasyfikacja towar�w pod k?tem typu,
- **ShipRoutes** � informacje o trasach morskich, kt�re statki pokonuj?,
- **ShipCargo** � przypisanie towar�w do konkretnych statk�w.

## 3. Dzia? HR
Dzia? odpowiedzialny za rekrutacj?, zarz?dzanie za?og? oraz przypisywanie cz?onk�w za?ogi do odpowiednich rejs�w. Tabele, do kt�rych dzia? HR ma dost?p, to:
- **CrewMembers** � dane cz?onk�w za?ogi (imi?, nazwisko, stopie?, do?wiadczenie),
- **Ranks** � stopnie i stanowiska cz?onk�w za?ogi,
- **ShipRoutes** � przypisanie za?ogi do odpowiednich tras.

## 4. Dzia? serwisu statk�w
Dzia? odpowiedzialny za utrzymanie floty w dobrym stanie technicznym, przeprowadzanie konserwacji i napraw statk�w oraz inspekcji technicznych. Tabele, do kt�rych maj? dost?p, to:
- **ShipInspections** � dane dotycz?ce przeprowadzanych inspekcji technicznych statk�w,
- **ShipMaintenance** � informacje o naprawach i konserwacjach statk�w,
- **FuelLogs** � rejestracja zu?ycia paliwa przez statki.

## Podsumowanie
Aplikacja umo?liwia efektywne zarz?dzanie flot? statk�w oraz wszystkimi procesami z ni? zwi?zanymi, takimi jak transport towar�w, planowanie tras, rekrutacja za?ogi, a tak?e utrzymanie techniczne statk�w. Dzi?ki podzia?owi na odpowiednie dzia?y, ka?dy u?ytkownik aplikacji ma dost?p tylko do tych danych, kt�re s? niezb?dne do wykonania jego obowi?zk�w.
