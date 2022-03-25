#include <iostream>
using namespace std;
int v[100], numar;
int main()
{
	int i;
	cout <<"numar= ";
	cin >> numar;
	int save=numar;

	for (i = 2; i <= save/2; i++)
	{
		while (numar % i == 0)
		{
			v[i]++;
			numar = numar / i;
		}
	}
	cout << " numarul " << save << " se descompune in : " << endl;
	for (i = 2; i <= save/2; i++)
	{
		if (v[i] != 0)
		{
			cout << i << " la puterea " << v[i] << endl;
		}
	}
}