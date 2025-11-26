#include <iostream>
using namespace std;

namespace Karakter {
	char karakter = '?';
	void jelka(int n) {
		int i, j, brojilac_zvezda, brojilac_mesta;

		for (i = 1; i <= n; i++) {
			brojilac_zvezda = i;
			brojilac_mesta = n - i + 1;


			for (j = 0; j < brojilac_mesta; j++) {
				cout << " ";
			}

			for (j = 0; j < brojilac_zvezda; j++) {
				if (j == brojilac_zvezda - 1) {
					cout << karakter;
				}
				else {
					cout << karakter << ".";
				}
			}
			cout << endl;

		}
		for (i = 0; i < n - 1; i++) {
			cout << " ";
		}
		cout << karakter << karakter << karakter << endl << endl;
	}

}
