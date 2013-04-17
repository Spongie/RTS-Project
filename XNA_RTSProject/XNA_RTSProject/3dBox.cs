using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNA_RTSProject
{
    class _3dBox
    {
        private Vector3 position;
        private int height;
        private int lenght;
        private int depth;

        public _3dBox(Vector3 position, int height, int lenght, int depth)
        {
            this.position = position;
            this.height = height;
            this.lenght = lenght;
            this.depth = depth;
        }
        public Vector3 Position
        {
            get { return position; }
            set
            {
                if (value != null)
                    position = value;
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value != null)
                    height = value;
            }
        }

        public int Lenght
        {
            get { return lenght; }
            set
            {
                if (value != null)
                    lenght = value;
            }
        }
        public int Depth
        {
            get { return depth; }
            set
            {
                if (value != null)
                    depth = value;
            }
        }
    }
}