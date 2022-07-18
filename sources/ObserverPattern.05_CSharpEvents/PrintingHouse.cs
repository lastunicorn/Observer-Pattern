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
using DustInTheWind.BookStore;
using LogAccess;

namespace ObserverPattern._05_CSharpEvents
{
    internal class PrintingHouse
    {
        private readonly BookRepository bookRepository;
        private readonly NewspaperRepository newspaperRepository;
        private readonly Log log;

        public event EventHandlerDelegate<Book> BookPrinted;

        public event EventHandlerDelegate<Newspaper> NewspaperPrinted;

        public PrintingHouse(BookRepository bookRepository, NewspaperRepository newspaperRepository, Log log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));

            log.WriteAsPrintingHouse("I live again. Mu-ha-ha.");
        }

        public void PrintRandomBook()
        {
            Book book = bookRepository.GetOne();

            log.WriteAsPrintingHouse($"Book printed: {book}");

            BookPrinted?.Invoke(book);
        }

        public void PrintNewspaper()
        {
            Newspaper lastNewspaper = newspaperRepository.GetLast();
            int lastNumber = lastNewspaper?.Number ?? 0;

            Newspaper newNewspaper = new()
            {
                Number = lastNumber + 1
            };

            newspaperRepository.Add(newNewspaper);

            log.WriteAsPrintingHouse($"Issue {newNewspaper.Number} of the newspaper '{newNewspaper.Title}' was printed.");

            NewspaperPrinted?.Invoke(newNewspaper);
        }
    }
}