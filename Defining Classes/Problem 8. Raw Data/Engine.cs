﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_8._Raw_Data
{
    public class Engine
    {
        private int speed;
        private int power;

        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }

        public int Power
        {
            get { return this.power; }
        }
    }
}
