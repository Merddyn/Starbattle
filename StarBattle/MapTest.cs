using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Engine;
using Book_Engine.Input;
using Tao.OpenGl;
using System.Windows.Forms;
using System.Drawing;


namespace StarBattle
{
    class MapTest : IGameObject
    {
        Renderer _renderer = new Renderer();
        Map _Map;
        Text _CurrentHealth;
        Text _TargetHealth;
        TextureManager _textureManager;
        List<Ship> _AllShips;
        //double _gameTime = 15;
        Input _input;
        int _NumberOfPlayers = 2;
        int _currentPlayer;
        int _currentShip;
        int _targetShip;
        int _targetPlayer;
        double _countDown;
        string CurrentHealth = "35";
        string TargetHealth = "40";
        string _PlayerCurrent = "1";
        Text _DisplayPlayer;
        Text CurrentForeShield;
        Text CurrentStarShield;
        Text CurrentAftShield;
        Text CurrentPortShield;
        Text TargetForeShield;
        Text TargetStarShield;
        Text TargetAftShield;
        Text TargetPortShield;
        string _CurrentForeShield;
        string _CurrentStarShield;
        string _CurrentAftShield;
        string _CurrentPortShield;
        string _TargetForeShield;
        string _TargetStarShield;
        string _TargetAftShield;
        string _TargetPortShield;
        Sprite _CurrentHull = new Sprite();
        Sprite _TargetHull = new Sprite();
        Sprite _CurrentShieldFore = new Sprite();
        Sprite _CurrentShieldStar = new Sprite();
        Sprite _CurrentShieldAft = new Sprite();
        Sprite _CurrentShieldPort = new Sprite();
        Sprite _TargetShieldFore = new Sprite();
        Sprite _TargetShieldStar = new Sprite();
        Sprite _TargetShieldAft = new Sprite();
        Sprite _TargetShieldPort = new Sprite();
        Sprite _CurrentSelectionOutline = new Sprite();
        Sprite _TargetSelectionOutline = new Sprite();
        StateSystem _system;
        Random r = new Random();
        PersistantGameData _gameData;
        float CurrentHullPercent;
        float CurrentForeShieldPercent;
        float CurrentStarShieldPercent;
        float CurrentAftShieldPercent;
        float CurrentPortShieldPercent;

        float TargetHullPercent;
        float TargetForeShieldPercent;
        float TargetStarShieldPercent;
        float TargetAftShieldPercent;
        float TargetPortShieldPercent;
        WeaponCoolDownUI WeaponUI;
        

        Book_Engine.Font _titleFont;
        Book_Engine.Font _generalFont;

        public MapTest(TextureManager textureManager, Input input, Book_Engine.Font generalFont, Book_Engine.Font titleFont, StateSystem System, PersistantGameData GameData)
        {
            
            _gameData = GameData;
            _titleFont = titleFont;
            _generalFont = generalFont;
            _input = input;
            _system = System;
            _textureManager = textureManager;
            OnGameStart();
            _Map.DisplayMap();
            UpdateUI();
            WeaponUI= new WeaponCoolDownUI(_textureManager, _generalFont);

        }

