-------------------------------------------------Cel:----------------------------------------------------------------

	Program słuzy do wyświetlania listy pracownikow i zakładow pracy, oraz czasu pracy pracowników w danym dniu,
Pozwala również na dodawanie:
	a) nowych pracowników,
	b) nowych zakładow pracy,
	c) dodawanie urlopu/delegacji/zwolnienia lekarskiego w wybranym dniu pracy dla wybranego pracownika.
	
-------------------------------------------------Sterowanie:---------------------------------------------------------

	Programem steruje się za pomoca pięciu przyciskow umieszczonych z lewej strony.
po naciśnięciu wyświetlą one odpowiednią kategorię w listview znajdującym się obok,
ponowne naciśnięcie tego samego klawisza powoduje wczytanie/odświerzenie danych w listview.

Dzialanie _Button_4 jest zależne od wybranej kategorii.

-------------------------------------------------Dalsze usprawnienia:------------------------------------------------

	W programie przy wyświetlaniu listy można dodać klasy któras będzie tranformowała dane z bazy danych
na bardziej czytalne np, zamiast wyświetlania id_zakładu w którym pracuje pracownik, będzie wyświetlać 
jego nazwę. 
	Tak samo przy tworzeniu nowego pracownika można zastąpić textbox przyjmujący numer zakładu w którym 
będzie pracował pracownik comboBox-em z którego wybierzemy nazwę zakładu. W przy nadawaniu urlopu z kolei
comboBox-em który będzie wyświetlał imiona i nazwiska pracowników.
	
-------------------------------------------------Często Zadawane Pytania:--------------------------------------------

1)
Q:Dlaczego raz używasz do pobierania z bazy sqlreadera a raz linq?
A:Miałem problemy z bazą danych na komputerze i udało mi sie go rozwiązać 
  dopiero po napisaniu części projektu,a skoro obie metody działają, 
  postanowiłem ich nie zmieniać.

2)
Q:Dlaczego w FAQ jest tylko jedno pytanie?
A:Na razie nie miałem pomysłu na więcej.
