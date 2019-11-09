using System;
using System.Collections.Generic;
using System.Text;

namespace Robots
{
    class Robot
    {
        public Robot(string name, int healthpoints, int battery, int maxhealthpoints, int maxbattery)
        {
            Name = name;
            Healthpoints = healthpoints;
            Battery = battery;
            Maxhealthpoints = maxhealthpoints;
            Maxbattery = maxbattery;
        }

        public string Name { get; }
        public int Healthpoints { get; set; }
        public int Battery { get; set; }
        public int Maxhealthpoints { get; }
        public int Maxbattery { get; }

        public void Update()
        {
            if (Healthpoints <= 0) return;
            Battery--;
            if (Battery > Maxbattery)
            {
                Battery = Maxbattery;
            }
            if (Battery > 0)
            {
                Healthpoints--;
                if (Healthpoints > (Maxhealthpoints / 2))
                {
                    Console.WriteLine($"{Name} is working.");
                }
                if (Healthpoints > 0 && Healthpoints <= (Maxhealthpoints / 2))
                {
                    Console.WriteLine($"{Name} is overworked.");
                }
                if (Healthpoints <= 0)
                {
                    Console.WriteLine($"{Name} was destroyed.");
                    Healthpoints = 0;
                }
            }
            if (Battery <= 0 && Healthpoints > 0)
            {
                Healthpoints++;
                if (Healthpoints > Maxhealthpoints)
                {
                    Healthpoints = Maxhealthpoints;
                }

                if (Healthpoints < (Maxhealthpoints / 2))
                {
                    Console.WriteLine($"{Name} is recovering.");
                }
                if (Healthpoints >= (Maxhealthpoints / 2) && Healthpoints < Maxhealthpoints)
                {
                    Console.WriteLine($"{Name} is resting.");
                }
                if (Healthpoints == Maxhealthpoints)
                {
                    Console.WriteLine($"{Name} is turned off.");
                }
                Battery = 0;
            }
        }

        public void Charger(int energy)
        {
            Battery += energy;
        }
    }
}
