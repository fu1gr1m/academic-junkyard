#include "funkcije.h"
#include <cmath>
void datumi::stvaranje(int d, int m, int g) {
	dan = d;
	mesec = m;
	godina = g;
}


bool datumi::prestupna() {
	if ((godina % 4 == 0) && (godina % 100 != 0) || (godina % 400 == 0)) {
		return true;
	}
	else {
		return false;
	}
}

void datumi::broj_dana_mesec() {
	switch (mesec) {
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		cout << "Mesec ima 31 dan." << endl;
		break;
	case 4: case 6: case 9: case 11:
		cout << "Mesec ima 30 dana." << endl;
		break;

	case 2:
		if ((godina % 4 == 0) && (godina % 100 != 0) || (godina % 400 == 0)) {
			cout << "Godina je prestupna, time mesec ima 29 dana." << endl;
		}
		else {
			cout << "Mesec ima 28 dana." << endl;
		}
		break;
	}
}

void datumi::broj_dana_godina() {
	int i = 0;
	int trenutni_mesec = 1;
	for (trenutni_mesec = 1; trenutni_mesec < mesec; trenutni_mesec++) {
		switch (trenutni_mesec) {
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			i += 31;
			break;
		case 4: case 6: case 9: case 11:
			i += 30;
			break;
		case 2:
			if ((godina % 4 == 0) && (godina % 100 != 0) || (godina % 400 == 0)) {
				i += 29;
			}
			else {
				i += 28;
			}
			break;
		}
	}
}

void datumi::povecavanje_za_jedan() {
	dan++;
	switch (mesec) {
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		if (dan > 31) {
			mesec++;
			if (mesec > 12) {
				godina++;
			}
		}
		break;
	case 4: case 6: case 9: case 11:
		if (dan > 31) {
			mesec++;
		}
		break;
	case 2:
		if ((godina % 4 == 0) && (godina % 100 != 0) || (godina % 400 == 0)) {
			if (dan > 29) {
				mesec++;
			}
		}
		else {
			if (dan > 28) {
				mesec++;
			}
		}
		break;
	}
}

void datumi::smanjivanje_za_jedan() {
	dan--;
	if (dan <= 0) {
		mesec--;
		if (mesec <= 0) {
			godina--;
		}
	}
	switch (mesec) {
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		dan = 31;
		break;
	case 4: case 6: case 9: case 11:
		dan = 30;
		break;
	case 2:
		if ((godina % 4 == 0) && (godina % 100 != 0) || (godina % 400 == 0)) {
			dan = 29;
		}
		else {
			dan = 28;
		}
		break;
	}
}

void datumi::dodavanje_oduzimanje_broja() {
	char c, v;
	while (1) {
		cout << "Da li zelite dodati ili oduzeti broj, napisite + ili -: ";
		cin >> c;
		switch (c) {
			case '+':
				dan++;
				switch (mesec) {
				case 1: case 3: case 5: case 7: case 8: case 10: case 12:
					if (dan > 31) {
						mesec++;
						if (mesec > 12) {
							godina++;
						}
					}
					break;
				case 4: case 6: case 9: case 11:
					if (dan > 31) {
						mesec++;
					}
					break;
				case 2:
					if ((godina % 4 == 0) && (godina % 100 != 0) || (godina % 400 == 0)) {
						if (dan > 29) {
							mesec++;
						}
					}
					else {
						if (dan > 28) {
							mesec++;
						}
					}
					break;
				}
				break;
			case '-':
				dan--;
				if (dan <= 0) {
					mesec--;
					if (mesec <= 0) {
						godina--;
					}
				}
				switch (mesec) {
				case 1: case 3: case 5: case 7: case 8: case 10: case 12:
					dan = 31;
					break;
				case 4: case 6: case 9: case 11:
					dan = 30;
					break;
				case 2:
					if ((godina % 4 == 0) && (godina % 100 != 0) || (godina % 400 == 0)) {
						dan = 29;
					}
					else {
						dan = 28;
					}
					break;
				}
				break;
		}

		cout << "Da li zelite da nastavite sa ovom operacijom?(D/N)";
		cin >> v;
		if (v == 'D') {
			continue;
		}
		else if (v == 'N') {
			break;
		}
		else {
			break;
		}
	}


}

bool datumi::uporedjivanje(datumi dtm1, datumi dtm2) {
	if (dtm1.godina > dtm2.godina) {
		return true;
	}
	else if (dtm1.godina < dtm2.godina) {
		return false;
	}
	else {
		if (dtm1.mesec > dtm2.mesec) {
			return true;
		}
		else if (dtm1.mesec < dtm2.mesec) {
			return false;
		}
		else {
			if (dtm1.dan > dtm2.dan) {
				return true;
			}
			else if (dtm1.dan < dtm2.dan) {
				return false;
			}
			else {
				cout << "Datumi se podudaraju." << endl;
			}
		}
	}
}

