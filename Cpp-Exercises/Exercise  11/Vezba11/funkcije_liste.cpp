#include "funkcije_liste.h"
void Liste::kreiranje() {
	cout << "Opcije za stvaranje liste:" << endl;
	cout << "Broj 1 za stvaranje prazne liste." << endl;
	cout << "Broj 2 za stvaranje liste od jednog broja." << endl;
	cout << "Broj 3 za stvaranje liste od druge liste." << endl;
	cout << "Unesite broj: ";
	int n;
	cin >> n;
	switch (n) {
	case 1:
	{
		poc = nullptr;
		kraj = nullptr;
		cout << "Stvorili ste praznu listu." << endl;
		break;
	}
	case 2:
	{
		int br;
		cout << "Unesite broj od kog zelite stvoriti listu:";
		if (poc) {
			Liste* temp = poc;
			while (temp != nullptr) {
				Liste* sled = temp->sled;
				delete temp;
				temp = sled;
			}
			poc = nullptr;
		}
		cin >> br;
		Liste* temp = new Liste;
		temp->broj = br;
		temp->sled = nullptr;
		poc = temp;
		kraj = temp;
		cout << "Stvorili ste listu u kojoj je jedini element broj: " << br << "." << endl;
		break;
	}
	case 3: {
		cout << "Stvaranje druge liste" << endl;
		dodela_vrednosti();
		cout << "Stvorili ste listu koja se sastoji od sledecih clanova: ";
		this->ispisivanje();
		break;
	}
	default:
	{
		cout << "Neispravna vrednost, unesite opet." << endl;
		kreiranje();
	}
	}
}
void Liste::citanje() {
	int duzina, br;
	cout << "Koliko brojeva zelite da ubacite u listu:";
	cin >> duzina;
	for (int i = 0; i < duzina; i++)
	{
		cout << i + 1 << ". broj: ";
		cin >> br;
		Liste* temp = new Liste;
		temp->broj = br;
		temp->sled = nullptr;
		if (poc == nullptr) {
			poc = temp;
			kraj = temp;
		}
		else
		{
			kraj->sled = temp;
			kraj = kraj->sled;
		}

	}
	sortiranje();
};
void Liste::ispisivanje() {
	Liste* temp = poc;
	if (temp == nullptr) {
		cout << "Lista je prazna." << endl;
	}
	else {
		cout << "Elementi liste: ";
		while (temp) {
			cout << temp->broj << " ";
			temp = temp->sled;
		}
		cout << endl;
	}
};
void Liste::praznjenje() {
	Liste* temp = poc;
	while (temp != nullptr) {
		Liste* sled = temp->sled;
		delete temp;
		temp = sled;
	}
	poc = nullptr;
};
void Liste::sortiranje() {
	int temp;
	Liste* i, * j;
	for (i = poc; i; i = i->sled)
	{
		for (j = i->sled; j; j = j->sled)
		{
			if (j->broj < i->broj)
			{
				temp = i->broj;
				i->broj = j->broj;
				j->broj = temp;
			}
		}
	}
};
int Liste::duzina() {
	int brojilac = 0;
	Liste* temp = poc;
	while (temp) {
		brojilac++;
		temp = temp->sled;
	}
	return brojilac;
};
void Liste::dodela_vrednosti() {
	Liste druga_lista;
	druga_lista.citanje();
	*this = druga_lista;
};
void Liste::umetanje() {
	int pozicija;
	cout << "Na kom mestu zelite da umetnete broj?:";
	cin >> pozicija;
	if (pozicija > duzina()) {
		cout << "Greska. Unesite ispravnu poziciju." << endl;
		umetanje();
	}
	else {
		int n;
		cout << "Unesite broj koji zelite da umetnete:";
		cin >> n;
		Liste* temp = poc;
		Liste* novi = new Liste;
		novi->broj = n;
		novi->sled = nullptr;
		if (pozicija == 1) {
			novi->sled = poc;
			poc = novi;
		}
		else {
			if (temp == NULL)
				cout << "Lista je prazna." << endl;
			else {
				for (int i = 1; i < pozicija - 1; i++)
					temp = temp->sled;
			}
			novi->sled = temp->sled;
			temp->sled = novi;
		}
	}
};
void Liste::izbacivanje_istih_brojeva() {
	Liste* ptr_1, * ptr_2, * ponavljac;
	ptr_1 = poc;
	while (ptr_1 && ptr_1->sled) {
		ptr_2 = ptr_1;
		while (ptr_2->sled) {
			if (ptr_1->broj == ptr_2->sled->broj) {
				ponavljac = ptr_2->sled;
				ptr_2->sled = ptr_2->sled->sled;
				delete (ponavljac);
			}
			else
				ptr_2 = ptr_2->sled;
		}
		ptr_1 = ptr_1->sled;
	}
};
void Liste::izbacivanje_prvog_ponavljanja() {
	int n;
	cout << "Unesite broj za izbacivanje prvog pojavljivanja: ";
	cin >> n;
	Liste* ptr1, * prvi;
	ptr1 = poc;
	while (ptr1) {
		if (ptr1->broj == n) {
			poc = ptr1->sled;
			delete ptr1;
			break;
		}
		else if (ptr1->sled->broj == n) {
			prvi = ptr1->sled;
			ptr1->sled = ptr1->sled->sled;
			delete prvi;
			break;
		}
		else {
			ptr1 = ptr1->sled;
		}
	}
};
void Liste::dodavanje_druge_liste() {
	Liste druga_lista;
	cout << "Stvaranje druge liste." << endl;
	druga_lista.citanje();
	Liste* temp = poc;
	while (temp->sled)
		temp = temp->sled;
	temp->sled = druga_lista.poc;
	this->sortiranje();
};
void Liste::izbacivanje_brojeva_druge_liste() {
	Liste druga_lista;
	Liste* temp_1 = poc, * temp_2, * prvi;
	cout << "Stvaranje druge liste" << endl;
	druga_lista.citanje();
	int n = druga_lista.duzina();
	temp_1 = druga_lista.poc;
	while (temp_1->sled)
		temp_1 = temp_1->sled;
	temp_1->sled = druga_lista.poc;
	temp_1 = druga_lista.poc;
	int** niz = new int* [n];
	for (int i = 0; i < n; i++) {
		niz[i] = new int;
		*niz[i] = temp_1->broj;
		temp_1 = temp_1->sled;
	}
	Liste* ptr_1, * ptr_2, * ponavljac;
	ptr_1 = poc;
	while (ptr_1 && ptr_1->sled) {
		ptr_2 = ptr_1;
		while (ptr_2->sled) {
			if (ptr_1->broj == ptr_2->sled->broj) {
				ponavljac = ptr_2->sled;
				ptr_2->sled = ptr_2->sled->sled;
				delete (ponavljac);
			}
			else
				ptr_2 = ptr_2->sled;
		}
		ptr_1 = ptr_1->sled;
	}
	for (int i = 0; i < this->duzina(); i++) {
		ptr_1 = poc;
		while (ptr_1) {
			if (ptr_1->broj == *niz[i]) {
				poc = ptr_1->sled;
				delete ptr_1;
				break;
			}
			else if (ptr_1->sled->broj == *niz[i]) {
				prvi = ptr_1->sled;
				ptr_1->sled = ptr_1->sled->sled;
				delete prvi;
				break;
			}
			else
				ptr_1 = ptr_1->sled;
		}

	}
};
void Liste::broj_ponavljanja_broja() {
	int broj, brojilac = 0;
	cout << "Za koji broj zelite da prebrojite broj ponavljanja?: ";
	cin >> broj;
	Liste* tek = poc;
	while (tek)
	{
		if (tek->broj == broj)
			brojilac++;
		tek = tek->sled;
	}
	cout << "Broj " << broj << " se ponavlja " << brojilac << " puta." << endl;
}
