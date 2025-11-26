#pragma once
#include <iostream>
#include <cmath>
#include <cstring>
#include <cstdlib>
#include <ctime>
#include "igrac.h"
#include "Igra.h"
#include "skor.h"
#include "Kazino.h"
using namespace std;

class Pseudorulet {
public:
	int krajnji_ishod = 0;
	bool polja_igrac[36];
	char boja = 'r';
	bool parni_broj = false;

	Pseudorulet() {
		for (int i = 0; i < 36; i++) {
			polja_igrac[i] = false;
		}
	}
	void generisanje_nasumicnog_broja();
	bool da_li_je_paran();
	void odredi_boju();
	void broj_u_nizu(int num);
	void pocetak_igre_pseudorulet(Igrac& igrac, Skor& skor);
	void postavi_ponisti_broj(int index, bool vrednost);
	void postavi_boju(char nova_boja);
	void postavi_paran_broj(bool vrednost);
	void postavi_balans(Igrac& igrac, Skor &skor, bool vrednost);
};