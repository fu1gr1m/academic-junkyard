#pragma once
#ifndef __TACKE_H__
#define __TACKE_H__
#include <iostream>
#include <cmath>
using namespace std;
class tacke_u_ravni {
public:
	double x;
	double y;
	tacke_u_ravni() {
		x = 0;
		y = 0;
	}

	void sastavi(const double&, const double&);
	double uzmiX() {
		return x;
	}
	double uzmiY() {
		return y;
	}
	void citaj();
	void pisi();
	friend void rastojanje(double T1, double T2);
};

class trougao {
public:
	tacke_u_ravni q, w, e;
	trougao() {
		q.x = -1, q.y = -1;
		w.x = 1, w.y = -1;
		e.x = 0, e.y = 1;
	}
	void sastavi(tacke_u_ravni a, tacke_u_ravni b, tacke_u_ravni c);
	double uzmiA() {
		return q.x;
		return q.y;
	};
	double uzmiB() {
		return w.x;
		return w.y;
	};
	double uzmiC() {
		return e.x;
		return e.y;
	};
	double stranicaAB();
	double stranicaBC();
	double stranicaCA();
	double obimt();
	double povrsina();
	void citanje();
	void pisanje();
	bool nalazenje_tacke(tacke_u_ravni t);
	friend bool zadiranje(trougao trg1, trougao trg2);

};

#endif