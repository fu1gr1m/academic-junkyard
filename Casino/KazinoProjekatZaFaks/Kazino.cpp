#include "Kazino.h"


void Kazino::pocetak_igre() {
pocetak:
	Igrac igrac;
	Skor skor;
	Blekdzek blekdzek;
	Pseudorulet rulet;
	Igra kazino;
	string ime_igraca;
	int balans, kolicina;
	cout << "Unesite vase ime: ";
	cin >> ime_igraca;
	cout << "Unesite balans: ";
drugiPoint:
	cin >> balans;
	if (cin.fail() || balans < 0) {
		cin.clear();
		cin.ignore();
		goto drugiPoint;
	}
	igrac.stvaranje_igrac(ime_igraca, balans);
	cout << "======================" << endl;
	cout << "Dobrodosli u Kazino." << endl;
	while (1) {
		int choice_1;
		restart:
		cout << "======================" << endl;
		cout << "Izaberite opciju..." << endl;
		cout << "1. Igrajte Blekdzek." << endl;
		cout << "2. Igrajte Rulet." << endl;
		cout << "3. Povecajte balans." << endl;
		cout << "4. Stanje na racunu." << endl;
		cout << "5. Izlaz." << endl;
		cout << "======================" << endl;
		cin >> choice_1;
		if (cin.fail() || choice_1 > 5 || choice_1 < 1) {
			cin.clear();
			cin.ignore();
			goto restart;
		}
		switch (choice_1) {
		case 1:
			if (igrac.balans > 10 && budzet > 500) {
				blekdzek.pocetak_igre_blekdzek(igrac, skor);
			}
			else {
				cout << "Nemate dovoljno novca da pokrenete ovu igru, ili kazino nema vise novca na raspologanju." << endl;
			}
			break;
		case 2:
			if (igrac.balans > 10 && budzet > 500) {
				rulet.pocetak_igre_pseudorulet(igrac, skor);
			}
			else {
				cout << "Nemate dovoljno novca da pokrenete ovu igru, ili kazino nema vise novca na raspologanju." << endl;
			}
			break;
		case 3:
			cout << "Koliko zelite da uvecate balans?" << endl;
			cin >> kolicina;
			igrac.balans += kolicina;
			cout << "Vas balans sada iznosi " << igrac.balans << endl;
			break;
		case 4:
			cout << "Stanje na vasem racunu je: " << igrac.balans << endl;
			break;
		case 5:
			goto pocetak;
			break;
		
		}
	}
}