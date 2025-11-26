#include "Igra.h"


void Igra::dodaj_igraca(Igrac* igrac, Skor* skor) {
	igraci[brojigraca] = igrac;
	skorovi[brojigraca] = skor;
	brojigraca++;
}

void Igra::promeni_balans(Igrac* igrac, int kolicina) {
	for (int i = 0; i < brojigraca; i++) {
		if (igraci[i] == igrac) {
			igraci[i]->balans += kolicina;
		}
	}
}

void Igra::promeni_skor_rulet(Igrac* igrac, int kolicina) {
	for (int i = 0; i < brojigraca; i++) {
		if (igraci[i] == igrac) {
			skorovi[i]->rezultat_rulet += kolicina;
		}
	}
}

void Igra::promeni_skor_blekdzek(Igrac* igrac, int kolicina) {
	for (int i = 0; i < brojigraca; i++) {
		if (igraci[i] == igrac) {
			skorovi[i]->rezultat_blekdzek += kolicina;
		}
	}
}
