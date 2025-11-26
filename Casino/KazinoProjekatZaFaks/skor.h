#pragma once
#include <iostream>
#include <cmath>
#include <cstring>
#include "igrac.h"
using namespace std;

class Skor {
public:
	Igrac* igrac;
	double rezultat_rulet;
	double rezultat_blekdzek;

	Skor() {
		rezultat_rulet = 0;
		rezultat_blekdzek = 0;
	}

	void ispisivanje_skor_rulet();
	void ispisivanje_skor_blekdzek();
};