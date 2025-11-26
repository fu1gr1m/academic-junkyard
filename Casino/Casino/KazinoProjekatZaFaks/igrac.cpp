#include "igrac.h"

void Igrac::stvaranje_igrac(string ime_igraca, int balans_igraca) {
restart:
	id = identifikator++;
	ime = ime_igraca;
	balans = balans_igraca;
}

void Igrac::ispisivanje_igrac() {
	cout << "ID:" << id << ", " << "Ime:" << ime << ", " << "Balans:" << balans << endl;
}