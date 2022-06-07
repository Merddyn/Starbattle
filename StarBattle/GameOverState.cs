using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;
using Book_Engine.Input;
using Tao.OpenGl;

namespace StarBattle
{
    class GameOverState : IGameObject
    {
        const double _timeOut = 4;
        double _countDown = _timeOut;

        StateSystem _system;
        Input _input;
        Font _generalFont;
        Font _titleFont;
        PersistantGameData _gameData;
        Renderer _renderer = new Renderer();

        Text _Player1Win;
        Text _Player1WinBlurb;

        Text _Player2Win;
        Text _Player2WinBlurb;

        Text _WaitWhat;
        Text _WhatJustHappened;

        public GameOverState(PersistantGameData data, StateSystem system, Input input, Font generalFont, Font titleFont)
        {
            _gameData = data;
            _system = system;
            _input = input;
            _generalFont = generalFont;
            _titleFont = titleFont;

            _Player1Win = new Text("Khan avenged himself!", _titleFont);
            _Player1WinBlurb = new Text("From hell's heart, I stab at thee.", _generalFont);
            _Player2Win = new Text("The Enterprise survived!", _titleFont);
            _Player2WinBlurb = new Text("KHAAAAAAAAAAN!!!", _generalFont);

            _WaitWhat = new Text("You survived!", _titleFont);
            _WhatJustHappened = new Text("KHAAAAAAAAAAN!!!", _generalFont);


            FormatText(_Player1Win, 300);
            FormatText(_Player1WinBlurb, 200);

            FormatText(_Player2Win, 300);
            FormatText(_Player2WinBlurb, 200);
        }

        private void FormatText(Text _text, int yPosition)
        {
            _text.SetPosition(-_text.Width / 2, yPosition);
            _text.SetColor(new Color(0, 0, 0, 1));
        }

        #region IGameObject Members

        public void Update(double elapsedTime)
        {
            _countDown -= elapsedTime;

            if (_countDown <= 0 || _input.Controller.ButtonA.Pressed || _input.Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Enter))
            {
                Finish();
            }
        }

        private void Finish()
        {
            _system.ChangeState("start_menu");
            _gameData.PlayerWon = 0;
            _gameData.JustWon = true;
            _countDown = 4;
            _gameData.FirstRound = false;
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            if (_gameData.PlayerWon == 1)
            {
                _renderer.DrawText(_Player1Win);
                _renderer.DrawText(_Player1WinBlurb);
            }
            else if (_gameData.PlayerWon == 2)
            {
                _renderer.DrawText(_Player2Win);
                _renderer.DrawText(_Player2WinBlurb);
            }
            else
            {
                _renderer.DrawText(_WaitWhat);
                _renderer.DrawText(_WhatJustHappened);
            }
            _renderer.Render();
        }
        #endregion
    }
}