        public void OnGameStart()
        {
            _AllShips = new List<Ship>();
            _AllShips.Add(new Ship(2, 3, 2, 2, 3, 50, 50, 1, 1, ShipClasses.Miranda, "Reliant", 16));
            _AllShips.Add(new Ship(-3, -2, 0, 3, 4, 60, 60, 2, 1, ShipClasses.Constitution, "Enterprise", 14));
            _AllShips.Add(new Ship(4, 4, 3, 1, 4, 20, 30, 3, 1, ShipClasses.Oberth, "Pegasus", 18));
           // _AllShips.Add(new Ship(-4, -4, 1, 2, 3, 50, 50, 2, 2, ShipClasses.Miranda, "Saratoga", 16));
            _NumberOfPlayers = _AllShips.Select(x => x._PlayerID).Distinct().Count();
            _currentPlayer = 1;
            _currentShip = 1;
            _targetPlayer = 2;
            _targetShip = 1;
            _Map = new Map(_textureManager, _AllShips);

            if (_gameData.FirstRound == true)
            {
                _CurrentHull.Texture = _textureManager.Get("MirandaHull");
                _CurrentHull.SetRotation(Math.PI / 2);
                _CurrentHull.SetColor(new Book_Engine.Color(0, 1.0f, 0.0f, 1));
                _CurrentHull.SetPosition(-506, -270);

                _TargetHull.Texture = _textureManager.Get("ConstitutionHull");
                _TargetHull.SetRotation(Math.PI / 2);
                _TargetHull.SetColor(new Book_Engine.Color(0, 1.0f, 0.0f, 1));
                _TargetHull.SetPosition(494, -270);


                _CurrentShieldFore.Texture = _textureManager.Get("ShieldArc");
                _CurrentShieldFore.SetRotation(Math.PI);
                _CurrentShieldFore.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _CurrentShieldFore.SetPosition(-506, -270);

                _CurrentShieldStar.Texture = _textureManager.Get("ShieldArc");
                _CurrentShieldStar.SetRotation(Math.PI / 2);
                _CurrentShieldStar.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _CurrentShieldStar.SetPosition(-506, -270);

                _CurrentShieldAft.Texture = _textureManager.Get("ShieldArc");
                _CurrentShieldAft.SetRotation(Math.PI * 2.0);
                _CurrentShieldAft.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _CurrentShieldAft.SetPosition(-506, -270);

                _CurrentShieldPort.Texture = _textureManager.Get("ShieldArc");
                _CurrentShieldPort.SetRotation(Math.PI * 1.5);
                _CurrentShieldPort.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _CurrentShieldPort.SetPosition(-506, -270);

                _TargetShieldFore.Texture = _textureManager.Get("ShieldArc");
                _TargetShieldFore.SetRotation(Math.PI);
                _TargetShieldFore.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _TargetShieldFore.SetPosition(494, -270);

                _TargetShieldStar.Texture = _textureManager.Get("ShieldArc");
                _TargetShieldStar.SetRotation(Math.PI / 2);
                _TargetShieldStar.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _TargetShieldStar.SetPosition(494, -270);

                _TargetShieldAft.Texture = _textureManager.Get("ShieldArc");
                _TargetShieldAft.SetRotation(Math.PI * 2.0);
                _TargetShieldAft.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _TargetShieldAft.SetPosition(494, -270);

                _TargetShieldPort.Texture = _textureManager.Get("ShieldArc");
                _TargetShieldPort.SetRotation(Math.PI * 1.5);
                _TargetShieldPort.SetColor(new Book_Engine.Color(0.0f, 1.0f, 1.0f, 1));
                _TargetShieldPort.SetPosition(494, -270);

                _TargetSelectionOutline.Texture = _textureManager.Get("SelectionOutline");
                _TargetSelectionOutline.SetColor(new Book_Engine.Color(1.0f, 0.0f, 0.0f, 1));
                _TargetSelectionOutline.SetScale(0.95, 0.95);

                _CurrentSelectionOutline.Texture = _textureManager.Get("SelectionOutline");
                _CurrentSelectionOutline.SetColor(new Book_Engine.Color(0.0f, 1.0f, 0.0f, 1));
            }
        }

