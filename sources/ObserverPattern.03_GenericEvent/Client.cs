﻿// Observer Pattern
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
using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPattern._03_GenericEvent
{
    internal class Client : ISubscriber<Book>, ISubscriber<Newspaper>
    {
        private readonly string name;
        private readonly PrintingHouse printingHouse;
        private readonly Log log;

        public Client(string name, PrintingHouse printingHouse, Log log)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.printingHouse = printingHouse ?? throw new ArgumentNullException(nameof(printingHouse));
            this.log = log ?? throw new ArgumentNullException(nameof(log));

            printingHouse.BookPrinted.Subscribe(this);
            log.WriteAsClient(name, "Subscribed to books.");

            printingHouse.NewspaperPrinted.Subscribe(this);
            log.WriteAsClient(name, "Subscribed to newspapers.");
        }

        public void HandleEvent(Book book)
        {
            log.WriteAsClient(name, $"Received book: {book}");
        }

        public void UnsubscribeFromBooks()
        {
            printingHouse.BookPrinted.Unsubscribe(this);
            log.WriteAsClient(name, "Unsubscribed from receiving books.");
        }

        public void HandleEvent(Newspaper newspaper)
        {
            log.WriteAsClient(name, $"Received newspaper {newspaper}");
        }
    }
}