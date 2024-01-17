## Stwórz nowy  projekt, który będziemy rozwijać. 

### To będzie baza filmowa. Możemy nazwać go FilmDB.

####  Zadanie 1
 
1. Załóż nowy projekt w serwisie GitHub.
1. Przy tworzeniu nowego projektu dodaj plik `.gitignore` dla Visual Studio.
1. Stwórz nowy projekt .NET Core Web App (Model-View-Controller) `FilmDB`.
1. Wybierz Framework .NET 8.0
1. Wybierz typ uwierzytelniania Individual Accounts.
1. Jeśli to konieczne zainstaluj SQL Express. 

#### Zadanie 2

1. Zajrzyj do folderu Data. Powinna być utworzona migracja, która będzie służyć zaimplementowaniu uwierzytelniania i autoryzacji. 
1. Zaktualizuj (utwórz) bazę danych (komenda `Update-Database` w konsoli Nuget Package Manager).
1. Zobacz tabele utworzone w bazie danych.

#### Zadanie 3
1. Stwórz folder `Models`.
1. Dodaj w tym folderze model `Film`.
1. W modelu utwórz właściwości:
    `ID` typu `int` - klucz główny.
    `Title` typu `string` - tytuł filmu - właściwość musi być wymagana.
    `Year` typu `int` - tekst filmu.
1. W utworzonym automatycznie kontekście utwórz właściwość `DbSet<Film>` o nazwie `Films`.

#### Zadanie 4

1. Utwórz migrację o nazwie `Initial`.
1. Zobacz pliki migracji.
1. Przy pomocy Package Manager Console zaktualizuj bazę danych na podstawie migracji.
1. Zobacz tabelę utworzoną w bazie danych.

#### Zadanie 5

1. Utwórz w projekcie folder `Repositories`.
1. Utwórz w projekcie klasę:
```csharp
public class FilmManager
{
    public FilmManager AddFilm(Film film)
    {
        return this;
    }

    public FilmManager RemoveFilm(int id)
    {
        return this;
    }

    public FilmManager UpdateFilm(Film film)
    {
        return this;
    }

    public FilmManager ChangeTitle(int id, string newTitle)
    {
        return this;
    }

    public FilmManager GetFilm(int id)
    {
        return null;
    }

    public List<Film> GetFilms()
    {
        return null;
    }
}
```
1. W klasie `FilmManager` w metodzie `AddFilm` należy:
    1. Dodać wstrzyknięcie `contextu` w konstruktorze klasy `ApplicationDbContext context`.
	1. Przypisz wstrzyknięty context do prywatnego pola `_context`.
    1. Dodać do kontekstu obiekt typu `Film` przekazany w parametrze metody `AddFilm`.
    1. Obiekt dodajemy wywołując metodę `Add` na właściwości `Films` kontekstu.
    1. Zatwierdzić zmiany wywołując metodę `SaveChanges` na obiekcie kontekstu.
1. W widoku `Index` utwórz obiekt klasy `Film` o nazwie `Film` przypisując do właściwości dowolne dane.
1. Do właściwości `ID` modelu przypisz wartość `1`.
1. Dodaj wstrzyknięcie `contextu` w konstruktorze klasy `ApplicationDbContext context`.
1. Przypisz wstrzyknięty context do prywatnego pola `_context`.
1. Utwórz obiekt klasy `FilmManager` o nazwie `FilmManager` i sprawdź działanie metody `AddFilm` jako argument przekazując obiekt `Film`.
1. Zobaczy typ i komunikat rzuconego wyjątku.
1. Zarejestruj klasę FilmManager w kontenerze DI.

#### Zadanie 6

1. Zmień implementację metody `AddFilm` w następujący sposób:
    1. Złap wyjątki rzucane w momencie wywoływania metody `SaveChanges`.
    1. Gdy złapany zostanie typ wyjątku spowodowany uzupełnieniem właściwości `ID`, do właściwości `ID` przypisz `0` i ponów zapis do bazy wywołując metodę `SaveChanges`.

#### Zadanie 7

