using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;
using Tao.OpenGl;
using System.Drawing;


namespace StarBattle
{
    public class Entity 
    {
        protected Sprite _sprite = new Sprite();
//        int X = 1;
//        int Y = 1;
        public RectangleF GetBoundingBox()
        {
            float width = (float)(_sprite.Texture.Width * _sprite.ScaleX);
            float height = (float)(_sprite.Texture.Height * _sprite.ScaleY);
            return new RectangleF((float)_sprite.GetPosition().X - width / 2, (float)_sprite.GetPosition().Y - height / 2, width, height);
        }

        // Render a bounding box

        public void Render_Debug()
        {
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            RectangleF bounds = GetBoundingBox();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                Gl.glColor3f(1, 1, 0);
                Gl.glVertex2f(bounds.Left, bounds.Top);
                Gl.glVertex2f(bounds.Right, bounds.Top);
                Gl.glVertex2f(bounds.Right, bounds.Bottom);
                Gl.glVertex2f(bounds.Left, bounds.Bottom);
            }
            Gl.glEnd();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
        }

    }
}
