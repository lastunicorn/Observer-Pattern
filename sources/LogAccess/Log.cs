// Observer Pattern
// Copyright (C) 2022 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace LogAccess
{
    public class Log
    {
        public void WriteAsPrintingHouse(string text)
        {
            string line = $"[Printing House] {text}";
            WriteLine(ConsoleColor.DarkYellow, line);
        }

        public void WriteAsClient(string name, string text)
        {
            string line = $"[{name}] {text}";
            WriteLine(ConsoleColor.Blue, line);
        }

        public void WriteTitle(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 79));
        }

        private static void WriteLine(ConsoleColor foregroundColor, string text)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(text);
            Console.ForegroundColor = old;
        }
    }
}