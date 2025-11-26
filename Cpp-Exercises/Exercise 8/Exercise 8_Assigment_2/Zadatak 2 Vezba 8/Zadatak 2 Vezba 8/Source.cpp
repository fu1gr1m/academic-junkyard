#include <iostream>
#include <ctime>



using namespace std;
int n;
class Vremena {
public:
	int dan, cas, minut, sekund;
	int ukupno_sekundi;
	double realni_dani;
	Vremena* sled;
	Vremena* lst = nullptr;

	void citanje() {
		double dan_broj;
		double cas_broj;
		double minut_broj;
		double sekund_broj;


		for (int i = 0; i < n; i++) {
			cout << i + 1 << ".Vreme" << endl;
			cout << "Dan: ";
			cin >> dan_broj;
			cout << "Cas: ";
			cin >> cas_broj;
			cout << "Minuti: ";
			cin >> minut_broj;
			cout << "Sekunde: ";
			cin >> sekund_broj;

			if (sekund_broj > 59) {
				while (sekund_broj > 59) {
					sekund_broj = sekund_broj - 60;
					minut_broj++;
				}
			}
			if (minut_broj > 59) {
				while (minut_broj > 59) {
					minut_broj = minut_broj - 60;
					cas_broj++;
				}
			}
			if (cas_broj > 23) {
				while (cas_broj > 23) {
					cas_broj = cas_broj - 24;
					dan_broj++;
				}
			}

			Vremena* novi = new Vremena();
			novi->dan = dan_broj;
			novi->cas = cas_broj;
			novi->minut = minut_broj;
			novi->sekund = sekund_broj;
			novi->sled = nullptr;
			if (!lst) {
				lst = novi;
			}
			else {
				Vremena* tek = lst;
				while (tek->sled) {
					tek = tek->sled;
				}
				tek->sled = novi;
			}

		}

	}

	void ispisivanje() {
		Vremena* tek = lst;
		if (!tek) {
			cout << "Ne postoje vremena!";
		}
		else {
			while (tek) {
				cout << "Vreme: " << tek->dan << " dana" << " " << tek->cas << "h" << " " << tek->minut << "min" << " " << tek->sekund << "sek" << endl;
				tek = tek->sled;
			}
		}
	}

	void stvaranje_po_sekundama() {
		double dan_broj = 0;
		double cas_broj = 0;
		double minut_broj = 0;
		double sekund_broj;

		cout << "Sekunde: ";
		cin >> sekund_broj;

		if (sekund_broj > 59) {
			while (sekund_broj > 59) {
				sekund_broj = sekund_broj - 60;
				minut_broj++;
			}
		}
		if (minut_broj > 59) {
			while (minut_broj > 59) {
				minut_broj = minut_broj - 60;
				cas_broj++;
			}
		}
		if (cas_broj > 23) {
			while (cas_broj > 23) {
				cas_broj = cas_broj - 24;
				dan_broj++;
			}
		}

		Vremena* novi = new Vremena();
		novi->dan = dan_broj;
		novi->cas = cas_broj;
		novi->minut = minut_broj;
		novi->sekund = sekund_broj;
		novi->sled = nullptr;
		if (!lst) {
			lst = novi;
		}
		else {
			Vremena* tek = lst;
			while (tek->sled) {
				tek = tek->sled;
			}
			tek->sled = novi;
		}

	}

