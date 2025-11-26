#include "tacke.h"
#include <cmath>

void tacke_u_ravni::sastavi(const double& xx, const double& yy) {
	x = xx;
	y = yy;
}

void tacke_u_ravni::citaj() {
	cin >> x >> y;
}

void tacke_u_ravni::pisi() {
	cout << "Koordinate su:" << x << ", " << y;
}

double rastojanje(tacke_u_ravni T1, tacke_u_ravni T2) {
	double distanca;
	distanca = sqrt((pow((T2.x - T1.x), 2)) + pow((T2.y - T1.y), 2));
	return distanca;
}

void trougao::sastavi(tacke_u_ravni a, tacke_u_ravni b, tacke_u_ravni c) {
	q = a;
	w = b;
	e = c;
}

double trougao::stranicaAB() {
	double distanca;
	distanca = sqrt(pow((w.x - q.x), 2) + pow((w.y - q.y), 2));
	return distanca;
}

double trougao::stranicaBC() {
	double distanca;
	distanca = sqrt(pow((e.x - w.x), 2) + pow((e.y - w.y), 2));
	return distanca;
}

double trougao::stranicaCA() {
	double distanca;
	distanca = sqrt(pow((q.x - e.x), 2) + pow((q.y - e.y), 2));
	return distanca;
}

double trougao::obimt() {
	double obim;
	obim = stranicaAB() + stranicaBC() + stranicaCA();
	return obim;
}

double trougao::povrsina() {
	double povrs;
	povrs = abs(q.x * (w.y - e.y) + w.x * (e.y - q.y) + e.x * (q.y - w.y)) / 2;
	return povrs;
}

void trougao::citanje() {
	cout << "Unesite koordinate tacke A:" << endl;
	cout << "X:"; cin >> q.x;
	cout << "Y:"; cin >> q.y;
	cout << "Unesite koordinate tacke B:" << endl;
	cout << "X:"; cin >> w.x;
	cout << "Y:"; cin >> w.y;
	cout << "Unesite koordinate tacke C:" << endl;
	cout << "X:"; cin >> e.x;
	cout << "Y:"; cin >> e.y;
}

void trougao::pisanje() {
	cout << "Koordinate tacke A su: " << q.x << ", " << q.y << endl;
	cout << "Koordinate tacke B su: " << w.x << ", " << w.y << endl;
	cout << "Koordinate tacke C su: " << e.x << ", " << e.y << endl;
}

bool trougao::nalazenje_tacke(tacke_u_ravni t) {
	trougao a, s, d;
	trougao povrsina_1, povrsina_2;
	double povrs_1, povrs_2;
	a.sastavi(t, a.w, a.e);
	s.sastavi(s.q, t, s.e);
	d.sastavi(d.q, d.w, t);
	povrs_1 = povrsina_1.povrsina();
	povrs_2 = a.povrsina() + s.povrsina() + d.povrsina();
	if (povrs_1 == povrs_2) {
		return true;
	}
	else {
		return false;
	}
}

bool zadiranje(trougao trg1, trougao trg2) {
	if (trg1.nalazenje_tacke(trg2.q) || trg1.nalazenje_tacke(trg2.w) || trg1.nalazenje_tacke(trg2.e)) {
		return true;
	}
	else {
		return false;
	}
}