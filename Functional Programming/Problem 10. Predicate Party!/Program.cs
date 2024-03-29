﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            ExecuteCommands(guests);
            ExecuteCommand(guests);

                
        }
        private static void ExecuteCommand(List<string> guests)
        {
            if (guests.Any())
            {
                var names = string.Join(", ", guests);
                Console.WriteLine($"{names} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void ExecuteCommands(List<string> comming)
        {
            var command = Console.ReadLine()
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Party!")
            {
                if (command.Length < 3)
                {
                    command = Console.ReadLine()
                        .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                switch (command[1])
                {
                    case "StartsWith":
                        ForeachName(command[0], comming, n => n.StartsWith(command[2]));
                        break;
                    case "EndsWith":
                        ForeachName(command[0], comming, n => n.EndsWith(command[2]));
                        break;
                    case "Length":
                        ForeachName(command[0], comming, n => n.Length == int.Parse(command[2]));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine()
                    .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void ForeachName(string command, List<string> comming, Func<string, bool> condition)
        {
            for (int i = comming.Count - 1; i >= 0; i--)
            {
                if (condition(comming[i]))
                {
                    switch (command)
                    {
                        case "Remove":
                            comming.RemoveAt(i);
                            break;
                        case "Double":
                            comming.Add(comming[i]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
