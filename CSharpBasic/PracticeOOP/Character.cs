﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class Character : GameObject, IDamageable
    {
        public Character(string name, int hpMax)
        {
            Name = name;
            HpMax = hpMax;
            Hp = hpMax;
        }

        public string Name { get; private set; }

        public int HpMax { get; private set; }

        public int Hp { get; protected set; }

        public virtual void Damage(IAttacker attacker, int amount)
        {
            Hp -= amount;
        }




        /*public Character(string name, string CharacterClass)
        {
            _name = name;
            _characterClass = CharacterClass;
            if (_characterClass == "Warrior")
            {
                _hpMax = 120;
            }
            else if (_characterClass == "Magician")
            {
                _hpMax = 80;
            }
            else
            {
                _hpMax = 100;
            }
            _hp = _hpMax;
        }

        string _name;
        int _hpMax;
        int _hp;
        string _characterClass;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CharacterClass
        {
            get { return _characterClass; }
            set { _characterClass = value; }
        }

        public int HpMax
        {
            get { return _hpMax; }
        }

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }*/

    }
}
