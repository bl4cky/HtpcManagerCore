﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HtpcManagerCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"HtpcManager Program started on {DateTime.Now.ToString("R")}");

            FileHandler fileHandler = new FileHandler(args);
            fileHandler.MoveAllFiles();
            //FileHandler.MoveAllFiles(args);


            Console.Read();

        }


    }
}
