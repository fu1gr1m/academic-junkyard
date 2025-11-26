#pragma once
#ifndef __LOGARITAM_H__
#define __LOGARITAM_H__
#include <iostream>
#include <cmath>
using namespace std;
class Funkcija {
public:
	int a, b, c;
	Funkcija() {
		a = 5;
		b = 5;
		c = 5;
	}
	virtual double realna_vrednost_x(double x);
	virtual void citanje_parametara_funkcije();
	virtual void ispisivanje_alg_oblika();
};


class Logaritam : public Funkcija {
public:
	double realna_vrednost_x(double x);
	void citanje_parametara_funkcije();
	void ispisivanje_alg_oblika() {
		cout << "Logaritam: " << a << " * log(" << b << " * x)" << endl;
	}
};

class Polinom : public Funkcija {
public:
	int red = 10;
	int* koeficijenti = new int[red];
	Polinom() {
		for (int i = 0; i < red; i++) {
			koeficijenti[i] = 1;
		}
	}

	~Polinom() {
		delete[] koeficijenti;
	}

	int operator+()const;
	int operator[](int i) const;
	void ispisivanje_polinoma();
	double realna_vrednost_x(double x);
	void ispisivanje_alg_oblika() {
		cout << "P(x)[";
		ispisivanje_polinoma();
		cout << "]" << endl;
	}

};

#endif