#pragma once
#include<iostream>
using namespace std;

class Liste {
private:
    int broj;
    Liste* poc, * kraj, *sled;
public:
    void kreiranje();
    void dodela_vrednosti();
    int duzina();
    void umetanje();
    void citanje();
    void izbacivanje_prvog_ponavljanja();
    void praznjenje();
    void ispisivanje();
    void izbacivanje_istih_brojeva();
    void dodavanje_druge_liste();
    void izbacivanje_brojeva_druge_liste();
    void broj_ponavljanja_broja();
    void sortiranje();

    Liste() {
        poc = nullptr;
        kraj = nullptr;
    };
};