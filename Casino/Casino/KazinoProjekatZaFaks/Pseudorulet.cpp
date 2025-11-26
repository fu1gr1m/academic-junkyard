#include "Pseudorulet.h"
void Pseudorulet::generisanje_nasumicnog_broja() {
	srand(time(nullptr));
	krajnji_ishod = rand() % 37;
};

bool Pseudorulet::da_li_je_paran() {
	return krajnji_ishod % 2 == 0;
}

void Pseudorulet::odredi_boju() {
    if (krajnji_ishod >= 1 && krajnji_ishod <= 10) {
        if (krajnji_ishod % 2 == 1) {
            boja = 'r';
        }
        else {
            boja = 'c';
        }
    }
    else if (krajnji_ishod >= 11 && krajnji_ishod <= 18) {
        if (krajnji_ishod % 2 == 0) {
            boja = 'r';
        }
        else {
            boja = 'c';
        }
    }
    else if (krajnji_ishod >= 19 && krajnji_ishod <= 28) {
        if (krajnji_ishod % 2 == 1) {
            boja = 'r';
        }
        else {
            boja = 'c';
        }
    }
    else if (krajnji_ishod >= 29 && krajnji_ishod <= 36) {
        if (krajnji_ishod % 2 == 0) {
            boja = 'r';
        }
        else {
            boja = 'c';
        }
    }
}

void Pseudorulet::broj_u_nizu(int num) {
    krajnji_ishod += num;
}

void Pseudorulet::pocetak_igre_pseudorulet(Igrac& igrac, Skor& skor) {
    cout << "Pseudorulet igra." << endl;
    while (1) {
        int choice;
        char b, choice_char;
        Kazino kazino;
    restart:
        cout << "Opcije ruleta..." << endl;
        cout << "1. Parne." << endl;
        cout << "2. Neparne. " << endl;
        cout << "3. Na boju." << endl;
        cout << "4. Vas skor." << endl;
        cout << "5. Izlaz." << endl;
        cin >> choice;
        if (cin.fail() || choice > 5 || choice < 1) {
            cin.clear();
            cin.ignore();
            goto restart;
        }
        switch (choice) {
        case 1:
            generisanje_nasumicnog_broja();
            if (da_li_je_paran() == true) {
                skor.rezultat_rulet += 1;
                igrac.balans += 1;
                cout << "Pogodili ste! Budzet i skor su vam uvecani za 1." << endl;
                kazino.budzet -= 1;
            }
            else {
                cout << "Broj nije paran. Balans i skor su vam je umanjeni za 1." << endl;
                skor.rezultat_rulet -= 1;
                igrac.balans -= 1;
                kazino.budzet += 1;
            }
            break;
        case 2:
            generisanje_nasumicnog_broja();
            if (da_li_je_paran() == false) {
                skor.rezultat_rulet += 1;
                igrac.balans += 1;
                cout << "Pogodili ste! Balans i skor su vam uvecani za 1." << endl;
                kazino.budzet -= 1;
            }
            else {
                cout << "Broj nije paran. Balans i skor su vam je umanjeni za 1." << endl;
                skor.rezultat_rulet -= 1;
                igrac.balans -= 1;
                kazino.budzet += 1;
            }
            break;
        case 3:
            while (1) {
            restart_2:
                cout << "Na koju boju zelite da igrate?(c/r) ";
                cin >> b;
                if (cin.fail()) {
                    cin.clear();
                    cin.ignore();
                    cout << "Nije unesena dobra vrednost!" << endl;
                    goto restart_2;
                }
                switch (b) {
                case 'r':
                    generisanje_nasumicnog_broja();
                    odredi_boju();
                    if (b == boja) {
                        cout << "Pogodili ste! Balans vam je uvecan za 1." << endl;
                        skor.rezultat_rulet += 1;
                        igrac.balans += 1;
                        kazino.budzet -= 1;
                        cout << "Da li zelite da nastavite da igrate?(d/n) " << endl;
                        cin >> choice_char;
                        if (choice_char == 'd') {
                            continue;
                        }
                        else {
                            goto restart;
                        }
                    }
                    else {
                        cout << "Niste pogodili boju. Balans vam je umanjen za 1." << endl;
                        skor.rezultat_rulet -= 1;
                        igrac.balans -= 1;
                        kazino.budzet += 1;
                        cout << "Da li zelite da nastavite da igrate?(d/n) " << endl;
                        cin >> choice_char;
                        if (choice_char == 'd') {
                            continue;
                        }
                        else {
                            goto restart;
                        }
                    }
                    break;
                case 'c':
                    generisanje_nasumicnog_broja();
                    odredi_boju();
                    if (b == boja) {
                        cout << "Pogodili ste! Balans vam je uvecan za 1." << endl;
                        skor.rezultat_rulet += 1;
                        igrac.balans += 1;
                        kazino.budzet -= 1;
                        cout << "Da li zelite da nastavite da igrate?(d/n) " << endl;
                        cin >> choice_char;
                        if (choice_char == 'd') {
                            continue;
                        }
                        else {
                            goto restart;
                        }
                    }
                    else {
                        cout << "Niste pogodili boju. Balans vam je umanjen za 1." << endl;
                        skor.rezultat_rulet -= 1;
                        igrac.balans -= 1;
                        kazino.budzet += 1;
                        cout << "Da li zelite da nastavite da igrate?(d/n) " << endl;
                        cin >> choice_char;
                        if (choice_char == 'd') {
                            continue;
                        }
                        else {
                            goto restart;
                        }
                    }
                    break;
                }
            }
            break;
        case 4:
            cout << "Vas skor u ruletu iznosi: " << skor.rezultat_rulet << endl;
            break;
        case 5:
            return;
            break;
        }
    }
}

void Pseudorulet::postavi_ponisti_broj(int index, bool vrednost) {
    polja_igrac[index] = vrednost;
}

void Pseudorulet::postavi_boju(char nova_boja) {
    boja *= nova_boja;
}

void Pseudorulet::postavi_paran_broj(bool vrednost) {
    parni_broj = vrednost;
}

void Pseudorulet::postavi_balans(Igrac& igrac, Skor& skor, bool vrednost) {
    if (vrednost == true) {
        igrac.balans += 1;
        skor.rezultat_rulet += 1;
    }
    else {
        igrac.balans -= 1;
        skor.rezultat_rulet -= 1;
    }
}
