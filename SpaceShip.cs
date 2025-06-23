using RockShooter2.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace RockShooter2
{
    public class SpaceShip : GameObject
    {
        Rectangle[] hitboxes;


        public SpaceShip() : base(Resources.SpaceShip)
        {
            position[0] = 300;
            position[1] = 600;

            size[0] = 100;
            size[1] = 100;

            // Create hitboxes
            hitboxes = new Rectangle[2];
            hitboxes[0] = new Rectangle((int)(position[0] + size[0] * 0.37f), position[1], (int)(size[0] * 0.23f), size[1]);
            hitboxes[1] = new Rectangle(position[0], (int)(position[1] + size[1] * 0.4f), size[0], (int)(size[1] * 0.6f));

        }



        public override void Move(int x, int y)
        {
            if (position[0] + x < 0)
                position[0] = 0;
            else if (position[0] + x > 640)
                position[0] = 640;
            else
                position[0] += x;

            position[1] += y;
            MoveHitbox();
        }



        internal override void MoveHitbox()
        {
            hitboxes[0].Location = new Point((int)(position[0] + size[0] * 0.37f), position[1]);
            hitboxes[1].Location = new Point(position[0], (int)(position[1] + size[1] * 0.4f));
        }



        public override bool PointInBound(int[] point)
        {
            return (hitboxes[0].Contains(point[0], point[1]) || hitboxes[1].Contains(point[0], point[1]));
        }



        public override bool PointInBound(int X, int Y)
        {
            int[] i = { X, Y };
            return PointInBound(i);
        }



        public override bool HitboxCollision(Rectangle hitbox)
        {
            return (hitboxes[0].IntersectsWith(hitbox) || hitboxes[1].IntersectsWith(hitbox));
        }


    }
}
