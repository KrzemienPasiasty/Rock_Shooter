using RockShooter2.Properties;
using System;

namespace RockShooter2
{
    public class Rock : GameObject
    {
        public int valuable = 0;

        public Rock() : base(null)
        {
            // Random valuable of rock
            valuable = GameWindow.random.Next(0, GameWindow.valuableRockIndex + 1);
            switch (valuable)
            {
                case 0:
                    sprite = Resources.Rock0;
                    break;
                case 1:
                    sprite = Resources.Rock1;
                    break;
                case 2:
                    sprite = Resources.Rock2;
                    break;
                case 3:
                    sprite = Resources.Rock3;
                    break;
            }

            // Romdom position and size 
            position[0] = GameWindow.random.Next(0, 700);
            position[1] = 0;
            size[0] = GameWindow.random.Next(20, 60);
            size[1] = size[0];

            SetHitbox();
        }




    }
}
