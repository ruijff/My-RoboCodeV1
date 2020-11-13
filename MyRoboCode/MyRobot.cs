using Robocode;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJFF
{
    class MyRobot : AdvancedRobot
    {
        private double bigStep = 150;
        private double smalStep = 75;
        private double scan = 360;
        private double energyLimit = 40;
        private double maxVelocity = 4;

        // The main method of your robot containing robot logics
        public override void Run()
        {
            TurnLeft(Heading - 90);
            SetColors(Color.Black, Color.Black, RadarColor);

            while (true)
            {
                ClearAllEvents();
                SetTurnGunRight(scan);
                SetAhead(bigStep);
                SetTurnGunRight(scan);
                Execute();
                //Back(smalStep);
                //TurnRight(GetRandomDirection());
                //TurnGunRight(scan);

                ManageRobotColors();
            }
        }

        // Robot event handler, when the robot gets hit by a bullet
        public override void OnHitByBullet(HitByBulletEvent e)
        {
            BodyColor = Color.Red;
            //double bearing = e.Bearing;
            //if (Energy < energyLimit)
            //{
            //    TurnRight(-bearing);
            //}
        }

        // Robot event handler, when the robot sees another robot
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            double distance = e.Distance;
            if (distance > 400 && distance <= 600)
            {
                Fire(1);
            }
            else if (distance > 200 && distance <= 400)
            {
                Fire(2);
            }
            else if (distance <= 200)
            {
                Fire(3);
            }
            //double bearing = e.Bearing;
            //Stop();
            //TurnRight(bearing);
            //Ahead(bigStep);
            //Resume();
        }

        public override void OnHitWall(HitWallEvent e)
        {
            Stop();
            TurnRight(-90);
            //Ahead(bigStep);
            Resume();
        }

        private double GetRandomDirection()
        {
            Random random = new Random();
            double newDirection = random.NextDouble() * 90;
            return newDirection;
        }

        private void ManageRobotColors()
        {
            BodyColor = Color.Black;

            if (GunHeat >= 2.5)
            {
                GunColor = Color.Red;
            }
            else if (GunHeat >= 1)
            {
                GunColor = Color.Yellow;
            }
            else if (GunHeat >= 0.1)
            {
                GunColor = Color.Green;
            }
            else
            {
                GunColor = Color.Black;
            }
        }
    }
}
