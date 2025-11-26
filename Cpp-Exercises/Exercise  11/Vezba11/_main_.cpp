#include "funkcije_liste.h"
#include <iostream>
int main() {
    Liste lista;
    int n = 0;
    while(n != 13) {
        cout << "\nIzaberite broj za operaciju:" << endl;
        cout << "1.Stvaranje liste." << endl;
        cout << "2.Citanje liste." << endl;
        cout << "3.Dodaj sadrzaj druge liste u prvu listu." << endl;
        cout << "4.Umetanje broja u listu." << endl;
        cout << "5.Izbaci prvo pojavljivanje odredjenog broja." << endl;
        cout << "6.Isprazni listu." << endl;
        cout << "7.Broj pojavljivanja broja." << endl;
        cout << "8.Izbaci visestruka ponavljanja brojeva iz liste." << endl;
        cout << "9.Izbaci brojeve iz liste koje sadrzi druga lista." << endl;
        cout << "10.Dodaj vrednost druge liste listi." << endl;
        cout << "11.Duzina liste." << endl;
        cout << "12.Pisi listu." << endl;
        cout << "13.Gasenje programa." << endl;
        cout << "Unesite broj: ";
        cin >> n;
        switch (n) {
        case 1:
            lista.kreiranje();
            break;
        case 2:
            lista.citanje();
            break;
        case 3:
            lista.dodavanje_druge_liste();
            break;
        case 4:
            lista.umetanje();
            break;
        case 5:
            lista.izbacivanje_prvog_ponavljanja();
            break;
        case 6:
            lista.praznjenje();
            break;
        case 7:
            lista.broj_ponavljanja_broja();
            break;
        case 8:
            lista.izbacivanje_istih_brojeva();
            break;
        case 9:
            lista.izbacivanje_brojeva_druge_liste();
            break;
        case 10:
            lista.dodela_vrednosti();
            break;
        case 11:
            cout << "Duzina liste je: " << lista.duzina() << endl;
            break;
        case 12:
            lista.ispisivanje();
            break;
        case 13:
            cout << "Izlaz.";
            break;
        }
    } 
}