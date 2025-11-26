#include <iostream>
#include "Karakter.h"
#include "Zvezdica.h"
using namespace std;
using namespace Karakter;
using namespace Zvezdica;


int main(){
	while (1) {
		int n;
		cout << "Unesite visinu jelke: ";
		cin >> n;
		if (n <= 2) {
			break;
		}

		Karakter::jelka(n);
		Zvezdica::jelka(n);

	}
	cout << "Uneli ste broj manji ili jednak broju 2, vidimo se!" << endl;
	return 0;
}