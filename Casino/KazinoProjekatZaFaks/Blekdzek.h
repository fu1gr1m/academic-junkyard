#pragma once
#include <iostream>
#include <cmath>
#include <cstring>
#include <cstdlib>
#include <ctime>
#include <algorithm>
#include "igrac.h"
#include "skor.h"
#include "Kazino.h"
using namespace std;

class Blekdzek {
public:
	int krajnji_rezultat = 0;
	const int Broj_karata = 52;
	const int broj_po_karti = 4;
	int spil[52];
	int ruka[9];

	Blekdzek() {
		for (int i = 0; i < Broj_karata; i++) {
			spil[i] = i % 13 + 1;
		}
		for (int i = 0; i < 9; i++) {
			ruka[i] = 0;
		}
	}

	void resetuj();
	int generisi_broj_1_13();
	int vuci_kartu();
	int vrednost_karte(int karta);
	void dodaj_ukrajnjirezultat(int vrednostkarte);
	void updatespiliruke();
	bool prekid_igre();
	int generisi_broj_15_25();
	bool uporedjivanje_brojeva();
	void pocetak_igre_blekdzek(Igrac& igrac, Skor& skor);
	int trenutni_rezultat();

};