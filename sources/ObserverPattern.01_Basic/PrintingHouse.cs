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
using System.Collections.Generic;
using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPattern._01_Basic
{
    internal class PrintingHouse
    {
        private readonly BookRepository bookRepository;
        private readonly Log log;
        private readonly List<IBookPrintedSubscriber> subscribers = new();

        public PrintingHouse(BookRepository bookRepository, Log log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));

            log.WriteAsPrintingHouse("I live again. Mu-ha-ha.");
        }

        public void Subscribe(IBookPrintedSubscriber subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));

            subscribers.Add(subscriber);
        }

        public void Unsubscribe(IBookPrintedSubscriber subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));

            subscribers.Remove(subscriber);
        }

        public void PrintRandomBook()
        {
            Book book = bookRepository.GetOne();

            log.WriteAsPrintingHouse($"Book printed: {book}");

            Notify(book);
        }

        private void Notify(Book book)
        {
            foreach (IBookPrintedSubscriber listener in subscribers)
                listener.HandleBookPrinted(book);
        }
    }
}