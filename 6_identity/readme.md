### Identity

## Konfiguracja

#### Zadanie 1

1. Razem z wykładowcą za pomocą scaffoldingu dodaj niezbędne widoki i konfigurację.
1. Ustaw options.SignIn.RequireConfirmedAccount = false. Dzięki temu na razie nie będziemy musieli potwierdzać adresu email.
1. Przetestuj działanie rejestracji i logowania.

## Dostęp do widoków i role

#### Zadanie 2

1. Utwórz stronę o nazwie `AddRole`. Strona będzie dodawała role do użytkownika.
1. Dla strony `Role` ustaw filtr `Authorize`, aby nie był dostępny dla niezalogowanych użytkowników.
1. Odbierz w konstruktorze zarejestrowaną usługę `RoleManager`. W tym celu należy zmodyfikować konfigurację AddDefaultIdentity.
`
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<FilmContext>();
` 
1. W layout utwórz link kierujący na stronę `AddRole`. Link ma być dostępny tylko dla zalogowanych użytkowników.
1. Strona ma wyświetlać formularz typu `post` z polem tekstowym na nazwę roli, która zostanie dodana.
1. Obsłuż żądanie typu `post` z formularza. Metoda powinna przyjmować parametr typu `string` z nazwą roli.
1. Dodaj rolę wykorzystując usługę `RoleManager` i odpowiednią metodę. Gdy rola zostanie dodana pomyślne zrób przekierowanie na stronę główną w przeciwnym wypadku zwróć komunikat z błędem.

#### Zadanie 2

1. Utwórz stronę o nazwie `RemoveRole`.
1. Widok powinien wyświetlać pole typu dropdown z listą ról w systemie oraz przyciskiem pozwalającym usunąć rolę.
1. Formularz powinien kierować na metodę typu `post`, która usunie rolę.
1. W przypadku pomyślnego usunięcia roli zrób przekierowanie na stronę główną, w przeciwnym przypadku zwrócić błąd.

#### Zadanie 3

1. Utwórz stronę `ListRoles` i wyświetl listę wszystkich ról w systemie.
1. Nad listą utwórz link do strony `AddRole`.
1. Na liście przy każdej pozycji utwórz link do widoku `RemoveRole`. Link `RemoveRole` powinien zawierać `ID` roli.

#### Zadanie 4

1. Przy każdym wierszu na liście ról utwórz link do widoku `EditRole`. Link powinien zawierać `ID` roli.
1. Analogicznie do zadania z dodawaniem nowych ról utwórz widok `EditRole`, który pozwoli na edytowanie ról.

#### Zadanie 5

1. Utwórz widok `AddToRole`.
1. Widok powinien zawierać formularz z dwoma elementami typu dropdown:
    1. Pierwsze powinno wyświetlić listę wszystkich użytkowników w systemie.
    1. Drugie powinno wyświetlić listę wszystkich ról w systemie.
1. Po wybraniu użytkownika i roli formularz powinien zostać wysłany na metodę obsługującą żądania typu `post`, która przyjmie identyfikator użytkownika oraz roli i doda użytkownika do roli.
1. W przypadku pomyślnego dodania użytkownika do roli zrób przekierowanie do widoku wszystkich ról i wyświetl odpowiedni komunikat. W przeciwnym przypadku wróć do formularza dodawania i wyświetl błędy.

#### Zadanie 6

1. Zmień widok główny, tak, aby wyświetlał login i role zalogowanego użytkownika.

#### Zadanie 7

1. Do programu dodaj rolę `Admin`.
1. Nadaj tę rolę dla swojego wybranego użytkownika.
1. W widokach związanych z zarządzaniem rolami Zmodyfikuj atrybut Authorize w taki sposób, aby dawał dostęp wyłącznie użytkownikom w roli `Admin`.
1. Przetestuj dostęp na dwóch różnych użytkownikach, z rolą `Admin` i bez tej roli.

#### Zadanie 8

1. Zmodyfikuj kod w ten sposób, żeby usunać film, gatunek lub aktora mogła tylko osoba o roli `Admin` a edytować osoba o roli `Admin` lub `Moderator`.