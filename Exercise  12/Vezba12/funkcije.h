#pragma once
#ifndef __POLINOM_H__
#define __POLINOM_H__
#include <iostream>
#include <cmath>
using namespace std;
class Niz {
public:
	
	int duz = 10;
	int* duz_niz = new int[duz];
	Niz() {
		for (int i = 0; i < duz; i++) {
			duz_niz[i] = 0;
		}
	}
	~Niz() {
		delete[] duz_niz;
	}
	int duzina_niza();
	void citanje();
	void getElement();
	void ispisivanje();

	
};

class Polinom:public Niz {
public:
	int* niz_red = new int[duz];
	int vred_polinom();
	void zbir();
	void proizvod();
	void pisanje();
	void citanje_koeficijenata();
	Polinom() {
		for (int i = 0; i < duz - 1; i++) {
			duz_niz[i] = 1;
		}
		for (int i = 1; i < duz; i++) {
			niz_red[i - 1] = i;
		}
	}

	~Polinom() {
		delete[] niz_red;
	}


};

class Veliki :public Niz {
public:
	int* decimale = new int[duz];

	Veliki() {

	}
	~Veliki() {
		delete decimale;
	}

	bool operator== (const Veliki& b) const;
	bool operator< (const Veliki& b) const;
	bool operator!= (const Veliki& b) const;
	bool operator> (const Veliki& b) const;
	bool operator>= (const Veliki& b) const;
	bool operator<= (const Veliki& b) const;

	void citanje_broja();
	void pisanje_decimala();
	void zbir_dva(Veliki& b);
	void proizvod_dva(Veliki& b);
	double sklopi_broj();
	

};

#endif