void datumi::citanje() {
	int d, m, g;
	cout << "Unesite godinu: ";
	cin >> g;
	cout << "Unesite mesec: ";
	cin >> m;
	cout << "Unesite dan: ";
	cin >> d;
	switch (m) {
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		if (d > 31) {
			m++;
			d = 1;
			if (m > 12) {
				g++;
				m = 1;
			}
		}
		break;
	case 4: case 6: case 9: case 11:
		if (d > 30) {
			m++;
			d = 1;
		}
		break;
	case 2:
		if ((g % 4 == 0) && (g % 100 != 0) || (g % 400 == 0)) {
			if (d > 29) {
				m++;
				d = 1;
			}
		}
		else {
			if (d > 28) {
				m++;
				d = 1;
			}
		}
		break;
	}
	dan = d;
	mesec = m;
	godina = g;
}

void datumi::pisanje() {
	cout << dan << "." << mesec << "." << godina << "." << endl;
}

int datumi::odredjivanje() {
	int d = dan, m = mesec, g = godina;

	d--;
	m--;
	g--;
	if (m <= 0) {
		m = 12;
		g--;
	}
	if (d <= 0) {
		m--;
		switch (m) {
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			d += 31;
			break;
		case 4: case 6: case 9: case 11:
			d += 30;
			break;
		case 2:
			if ((g % 4 == 0) && (g % 100 != 0) || (g % 400 == 0)) {
				d += 29;
			}
			else {
				d += 28;
			}
			break;
		}
		if (m <= 0) {
			g--;
		}
	}
	switch (m) {
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		d += 31;
		break;
	case 4: case 6: case 9: case 11:
		d += 30;
		break;
	case 2:
		if ((g % 4 == 0) && (g % 100 != 0) || (g % 400 == 0)) {
			d += 29;
		}
		else {
			d += 28;
		}
		break;
	}

	while (g > 0) {
		if ((g % 4 == 0) && (g % 100 != 0) || (g % 400 == 0)) {
			d += 366;
			g--;
		}
		else {
			d += 365;
			g--;
		}
	}

	while (m > 0) {
		switch (m) {
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			d += 31;
			m--;
			break;
		case 4: case 6: case 9: case 11:
			d += 30;
			m--;
			break;

		case 2:
			if ((g % 4 == 0) && (g % 100 != 0) || (g % 400 == 0)) {
				d += 29;
				m--;
			}
			else {
				d += 28;
				m--;
			}
			break;
		}
	}
	return d;
}

int datumi::izmedju_dva_datuma(datumi dtm1, datumi dtm2) {
	int d1, m1, g1;
	int d2, m2, g2;
	int dani;
	d1 = dtm1.dan; m1 = dtm1.mesec; g1 = dtm1.godina;
	d2 = dtm2.dan; m2 = dtm2.mesec; g2 = dtm2.godina;

	while (g1 > 0) {
		if ((g1 % 4 == 0) && (g1 % 100 != 0) || (g1 % 400 == 0)) {
			d1 += 366;
			g1--;
		}
		else {
			d1 += 365;
			g1--;
		}
	}

	while (m1 > 0) {
		switch (m1) {
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			d1 += 31;
			m1--;
			break;
		case 4: case 6: case 9: case 11:
			d1 += 30;
			m1--;
			break;

		case 2:
			if ((g1 % 4 == 0) && (g1 % 100 != 0) || (g1 % 400 == 0)) {
				d1 += 29;
				m1--;
			}
			else {
				d1 += 28;
				m1--;
			}
			break;
		}
	}

	while (g2 > 0) {
		if ((g2 % 4 == 0) && (g2 % 100 != 0) || (g2 % 400 == 0)) {
			d2 += 366;
			g2--;
		}
		else {
			d2 += 365;
			g2--;
		}
	}

	while (m2 > 0) {
		switch (m2) {
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			d2 += 31;
			m2--;
			break;
		case 4: case 6: case 9: case 11:
			d2 += 30;
			m2--;
			break;

		case 2:
			if ((g2 % 4 == 0) && (g2 % 100 != 0) || (g2 % 400 == 0)) {
				d2 += 29;
				m2--;
			}
			else {
				d2 += 28;
				m2--;
			}
			break;
		}
	}

	dani = abs(d1 - d2);
	return dani;
}

void datumi::podesavanje_formata_ispisivanja() {
	char b;
	cout << "Da li zelite da ispisete mesece brojevima ili slovima (B/S):";
	cin >> b;
	switch (b) {
		case 'S':
			switch (mesec) {
				case 1:
					cout << dan << "." << "Januar" << "." << godina;
					break;
				case 2:
					cout << dan << "." << "Februar" << "." << godina;
					break;
				case 3:
					cout << dan << "." << "Mart" << "." << godina;
					break;
				case 4:
					cout << dan << "." << "April" << "." << godina;
					break;
				case 5:
					cout << dan << "." << "Maj" << "." << godina;
					break;
				case 6:
					cout << dan << "." << "Jun" << "." << godina;
					break;
				case 7:
					cout << dan << "." << "Jul" << "." << godina;
					break;
				case 8:
					cout << dan << "." << "Avgust" << "." << godina;
					break;
				case 9:
					cout << dan << "." << "Septembar" << "." << godina;
					break;
				case 10:
					cout << dan << "." << "Oktobar" << "." << godina;
					break;
				case 11:
					cout << dan << "." << "Novembar" << "." << godina;
					break;
				case 12:
					cout << dan << "." << "Decembar" << "." << godina;
					break;
			}
		case 'B':
			cout << dan << "." << mesec << "." << godina << "." << endl;
			break;
	}



}