	void uporedjivanje() {
		Vremena* tek_1 = lst;
		Vremena* tek_2 = lst;
		int b, a;
		cout << "Koja vremena zlite da uporedite, unesite 2 broja: (ima ih " << n << ")";
		cin >> b >> a;
		for (int i = 1; i < b; i++) {
			tek_1 = tek_1->sled;
		}

		for (int i = 1; i < a; i++) {
			tek_2 = tek_2->sled;
		}

		if (tek_1->dan > tek_2->dan) {
			cout << "Vreme " << b << " je vece od vremena " << a << "." << endl;
		}
		else if (tek_1->dan < tek_2->dan) {
			cout << "Vreme " << b << " je manje od vremena " << a << "." << endl;
		}
		else {
			if (tek_1->cas > tek_2->cas) {
				cout << "Vreme " << b << " je vece od vremena " << a << "." << endl;
			}
			else if (tek_1->cas > tek_2->cas) {
				cout << "Vreme " << b << " je manje od vremena " << a << "." << endl;
			}
			else {
				if (tek_1->minut > tek_2->minut) {
					cout << "Vreme " << b << " je vece od vremena " << a << "." << endl;
				}
				else if (tek_1->minut < tek_2->minut) {
					cout << "Vreme " << b << " je manje od vremena " << a << "." << endl;
				}
				else {
					if (tek_1->sekund > tek_2->sekund) {
						cout << "Vreme " << b << " je vece od vremena " << a << "." << endl;
					}
					else if (tek_1->sekund < tek_2->sekund) {
						cout << "Vreme " << b << " je manje od vremena " << a << "." << endl;
					}
					else {
						cout << "Vremena se podudaraju." << endl;
					}
				}
			}
		}

	}

	void zbir_dva_vremena() {
		Vremena* tek_1 = lst;
		Vremena* tek_2 = lst;
		int b, a;
		cout << "Koja vremena zelite da saberete, unesite 2 broja: (ima ih " << n << ")";
		cin >> b >> a;
		for (int i = 1; i < b; i++) {
			tek_1 = tek_1->sled;
		}

		for (int i = 1; i < a; i++) {
			tek_2 = tek_2->sled;
		}

		int dani, casovi, minuti, sekunde;
		dani = tek_1->dan + tek_2->dan;
		casovi = tek_1->cas + tek_2->cas;
		minuti = tek_1->minut + tek_2->minut;
		sekunde = tek_1->sekund + tek_2->sekund;

		if (sekunde > 59) {
			while (sekunde > 59) {
				sekunde = sekunde - 60;
				minuti++;
			}
		}
		if (minuti > 59) {
			while (minuti > 59) {
				minuti = minuti - 60;
				casovi++;
			}
		}
		if (casovi > 23) {
			while (casovi > 23) {
				casovi = casovi - 24;
				dani++;
			}
		}

		cout << "Zbir ova dva vremena iznosi: " << dani << " dana" << " " << casovi << "h" << " " << minuti << "min " << sekunde << "sek " << endl;



	}

	void razlika_dva_vremena() {

		Vremena* tek_1 = lst;
		Vremena* tek_2 = lst;
		int b, a;
		cout << "Koja vremena zelite da oduzmete, unesite 2 broja: (ima ih " << n << ")";
		cin >> b >> a;
		for (int i = 1; i < b; i++) {
			tek_1 = tek_1->sled;
		}

		for (int i = 1; i < a; i++) {
			tek_2 = tek_2->sled;
		}

		int dani, casovi, minuti, sekunde;
		dani = tek_1->dan - tek_2->dan;
		casovi = tek_1->cas - tek_2->cas;
		minuti = tek_1->minut - tek_2->minut;
		sekunde = tek_1->sekund - tek_2->sekund;

		if (sekunde > 59) {
			while (sekunde > 59) {
				sekunde = sekunde - 60;
			}
		}
		if (sekunde < 0) {
			minuti--;
			sekunde = sekunde + 60;
		}
		if (minuti > 59) {
			while (minuti > 59) {
				minuti = minuti - 60;
			}
		}
		if (minuti < 0) {
			casovi--;
			minuti = minuti + 60;
		}
		if (casovi > 23) {
			while (casovi > 23) {
				casovi = casovi - 24;
			}
		}
		if (casovi < 0) {
			dani--;
			casovi = casovi + 24;
		}


		cout << "Razlika ova dva vremena iznosi: " << dani << " dana" << " " << casovi << "h" << " " << minuti << "min " << sekunde << "sek " << endl;

	}



