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

using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPattern._03_GenericEvent
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BookStoreDbContext bookStoreDbContext = new();
            BookRepository bookRepository = new(bookStoreDbContext);
            NewspaperRepository newspaperRepository = new(bookStoreDbContext);
            Log log = new();

            log.WriteTitle("The setup");
            PrintingHouse printingHouse = new(bookRepository, newspaperRepository, log);
            Client client1 = new("Alina", printingHouse, log);
            Client client2 = new("Mihai", printingHouse, log);

            log.WriteTitle("First printing");
            printingHouse.PrintRandomBook();

            log.WriteTitle("Second printing");
            client1.UnsubscribeFromBooks();
            printingHouse.PrintRandomBook();

            log.WriteTitle("Third printing");
            printingHouse.PrintNewspaper();
            printingHouse.PrintNewspaper();
        }
    }
}