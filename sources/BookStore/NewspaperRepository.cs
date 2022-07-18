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
using System.Linq;

namespace DustInTheWind.BookStore
{
    public class NewspaperRepository
    {
        private readonly BookStoreDbContext dbContext;

        public NewspaperRepository(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Newspaper GetLast()
        {
            return dbContext.Newspapers
                .OrderByDescending(x => x.Number)
                .FirstOrDefault();
        }

        public void Add(Newspaper newspaper)
        {
            if (newspaper == null) throw new ArgumentNullException(nameof(newspaper));

            dbContext.Newspapers.Add(newspaper);
        }
    }
}