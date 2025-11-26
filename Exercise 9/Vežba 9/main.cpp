#include "tacke.h"
#include <iostream>
#include <cmath>

using namespace std;
int main() {
	while (true) {
		cout << "Unesite broj trouglova (ako zelite da izadjete iz programa ukucajte nulu): ";
		int broj_trouglova = 0, trenutni_broj_trouglova = 0;
		cin >> broj_trouglova;
		if (broj_trouglova == 0) {
			cout << "Vidimo se!";
			break;
		}
		if (broj_trouglova < 0) {
			cout << "Losa vrednost!";
			break;
		}

		int i = 0;
		trougao** niz = new trougao * [broj_trouglova];
		while(i < broj_trouglova) {
			trougao* trenutni = new trougao();
			cout << "Trougao " << i + 1 << endl;
			if (trenutni_broj_trouglova < 1) {
				niz[i] = new trougao();
				niz[i]->citanje();
				trenutni_broj_trouglova++;
				i++;
			}
			else {
				bool da_li = false;
				trenutni->citanje();
				for (int j = 0; j < i; j++) {
					if (zadiranje(*trenutni, *niz[j]) == true) {
						da_li = true;
					}
				}
				if (da_li == true) {
					cout << "Trougao zadira! Trougao nije unesen." << endl;
				}
				else {
					niz[i] = trenutni;
					trenutni_broj_trouglova++;
					i++;
				}
			}	
		}


		trougao* temp;
		for (int i = 0; i < broj_trouglova; i++) {
			for (int j = i + 1; j < broj_trouglova; j++) {
				if (niz[i]->povrsina() > niz[j]->povrsina()) {
					temp = niz[i];
					niz[i] = niz[j];
					niz[j] = temp;
				}
			}
		}


		for (int i = 0; i < broj_trouglova; i++) {
			cout << "Trougao " << i + 1 << ": " << endl;
			niz[i]->pisanje();
			cout << "Povrsina: " << niz[i]->povrsina() << endl;
		}


	}

	return 0;
}