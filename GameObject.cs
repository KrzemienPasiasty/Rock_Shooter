using System;
using System.Drawing;

namespace RockShooter2
{
    public class GameObject : IDisposable
    {
        public Bitmap sprite;
        public Rectangle hitbox;

        private int[] _position;
        public virtual int[] position { get { return _position; } set {  _position = value; } }

        private int[] _size;
        public int[] size { get { return _size; } set { _size = value; } }


        public GameObject(Bitmap sprite)
        {
            this.sprite = sprite;
            _position = new int[2];
            _size = new int[2];
            SetHitbox();
        }


        /// <summary>
        /// Set rectangle as a new object hitbox
        /// </summary>
        /// <param name="hitbox"></param>
        public virtual void SetHitbox(Rectangle hitbox)
        {
            this.hitbox = hitbox;
        }



        /// <summary>
        /// Create dafault rectangle around the object and set it as a hitbox
        /// </summary>
        public virtual void SetHitbox()
        {
            SetHitbox(new Rectangle(position[0], position[1], size[0], size[1]));
        }



        /// <summary>
        /// Move hitbox to the current object position
        /// </summary>
        internal virtual void MoveHitbox()
        {
            hitbox.Location = new Point(position[0], position[1]);
        }



        /// <summary>
        /// Check if point is colliding with object
        /// </summary>
        /// <param name="point">The X and the Y of point</param>
        /// <returns>True when point collide with object</returns>
        public virtual bool PointInBound(int[] point)
        {
            return hitbox.Contains(point[0], point[1]);
        }



        /// <summary>
        /// Check if coordinates is colliding with the object
        /// </summary>
        /// <param name="X">x coordinate</param>
        /// <param name="Y">y coordinate</param>
        /// <returns>True when coordinate collide with the object</returns>
        public virtual bool PointInBound(int X, int Y)
        {
            int[] i = { X, Y };
            return PointInBound(i);
        }



        /// <summary>
        /// Check if any of the points is colliding with the object
        /// </summary>
        /// <param name="points">the table of points</param>
        /// <returns></returns>
        public virtual bool PointsInBound(int[][] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (PointInBound(points[i]))
                    return true;
            }
            return false;
        }



        /// <summary>
        /// Check if object is colliding with the rectangle
        /// </summary>
        /// <param name="hitbox"></param>
        /// <returns></returns>
        public virtual bool HitboxCollision(Rectangle hitbox)
        {
            return this.hitbox.IntersectsWith(hitbox);
        }



        public void DrawImage(Graphics g)
        {
            g.DrawImage(sprite, _position[0], _position[1], _size[0], _size[1]);

        }



        /// <summary>
        /// Move the objects
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void Move(int x, int y)
        {
            position[0] += x;
            position[1] += y;
            MoveHitbox();
        }



        /// <summary>
        /// Dispose all using resources and destroy the object
        /// </summary>
        public void Dispose()
        {
            try
            {
                sprite.Dispose();
                GC.SuppressFinalize(this);
            }
            catch { }

        }
    }
}
