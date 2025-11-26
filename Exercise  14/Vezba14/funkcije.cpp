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


void Logaritam::citanje_parametara_funkcije() {
	cout << "a: ";
	cin >> a;
	cout << "b: ";
	cin >> b;
}

double Logaritam::realna_vrednost_x(double x) {
	double p;
	p = a * log(b * x);
	return p;
}



