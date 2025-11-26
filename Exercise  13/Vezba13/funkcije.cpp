#include "funkcije.h"
void Funkcija::citanje_parametara_funkcije() {};
void Funkcija::ispisivanje_alg_oblika() {};
double Funkcija::realna_vrednost_x(double x) {
	return 0;
}

void Polinom::ispisivanje_polinoma() {
	for (int i = red - 1; i >= 0; i--) {
		cout << koeficijenti[i] << " ";
	}
}

double Polinom::realna_vrednost_x(double x) {
	double ukupno = 0;
	for (int i = red - 1; i > 0; i--) {
		ukupno += koeficijenti[i] * pow(x, i + 1);
	}
	return ukupno;
}

int Polinom:: operator+()const {
	return red;
}
int Polinom:: operator[](int i)const {
	return koeficijenti[i];
}

void Sinusoida::citanje_parametara_funkcije() {
	cout << "Unesite a: ";
	cin >> a;
	cout << "Unesite b: ";
	cin >> b;
	cout << "Unesite c: ";
	cin >> c;
}

double Sinusoida::realna_vrednost_x(double x) {
	double p;
	p = a * sin(b * x + c);
	return p;
}

void Niz::dodavanje_fje() {
	int a, b;
	cout << "Na koje mesto dodajete funkciju [1-5]?: ";
	cin >> a;
	if (a > 5 || a < 1) {
		cout << "Losa vrednost!";
		exit(0);
	}

	cout << "Koju funkciju bi zeleli da dodate?" << endl;
	cout << "1. Polinom" << endl;
	cout << "2. Sinusoida" << endl;
	cin >> b;
	if (b > 2 || b < 1) {
		cout << "Losa vrednost!";
		exit(0);
	}

	switch (b) {
	case 1:
		niz[a - 1] = new Polinom;
		cout << "Stvaranje novog polinoma je izvrseno." << endl;
		break;
	case 2:
		Sinusoida sinusoida;
		niz[a - 1] = new Sinusoida;
		sinusoida.citanje_parametara_funkcije();
		break;
	}
	
}

double Niz::operator()(double x)const {
	double ukupno = 0;
	for (int i = 0; i < 5; i++) {
		if (niz[i]) {
			ukupno += niz[i]->realna_vrednost_x(x);
		}
	}
	return ukupno;
}