	void mnozenje_celim_brojem() {
		Vremena* tek_1 = lst;
		int b, a;
		cout << "Koje vreme zelite da pomnozite celim brojem, unesite broj: (ima ih " << n << ")";
		cin >> b;
		cout << "Sa kojim brojem zelite da pomnozite ovo vreme(unesite ceo broj): ";
		cin >> a;
		for (int i = 1; i < b; i++) {
			tek_1 = tek_1->sled;
		}

		int dani, casovi, minuti, sekunde;
		dani = tek_1->dan * a;
		casovi = tek_1->cas * a;
		minuti = tek_1->minut * a;
		sekunde = tek_1->sekund * a;

		if (sekunde > 59) {
			while (sekunde > 59) {
				sekunde = sekunde - 60;
				minuti++;
			}
		}
		if (sekunde < 0) {
			minuti--;
			sekunde = sekunde + 60;
		}
		if (minuti > 59) {
			while (minuti > 59) {
				minuti = minuti - 60;
				casovi++;
			}
		}
		if (minuti < 0) {
			casovi--;
			minuti = minuti + 60;
		}
		if (casovi > 23) {
			while (casovi > 23) {
				casovi = casovi - 24;
				dani++;
			}
		}
		if (casovi < 0) {
			dani--;
			casovi = casovi + 24;
		}


		cout << "Ovo vreme pomnozeno celim brojem iznosi: " << dani << " dana" << " " << casovi << "h" << " " << minuti << "min " << sekunde << "sek " << endl;

	}

	void deljenje_celim_brojem() {
		Vremena* tek_1 = lst;
		int b, a;
		cout << "Koja vremena zelite da podelite celim brojem, unesite broj: (ima ih " << n << ")";
		cin >> b;
		cout << "Sa kojim brojem zelite da podelite ovo vreme(unesite ceo broj): ";
		cin >> a;
		for (int i = 1; i < b; i++) {
			tek_1 = tek_1->sled;
		}

		int dani, casovi, minuti, sekunde;
		dani = tek_1->dan / a;
		casovi = tek_1->cas / a;
		minuti = tek_1->minut / a;
		sekunde = tek_1->sekund / a;

		if (sekunde > 59) {
			while (sekunde > 59) {
				sekunde = sekunde - 60;
			}
		}
		if (sekunde < 0) {
			minuti--;
			sekunde = sekunde + 60;
		}
		if (minuti > 59) {
			while (minuti > 59) {
				minuti = minuti - 60;
			}
		}
		if (minuti < 0) {
			casovi--;
			minuti = minuti + 60;
		}
		if (casovi > 23) {
			while (casovi > 23) {
				casovi = casovi - 24;
			}
		}
		if (casovi < 0) {
			dani--;
			casovi = casovi + 24;
		}



		cout << "Ovo vreme podeljeno celim brojem iznosi: " << dani << " dana" << " " << casovi << "h" << " " << minuti << "min " << sekunde << "sek " << endl;

	}

	void stvaranje_po_realnim_danima() {
		
		for (int i = 0; i < n; i++) {
			int dan_u_sekundama = 86400;
			double realan_dan;
			double dan_broj = 0;
			double cas_broj = 0;
			double minut_broj = 0;
			double sekund_broj = 0;

			cout << i + 1 << ".Vreme" << endl;
			cout << "Realan broj dana: ";
			cin >> realan_dan;
			Vremena* novi = new Vremena();
			sekund_broj = realan_dan * dan_u_sekundama;
			novi->ukupno_sekundi = sekund_broj;
			novi->realni_dani = realan_dan;
			
			if (sekund_broj > 59) {
				while (sekund_broj > 59) {
					sekund_broj = sekund_broj - 60;
					minut_broj++;
				}
			}
			if (minut_broj > 59) {
				while (minut_broj > 59) {
					minut_broj = minut_broj - 60;
					cas_broj++;
				}
			}
			if (cas_broj > 23) {
				while (cas_broj > 23) {
					cas_broj = cas_broj - 24;
					dan_broj++;
				}
			}

		

			novi->dan = dan_broj;
			novi->cas = cas_broj;
			novi->minut = minut_broj;
			novi->sekund = sekund_broj;
			novi->sled = nullptr;
			if (!lst) {
				lst = novi;
			}
			else {
				Vremena* tek = lst;
				while (tek->sled) {
					tek = tek->sled;
				}
				tek->sled = novi;
			}

		}
	}

