using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EXAMEN_FP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lista_Numere();
            //Problema2();
            //Problema3();
            Problema4(); //facuta fara fisiere
            //Problema5();
        }

        private static void Problema5()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("T = ");
            int T = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                if(arr[i] == T)
                    Console.WriteLine($"Prima aparitie a elementului {T} in vector este pe pozitia {i}");
            }

        }

        private static void Problema4()
        {
            Console.Write("n = ");
            int numar;
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            int[] cifre = new int[n];
            for (int i = 0; i < n; i++)
            {
                numar = int.Parse(Console.ReadLine());
                v[i] = numar;
                cifre[i] = sumacifre(numar);

            }
            Console.WriteLine(1);
            int aux = 0;
            for (int i = 0; i < n; i++)
            {
                int j = i;
                while (j > 0 && cifre[j - 1] > cifre[j])
                {
                    aux = v[j];
                    v[j] = v[j - 1];
                    v[j-1] = aux;
                    aux = cifre[j];
                    cifre[j] = cifre[j - 1];
                    cifre[j] = aux;
                    j++;
                }
            }
            Console.WriteLine(2);
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} , ");
            }
            
        }

        private static int sumacifre(int numar)
        {
            int suma = 0;
            while (numar != 0)
            {
                suma += numar % 10;
                numar /= 10;
            }
            return suma;
        }

        private static void Problema3()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[,] v = new int[n, n];
            citireMatrice(v, n); //functie care citeste elementele din matrice
            int sumapozitiva = deasupraDP_DS(v, n); // functia care returneaza suma elementelor pozitive de deasupra diag P si S
            Console.WriteLine($"sp = {sumapozitiva}");
            int sumanegativa = subDP_DS(v, n); //functia care returneaza suma elementelor negative de desuptul diag P si S
            Console.WriteLine($"sn = {sumanegativa}");
            int diferenta = sumapozitiva - sumanegativa; //diferenta dintre cele doua sume
            Console.WriteLine(diferenta);
        }

        private static int subDP_DS(int[,] v, int n)
        {
            int suma = 0;
            for (int i = n - 1 ; i >= n/2; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (i != j && i + j > n-1)
                    {
                        if (v[i, j] < 0)
                        {
                            suma += v[i, j];
                            Console.WriteLine($"elementul v[{i},{j}]= {v[i, j]}");
                        }

                    }
                }
            }
            return suma;
        }

        private static int deasupraDP_DS(int[,] v, int n)
        {
            int suma = 0;
            for (int i = 0; i < n/2; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (i != j && i + j < n-1)
                    {
                        if (v[i, j] >= 0)
                        {
                            suma += v[i, j];
                            Console.WriteLine($"elementul v[{i},{j}]= {v[i,j]}");
                        }

                    }
                }
            }
            return suma;
        }

        private static void citireMatrice(int[,] v, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"v[{i},{j}] = ");
                    v[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        private static void Problema2()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int suma =SumaDivizoriPrimi(n);
            Console.WriteLine(suma);
        }

        private static int SumaDivizoriPrimi(int n)
        {
            int s = 0;
            int numar = n; //salvam numarul n sa nu strice conditia for-ului in momentul impartirii la i (36)
            for (int i = 2; i <= numar/2; i++) //divizorii incep de la 2 pana la jumatatea numarului
            {
                if (n % i == 0) //daca numarul n se imparte
                {
                    s += i; //adunam divizoru la suma
                    while (n % i == 0)
                    {
                        n /= i;
                    }
                }
            }
            if (numar == 1) //caz particular! 
                s = 1;
            return s;//returnam suma
        }

        private static void Lista_Numere()
        {
            int max1 = int.MinValue; //cel mai mare numar
            int max2 = int.MinValue; //al 2 lea cel mai mare numar
            int max3 = int.MinValue; //al 3 lea cel mai mare numar
            int count = 0; // numara cate numere au fost introduse de la tastatura
            int obs = 0; //o variabila care sa termine whileul dupa ce un numar a trecut prin if
            int numar = int.Parse(Console.ReadLine());
            while (numar != 0)
            {
                obs = 0;
                if (numar >= max1 && obs == 0)
                {
                    max3 = max2; //pentru a nu pierde valoarea din max1, valoarea lui se pastreaza in max2 care este pastrat in max3
                    max2 = max1;
                    max1 = numar;
                    obs++;
                }
                if (numar >= max2 && obs == 0)
                {
                    max3 = max2;
                    max2 = numar;
                    obs++;
                }
                if (numar >= max3 && obs == 0)
                {
                    max3 = numar;
                    obs++;
                }
                numar = int.Parse(Console.ReadLine());
                count++;
            }
            if (count < 3)
            {
                if (max1 != int.MinValue)
                    Console.Write($"{max1} ");

                if (max2 != int.MinValue)
                    Console.Write($"{max2} ");

                if (max3 != int.MinValue)
                    Console.Write($"{max3} ");
                Console.WriteLine();
            }
            if (count > 3)
            {
                Console.WriteLine($"{max1} {max2} {max3}");
            }
            if(count == 0)
            {
                Console.WriteLine(0);
            }
                

        }
    }
}
