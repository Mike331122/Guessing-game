using System;

namespace Guessing_game
{
    class Program
    {
        static int numb_pla;
        static int i = 0;
        static string imie;
        static int numb_max = 20;
        static int numb_min = 0;
        static int[] numbers = new int[numb_max];
        static int quantity;
        static void Main(string[] args)
        {
            Introduction();
            Setting();
        }

        static void ColorsWrite(ConsoleColor color, string write, char line = 'y')
        {
            
            Console.ForegroundColor = color;
            switch (line)
            {
                case 'y':
                    Console.Write($"\n{write}");
                    break;
                case 'n':
                    Console.Write($"{write}");
                    break;
            }
            
            Console.ResetColor();
        }

        static void ColorsLine(ConsoleColor color, string write, char line = 'y')
        {

            Console.ForegroundColor = color;

            switch (line)
            {
                case 'y':
                    Console.WriteLine($"\n{write}");
                    break;
                case 'n':
                    Console.WriteLine($"{write}");
                    break;
            }
            
            Console.ResetColor();
        }

        static void Introduction()
        {

            ColorsWrite(ConsoleColor.Blue, "Wprowadź swoje imię : ");
            imie = Console.ReadLine();
            Console.Clear();

        }

        static int Asking()
        {
            int set = 0;

            ColorsLine(ConsoleColor.Gray, $"{imie} wybierz scenariusz gry.");
            ColorsLine(ConsoleColor.Cyan, "1. Zgaduj liczbę dopóki nie wygrasz, w zakresie od 0 do 20 liczb.");
            ColorsLine(ConsoleColor.DarkBlue, "2. Zgaduj dopóki nie wygrasz, samemu ustalając zakres.");
            ColorsLine(ConsoleColor.DarkCyan, "3. Posiadasz 5 prób w zakresie od 0 do 20 liczb.");
            ColorsLine(ConsoleColor.DarkMagenta, "4. Samemu ustalasz ilość prób oraz zakres liczb.");
            
            set = Checking("Wprowadź scenariusz :");

            return set;
        }

        static void Setting()
        {
            int set = Asking();

            switch (set)
            {
                case 1:
                    Console.Clear();
                    ColorsLine(ConsoleColor.Red, $"Witaj {imie}. Wybrałeś scenariusz nr : {set}. Mam w głowie pewną specyficzną liczbę, wiesz jaką ?");

                    Game1();
                    break;
                case 2:
                    Console.Clear();
                    ColorsLine(ConsoleColor.Red, $"Witaj {imie}. Wybrałeś scenariusz nr : {set}. Mam w głowie pewną specyficzną liczbę, wiesz jaką ?");

                    Range();
                    Game2();
                    break;
                case 3:
                    Console.Clear();
                    ColorsLine(ConsoleColor.Red, $"Witaj {imie}. Wybrałeś scenariusz nr : {set}. Mam w głowie pewną specyficzną liczbę, wiesz jaką ?");

                    Game3();
                    break;
                case 4:
                    Console.Clear();
                    ColorsLine(ConsoleColor.Red, $"Witaj {imie}. Wybrałeś scenariusz nr : {set}. Mam w głowie pewną specyficzną liczbę, wiesz jaką ?");
                    
                    Range();
                    quantity = Quantity();
                    Game4();
                    break;
                default:
                    Console.Clear();
                    ColorsLine(ConsoleColor.Red, $"{imie} wprowadzone przez ciebie dane nie pasują do żadnego scenariusza. ");

                    Asking();
                    break;
            }
        }

        static void DownNumber()
        {
           
            string numb_var;
            bool var_correct = true;

            while (var_correct)
            {
                ColorsWrite(ConsoleColor.DarkGreen, "Podaj liczbę :");

                numb_var = Console.ReadLine();

                try
                {
                    numb_pla = Convert.ToInt32(numb_var);
                    if (numb_pla > numb_max)
                    {
                        ColorsLine(ConsoleColor.Red, "Wprowadzona liczba przekracza górną granicę!\nWprowadź inną liczbę.");
                        
                    }
                    else if(numb_pla < numb_min)
                    {
                        ColorsLine(ConsoleColor.Red, "Wprowadzona liczba przekracza dolną granicę!\nWprowadź inną liczbę.");
                    }
                    else
                    {
                        var_correct = false;
                    }
                }
                catch (FormatException)
                {
                    ColorsLine(ConsoleColor.Red, "Wprowadzone dane Nie są liczbą!\nWprowadź liczbę");
                    continue;
                }
            }

            i++;

            Console.Clear();

        }

