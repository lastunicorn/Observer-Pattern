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

namespace DustInTheWind.BookStore
{
    public class BookRepository
    {
        private readonly BookStoreDbContext dbContext;
        private readonly Random random;

        public BookRepository(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            random = new Random();
        }

        public Book GetOne()
        {
            if (dbContext.Books.Count == 0)
                return null;

            int index = random.Next(dbContext.Books.Count);
            return dbContext.Books[index];
        }
    }
}