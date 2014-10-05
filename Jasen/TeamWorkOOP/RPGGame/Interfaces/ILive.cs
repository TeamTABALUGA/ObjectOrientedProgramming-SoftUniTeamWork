﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGGame
{
    public interface ILive
    {
        void CreatureLiveStatus();
        void DamageMade();
        void CurrentDamageResistance();
    }
}