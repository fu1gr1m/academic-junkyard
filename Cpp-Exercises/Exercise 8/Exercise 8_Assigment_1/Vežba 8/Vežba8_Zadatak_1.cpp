#include <iostream>
#include <cmath>
#define PI 3.14159265359

using namespace std;

int n;
class Sfera {
public:
	int i, j;
	double x, y, z;
	double r;
	double povrsina = 0;
	double zapremina = 0;
	double razdaljina = 0;
	double razd_2_sfere = 0;
	Sfera* sled;
	Sfera* lst = nullptr;

	void citanje() {
		double broj_x;
		double broj_y;
		double broj_z;
		double broj_r;
		for (int i = 0; i < n; i++) {
			cout << i + 1 << ".Sfera\n";
			cout << "Element X: ";
			cin >> broj_x;
			cout << "Element Y: ";
			cin >> broj_y;
			cout << "Element Z: ";
			cin >> broj_z;
			cout << "Poluprecnik r: ";
			cin >> broj_r;
			Sfera* novi = new Sfera();
			novi->x = broj_x;
			novi->y = broj_y;
			novi->z = broj_z;
			novi->r = broj_r;
			novi->sled = nullptr;
			if (!lst) {
				lst = novi;
			}
			else {
				Sfera* tek = lst;
				while (tek->sled) {
					tek = tek->sled;
				}
				tek->sled = novi;
			}

		}
	}
	void ispisi() {
		Sfera* tek = lst;
		if (!lst) {
			cout << "Ne postoje sfere." << endl;
		}
		else {
			while (tek) {
				cout << "X = " << tek->x << " " << "Y = " << tek->y << " " << "Z = " << tek->z << " " << "r = " << tek->r << " " << "Zapremina = " << tek->zapremina << " " << endl;
				tek = tek->sled;
			}
		}
	}

	void povrsina_sfere() {
		while (lst) {
			lst->povrsina = 4 * (lst->r * lst->r) * PI;
		}
	}

	void zapremina_sfere() {
		Sfera* tek = lst;
		while (tek)
		{
			tek->zapremina = 4 * (tek->r * tek->r * tek->r) * PI / 3;
			tek = tek->sled;
		}
	}

	void premestanje() {
		double broj_x;
		double broj_y;
		double broj_z;
		int b;
		Sfera* tek = lst;
		cout << "Koju sferu zelite da pomerite (ima ih " << n << "): ";
		cin >> b;
		for (int i = 1; i < b; i++) {
			tek = tek->sled;
		}
		cout << "Novi elementi te sfere" << endl;
		cout << "Element X: ";
		cin >> broj_x;
		cout << "Element Y: ";
		cin >> broj_y;
		cout << "Element Z: ";
		cin >> broj_z;

		tek->x = broj_x;
		tek->y = broj_y;
		tek->z = broj_z;

	}

	void pomakinjanje() {
		double broj_x;
		double broj_y;
		double broj_z;
		int b = 0;
		Sfera* tek = lst;
		cout << "Koju sferu zelite da pomaknete (ima ih " << n << "): ";
		cin >> b;
		for (int i = 1; i < b; i++) {
			tek = tek->sled;
		}
		cout << "Unesite vrednost za koju želite da pomaknete elemente sfere" << endl;
		cout << "Element X: ";
		cin >> broj_x;
		cout << "Element Y: ";
		cin >> broj_y;
		cout << "Element Z: ";
		cin >> broj_z;

		tek->x += broj_x;
		tek->y += broj_y;
		tek->z += broj_z;
	}

	void udaljenost_od_kord_pocetka() {
		Sfera* tek = lst;
		while (tek) {
			tek->razdaljina = sqrt((tek->x * tek->x) + (tek->y * tek->y) + (tek->z * tek->z));
			tek = tek->sled;
		}
	}


	void najbliza_najudaljenija() {

		double min = lst->razdaljina;
		double max = lst->razdaljina;
		while (lst) {
			if (min > lst->razdaljina) {
				min = lst->razdaljina;
			}
			if (max < lst->razdaljina) {
				max = lst->razdaljina;
			}
			lst = lst->sled;
		}

		cout << "Najbliza sfera od koordinatnog pocetka je udaljena: " << min << endl;
		cout << "Najudaljenija sfera od koord pocetka je udaljena: " << max << endl;

	}

	void sortiraj_zapremina() {
		double temp;
		Sfera* i, * j;
		for (i = lst; i; i = i->sled)
		{
			for (j = i->sled; j; j = j->sled)
			{
				if (j->zapremina < i->zapremina)
				{
					temp = i->zapremina;
					i->zapremina = j->zapremina;
					j->zapremina = temp;
					temp = i->x;
					i->x = j->x;
					j->x = temp;
					temp = i->y;
					i->y = j->y;
					j->y = temp;
					temp = i->z;
					i->z = j->z;
					j->z = temp;
					temp = i->r;
					i->r = j->r;
					j->r = temp;
				}
			}
		}
	}

	void najblize_rastojranje_izmedju_2_sfere() {
		Sfera* tek_1;
		Sfera* tek_2;
		Sfera* rastojanje = nullptr;
		double rastojanjee = 0;
		int i = 0, j;
		for (tek_1 = lst; tek_1; tek_1 = tek_1->sled) {
			i++;
			j = i;
			for (tek_2 = tek_1->sled; tek_2; tek_2 = tek_2->sled) {
				j++;
				Sfera* novi = new Sfera();
				novi->sled = nullptr;
				novi->razd_2_sfere = rastojanjee;
				if (!rastojanje) {
					rastojanje = novi;
					rastojanje->razd_2_sfere = sqrt(pow((tek_1->x - tek_2->x), 2) + pow((tek_1->y - tek_2->y), 2) + pow((tek_1->z - tek_2->z), 2) - tek_1->r - tek_2->r);
				}
				else {
					Sfera* tek = rastojanje;
					while (tek->sled) {
						tek = tek->sled;
					}
					tek->sled = novi;
					novi->razd_2_sfere = sqrt(pow((tek_1->x - tek_2->x), 2) + pow((tek_1->y - tek_2->y), 2) + pow((tek_1->z - tek_2->z), 2) - tek_1->r - tek_2->r);
					novi->i = i;
					novi->j = j;
				}
			}
		}

		double minimalno = rastojanje->razd_2_sfere;
		int a = 0, b = 0;
		while (rastojanje) {
			if (minimalno > rastojanje->razd_2_sfere) {
				minimalno = rastojanje->razd_2_sfere;
				a = rastojanje->i;
				b = rastojanje->j;
			}
			rastojanje = rastojanje->sled;
		}

		cout << "Najmanje rastojanje iznosi: " << minimalno << " izmedju dve sfere " << a << " i " << b << "." << endl;

	}
};


int main() {
	Sfera sfere;
	while (1) {
		cout << "Koliko sfera zelite da uneste(max 10): ";
		cin >> n;
		if (n > 10 || n < 0) {
			cout << "Losa vrednost!";
			break;
		}
		sfere.citanje();
		sfere.zapremina_sfere();
		sfere.sortiraj_zapremina();		
		sfere.ispisi();
		for (int i = 0; i < n; i++) {   //na ovaj nacin ce korisnik svaku sferu pomeriti za isti podatak
			sfere.pomakinjanje();
		}
		sfere.najblize_rastojranje_izmedju_2_sfere();
		sfere.udaljenost_od_kord_pocetka();
		sfere.najbliza_najudaljenija();
		
	}
	return 0;

}
