#include "funkcije.h"
#include <iostream>
using namespace std;

int main() {
	int choice_1, choice_2, choice_3, choice_4;
	Niz niz;
	Polinom polinom;
	Veliki decimala_1, decimala_2;
	while (1) {
		cout << "Izaberite klasu nad kojom zelite da izvedete operaciju. " << endl;
		cout << "1. Niz " << endl;
		cout << "2. Polinom " << endl;
		cout << "3. Veliki" << endl;
		cout << "Unesite bilo koji drugi broj za izlaz." << endl;
		cin >> choice_1;
		if (choice_1 < 1 || choice_1 > 3) {
			cout << "Izlaz." << endl;
			break;
		}
		switch (choice_1) {
			case 1:
				while (1) {
					cout << "1. Ispisivanje duzine niza." << endl;
					cout << "2. Prikazivanje elementa na indeksu." << endl;
					cout << "3. Ucitavanje niza." << endl;
					cout << "4. Ispisivanje niza." << endl;
					cout << "Unesite bilo koji drugi broj za izlaz." << endl;;
					cin >> choice_2;
					if (choice_2 < 1 || choice_2 > 4) {
						cout << "Izlaz." << endl;
						exit(0);
					}
					switch (choice_2) {
						case 1:
							cout << "Duzina niza je: " << niz.duzina_niza() << endl;
							break;
						case 2:
							niz.getElement();
							break;
						case 3:
							niz.citanje();
							break;
						case 4:
							niz.ispisivanje();
							break;
					}
				}
			case 2:
				while (1) {
					cout << "1. Izracunavanje P(x)" << endl;
					cout << "2. P1 + P2" << endl;
					cout << "3. P1 * P2" << endl;
					cout << "Unesite bilo koji drugi broj za izlaz." << endl;
					cin >> choice_3;
					if (choice_3 > 3 || choice_3 < 1) {
						cout << "Izlaz." << endl;
						exit(0);
					}
					switch (choice_3) {
						case 1:
							polinom.citanje_koeficijenata();
							cout << "Vrednost: " << polinom.vred_polinom() << endl;
							break;
						case 2:
							cout << "Unesite koeficijent prvog polinoma: " << endl;
							polinom.citanje_koeficijenata();
							polinom.zbir();
							break;
						case 3:
							cout << "Unesite koeficijent prvog polinoma: " << endl;
							polinom.citanje_koeficijenata();
							polinom.proizvod();
							break;
					}
				}
			case 3:
				while (1) {
					cout << "1. Zbir dva cela broja." << endl;
					cout << "2. Proizvod dva cela broja." << endl;
					cout << "3. Da li je a==b." << endl;
					cout << "4. Da li je a<b" << endl;
					cout << "5. Da li je a<=b" << endl;
					cin >> choice_4;
					if (choice_4 > 5 || choice_4 < 1) {
						cout << "Izlaz." << endl;
						exit(0);
					}
					switch (choice_4) {
						case 1:
							cout << "Prvi broj: ";
							decimala_1.citanje_broja();
							cout << "Drugi broj: ";
							decimala_2.citanje_broja();
							decimala_1.zbir_dva(decimala_2);
							break;
						case 2:
							cout << "Prvi broj: ";
							cout << "Prvi broj: ";
							decimala_1.citanje_broja();
							cout << "Drugi broj: ";
							decimala_2.citanje_broja();
							decimala_1.proizvod_dva(decimala_2);
							break;
						case 3:
							cout << "Prvi broj: ";
							decimala_1.citanje_broja();
							cout << "Drugi broj: ";
							decimala_2.citanje_broja();
							if (decimala_1 == decimala_2) {
								cout << "Uneti brojevi su jednaki." << endl;
							}
							else {
								cout << "Uneti brojevi nisu jednaki." << endl;
							}
							break;
						case 4:
							cout << "Prvi broj: ";
							decimala_1.citanje_broja();
							cout << "Drugi broj: ";
							decimala_2.citanje_broja();
							if (decimala_1 < decimala_2) {
								cout << decimala_1.sklopi_broj() << " je manji od " << decimala_2.sklopi_broj() << "." << endl;
							}
							else {
								cout << decimala_1.sklopi_broj() << " je veci od " << decimala_2.sklopi_broj() << "." << endl;
							}
							break;
						case 5:
							cout << "Prvi broj: ";
							decimala_1.citanje_broja();
							cout << "Drugi broj: ";
							decimala_2.citanje_broja();
							if (decimala_1 >= decimala_2) {
								cout << decimala_1.sklopi_broj() << " je veci ili jednak broju " << decimala_2.sklopi_broj() << "." << endl;
							}
							else {
								cout << decimala_1.sklopi_broj() << " je manji ili jednak broju " << decimala_2.sklopi_broj() << "." << endl;
							}
							break;
					}
				}
		}
	}
}
