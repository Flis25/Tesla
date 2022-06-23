using projekt_továren.Tridy;
using ConsoleApp;

bool xd = true;
while (xd = true)
{
    xd = false;
Továrna továrnaTesla = new Továrna();
string input = továrnaTesla.Menu();
if (input == "1")
{
        továrnaTesla.ZobrazStranku("index.html");
        Console.Clear();
        xd = true;
}
else if (input == "2")
{
    Auto vytvoreneAuto = new Auto();
    vytvoreneAuto = továrnaTesla.VytvorAuto();
    továrnaTesla.VytvorStranku(vytvoreneAuto);

    Console.WriteLine("Chcete zobrazit vámi vytvořené auto: y/n");
    string input2 = Console.ReadLine();
    if (input2 == "y")
    {
        továrnaTesla.ZobrazStranku("index.html");
    }
    else
    {
        xd = true;
    }
}
}