	void preracunavanje_u_realne_dane() {
		int dan_u_sekundama = 86400;
		double dani;
		double casovi;
		double minuti;
		Vremena* tek_1 = lst;
		int b;
		cout << "Koje vreme zelite da preracunate u realne dane, unesite broj: (ima ih " << n << ")";
		cin >> b;
		for (int i = 1; i < b; i++) {
			tek_1 = tek_1->sled;
		}

		minuti = tek_1->minut + (tek_1->sekund / 60);
		casovi = tek_1->cas + (minuti / 60);
		dani = tek_1->dan + (casovi / 24);

		cout << "Ovo vreme preracunato u realne dane iznosi: " << dani << " dana"<< endl;

		


	}


	void sortiranje() {
		int temp, temp1, temp2, temp3, temp4;
		Vremena* i, *j;
		for (i = lst; i; i = i->sled) {
			for (j = i->sled; j; j = j->sled) {

				if (j->ukupno_sekundi < i->ukupno_sekundi) {
					temp = i->ukupno_sekundi;
					i->ukupno_sekundi = j->ukupno_sekundi;
					j->ukupno_sekundi = temp;
					temp2 = i->dan;
					i->dan = j->dan;
					j->dan = temp2;
					temp3 = i->cas;
					i->cas = j->cas;
					j->cas = temp3;
					temp4 = i->minut;
					i->minut = j->minut;
					j->minut = temp4;
					temp1 = i->sekund;
					i->sekund = j->sekund;
					j->sekund = temp1;
				}

			}
		}
		
	}

	void izostavljanje_vremena() {
		Vremena* tek = lst;
		double b, a;
		cout << "Unesite interval od 2 realna broja izmedju kojih hocete da izostavite brojeve: ";
		cout << "Prvi interval:";
		cin >> b;
		cout << "Drugi interval:";
		cin >> a;

		while (tek) {
			if (tek->realni_dani > b && tek->realni_dani < a) {
				tek = tek->sled;
			}
			else {
				cout << "Vreme: " << tek->dan << " dana" << " " << tek->cas << "h" << " " << tek->minut << "min" << " " << tek->sekund << "sek" << endl;
				tek = tek->sled;
			}
		}
		


	}


	void obrisi() {
		Vremena* tek = lst;
		Vremena* novo = nullptr;
		while (tek)
		{
			novo = tek->sled;
			delete tek;
			tek = sled;
		}
		lst = nullptr;
	}
};







int main() {
	Vremena vreme;
	while (1) {
		cout << "Koliko vremena zelite da unesete(max 20): ";
		cin >> n;
		if (n > 20 || n < 0) {
			cout << "Losa vrednost.";
			break;
		}
		vreme.stvaranje_po_realnim_danima();
		vreme.ispisivanje();
		cout << endl;
		cout << "Vreme stvoreno po sekundama: " << endl;
		vreme.ispisivanje();
		vreme.uporedjivanje();
		vreme.zbir_dva_vremena();
		vreme.razlika_dva_vremena();
		vreme.mnozenje_celim_brojem();
		vreme.deljenje_celim_brojem();
		vreme.preracunavanje_u_realne_dane();
		cout << "Sortirano vreme: " << endl;
		vreme.sortiranje();
		vreme.ispisivanje();
		vreme.izostavljanje_vremena();
		vreme.obrisi();

	}


	return 0;
}