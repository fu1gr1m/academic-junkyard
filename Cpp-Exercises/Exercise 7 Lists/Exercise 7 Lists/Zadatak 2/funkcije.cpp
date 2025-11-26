#include "funkcije.h"
#include <iostream>
using namespace std;
Elem* brojilac = nullptr;

void dodaj(int broj){
	Elem* novi = (Elem*)malloc(sizeof(Elem));
	novi->br = broj;
	novi->sled = brojilac;
	brojilac = novi;
}
void uzmi() {
	if (brojilac == nullptr) {
		cout << "Stek nema elemente" << endl;	
	}
	else {
		cout << "Uzeti element je: " << brojilac->br << endl;
		brojilac = brojilac->sled;
	}
}
void ispis(){
	if (brojilac == nullptr) {
		cout << "Stek je prazan.";
	}
	else {
		for (Elem* ptr = brojilac; ptr; ptr = ptr->sled)
			cout << ptr->br << " ";
	}
	cout << endl;
}


void praznjenje(){
	while (brojilac) {
		Elem* stari = brojilac;
		brojilac = brojilac->sled;
		delete stari;
	}
	brojilac = nullptr;
	cout << "Stek je ispraznjen.";
}

void odredjivanje_broja_liste() {
	Elem* ptr;
	int counter = 0;
	if (brojilac == nullptr) {
		cout << "Stek je prazan.";
	}
	else {
		ptr = brojilac;
		while (ptr != nullptr) {
			counter += 1;
			ptr = ptr->sled;
		}
		cout << "Broj elemenata liste: " << counter;
	}
	
	cout << endl;
}

void citanje_liste_pocetak() {
	int broj;
	int n;
	cout << "Koliko elemenata zelite da unesete na pocetak liste (max 10): ";
	cin >> n;
	if (n > 10 || n < 0) {
		cout << "Niste uneli validan broj elemenata!";
	}
	else {
		for (int i = 0; i < n; i++) {
			cout << i + 1 << ".Element: ";
			cin >> broj;
			Elem* novi = new Elem();
			novi->br = broj;
			novi->sled = brojilac;
			novi->pret = nullptr;
			if (brojilac != nullptr) {
				brojilac->pret = novi;
			}
			brojilac = novi;
		}
	}
}

void citanje_liste_kraj() {
	int broj;
	int n;

	cout << "Koliko elemenata zelite da unesete na kraj liste (max 10): ";
	cin >> n;
	if (n > 10 || n < 0) {
		cout << "Niste uneli validan broj elemenata!";
	}
	else {
		for (int i = 0; i < n; i++) {
			cout << i + 1 << ".Element: ";
			cin >> broj;
			Elem* novi = new Elem();
			novi->br = broj;
			novi->sled = nullptr;
			if (!brojilac) {
				brojilac = novi;
			}
			else {
				Elem* ptr = brojilac;
				while (ptr->sled) {
					ptr = ptr->sled;
				}
				ptr->sled = novi;
				novi->pret = ptr;
			}
		}
	}
}

void umetanje_broja(int n, int b) {
	Elem* tek = brojilac;
	Elem* novi = new Elem();
	novi->br = n;
	novi->sled = nullptr;
	novi->pret = nullptr;
	if (b == 1) {
		novi->sled = brojilac;
		brojilac->pret = novi;
		brojilac = novi;
	}
	else {
		if (tek == nullptr)
			cout << "Lista je prazna." << endl;
		else {
			for (int i = 1; i < b - 1; i++)
				tek = tek->sled;
		}
		novi->sled = tek->sled;
		novi->pret = tek;
		tek->sled = novi;
	}
}

void izostavljanje_iz_liste(int n) {
	Elem* tek = brojilac, * stari, * prosli = nullptr;
	while (tek) {
		if (tek->br != n) {
			prosli = tek;
			tek = tek->sled;
		}
		else {
			stari = tek;
			tek = tek->sled;
			if (!prosli)
				brojilac = tek;
			else
				prosli->sled = tek;
			delete stari;
		}
	}
}
