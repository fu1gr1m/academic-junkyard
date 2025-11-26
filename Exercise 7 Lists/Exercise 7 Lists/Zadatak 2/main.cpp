#include "funkcije.h"
#include <iostream>
using namespace std;


int main() {
	int broj;
	int izbor;
	int b;
	cout << "1. Dodaj broj u listu." << endl;
	cout << "2. Uzmi broj iz liste." << endl;
	cout << "3. Ispisi ceo listu." << endl;
	cout << "4. Isprazni ceo listu." << endl;
	cout << "5. Odredjivanje broja elemenata liste. " << endl;
	cout << "6. Citanje liste sa pocetka." << endl;
	cout << "7. Citanje liste sa kraja." << endl;
	cout << "8. Umetanje broja u uredjenu listu." << endl;
	cout << "9. Uklanjanje jednog broja na svakom mestu u listi" << endl;

	while (1) {
		cout << "Izaberi opciju: ";
		cin >> izbor;
		if (izbor > 10 || izbor < 1) {
			cout << "Niste uzeli validnu opciju.";
			break;
		}
		switch (izbor) {
			case 1: {
				cout << "Izberi broj koji zelis ubaciti: ";
				cin >> broj;
				dodaj(broj);
				break;
			}
			case 2: {
				uzmi();
				break;
			}
			case 3: {
				ispis();
				break;
			}
			case 4: {
				praznjenje();
				break;
			}
			case 5: {
				odredjivanje_broja_liste();
				break;
			}
			case 6: {
				citanje_liste_pocetak();
				break;
			}
			case 7: {
				citanje_liste_kraj();
				break;
			}
			case 8: {
				cout << "Koji broj zelite da umetnete: ";
				cin >> broj;
				cout << "Na koje mesto zelite da umetnete: ";
				cin >> b;
				umetanje_broja(broj, b);
				break;
			}
			case 9: {
				cout << "Koji broj zelite da uklonite: ";
				cin >> broj;
				izostavljanje_iz_liste(broj);
				break;
			}
		}
	}



	return 0;
}