#include "skor.h";

void Skor::ispisivanje_skor_rulet() {
	cout << igrac->ime << ": " << rezultat_rulet;
}

void Skor::ispisivanje_skor_blekdzek() {
	cout << igrac->ime << ": " << rezultat_blekdzek;
}