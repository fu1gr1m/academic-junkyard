#include "funkcije.h"
#include <iostream>
#include <cmath>
using namespace std;

int main() {
	while (true) {
		cout << "Unesite broj datuma: ";
		int broj_datuma, broj_datuma_trenutni = 1;
		cin >> broj_datuma;
		if (broj_datuma < 1) {
			cout << "Losa vrednost.";
			break;
		}

		int i = 0;
		datumi** niz = new datumi * [broj_datuma]; 
		while (i < broj_datuma) {
			cout << "Datum " << i + 1 << ":" << endl;
			niz[i] = new datumi();
			niz[i]->citanje();
			i++;
		}

		int j = 0;
		datumi** niz2 = new datumi * [broj_datuma_trenutni];
		while (j < broj_datuma_trenutni) {
			cout << "Uneste interval ispod kog zelite da izbrisete datume iz liste: ";
			niz2[j] = new datumi();
			niz2[j]->citanje();
			break;
		}

		datumi** niz3 = new datumi * [broj_datuma];
		for (int p = 0; p < broj_datuma; p++) {
			if (niz[p]->odredjivanje() > niz2[j]->odredjivanje()) {
				cout << "Datum " << p + 1 << ": " << endl;
				niz[p]->pisanje();
			}
		}

		int min = 10000;
		int b = 0, n = 0;
		for (int p = 0; p < broj_datuma; p++) {
			for (int o = p + 1; o < broj_datuma; o++) {
				if (niz[p]->odredjivanje() > niz2[0]->odredjivanje()) {
					if (niz[o]->odredjivanje() > niz2[0]->odredjivanje()) {
						if (min > abs(niz[p]->odredjivanje() - niz[o]->odredjivanje())) {
							min = abs(niz[p]->odredjivanje() - niz[o]->odredjivanje());
							b = p + 1;
							n = o + 1;
						}
					}
				}
			}
		}

		cout << "Razmak izmedju dva najbliza datuma iznosi " << min << " dana. Izmedju " << b << " i " << n << " datuma." << endl;
		char a;
		cout << "Da li zelite da nastavite sa radom? (D/N):";
		cin >> a;
		if (a == 'N' || a == 'n') {
			cout << "Izlaz";
			break;
		}
		else {
			continue;
		}
	}
}