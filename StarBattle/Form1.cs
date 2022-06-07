using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book_Engine;
using Book_Engine.Input;
using Tao.OpenGl;
using Tao.DevIl;

namespace StarBattle
{
    public partial class Form1 : Form
    {
        bool _fullscreen = false;
        FastLoop _fastLoop;
        StateSystem _system = new StateSystem();
        Input _input = new Input();
        TextureManager _textureManager = new TextureManager();
        SoundManager _soundManager = new SoundManager();
        Book_Engine.Font _titleFont;
        Book_Engine.Font _generalFont;
        PersistantGameData _persistantGameData = new PersistantGameData();
        

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();

            _input.Mouse = new Mouse(this, simpleOpenGlControl1);
            _input.Controller = new XboxController(0);
            _input.Keyboard = new Keyboard(simpleOpenGlControl1);
            _input.Controller2 = new XboxController(1);


            InitializeDisplay();
            InitializeSounds();
            InitializeTextures();
            InitializeGameData();
            InitializeFonts();
            InitializeGameState();
            

            _fastLoop = new FastLoop(GameLoop);
        }
    
        private void InitializeFonts()
        {
            //Fonts are loaded here.
            _titleFont = new Book_Engine.Font(_textureManager.Get("title_font"), FontParser.Parse("title_font.fnt"));
            _generalFont = new Book_Engine.Font(_textureManager.Get("general_font"), FontParser.Parse("general_font.fnt"));
        }

        private void InitializeSounds()
        {
            //Sounds are loaded here.
        }

        private void InitializeGameState()
        {
            //Game states are loaded here
            _system.AddState("start_menu", new StartMenuState(_titleFont, _generalFont, _input, _system, _textureManager));
            _system.AddState("game_over", new GameOverState(_persistantGameData, _system, _input, _generalFont, _titleFont));
            _system.AddState("Map_Test", new MapTest(_textureManager, _input, _generalFont, _titleFont, _system, _persistantGameData));
            _system.ChangeState("start_menu");
        }

        private void InitializeTextures()
        {
            // Init DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            //Textures are loaded here.
          /*  _textureManager.LoadTexture("background", "background.tga");
            _textureManager.LoadTexture("background_layer_1", "background_p.tga");
            _textureManager.LoadTexture("enemy_ship", "spaceship2.tga");
            _textureManager.LoadTexture("player_ship", "spaceship.tga");
            */

            _textureManager.LoadTexture("title_font", "title_font.tga");
            _textureManager.LoadTexture("general_font", "general_font.tga");
            _textureManager.LoadTexture("bullet", "bullet.tga");
            _textureManager.LoadTexture("explosion", "explode.tga");
            _textureManager.LoadTexture("emblem", "TGEmblem.png");
            _textureManager.LoadTexture("Miranda", "Miranda.png");
            _textureManager.LoadTexture("Constitution", "Constitution.png");
            _textureManager.LoadTexture("background", "background.jpg");
            _textureManager.LoadTexture("MirandaHull", "Miranda_silhouette.png");
            _textureManager.LoadTexture("ConstitutionHull", "Constitution_silhouette.png");
            _textureManager.LoadTexture("ShieldArc", "Shield_Quarter.png");
            _textureManager.LoadTexture("Oberth", "Oberth.png");
            _textureManager.LoadTexture("OberthHull", "Oberth.png");
            _textureManager.LoadTexture("SelectionOutline", "Selection_box.png");

        }

        private void InitializeGameData()
        {
            LevelDescription level = new LevelDescription();
            level.Time = 30; //Level now lasts 30 seconds
            _persistantGameData.CurrentLevel = level;
            
        }



        private void UpdateInput(double elapsedTime)
        {
            _input.Update(elapsedTime);
        }

        private void GameLoop(double elapsedTime)
        {
            UpdateInput(elapsedTime);
            _system.Update(elapsedTime);
            _system.Render();
            simpleOpenGlControl1.Refresh();
        }

        private void InitializeDisplay()
        {
            if(_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                ClientSize = new Size(1280, 720);
            }
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
    }
}
