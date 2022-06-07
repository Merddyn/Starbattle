using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.DevIl;
using System.Runtime.InteropServices;

namespace Book_Engine
{
    public class Renderer
    {
        Batch _batch = new Batch();
        int _currentTextureId = -1;

        public Renderer()
        {

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
        }
        
        public void DrawImmediateModeVertex(Vector position, Color color, Point uvs)
        {
            Gl.glColor4f(color.Red, color.Green, color.Blue, color.Alpha);
            Gl.glTexCoord2f(uvs.X, uvs.Y);
            Gl.glVertex3d(position.X, position.Y, position.Z);
        }


        public void DrawSprite(Sprite sprite)
        {
            if(sprite.Texture.Id == _currentTextureId)
            {
                _batch.AddSprite(sprite);
            }
            else
            {
                _batch.Draw(); // Draw all with current texture

                //Update texture info
                _currentTextureId = sprite.Texture.Id;
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, _currentTextureId);
                _batch.AddSprite(sprite);
            }
            _batch.AddSprite(sprite);
        }

        public void Render()
        {
            _batch.Draw();
        }

        /* Pre-batch DrawSprite code
        public void DrawSprite(Sprite sprite)
        {
            Gl.glBegin(Gl.GL_TRIANGLES);
            {
                for (int i = 0; i < Sprite.VertexAmount; i++)
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, sprite.Texture.Id);
                    DrawImmediateModeVertex(
                        sprite.VertexPositions[i],
                        sprite.VertexColors[i],
                        sprite.VertexUVs[i]);
                }
            }
            Gl.glEnd();
        }
        */
        public void DrawText(Text text)
        {
            foreach(CharacterSprite c in text.CharacterSprites)
            {
                DrawSprite(c.Sprite);
            }
        }
        
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        public static Vector Zero = new Vector(0, 0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }
        public double LengthSquared()
        {
            return (X * X + Y * Y + Z * Z);
        }
       
        public bool Equals(Vector v)
        {
            return (X == v.X) && (Y == v.Y) && (Z == v.Z);
        }

        public override int GetHashCode()
        {
            return (int)X ^ (int)Y ^ (int)Z;
        }

        public static bool operator == (Vector v1, Vector v2)
        {
            //If they're the same object or both null, return true.
            if (System.Object.ReferenceEquals(v1, v2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (v1 == null || v2 == null)
            {
                return false;
            }

            return v1.Equals(v2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                return Equals((Vector)obj);
            }
            return base.Equals(obj);
        }
        
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }

        public Vector Add(Vector r)
        {
            return new Vector(X + r.X, Y + r.Y, Z + r.Z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }

        public Vector Subtract(Vector r)
        {
            return new Vector(X - r.X, Y - r.Y, Z - r.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Subtract(v2);
        }

        public Vector Multiply(double v)
        {
            return new Vector(X * v, Y * v, Z * v);
        }

        public static Vector operator * (Vector v, double s)
        {
            return v.Multiply(s);
        }

        public Vector Normalize(Vector v)
        {
            double r = v.Length();
            if (r != 0.0) //guard against divide by zero
            {
                return new Vector(v.X / r, v.Y / r, v.Z / r); // normalize and return
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }
        public double DotProduct(Vector v)
        {
            return (v.X * X) + (Y * v.Y) + (Z * v.Z);
        }
        public static double operator * (Vector v1, Vector v2)
        {
            return v1.DotProduct(v2);
        }

        public Vector CrossProduct(Vector v)
        {
            double nx = Y * v.Z - Z * v.Y;
            double ny = Z * v.X - X * v.Z;
            double nz = X * v.Y - Y * v.X;
            return new Vector(nx, ny, nz);
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
        }
    }


    
}
