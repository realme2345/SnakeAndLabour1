﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLabour
{
    internal class UC5SnakeAndLadder
    {
        private int InitialPosition { get; } = 0;
        private int CurrentPosition { get; set; }

        private static int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        private static string CheckOption()
        {
            Random random = new Random();
            int option = random.Next(0, 3);
        Step:
            switch (option)
            {
                case 0:
                    return "no_play";
                case 1:
                    return "ladder";
                case 2:
                    return "snake";
                default:
                    goto Step;
            }
        }

        private static int Play(string option, int position, int roll)
        {
            if (option == "ladder")
            {
                if (position + roll > 100) position += 0;
                else position += roll;
            }
            else if (option == "snake")
            {
                if (position - roll > 0) position -= roll;
            }
            else position -= 0;
            return position;
        }

        public static void Solution()
        {
            UC5SnakeAndLadder app = new UC5SnakeAndLadder();
            app.CurrentPosition = app.InitialPosition;
            while (app.CurrentPosition < 100)
            {
                string option = CheckOption();
                int roll = RollDice();
                app.CurrentPosition = Play(option, app.CurrentPosition, roll);
                Console.WriteLine($"You got: {option}/{roll} and Position is at: {app.CurrentPosition}");
            }
            Console.WriteLine("Hey Player, You won");
        }
    }
}