        public void Update(double elapsedTime)
        {
            if (_gameData.JustWon == true)
            {
                OnGameStart();
                _gameData.JustWon = false;
            }
           // _gameTime -= elapsedTime;
            foreach(Tile tile in _Map._TileList)
            {
                tile.UpdateGraphics();
            }
            var i = _AllShips.FindIndex(x => x._PlayerID == _currentPlayer && x._TurnID == _currentShip);
            var k = _AllShips.FindIndex(x => x._PlayerID == _targetPlayer && x._TurnID == _targetShip);
            _countDown -= elapsedTime;
            UpdateInput(elapsedTime);
            UpdateUI();
            WeaponUI.UpdateUI(_AllShips[i], _AllShips[k]);


            for (int a = 0; a < _AllShips.Count; a++)
            {
                if (_AllShips[a]._Hull <= 0)
                {
                    if (_targetPlayer == _AllShips[a]._PlayerID && _targetShip == _AllShips[a]._TurnID)
                    {
                        ChangeTarget();
                    }
                    if (_currentPlayer == _AllShips[a]._PlayerID && _currentShip == _AllShips[a]._TurnID)
                    {
                        ChangeTurn();
                    }
                    _Map._TileList.RemoveAt(_Map._TileList.FindIndex(x => x._ShipName == _AllShips[a]._name));
                    _AllShips.RemoveAt(a);

                }
            }
            /*   foreach (Ship ship in _AllShips)
               {
                   if(ship._Hull <= 0)
                   {
                       _AllShips.Remove(ship);
                   //    if(ship._PlayerID == 1)
                   //    {
                   //        _gameData.PlayerWon = 2;
                   //    }
                   //    if (ship._PlayerID == 2)
                   //    {
                   //        _gameData.PlayerWon = 1;
                   //    }
                   //    _system.ChangeState("game_over");
                   }
               }*/
            
            int RemainingPlayers = _AllShips.Select(x => x._PlayerID).Distinct().Count();
            if (RemainingPlayers <= 1)
            {
                _system.ChangeState("game_over");
            }
            // Switch these once the stat blocks are Current / Target as opposed to 1 / 2


            //            _Map.Update();
            /*
            if (_gameTime > 14)
            {
                _Map.Update();
            }
            if (_gameTime <= 10 && _gameTime >= 9) 
            {
                var i = _AllShips.FindIndex(x => x._ShipClass == "Miranda");
                _AllShips[i]._facing = 3;
                _Map.MoveShip(_AllShips[i], 1, -1);
                _Map.Update();
            }
            if (_gameTime <= 5 && _gameTime >= 4)
            {
                var i = _AllShips.FindIndex(x => x._ShipClass == "Miranda");
                _AllShips[i]._X = 1;
                i = _AllShips.FindIndex(x => x._ShipClass == "Constitution");
                _AllShips[i]._X = -1;
                _Map.Update();
            }*/
        }