        static int ExcNumbMax()
        {
            int exc = 0;
            string check;
            bool var_correct = true;

            while (var_correct)
            {

                ColorsWrite(ConsoleColor.DarkGreen, "Podaj maksymalną granicę (Powinna być conajmniej 10 większa od minimalnej) :");

                check = Console.ReadLine();

                try
                {
                    exc = Convert.ToInt32(check);
                    if(exc > (numb_min + 9))
                    {
                        var_correct = false;
                    }
                    else
                    {
                        ColorsLine(ConsoleColor.Red, "Wprowadzona liczba jest mniejsza od minimalnej granicy albo jest zbyt mała aby móc rozpocząć gre!\nSpróbuj ponownie.");
                    }                  
                }
                catch (FormatException)
                {
                    ColorsLine(ConsoleColor.Red, "Wprowadzone dane nie są liczbą!\nSpróbuj ponownie.");
                    continue;
                }
            }

            return exc;
        }

        static int ExcNumbMin()
        {
            int exc;
            
            exc = Checking("Podaj minimalną granicę :");

            return exc;
        }

        static void AllNumbers()
        {
            numbers[i - 1] = numb_pla;

            ColorsWrite(ConsoleColor.Gray, "Używane liczby : ");

            for (int j = 0; j < i; j++)
            {
                if (j == (numbers.Length - 1))
                {
                    ColorsWrite(ConsoleColor.Gray, $"{numbers[j]} ", 'n');
                }
                else
                {
                    ColorsWrite(ConsoleColor.Gray, $"{numbers[j]}, ", 'n');


                }
            }
        }

        static void Range()
        {
            Console.Clear();

            ColorsLine(ConsoleColor.Yellow, "Podaj zakres liczb w których chcesz zgadywać.");

            numb_min = ExcNumbMin();
            numb_max = ExcNumbMax();

            Console.Clear();
            ColorsLine(ConsoleColor.Yellow, $"Wybrałeś zakres liczb od {numb_min} do {numb_max}");
        }

        static int Quantity()
        {
            int quantity = 1;
            bool var_correct = true;

            while (var_correct)
            {
                ColorsWrite(ConsoleColor.Yellow, "Podaj ilość prób :");

                try
                {
                    quantity = Convert.ToInt32(Console.ReadLine());

                    if(quantity <= 0)
                    {
                        ColorsLine(ConsoleColor.Red, "Nie można odpalić gry gdy nie ma prób.");
                        
                    }
                    else
                    {
                        var_correct = false;
                    }                  
                }
                catch (FormatException)
                {
                    ColorsLine(ConsoleColor.Red, "Wprowadzone dane nie są liczbą!\nSpróbuj ponownie.");
                    continue;
                }
            }

            return quantity;
        }

        static int Checking( string write)
        {
            bool var_correct = true;
            int number = 0;
            string check;

            while (var_correct)
            {
                ColorsWrite(ConsoleColor.Yellow, write);

                check = Console.ReadLine();

                try
                {
                    number = Convert.ToInt32(check);

                    var_correct = false;

                }
                catch (FormatException)
                {
                    ColorsLine(ConsoleColor.Red, "Wprowadzone dane nie są liczbą!\nSpróbuj ponownie.");
                    continue;
                }
            }

            return number;
        }

        static char Checking1(string write)
        {
            bool var_correct = true;
            char answer = 'N';
            string check;

            while (var_correct)
            {
                ColorsWrite(ConsoleColor.Yellow, write);

                check = Console.ReadLine();

                try
                {
                    answer = Convert.ToChar(check);

                    var_correct = false;

                }
                catch (FormatException)
                {
                    ColorsLine(ConsoleColor.Red, "Odpowiedź nie jest pojedynczą literą!\nSpróbuj ponownie.");
                    continue;
                }
            }

            return answer;
        }

