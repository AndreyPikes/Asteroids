using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Asteroid
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        protected Image[] images;

        protected Image currentImage;

        private static Random randomImage = new Random();

        public Asteroid(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
            SetImages();
            this.currentImage = images[randomImage.Next(0, images.Length)];

        }

        public virtual void SetImages()
        {
            images = new Image[4] { Resources.meteorBrown_big1, Resources.meteorBrown_big2,
            Resources.meteorBrown_big3, Resources.meteorBrown_big4 };
        }

        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(currentImage, pos.X, pos.Y, size.Width, size.Height);
        }

        public virtual void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;

            if (pos.X < 0 || pos.X > Game.Width) dir.X = -dir.X;   
            if (pos.Y < 0 || pos.Y > Game.Height) dir.Y = -dir.Y;
        }
    }
}