        private void UpdateInput(double elapsedTime)
        {
            var i = _AllShips.FindIndex(x => x._PlayerID == _currentPlayer && x._TurnID ==_currentShip);
            var k = _AllShips.FindIndex(x => x._PlayerID == _targetPlayer && x._TurnID == _targetShip);
            var j = _Map._TileList.FindIndex(x => x._X == _AllShips[i]._X && x._X == _AllShips[i]._X && x._Contents == (TileGraphics)(int)_AllShips[i]._ShipClass);
            if (_input.Keyboard.IsKeyPressed(Keys.Space) || (_currentPlayer == 1 && _input.Controller.ButtonA.Pressed) || (_currentPlayer == 2 && _input.Controller2.ButtonA.Pressed))
            {
                /*Console.WriteLine("Firing Arc: " + ArcMath.GetArc(_AllShips[i], _AllShips[k]) + " Shield hit: " + ArcMath.GetShield(_AllShips[i], _AllShips[k]));
                _AllShips[i].Fire(_AllShips[k]);
                Console.WriteLine("Hull: " + _AllShips[k]._Hull);*/
                int Arc = ArcMath.GetArc(_AllShips[i], _AllShips[k]);
                foreach (Weapon weapon in _AllShips[i]._Weapons)
                {
                    weapon.Attack(_AllShips[k], r);
                }
            }
            //Get controls and apply to player character
            double _x = _input.Controller.LeftControlStick.X;
            double _y = _input.Controller.LeftControlStick.Y * -1;
            
            
            double _x2 = _input.Controller2.LeftControlStick.X;
            double _y2 = _input.Controller2.LeftControlStick.Y * -1;
            Vector controlInput = new Vector(_x, _y, 0);

            if (_input.Keyboard.IsKeyPressed(Keys.A))
            {
                System.Diagnostics.Debug.WriteLine("Arc: " + ArcMath.GetArc(_AllShips[i], _AllShips[k]) + ", Shield: " + ArcMath.GetShield(_AllShips[i], _AllShips[k]));
                ArcMath.GetShield(_AllShips[i], _AllShips[k]);
                ArcMath.TestCode(_AllShips[i], _AllShips[k]);   
            }

            //Require half a second between moves.
            if (_countDown <= 0)
            {
                if (_input.Keyboard.IsKeyPressed(Keys.Left) || (_currentPlayer == 1 && _x < -0.8) || (_currentPlayer == 2 && _x2 < -0.8))
                {
                    if (_AllShips[i]._turnCooldown == 0)
                    {
                        _Map._TileList[j]._facing = _AllShips[i].Turn("Left");
                        _countDown = 0.5;
                    }
                }

                if (_input.Keyboard.IsKeyPressed(Keys.Right) || (_currentPlayer == 1 && _x > 0.8) || (_currentPlayer == 2 && _x2 > 0.8))
                {
                    if (_AllShips[i]._turnCooldown == 0)
                    {

                        _Map._TileList[j]._facing = _AllShips[i].Turn("Right");
                        _countDown = 0.5;
                    }
                }

                if (_input.Keyboard.IsKeyPressed(Keys.Up) || (_currentPlayer == 1 && _y > 0.8) || (_currentPlayer == 2 && _y2 > 0.8))
                {
                    if (_AllShips[i]._remainingMove > 0)
                    {
                        if (_AllShips[i]._facing == 0)
                        {
                            _Map.MoveShip(_AllShips[i], 0, 1);
                        }
                        if (_AllShips[i]._facing == 1)
                        {
                            _Map.MoveShip(_AllShips[i], 1, 0);
                        }
                        if (_AllShips[i]._facing == 2)
                        {
                            _Map.MoveShip(_AllShips[i], 0, -1);
                        }
                        if (_AllShips[i]._facing == 3)
                        {
                            _Map.MoveShip(_AllShips[i], -1, 0);
                        }
                        _countDown = 0.25;
                        _AllShips[i]._remainingMove -= 1;
                    }

                }
            }

            if (_input.Keyboard.IsKeyPressed(Keys.Down) || (_currentPlayer == 1 && _input.Controller.ButtonStart.Pressed) || (_currentPlayer == 2 && _input.Controller2.ButtonStart.Pressed))
            {
                ChangeTurn();
            }
            if (_input.Keyboard.IsKeyPressed(Keys.B) || (_currentPlayer == 1 && _input.Controller.ButtonX.Pressed) || (_currentPlayer == 2 && _input.Controller2.ButtonX.Pressed))
            {
                ChangeTarget();
            }
        }

        private void ChangeTurn()
        {
            int HighestRemainingShipNumber = 0;
            foreach (Ship ship in _AllShips)
            {
                if (ship._TurnID > HighestRemainingShipNumber)
                {
                    HighestRemainingShipNumber = ship._TurnID;
                }
            }
            do
            {
                _currentPlayer++;
                if (_currentPlayer > _NumberOfPlayers)
                {
                    _currentPlayer = 1;
                    _currentShip++;
                    if (_currentShip > HighestRemainingShipNumber)
                    {
                        _currentShip = 1;
                        foreach (Ship ship in _AllShips)
                        {
                            ship._remainingMove = ship._Speed;
                            foreach (Weapon weapon in ship._Weapons)
                            {
                                weapon._CoolDown = Math.Max(0, weapon._CoolDown - 1);
                            }
                        }
                    }
                }
            } while (_AllShips.FindIndex(x => x._PlayerID == _currentPlayer && x._TurnID == _currentShip) == -1);


            /*if (_currentPlayer == 2)
            {
                _currentPlayer = 1;
            }
            else
            {
                 _currentPlayer = 2;
            }*/
            ChangeTarget();
            Console.WriteLine("Turn Change");
            ChangeShipHullTexture(_CurrentHull, _AllShips[_AllShips.FindIndex(x => x._PlayerID == _currentPlayer && x._TurnID == _currentShip)]);
        }

