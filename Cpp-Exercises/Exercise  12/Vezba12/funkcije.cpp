#include "funkcije.h"
void Niz::getElement() {
	{
		int n;
		cout << "Unesite indeks elementa: ";
		cin >> n;
		if (n < 1 || n > duz) {
			cout << "Greska.";
			exit(0);
		}
		cout << "Element na poziciji " << n << " je: " << duz_niz[n - 1] << endl;
	}
};
int Niz::duzina_niza() {
	return duz;
}
void Niz::ispisivanje() {
	for (int i = 0; i < duz; i++)
		cout << duz_niz[i] << " ";
	cout << endl;
}
void Niz::citanje() {
	for (int i = 0; i < duz; i++) {
		cout << "Unesite " << i + 1 << ". element: ";
		cin >> duz_niz[i];
	}
}
void Polinom::pisanje() {
	for (int i = 0; i < duz - 1; i++)
		cout << niz_red[i] << " ";
	cout << endl;
};

int Polinom::vred_polinom() {
	int a, p = 0;
	cout << "Unesite promenljivu za izracunavanje vrednosti polinoma: ";
	cin >> a;
	for (int i = 0; i < duz - 1; i++) {
		p += duz_niz[i] * pow(a, niz_red[i]);
	}
	return p;
};
void Polinom::zbir() {
	Polinom broj;
	cout << "Unesite koeficijente drugog polinoma: " << endl;
	broj.citanje_koeficijenata();
	cout << "1. polinom: ";
	int x = this->vred_polinom();
	cout << "2. polinom: ";
	int y = broj.vred_polinom();
	cout << "Vrednost zbira ova dva polinoma je: " << x + y << endl;
}
void Polinom::citanje_koeficijenata() {
	for (int i = 0; i < duz - 1; i++) {
		cout << i + 1 << ". koeficijent: ";
		cin >> duz_niz[i];
	}
}
void Polinom::proizvod() {
	Polinom broj;
	cout << "Unesite koeficijente drugog polinoma: " << endl;
	broj.citanje_koeficijenata();
	cout << "1. polinom: ";
	int x = this->vred_polinom();
	cout << "2. polinom: ";
	int y = broj.vred_polinom();
	cout << "Vrednost zbira ova dva polinoma je: " << x * y << endl;
}
void Veliki::citanje_broja() {
	int brojilac = 0;
	int  broj;
	cin >> broj;
	while (broj > 0) {
		int b, * niz = new int[duz];
		b = broj % 10;
		decimale[brojilac] = b;
		broj /= 10;
		brojilac++;
		duz = brojilac;

	}
	for (int i = 0, j = duz - 1; i < duz / 2; i++, j--)
	{
		int temp;
		temp = decimale[i];
		decimale[i] = decimale[j];
		decimale[j] = temp;
	}
}

void Veliki::pisanje_decimala() {
	for (int i = 0; i < duz; i++)
		cout << decimale[i] << " ";
	cout << endl;
}
double Veliki::sklopi_broj() {
	double broj = 0;
	for (int i = 0; i < this->duz; i++)
		broj += this->decimale[i] * pow(10, this->duz - i - 1);
	return broj;
}
void Veliki::zbir_dva(Veliki& b) {
	double n = 0;
	n = this->sklopi_broj() + b.sklopi_broj();
	cout << "Zbir je: " << n << endl;
}
void Veliki::proizvod_dva(Veliki& b) {
	double n = 0;
	n = this->sklopi_broj() * b.sklopi_broj();
	cout << "Proizvod je: " << n << endl;
}
bool Veliki::operator== (const Veliki& b) const {
	double broj_1 = 0, broj_2 = 0;
	for (int i = 0; i < this->duz; i++)
		broj_1 += this->decimale[i] * pow(10, this->duz - i - 1);
	for (int i = 0; i < b.duz; i++)
		broj_2 += b.decimale[i] * pow(10, b.duz - i - 1);
	if (broj_1 == broj_2)
		return true;
	else
		return false;
}
bool Veliki::operator< (const Veliki& b) const {
	double broj_1 = 0, broj_2 = 0;
	for (int i = 0; i < this->duz; i++)
		broj_1 += this->decimale[i] * pow(10, this->duz- i - 1);
	for (int i = 0; i < b.duz; i++)
		broj_2 += b.decimale[i] * pow(10, b.duz - i - 1);
	if (broj_1 < broj_2)
		return true;
	else
		return false;
}
bool Veliki::operator!= (const Veliki& b) const {
	return !(*this == b);
}
bool Veliki::operator> (const Veliki& b) const {
	return !(*this < b);
}
bool Veliki::operator<= (const Veliki& b) const {
	return (*this < b || *this == b);
}
bool Veliki::operator>= (const Veliki& b) const {
	return (*this > b || *this == b);
}
