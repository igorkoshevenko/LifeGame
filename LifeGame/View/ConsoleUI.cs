using System;
using System.Collections.Generic;
using System.Threading;
using LifeGame.Ocean;

namespace LifeGame.View
{
    public class ConsoleUI : IDisplay
    {
        private readonly Dictionary<string, ConsoleColor> _colorsForEntities = new Dictionary<string, ConsoleColor>
        {
            {"|", ConsoleColor.Blue},
            {"@", ConsoleColor.Red},
            {"*", ConsoleColor.Green},
            {"-", ConsoleColor.White}
        };

        public void Display(IOceanViewer oceanViewer)
        {
            var dataToRender = oceanViewer.GetOceanStates(Constants.Constants.Iterations);
            foreach (var data in dataToRender)
            {
                for (var i = 0; i < Constants.Constants.MaxRows; i++)
                {
                    for (var j = 0; j < Constants.Constants.MaxColumns; j++)
                    {
                        Console.ForegroundColor = _colorsForEntities[data.Key[i, j].GetImage];
                        Console.Write(data.Key[i, j].GetImage);
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Prey - " + data.Value[0]);
                Console.WriteLine("Predator - " + data.Value[1]);
                Console.WriteLine("Obstacles - " + data.Value[2]);
                Console.WriteLine("Iteration - " + data.Value[3]);
                Thread.Sleep(1000);
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
