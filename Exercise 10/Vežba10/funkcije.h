#pragma once
#ifndef __DATUMI_H__
#define __DATUMI_H__
#include <iostream>
#include <cmath>
using namespace std;
class datumi {
public:
	int dan, mesec, godina;
	datumi() {
		dan = 0;
		mesec = 0;
		godina = 0;
	}

	void stvaranje(int d, int m, int g);

	int uzmiDan() {
		return dan;
	}
	int uzmiMesec() {
		return mesec;
	}
	int uzmiGodinu() {
		return godina;
	}

	bool prestupna();
	void broj_dana_mesec();
	void broj_dana_godina();
	void povecavanje_za_jedan();
	void smanjivanje_za_jedan();
	void dodavanje_oduzimanje_broja();
	bool uporedjivanje(datumi dtm1, datumi dtm2);
	void citanje();
	void pisanje();
	int odredjivanje();
	int izmedju_dva_datuma(datumi dtm1, datumi dtm2);
	void podesavanje_formata_ispisivanja();
};
#endif