﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace OnePieceDiscoBot
{
    class Program
    {
        static void Main(string[] args) => new MyBot().Start().GetAwaiter().GetResult();
       
    }
}
