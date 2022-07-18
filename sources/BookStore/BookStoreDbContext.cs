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

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace DustInTheWind.BookStore
{
    public class BookStoreDbContext
    {
        public List<Book> Books { get; }

        public List<Newspaper> Newspapers { get; } = new();

        public BookStoreDbContext()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream("DustInTheWind.BookStore.Books.txt");
            using StreamReader streamReader = new(stream);

            string json = streamReader.ReadToEnd();
            Books = JsonConvert.DeserializeObject<List<Book>>(json);
        }
    }
}