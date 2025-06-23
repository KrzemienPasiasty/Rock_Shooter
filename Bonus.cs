using RockShooter2.Properties;
using System;
 

namespace RockShooter2
{
    public class Bonus : GameObject
    {
        public int valuable = 1;

        public Bonus(int valuable, int[] position) : base(null)
        {
            // set valuable of bonus
            this.valuable = valuable;
            switch (valuable)
            {
                case 1:
                    sprite = Resources.Bonus1;
                    break;
                case 2:
                    sprite = Resources.Bonus2;
                    break;
                case 3:
                    sprite = Resources.Bonus3;
                    break;
            }

            this.position = position;
            size[0] = 40;
            size[1] = 40;

            SetHitbox();
        }
    }
}
