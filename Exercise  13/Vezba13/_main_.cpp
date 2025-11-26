#include "funkcije.h"
#include <iostream>
using namespace std;


int main() {
	int choice_1, choice_2, choice_3, choice_4, broj;
	Polinom polinom;
	Sinusoida sinusoida;
	Niz niz;
	while (1) {
		cout << "Nad kojom klasom zelite da izvedete operaciju?" << endl;
		cout << "1. Sinusoida." << endl;
		cout << "2. Polinom." << endl;
		cout << "3. Niz" << endl;
		cout << "4. Izlaz" << endl;
		cin >> choice_1;
		if (choice_1 > 3 || choice_1 < 1) {
			cout << "Izlaz.";
			exit(0);
		}
		switch (choice_1) {
		case 1:
			sinusoida.citanje_parametara_funkcije();
			while (1) {
				cout << "Koju opciju zelite da izvrsite?" << endl;
				cout << "1. Postavljanje parametara sinusoide." << endl;
				cout << "2. Ispisivanje sinusoide." << endl;
				cin >> choice_2;
				if (choice_2 > 2 || choice_2 < 1) {
					cout << "Losa vrednost.";
					exit(0);
				}

				switch (choice_2) {
				case 1:
					sinusoida.citanje_parametara_funkcije();
					break;
				case 2:
					sinusoida.ispisivanje_alg_oblika();
					break;
				}
			}
			break;
		case 2:
			while (1) {
				cout << "Koju opciju zelite da izvrsite?" << endl;
				cout << "1. Dohvatanje reda polinoma." << endl;
				cout << "2. Pristupanje pojedinim koeficijentima." << endl;
				cout << "3. Ispisivanje polinoma." << endl;
				cin >> choice_3;
				if (choice_3 > 3 || choice_3 < 1) {
					cout << "Losa vrednost!";
					exit(0);
				}
				switch (choice_3) {
				case 1:
					cout << "Red polinoma: " << +polinom << endl;
					break;
				case 2:
					cout << "Kojem koeficijentu zelite da pristupite(1-10): ";
					cin >> broj;
					if (broj > 10 || broj < 1) {
						cout << "Losa vrednost!";
						exit(0);
					}
					cout << "Na " << broj << " mestu nalazi se koeficijent: " << polinom[broj] << endl;
					break;
				case 3:
					polinom.ispisivanje_alg_oblika();
					break;
				}

	
			}
			break;
		case 3:
			while (1) {
				cout << "Koju opciju zelite da izvrsite?" << endl;
				cout << "1. Dodavanje funkcije u niz." << endl;
				cout << "2. Zbir svih vrednost u tacki x." << endl;
				cin >> choice_4;
				if (choice_4 > 2 || choice_4 < 1) {
					cout << "Losa vrednost!";
					exit(0);
				}

				switch (choice_4) {
				case 1:
					niz.dodavanje_fje();
					break;
				case 2:
					double broj;
					cout << "Unesite broj za koji zelite da izracunate zbir svih vrednosti: ";
					cin >> broj;
					cout << "Zbir svih vrednost u tacki x: " << niz(broj) << endl;
					break;
				}
			}
			break;
		}
	}
}