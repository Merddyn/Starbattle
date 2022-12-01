using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Sdl;

namespace Book_Engine.Input
{
    public class Input
    {
        public Mouse Mouse { get; set; }
        //public Point MousePosition { get; set; }
        bool _usingController = false;
        public XboxController Controller { get; set; }
        public Keyboard Keyboard { get; set; }
        public XboxController Controller2 { get; set; }

        public Input()
        {
            
        Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_JOYSTICK);
            if (Sdl.SDL_NumJoysticks() > 0)
            {
                Controller = new XboxController(0);
                _usingController = true;
            }
            if (Sdl.SDL_NumJoysticks() > 1)
            {
                Controller2 = new XboxController(1);
            }
            
        }
        public void Update(double elapsedTime)
        {
            if (_usingController)
            {
                Sdl.SDL_JoystickUpdate();
                Controller.Update();
            }
            if (Sdl.SDL_NumJoysticks() > 1)
            {
                Controller2.Update();
            }
            Mouse.Update(elapsedTime);
            Keyboard.Process();
        }

    }
}
