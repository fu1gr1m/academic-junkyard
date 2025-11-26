#include <iostream>
using namespace std;

namespace Zvezdica {
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
					cout << "*";
				}
				else {
					cout << "*.";
				}
			}
			cout << endl;

		}
		for (i = 0; i < n - 1; i++) {
			cout << " ";
		}
		cout << "***" << endl;
	}
}