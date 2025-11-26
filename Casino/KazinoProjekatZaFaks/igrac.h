#pragma once
#include <iostream>
#include <cmath>
#include <cstring>
using namespace std;

class Igrac {
public:
	string ime;
	int id;
	int balans = 0;

	int identifikator = 1;
	const int MAX_NAME_LENGTH = 80;

	void stvaranje_igrac(string ime_igraca, int balans_igraca);
	void ispisivanje_igrac();

};