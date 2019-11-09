using System;
using System.Collections.Generic;
using System.Text;

namespace Robots
{
    class Lab
    {
        private readonly List<Robot> robots;

        public Lab()
        {
            robots = new List<Robot>
            {
                new Robot("Android", 50, 0, 50, 10),
                new Robot("Megatron", 250, 0, 250, 80),
                new Robot("Mettaton", 150, 0, 150, 30),
                new Robot("Golem", 200, 0, 200, 50),
                new Robot("Oxygen", 30, 0, 30, 4),
                new Robot("Rob Bott", 20, 0, 20, 10),
                new Robot("Terminator", 230, 0, 230, 200),
            };
        }
        public void Update()
        {
            foreach (var robot in robots)
            {
                robot.Update();
            }
        }
        public void ChargeUp(string name, int energy)
        {
            Robot robot = FindRobotBy(name);
            if (robot != null)
            {
                robot.Charger(energy);
            }
        }

        private Robot FindRobotBy(string name)
        {
            foreach (var robot in robots)
            {
                if (robot.Name.ToLower() == name.ToLower())
                {
                    return robot;
                }
            }
            return null;
        }
    }
}
