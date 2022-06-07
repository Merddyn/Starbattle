using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Book_Engine;

namespace StarBattle
{
    public class WeaponCoolDownUI
    {
        TextureManager _textureManager;
        List<Text> _WeaponUI = new List<Text>();
        Font _GeneralFont;



        public WeaponCoolDownUI(TextureManager textureManager, Font GeneralFont)
        {
            _textureManager = textureManager;
            _GeneralFont = GeneralFont;
        }

        public void UpdateUI(Ship CurrentShip, Ship TargetShip)
        {
            for (int i = _WeaponUI.Count - 1; i >= 0; i--)
            {
                _WeaponUI.RemoveAt(i);   
            }
            
            
            foreach (Weapon weapon in CurrentShip._Weapons)
            {
                if (weapon._Type == "Phaser")
                {
                    if (weapon._FireRate == 3)
                    {
                        if (weapon._Arc == 0)
                        {
                            _WeaponUI.Add(new Text("Fore Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                        if (weapon._Arc == 1)
                        {
                            _WeaponUI.Add(new Text("Star Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                        if (weapon._Arc == 2)
                        {
                            _WeaponUI.Add(new Text("Aft Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                        if (weapon._Arc == 3)
                        {
                            _WeaponUI.Add(new Text("Port Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                    }
                    else if (weapon._Arc == 0)
                    {
                        _WeaponUI.Add(new Text("Fore P " + weapon._CoolDown, _GeneralFont));
                    }
                    else if (weapon._Arc == 1)
                    {
                        _WeaponUI.Add(new Text("Starboard P " + weapon._CoolDown, _GeneralFont));
                    }
                    else if (weapon._Arc == 2)
                    {
                        _WeaponUI.Add(new Text("Aft P " + weapon._CoolDown, _GeneralFont));
                    }
                    else if (weapon._Arc == 3)
                    {
                        _WeaponUI.Add(new Text("Port P " + weapon._CoolDown, _GeneralFont));
                    }
                }
                else if(weapon._Type == "Torpedo")
                {
                    if (weapon._Arc == 0)
                    {
                        _WeaponUI.Add(new Text("Fore T " + weapon._CoolDown, _GeneralFont));
                    }
                    if (weapon._Arc == 1)
                    {
                        _WeaponUI.Add(new Text("Starboard T " + weapon._CoolDown, _GeneralFont));
                    }
                    if (weapon._Arc == 2)
                    {
                        _WeaponUI.Add(new Text("Aft T " + weapon._CoolDown, _GeneralFont));
                    }
                    if (weapon._Arc == 3)
                    {
                        _WeaponUI.Add(new Text("Port T " + weapon._CoolDown, _GeneralFont));
                    }
                }
                int a = _WeaponUI.Count - 1;
                _WeaponUI[a].SetPosition((_WeaponUI[0].Width / 2) - 690, +330 - (a * 28));
                _WeaponUI[a].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
                    //_DisplayPlayer.SetPosition(-(_DisplayPlayer.Width / 2) - 500, +250);
            }
            _WeaponUI.Add(new Text("Moves: " + CurrentShip._remainingMove + "/" + CurrentShip._Speed, _GeneralFont));
            int d = _WeaponUI.Count - 1;
            _WeaponUI[d].SetPosition((_WeaponUI[0].Width / 2) - 690, +330 - (d * 28));
            _WeaponUI[d].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
            _WeaponUI.Add(new Text("Turn Cool: " + CurrentShip._turnCooldown, _GeneralFont));
            d = _WeaponUI.Count - 1;
            _WeaponUI[d].SetPosition((_WeaponUI[0].Width / 2) - 690, +330 - (d * 28));
            _WeaponUI[d].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
            _WeaponUI.Add(new Text("Ship: " + CurrentShip._name, _GeneralFont));
            d = _WeaponUI.Count - 1;
            _WeaponUI[d].SetPosition((_WeaponUI[0].Width / 2) - 690, +330 - (d * 28));
            _WeaponUI[d].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));


            int c = _WeaponUI.Count;
            foreach (Weapon weapon in TargetShip._Weapons)
            {
                if (weapon._Type == "Phaser")
                {
                    if (weapon._FireRate == 3)
                    {
                        if (weapon._Arc == 0)
                        {
                            _WeaponUI.Add(new Text("Fore Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                        if (weapon._Arc == 1)
                        {
                            _WeaponUI.Add(new Text("Star Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                        if (weapon._Arc == 2)
                        {
                            _WeaponUI.Add(new Text("Aft Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                        if (weapon._Arc == 3)
                        {
                            _WeaponUI.Add(new Text("Port Mega-P " + weapon._CoolDown, _GeneralFont));
                        }
                    }
                    else if (weapon._Arc == 0)
                    {
                        _WeaponUI.Add(new Text("Fore P " + weapon._CoolDown, _GeneralFont));
                    }
                    else if (weapon._Arc == 1)
                    {
                        _WeaponUI.Add(new Text("Starboard P " + weapon._CoolDown, _GeneralFont));
                    }
                    else if (weapon._Arc == 2)
                    {
                        _WeaponUI.Add(new Text("Aft P " + weapon._CoolDown, _GeneralFont));
                    }
                    else if (weapon._Arc == 3)
                    {
                        _WeaponUI.Add(new Text("Port P " + weapon._CoolDown, _GeneralFont));
                    }
                }
                else if (weapon._Type == "Torpedo")
                {
                    if (weapon._Arc == 0)
                    {
                        _WeaponUI.Add(new Text("Fore T " + weapon._CoolDown, _GeneralFont));
                    }
                    if (weapon._Arc == 1)
                    {
                        _WeaponUI.Add(new Text("Starboard T " + weapon._CoolDown, _GeneralFont));
                    }
                    if (weapon._Arc == 2)
                    {
                        _WeaponUI.Add(new Text("Aft T " + weapon._CoolDown, _GeneralFont));
                    }
                    if (weapon._Arc == 3)
                    {
                        _WeaponUI.Add(new Text("Port T " + weapon._CoolDown, _GeneralFont));
                    }
                }
                int a = _WeaponUI.Count - 1;
                int b = _WeaponUI.Count - c;
                _WeaponUI[a].SetPosition((_WeaponUI[0].Width / 2) + 265, +360 - (b * 28));
                _WeaponUI[a].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
                //_DisplayPlayer.SetPosition(-(_DisplayPlayer.Width / 2) - 500, +250);
                
            }
            
            _WeaponUI.Add(new Text("Moves: " + TargetShip._remainingMove + "/" + TargetShip._Speed, _GeneralFont));
            d = (_WeaponUI.Count - c);
            int e = (_WeaponUI.Count - 1);
            _WeaponUI[e].SetPosition((_WeaponUI[0].Width / 2) +265, +360 - (d * 28));
            _WeaponUI[e].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
            _WeaponUI.Add(new Text("Turn Cool: " + TargetShip._turnCooldown, _GeneralFont));
            d = _WeaponUI.Count - c;
            e = _WeaponUI.Count - 1;
            _WeaponUI[e].SetPosition((_WeaponUI[0].Width / 2) +265, +360 - (d * 28));
            _WeaponUI[e].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
            _WeaponUI.Add(new Text("Ship: " + TargetShip._name, _GeneralFont));
            d = _WeaponUI.Count - c;
            e = _WeaponUI.Count - 1;
            _WeaponUI[e].SetPosition((_WeaponUI[0].Width / 2) + 265, +360 - (d * 28));
            _WeaponUI[e].SetColor(new Book_Engine.Color(0.5f, 0.5f, 0.5f, 1));
        }

        public void Render(Renderer renderer)
        {
            foreach(Text text in _WeaponUI)
            {
                renderer.DrawText(text);
            }
        }
    }
}
