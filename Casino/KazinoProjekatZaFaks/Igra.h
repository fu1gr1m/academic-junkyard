#pragma once
#include <iostream>
#include <cmath>
#include <cstring>
#include "skor.h"
#include "Blekdzek.h"
#include "Pseudorulet.h"
#include "igrac.h"
using namespace std;


class Igra {
public:
	
	Igrac* igraci[100];
	Skor* skorovi[100];
	int brojigraca;
	int budzet = 1000;

	string naziv;
	int max_duz = 30;
	

	Igra() {
		brojigraca = 0;
	}

	void dodaj_igraca(Igrac* igrac, Skor* skor);
	void promeni_balans(Igrac* igrac, int kolicina);
	void promeni_skor_rulet(Igrac* igrac, int kolicina);
	void promeni_skor_blekdzek(Igrac* igrac, int kolicina);

};