        static void Game(int numb_comp)
        {

            bool koniec_gry = true;

            while (koniec_gry)
            {
                if (numb_comp == numb_pla)
                {
                    ColorsLine(ConsoleColor.Green, "Wygrałeś");

                    koniec_gry = false;

                }
                else if (numb_pla < numb_comp)
                {
                    AllNumbers();
                    ColorsLine(ConsoleColor.Red, "Za mała");
                    DownNumber();
                }
                else
                {
                    AllNumbers();
                    ColorsLine(ConsoleColor.Red, "Za duża");
                    DownNumber();
                }
            }

            ColorsLine(ConsoleColor.Yellow, $"Poprawną odpowiedź podałeś przy {i} próbie");

            Resault();
        }

        static void Game(int numb_comp, int j)
        {

            bool koniec_gry = true;

            while (koniec_gry)
            {               
                if (i == j)
                {
                    if (numb_comp == numb_pla)
                    {
                        ColorsLine(ConsoleColor.Green, "Wygrałeś");

                        koniec_gry = false;
                    }
                    else
                    {
                        ColorsLine(ConsoleColor.Red, "Przegrałeś!\nPrzekroczyłeś limit dozwolonych prób.");

                        koniec_gry = false;
                    }                 
                }
                else if (numb_comp == numb_pla)
                {
                    ColorsLine(ConsoleColor.Green, "Wygrałeś");

                    koniec_gry = false;
                }
                else if (numb_pla < numb_comp)
                {
                    AllNumbers();
                    ColorsLine(ConsoleColor.Red, "Za mała");
                    DownNumber();
                }
                else if (numb_pla > numb_comp)
                {
                    AllNumbers();
                    ColorsLine(ConsoleColor.Red, "Za duża");
                    DownNumber();
                }
            }

            ColorsLine(ConsoleColor.Yellow, $"Poprawną odpowiedź podałeś przy {i} próbie");

            Resault();
        }

        static void Game1()
        {
            int numb_comp;
            Random r = new Random();

            DownNumber();
            numb_comp = r.Next(0, 21);

            Game(numb_comp);

        }

        static void Game2()
        {  
            int numb_comp;
            Random r = new Random();

            DownNumber();
            numb_comp = r.Next(numb_min, numb_max);

            Game(numb_comp);

        }

        static void Game3()
        {
            int numb_comp;
            Random r = new Random();

            DownNumber();
            numb_comp = r.Next(0, 21);

            Game(numb_comp, 5);

        }

        static void Game4()
        {
            int numb_comp;
            Random r = new Random();

            DownNumber();
            numb_comp = r.Next(numb_min, numb_max);

            Game(numb_comp, quantity);

        }

        static void Resault()
        {
            char answer;
            bool var_correct = true;

            while (var_correct)
            {
                ColorsLine(ConsoleColor.Green, "Czy chcesz kontynuować rozgrywkę ? (Y/N)");
                answer = Checking1("Podaj odpowiedź :");

                switch (answer)
                {
                    case 'Y':
                        Console.Clear();

                        Array.Clear(numbers, 0, numbers.Length);

                        i = 0;
                        numb_min = 0;
                        numb_max = 20;

                        Setting();
                        var_correct = false;
                        break;
                    case 'y':
                        Console.Clear();

                        Array.Clear(numbers, 0, numbers.Length);

                        i = 0;
                        numb_min = 0;
                        numb_max = 20;

                        Setting();
                        var_correct = false;
                        break;
                    case 'N':
                        Console.Clear();

                        var_correct = false;
                        break;
                    case 'n':
                        Console.Clear();

                        var_correct = false;
                        break;
                    default:
                        ColorsLine(ConsoleColor.Red, "Wprowadzono zły znak.\nSpróbuj jeszcze raz.");

                        continue;     
                }
            }
        }
    }
}