        private void ChangeShipHullTexture(Sprite sprite, Ship ship)
        {
            sprite.SetRotation(0);
            if (ship._ShipClass == ShipClasses.Miranda)
            {
                sprite.Texture = _textureManager.Get("MirandaHull");
            }
            else if (ship._ShipClass == ShipClasses.Constitution)
            {
                sprite.Texture = _textureManager.Get("ConstitutionHull");
            }
            else if (ship._ShipClass == ShipClasses.Oberth)
            {
                sprite.Texture = _textureManager.Get("OberthHull");
            }
            sprite.SetRotation(Math.PI / 2);
        }

        private void ChangeTarget()
        {
            do
            {
                _targetShip++;
                if (_targetShip >= _AllShips.Count)
                {
                    _targetShip = 1;
                    _targetPlayer++;
                    if (_targetPlayer > _NumberOfPlayers)
                    {
                        _targetPlayer = 1;
                    }
                }
                
            } while (_AllShips.FindIndex(x => x._PlayerID == _targetPlayer && x._TurnID == _targetShip) == -1);
            ChangeShipHullTexture(_TargetHull, _AllShips[_AllShips.FindIndex(x => x._PlayerID == _targetPlayer && x._TurnID == _targetShip)]);
            Console.WriteLine("Changed target: New target Player = " + _targetPlayer + ", ship " + _targetShip + " Ship: " + _AllShips[(_AllShips.FindIndex(x => x._PlayerID == _targetPlayer && x._TurnID == _targetShip))]._name);

        }

