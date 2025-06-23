using RockShooter2.Properties;
using System.Windows.Forms;


namespace RockShooter2
{   
    public class Shot : GameObject
    {
        public Shot(SpaceShip ss) : base(Resources.Shot)
        {
            size[0] = Resources.Shot.Width;
            size[1] = Resources.Shot.Height;

            position[0] = (2 * ss.position[0] + ss.size[0]) / 2;
            position[1] = ss.position[1];

            SetHitbox();
        }
    }
}