1. W klasie `FilmManager` w metodzie `RemoveFilm` należy:
    1. Pobrać obiekt typu `Film` za pomocą metody `Single` lub `SingleOrDefault`. Obiekt pobierz na podstawie właściwości `ID` modelu i parametru metody.
    1. Usunąć pobrany model z bazy przy pomocy metody `Remove`, która powinna być wywołana na właściwość `Films` kontekstu.
    1. Zatwierdzić zmiany metodą `SaveChanges`.
	
#### Zadanie 8

1. W klasie `FilmManager` zmień implementację metody `GetFilm` w następujący sposób:
    1. Pobrać obiekt typu `Film` za pomocą metody `SingleOrDefault`. Obiekt pobierz na podstawie właściwości `ID` modelu i parametru metody.
    

#### Zadanie 9
1. W klasie `FilmManager` w metodzie `ChangeTitle` należy:
    1. Pobrać obiekt typu `Film` za pomocą metody `Single`. Obiekt pobierz na podstawie właściwości `ID` modelu i parametru metody.
    1. Zmodyfikować właściwość `Title`, na wartość `title` z parametru.
    1. Zatwierdź zmiany metodą `SaveChanges`.

#### Zadanie 10

1. Sprawdź działanie metody `ChangeTitle` z argumentem `null` przekazanym w miejsce parametru `newTitle`.
1. Zobacz rzucony wyjątek.
1. Zmień implementację metody w następujący sposób:
    1. Jeśli właściwość `Title` parametru równa się `null` przypisz do właściwości tekst `Brak Tytułu`.

#### Zadanie 11

1. W klasie `FilmManager` w metodzie `UpdateFilm` należy:
    1. Zaktualizować obiekt przekazany w parametrze metody, używając metody `Update` właściwości `Films` kontekstu.
    1. Zatwierdź zmiany metodą `SaveChanges`.

#### Zadanie 12

1. W klasie `FilmManager` zmień implementację metody `GetFilms` w następujący sposób:
    1. Pobrać listę obiektów typu `Film` za pomocą metody `ToList`.


#### Zadanie 13

1. Utwórz widok `AddFilm`.
1. Widok powinien wyświetlać formularz zbudowany na podstawie modelu `AddFilm`.
1. Jeżeli widok został dodany automatycznie upewnij się, że model `Film` ma dodany odpowiedni atrybut mapujący.
1. Jeżeli widok tworzyłeś ręcznie dodaj odpowiedni binding.
1. W widoku w odpowiedniej metodzie obsłuż żądanie, wywoływane metodą http `post` lub zmodyfikuj istniejącą implementację, żeby korzystała z przygotowanego repozytorium.

#### Zadanie 14

1. W widoku `Index` pobierz wszystkie filmy z tabeli `Films`.
1. Filmy przekaż do widoku przez model.
1. W widoku wyświetl listę filmów w tabeli `<table>`.
1. Nad tabelą utwórz link kierujący na akcję `Add`, która pozwoli dodać nowy film.

#### Zadanie 15

1. Utwórz widok o nazwie `RemoveFilm`, który przyjmie parametr typu `int` o nazwie `id`, którym będzie klucz główny filmu do usunięcia.
    1. Logika powinna pobrać film o podanym `id` i przekazać go do widoku przez model.
    1. Wyświetl wszystkie informacje o filmie oraz przycisk z tekstem `Potwierdź Usunięcie`, wykonujące metodę http `post`.
    1. W widoku wyświetl również przycisk pozwalający wrócić do akcji `Index`.
    1. Metoda powinna usuwać encję o podanym `id` z bazy danych.
    1. Przed usunięciem sprawdź czy film o podanym `id` istnieje w bazie.
    1. Po usunięciu filmu akcja powinna przekierować na akcję `Index`.
1. W widoku `Index` przy każdym filmie w tabeli utwórz przycisk kierujący do widoku `RemoveFilm` z `id` danego filmu.

#### Zadanie 16

1. W kontrolerze `Film` utwórz widok o nazwie `EditFilm`:
1. Widok z parametrem `id` typu `int` powinien pobrać film o podanym identyfikatorze i przekazać go do widoku przez model.
1. Wyświetl formularz edycji. Formularz w przeciwieństwie do formularza dodawania powinien również zawierać ukryte pole `ID`.
1. Zapisz edytowany film do bazy.