        private void UpdateUI()
        {


            // Switch these once the stat blocks are Current / Target as opposed to 1 / 2
            var i = _AllShips.FindIndex(x => x._PlayerID == _currentPlayer && x._TurnID == _currentShip);
            //var k = _AllShips.FindIndex(x => x._TurnID == _targetShip);
            var k = _AllShips.FindIndex(x => x._PlayerID == _targetPlayer && x._TurnID ==_targetShip);
            //var i = 0;
            //var k = 1;


            _CurrentSelectionOutline.SetPosition(_AllShips[i]._X * 60, _AllShips[i]._Y * 60);

            
            _TargetSelectionOutline.SetPosition(_AllShips[k]._X * 60, _AllShips[k]._Y * 60);

            CurrentHealth = _AllShips[i]._Hull.ToString();
            _CurrentHealth = new Text(CurrentHealth, _generalFont);
            _CurrentHealth.SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
            _CurrentHealth.SetPosition(-(_CurrentHealth.Width / 2) - 500, -250);

            TargetHealth = _AllShips[k]._Hull.ToString();
            _TargetHealth = new Text(TargetHealth, _generalFont);
            _TargetHealth.SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
            _TargetHealth.SetPosition(-(_TargetHealth.Width / 2) + 500, -250);



            _CurrentForeShield = _AllShips[i]._foreShield._integrity.ToString();
            _CurrentStarShield = _AllShips[i]._starShield._integrity.ToString();
            _CurrentAftShield = _AllShips[i]._aftShield._integrity.ToString();
            _CurrentPortShield = _AllShips[i]._portShield._integrity.ToString();
            _TargetForeShield = _AllShips[k]._foreShield._integrity.ToString();
            _TargetStarShield = _AllShips[k]._starShield._integrity.ToString();
            _TargetAftShield = _AllShips[k]._aftShield._integrity.ToString();
            _TargetPortShield = _AllShips[k]._portShield._integrity.ToString();

            CurrentForeShield = new Text(_CurrentForeShield, _generalFont);
            CurrentForeShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            CurrentForeShield.SetPosition(-(CurrentForeShield.Width / 2) - 500, -200);

            CurrentStarShield = new Text(_CurrentStarShield, _generalFont);
            CurrentStarShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            CurrentStarShield.SetPosition(-(CurrentStarShield.Width / 2) - 450, -250);

            CurrentAftShield = new Text(_CurrentAftShield, _generalFont);
            CurrentAftShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            CurrentAftShield.SetPosition(-(CurrentAftShield.Width / 2) - 500, -300);

            CurrentPortShield = new Text(_CurrentPortShield, _generalFont);
            CurrentPortShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            CurrentPortShield.SetPosition(-(CurrentPortShield.Width / 2) - 550, -250);

            TargetForeShield = new Text(_TargetForeShield, _generalFont);
            TargetForeShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            TargetForeShield.SetPosition(-(TargetForeShield.Width / 2) + 500, -200);

            TargetStarShield = new Text(_TargetStarShield, _generalFont);
            TargetStarShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            TargetStarShield.SetPosition(-(TargetStarShield.Width / 2) + 550, -250);

            TargetAftShield = new Text(_TargetAftShield, _generalFont); ;
            TargetAftShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            TargetAftShield.SetPosition(-(TargetAftShield.Width / 2) + 500, -300);

            TargetPortShield = new Text(_TargetPortShield, _generalFont);
            TargetPortShield.SetColor(new Book_Engine.Color(0.0f, 0.5f, 0.75f, 1));
            TargetPortShield.SetPosition(-(TargetPortShield.Width / 2) + 450, -250);

            _PlayerCurrent = _currentPlayer.ToString();
            _DisplayPlayer = new Text("Player: " + _PlayerCurrent + " Ship: " + _AllShips[i]._name, _generalFont);
            _DisplayPlayer.SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
            _DisplayPlayer.SetPosition(-(_DisplayPlayer.Width / 2), +360);
            
            {
                CurrentHullPercent = ((float)_AllShips[i]._Hull / (float)_AllShips[i]._MaxHull);
                CurrentForeShieldPercent = ((float)_AllShips[i]._foreShield._integrity / (float)_AllShips[i]._foreShield._maxIntegrity);
                CurrentStarShieldPercent = ((float)_AllShips[i]._starShield._integrity / (float)_AllShips[i]._starShield._maxIntegrity);
                CurrentAftShieldPercent = ((float)_AllShips[i]._aftShield._integrity / (float)_AllShips[i]._aftShield._maxIntegrity);
                CurrentPortShieldPercent = ((float)_AllShips[i]._portShield._integrity / (float)_AllShips[i]._portShield._maxIntegrity);

                TargetHullPercent = ((float)_AllShips[k]._Hull / (float)_AllShips[k]._MaxHull);
                TargetForeShieldPercent = ((float)_AllShips[k]._foreShield._integrity / (float)_AllShips[k]._foreShield._maxIntegrity);
                TargetStarShieldPercent = ((float)_AllShips[k]._starShield._integrity / (float)_AllShips[k]._starShield._maxIntegrity);
                TargetAftShieldPercent = ((float)_AllShips[k]._aftShield._integrity / (float)_AllShips[k]._aftShield._maxIntegrity);
                TargetPortShieldPercent = ((float)_AllShips[k]._portShield._integrity / (float)_AllShips[k]._portShield._maxIntegrity);

                _CurrentHull.SetColor(new Book_Engine.Color((1 - CurrentHullPercent), (0 + CurrentHullPercent), (0), 1));

                _TargetHull.SetColor(new Book_Engine.Color((1 - TargetHullPercent), (0 + TargetHullPercent), (0), 1));


                _CurrentShieldFore.SetColor(new Book_Engine.Color((1 - CurrentForeShieldPercent), (0 + CurrentForeShieldPercent), (0 + CurrentForeShieldPercent), 1));
                if (CurrentForeShieldPercent <= 0.0)
                {
                    _CurrentShieldFore.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }

                _CurrentShieldStar.SetColor(new Book_Engine.Color((1 - CurrentStarShieldPercent), (0 + CurrentStarShieldPercent), (0 + CurrentStarShieldPercent), 1));
                if (CurrentStarShieldPercent <= 0.0)
                {
                    _CurrentShieldStar.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }

                _CurrentShieldAft.SetColor(new Book_Engine.Color((1 - CurrentAftShieldPercent), (0 + CurrentAftShieldPercent), (0 + CurrentAftShieldPercent), 1));
                if (CurrentAftShieldPercent <= 0.0)
                {
                    _CurrentShieldAft.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }

                _CurrentShieldPort.SetColor(new Book_Engine.Color((1 - CurrentPortShieldPercent), (0 + CurrentPortShieldPercent), (0 + CurrentPortShieldPercent), 1));
                if (CurrentPortShieldPercent <= 0.0)
                {
                    _CurrentShieldPort.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }

                _TargetShieldFore.SetColor(new Book_Engine.Color((1 - TargetForeShieldPercent), (0 + TargetForeShieldPercent), (0 + TargetForeShieldPercent), 1));
                if (TargetForeShieldPercent <= 0.0)
                {
                    _TargetShieldFore.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }

                _TargetShieldStar.SetColor(new Book_Engine.Color((1 - TargetStarShieldPercent), (0 + TargetStarShieldPercent), (0 + TargetStarShieldPercent), 1));
                if (TargetStarShieldPercent <= 0.0)
                {
                    _TargetShieldStar.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }

                _TargetShieldAft.SetColor(new Book_Engine.Color((1 - TargetAftShieldPercent), (0 + TargetAftShieldPercent), (0 + TargetAftShieldPercent), 1));
                if (TargetAftShieldPercent <= 0.0)
                {
                    _TargetShieldAft.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }

                _TargetShieldPort.SetColor(new Book_Engine.Color((1 - TargetPortShieldPercent), (0 + TargetPortShieldPercent), (0 + TargetPortShieldPercent), 1));
                if (TargetPortShieldPercent <= 0.0)
                {
                    _TargetShieldPort.SetColor(new Book_Engine.Color(0, 0, 0, 0));
                }
            }
        }


