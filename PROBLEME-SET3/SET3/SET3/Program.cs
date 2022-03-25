using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET3
{
    class Program
    {
        static void Main(string[] args)
        {
            //p1();
            //p2();
            //p3();
            //p4();
            //p5();
            //p6();
            //p7();
            //p8();
            //p9();
            //p10();
            p11();
        }
        /// <summary>
        /// functie care creeaza o lista cu numere de la 2 la n
        /// </summary>
        /// <param name="n"></param>
        /// <param name="v"></param>
        public static void initializare_vector(int x, int[] v)
        {
            for (int i = 0; i < x; i++)
            {
                v[i] = i + 2;
            }
        }

        /// <summary>
        /// Se da un numar natural n. 
        /// Se cere sa se afiseze toate numerele prime mai mici sau egale cu n (ciurul lui Eratostene). 
        /// </summary>
        private static void p11()
        {
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());
            int[] v = new int[x + 1];
            initializare_vector(x, v);
            Console.Write("introduceti numarul n= ");
            int n = int.Parse(Console.ReadLine());
            //int[] u = new int[x + 1];
            //initializare_vector(x, u);
            //int q = 0, indice = x + 2, numar_prim = 0;

            for (int i = 0; i < n; i++)
            {
                if (v[i] != 0)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (v[j] != 0 && v[j] % v[i] == 0)
                        {
                            v[j] = 0;
                        }
                    }
                }
            }
            Console.WriteLine($"numerele prime mai mici decat {n} sunt:");
            for (int i = 0; i < n + 1; i++)
            {
                if (v[i] != 0)
                {
                    Console.WriteLine(v[i]);
                }
                
            }
        }

        /// <summary> in ordine crescatoare. 
        /// Se cere sa se determine pozitia unui element dat k. 
        /// Daca elementul nu se gaseste in vector rezultatul va fi -1.
        /// </summary>
        private static void p10()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            citire_vector(n, v);
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            int sfarsit = n-1, inceput = 0, mijloc = 0, Obs = 0;
            while (inceput <= sfarsit && Obs == 0)
            {
                mijloc = (sfarsit + inceput) / 2;
                if (k == v[mijloc])
                {
                    Console.WriteLine($"elementul {k} a fost gasit pe pozitia {mijloc}");
                    Obs = 1;
                }
                if (k < v[mijloc])
                {
                    sfarsit = mijloc - 1;
                }
                else
                {
                    inceput = mijloc + 1;
                }
            }
            if (Obs == 0)
                Console.WriteLine(-1);
        }

        /// <summary>
        /// Rotire k. Se da un vector cu n elemente. Rotiti elementele vectorului cu k pozitii spre stanga. 
        /// </summary>
        private static void p9()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            citire_vector(n, v);
            int save = 0;
            for (int j = 0; j < k; j++)
            {
                save = v[0];
                for (int i = 0; i < n - 1; i++)
                {
                    v[i] = v[i + 1];
                }
                v[n - 1] = save;
            }
            afisare_vector(n, v);
        }

        /// <summary>
        /// Rotire. Se da un vector cu n elemente. 
        /// Rotiti elementele vectorului cu o pozitie spre stanga. 
        /// Prin rotire spre stanga primul element devine ultimul, al doilea devine primul etc. 
        /// </summary>
        private static void p8()
        {
            
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            citire_vector(n, v);
            int save = v[0];
            for (int i = 0; i < n-1; i++)
            {
                v[i] = v[i+1];
            }
            v[n - 1] = save;
            afisare_vector(n, v);
        }

        /// <summary>
        /// functie care afiseaza numerele din vector
        /// </summary>
        /// <param name="n"></param> numarul de elemente din vector 
        /// <param name="v"></param> vectorul v[]
        public static void afisare_vector(int n, int[] v)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"v[{i}]= {v[i]} ");
            }
        }

        /// <summary>
        /// functie care citeste numerele dintr un vector
        /// </summary>
        /// <param name="n"></param> numarul de elemente din vector
        /// <param name="v"></param> vectorul v[]
        public static void citire_vector(int n, int[] v)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
            }
        }

        /// <summary>
        /// Reverse. Se da un vector nu n elemente. 
        /// Se cere sa se inverseze ordinea elementelor din vector. 
        /// Prin inversare se intelege ca primul element devine ultimul, al doilea devine penultimul etc.
        /// </summary>
        private static void p7()
        {
            int aux = 0;
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            
            for (int i = 0; i < n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
            }
            int k = n - 1;
            for (int i = 0; i < n/2; i++)
            {
                Console.WriteLine();
                aux = v[i];
                v[i] = v[k];
                v[k] = aux;
                k--;
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"v[{i}]= {v[i]} ");
            }
        }

        /// <summary>
        /// Se da un vector cu n elemente si o pozitie din vector k. 
        /// Se cere sa se stearga din vector elementul de pe pozitia k. 
        /// Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga. 
        /// </summary>
        private static void p6()
        {
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            Console.Write("Se va sterge nr de pe pozitia : ");
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
            }
            for (int i = k; i < n; i++)
            {
                v[i] = v[i+1];
            }
            Console.WriteLine();
            for (int i = 0; i < n-1; i++)
            {
                Console.WriteLine($"v[{i}]= {v[i]} ");
            }
        }

        /// <summary>
        /// Se da un vector cu n elemente, o valoare e si o pozitie din vector k. 
        /// Se cere sa se insereze valoarea e in vector pe pozitia k.
        /// Primul element al vectorului se considera pe pozitia zero. 
        /// </summary>
        private static void p5()
        {
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 2];
            int e, k, aux = 0;
            Console.Write("Introduceti numarul inserat = ");
            e = int.Parse(Console.ReadLine());
            Console.Write("Introduceti pozitia la care sa fie inserat nr = ");
            k = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
            }
            for (int i = k; i < n+1; i++)
            {
                aux = v[i];
                v[i] = e;
                e = aux;
            }
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine($"v[{i}]= {v[i]} ");
            }

        }

        /// <summary>
        /// Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea. 
        /// </summary>
        private static void p4()
        {
            int minim, maxim, count_max = 0, count_min = 0;
            minim = int.MaxValue;
            maxim = int.MinValue;
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
                if (v[i] > maxim)
                {
                    maxim = v[i];
                    count_max = 0;
                }
                if (v[i] < minim)
                {
                    minim = v[i];
                    count_min = 0;
                }
                if (v[i] == maxim)
                {
                    count_max++;
                }
                if (v[i] == minim)
                {
                    count_min++;
                }
            }
            Console.WriteLine($"Cel mai mic numar din vector este {minim} si apare de {count_min} ori!");
            Console.WriteLine($"Cel mai mare numar din vector este {maxim} si apare de {count_max} ori!");

        }

        /// <summary>
        /// Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului. 
        /// Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz)
        /// </summary>
        private static void p3()
        {
            int minim, maxim;
            minim = int.MaxValue;
            maxim = int.MinValue;
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
                if (v[i] >= maxim)
                {
                    maxim = v[i];
                }
                if (v[i] <= minim)
                {
                    minim = v[i];
                }
            }
            for (int i = 1; i <= n; i++)
            {
                if (v[i] == minim)
                {
                    Console.WriteLine($"Cel mai mic numar din vector este {minim} si apare pe pozitia {i}");
                }
                if(v[i] == maxim)
                {
                    Console.WriteLine($"Cel mai mare numar din vector este {maxim} si apare pe pozitia {i}");
                }
            }
        }

        /// <summary>
        /// Se da un vector cu n elemente si o valoare k. 
        /// Se cere sa se determine prima pozitie din vector pe care apare k. 
        /// Daca k nu apare in vector rezultatul va fi -1. 
        /// </summary>
        private static void p2()
        {
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n + 1];
            Console.Write("numarul cautat = ");
            int k = int.Parse(Console.ReadLine());
            int pozitie = -1;
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
                if (v[i] == k)
                {
                    pozitie = i;
                    Console.WriteLine($"Prima aparitie a numarului {k}, este pe pozitia {pozitie}");
                    break;
                }
            }
            if(pozitie == -1)
            {
                Console.WriteLine(pozitie);
            }
        }

        /// <summary>
        /// Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.
        /// </summary>
        private static void p1()
        {
            int suma = 0;
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n+1];
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"numar {i}= ");
                v[i] = int.Parse(Console.ReadLine());
                suma += v[i];
            }
            Console.WriteLine($"Suma elementelor din vectorul V este : {suma}");
        }
    }
}
