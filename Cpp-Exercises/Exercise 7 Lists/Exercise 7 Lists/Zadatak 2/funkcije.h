#ifndef __FUNKCIJE_H__
#define __FUNKCIJE_H__
struct Elem {
	int br;
	Elem* sled;
	Elem* pret;
};
void dodaj(int broj);
void uzmi();
void ispis();
void praznjenje();
void odredjivanje_broja_liste();
void citanje_liste_pocetak();
void citanje_liste_kraj();
void umetanje_broja(int n, int b);
//new
void izostavljanje_iz_liste(int n);
#endif
