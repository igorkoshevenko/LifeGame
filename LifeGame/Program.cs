using System;
using LifeGame.Ocean;
using LifeGame.View;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IOceanViewer oceanViewer = new Ocean.Ocean();
            IDisplay iDisplay = new ConsoleUI();
            iDisplay.Display(oceanViewer);
            Console.ReadKey();
        }
    }
}
