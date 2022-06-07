using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;
using Tao.OpenGl;
using Book_Engine.Input;

namespace StarBattle
{
    class StartMenuState : IGameObject
    {
        Renderer _renderer = new Renderer();
        Text _title;
        Text _credit;
        Book_Engine.Font _generalFont;
        Input _input;
        VerticalMenu _menu;
        StateSystem _system;
        Sprite _emblem = new Sprite();
        ScrollingBackground _background;

        public StartMenuState(Book_Engine.Font titleFont, Book_Engine.Font generalFont, Input input, StateSystem system, TextureManager textureManager)
        {
            _system = system;
            _input = input;
            _generalFont = generalFont;
            _background = new ScrollingBackground(textureManager.Get("background"));
            _background.SetScale(2, 2);
            _background.Speed = 0.05f;

            InitializeMenu();
            _title = new Text("Star Battle", titleFont);
            _title.SetColor(new Color(0.5f, 0.5f, 0.5f, 1));
            // Center on the x and place somewhere near the top
            _title.SetPosition(-_title.Width / 2, 300);
            _credit = new Text("A Twilight Guardians production", titleFont);
            _credit.SetColor(new Color(0, 0.5f, 0.5f, 1));
            _credit.SetPosition(-_credit.Width / 2, -250);
            _emblem.Texture = textureManager.Get("emblem");
            _emblem.SetScale(1.5, 1.5);
            _emblem.SetPosition(0, -150); // put it somewhere easy to see

        }

        public void InitializeMenu()
        {
            _menu = new VerticalMenu(0, 150, _input);
            Button startGame = new Button(delegate (object o, EventArgs e)
            {
                _system.ChangeState("Map_Test");
            }, new Text("Start", _generalFont));

            Button exitGame = new Button(delegate (object o, EventArgs e)
            {
                //Quit
                System.Windows.Forms.Application.Exit();
            }, new Text("Exit", _generalFont));

            _menu.AddButton(startGame);
            _menu.AddButton(exitGame);
        }

        public void Update(double elapsedTime)
        {
            _background.Update((float)elapsedTime);

            _menu.HandleInput();
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 0);    
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _background.Render(_renderer);
            _renderer.DrawText(_title);
            _renderer.DrawText(_credit);
            _menu.Render(_renderer);
            _renderer.DrawSprite(_emblem);
            _renderer.Render();
        }
    }
}