        public void Render()
        {
            var i = _AllShips.FindIndex(x => x._PlayerID == _currentPlayer && x._TurnID == _currentShip);
            //var k = _AllShips.FindIndex(x => x._TurnID == _targetShip);
            var k = _AllShips.FindIndex(x => x._PlayerID == _targetPlayer && x._TurnID == _targetShip);
            //var i = 0;
            //var k = 1;

            _Map._TileList[_Map._TileList.FindIndex(x => x._ShipName == _AllShips[i]._name)].Render_Debug();
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _Map.Render(_renderer);
            if (_currentPlayer == 1)
            {

            }
            else
            {

            }
            _renderer.DrawSprite(_CurrentHull);
            _renderer.DrawSprite(_CurrentShieldFore);
            _renderer.DrawSprite(_CurrentShieldStar);
            _renderer.DrawSprite(_CurrentShieldAft);
            _renderer.DrawSprite(_CurrentShieldPort);

            _renderer.DrawSprite(_TargetHull);
            _renderer.DrawSprite(_TargetShieldFore);
            _renderer.DrawSprite(_TargetShieldStar);
            _renderer.DrawSprite(_TargetShieldAft);
            _renderer.DrawSprite(_TargetShieldPort);
            _renderer.DrawSprite(_CurrentSelectionOutline);
            _renderer.DrawSprite(_TargetSelectionOutline);

            _renderer.DrawText(_CurrentHealth);
              _renderer.DrawText(_TargetHealth);
              _renderer.DrawText(_DisplayPlayer);
              _renderer.DrawText(CurrentForeShield);
              _renderer.DrawText(CurrentStarShield);
              _renderer.DrawText(CurrentAftShield);
              _renderer.DrawText(CurrentPortShield);
              _renderer.DrawText(TargetForeShield);
              _renderer.DrawText(TargetStarShield);
              _renderer.DrawText(TargetAftShield);
              _renderer.DrawText(TargetPortShield);
            
            WeaponUI.Render(_renderer);
            
            _renderer.Render();

        }
    }
}
