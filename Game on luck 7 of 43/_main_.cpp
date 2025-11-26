#include <iostream>



int main() {

	while (1) {
		srand(time(NULL));
		int n = 7, b, brojilac = 0;
		int* niz_1;
		int* niz_2;
		niz_1 = new int[n];
		niz_2 = new int[n];
		char slovo;


		std::cout << "Unesite 7 elemenata u niz: " << std::endl;
		for (int i = 0; i < n; i++) {
			std::cout << "Br " << i + 1 << ". :";
			std::cin >> niz_1[i];
		}

		for (int i = 0; i < n; i++) {
			int broj = (rand() % 37) + 7;
			niz_2[i] = broj;
		}


		for (int i = 0; i < n; i++) {
			for (int j = i + 1; j < n; j++) {
				if (niz_1[i] == niz_2[j]) {
					brojilac++;
				}
			}
		}

		std::cout << "Vas niz: " << std::endl;
		for (int i = 0; i < n; i++) {
			std::cout << niz_1[i] << " ";
		}
		std::cout << "\n";
		std::cout << "Nasumicni niz: " << std::endl;
		for (int i = 0; i < n; i++) {
			std::cout << niz_2[i] << " ";
		}
		std::cout << "\n";
		std::cout << "Broj pogadaka: " << brojilac << std::endl;

		if (brojilac > 4) {
			std::cout << "Cestitamo, pobedili ste!" << std::endl;
		}

		if (brojilac < 5) {
			std::cout << "Vise srece drugi put..." << std::endl;
		}

		delete[] niz_1;
		delete[] niz_2;

		std::cout << "Da li zelite da nastavite sa igrom? " << std::endl;
		std::cin >> slovo;
		if (slovo == 'd' || slovo == 'D') {
			continue;
		}
		else {
			break;
		}
	}
	return 0;
}
