#include "Blekdzek.h"
void Blekdzek::resetuj() {
	for (int i = 0; i < Broj_karata; i++) {
		spil[i] = i % 13 + 1;
	}
	for (int i = 0; i < 9; i++) {
		ruka[i] = 0;
	}
	random_shuffle(begin(spil), end(spil));
}

int Blekdzek::generisi_broj_1_13() {
	srand(time(nullptr));
	int broj = rand() % 13 + 1;
	return broj;
}

int Blekdzek::vuci_kartu() {
	int broj = generisi_broj_1_13();
	if (broj == 1) {
		if (trenutni_rezultat() < 10) {
			broj = 11;
		}
	}
	for (int i = 0; i < Broj_karata; i++) {
		if(spil[i] == broj){
			spil[i] = 0;
			break;
		}
	}
	return broj;
}

int Blekdzek::vrednost_karte(int karta) {
	if (karta == 1) {
		return 11;
	}
	else if (karta >= 11) {
		return 10;
	}
	else {
		return karta;
	}
}

void Blekdzek::dodaj_ukrajnjirezultat(int vrednostkarte) {
	krajnji_rezultat += vrednostkarte;
}

void Blekdzek::updatespiliruke() {
	int karta = vuci_kartu();
	int brojilac = 0;
	for (int i = 0; i < 52; i++) {
		if (spil[i] == karta) {
			spil[i] = 0;
			break;
		}
	}
	for (int i = 0; i < 9; i++) {
		brojilac++;
		if (ruka[i] == 0) {
			ruka[i] = karta;
			break;
		}
	}

	cout << "Izvukli ste kartu: " << karta << endl;
	cout << "Vase karte: ";
	for (int i = 0; i < brojilac; i++) {
		cout << ruka[i] << " ";
	}
	cout << endl;
}

bool Blekdzek::prekid_igre() {
	if (krajnji_rezultat > 21) {
		return true;
	}
}

int Blekdzek::generisi_broj_15_25() {
	srand(time(nullptr));
	int broj = 15 + rand() % (25 - 15 + 1);
	return broj;
}


int Blekdzek::trenutni_rezultat() {
	int broj = 0;
	for (int i = 0; i < 9; i++) {
		broj += vrednost_karte(ruka[i]);
	}
	return broj;
}

void Blekdzek::pocetak_igre_blekdzek(Igrac& igrac, Skor& skor) {
	cout << "Blekdzek igra." << endl;
	Kazino kazino;
restart:
	resetuj();
	int choice = 0;
	while (choice != 5) {
		char b;
	restart_2:
		cout << "Opcije blekdzeka..." << endl;
		cout << "1. Trenutni rezultat karata u ruci." << endl;
		cout << "2. Vuci novu kartu." << endl;
		cout << "3. Odustani." << endl;
		cout << "4. Vas skor." << endl;
		cout << "5. Izlaz." << endl;
		cin >> choice;
		if (cin.fail() || choice > 5 || choice < 1) {
			cin.clear();
			cin.ignore();
			goto restart_2;
		}
		switch (choice) {
		case 1:
			cout << "Trenutni rezultat karata u ruci vam je: " << trenutni_rezultat() << endl;
			break;
		case 2:
			updatespiliruke();
			if (trenutni_rezultat() > 21) {
				cout << "Izgubili ste. Ukupan broj poena na kartama u ruci vam iznosi: " << trenutni_rezultat() << endl;
				cout << "Balans i skor vam je smanjen za 3." << endl;
				skor.rezultat_blekdzek -= 3;
				igrac.balans -= 3;
				kazino.budzet += 3;
				cout << "Da li zelite da nastavite da igrate? (d/n):";
				cin >> b;
				if (b == 'd') {
					goto restart;
				}
				else {
					return;
				}
			}
			break;
		case 3:
			if (trenutni_rezultat() < generisi_broj_15_25()) {
				cout << "Vas rezultat " << trenutni_rezultat() << " je manji od " << generisi_broj_15_25() << ".";
				cout << "Izgubili ste." << endl;
				cout << "Balans i skor vam je smanjen za 3." << endl;
				skor.rezultat_blekdzek -= 3;
				igrac.balans -= 3;
				kazino.budzet += 3;
				cout << "Da li zelite da nastavite da igrate? (d/n):";
				cin >> b;
				if (b == 'd') {
					goto restart;
				}
				else {
					return;
				}
			}
			else {
				cout << "Vas rezultat " << trenutni_rezultat() << " je isti kao " << generisi_broj_15_25() << ".";
				cout << "Pobedili ste!" << endl;
				cout << "Budzet i skor su vam uvecani za 3." << endl;
				skor.rezultat_blekdzek += 3;
				igrac.balans += 3;
				kazino.budzet -= 3;
				cout << "Da li zelite da nastavite da igrate? (d/n):";
				cin >> b;
				if (b == 'd') {
					goto restart;
				}
				else {
					return;
				}
			}
			break;
		case 4:
			cout << "Vas skor u blekdzeku iznosi: " << skor.rezultat_blekdzek << endl;
			break;
		case 5:
			return;
			break;
		}
		

	}
}

