using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinQ_CSharp.Entities;

namespace LinQ_CSharp
{
    public class LinqQueries
    {
        List<Book> lstbook = new List<Book>();
        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string jsonSring = reader.ReadToEnd();
                this.lstbook = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(jsonSring, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new List<Book>();
            }
        }
        public IEnumerable<Book> AllCollection()
        {
            return lstbook;
        }

        public IEnumerable<Book> LibrosDespues2000()
        {
            try
            {
                //Extension Method 
                return from book in lstbook where book.PublishedDate.Year > 2000 select book;
            }
            catch
            {
                return lstbook.Where(book => book.PublishedDate.Year > 2000);
            }
        }

        public IEnumerable<Book> LibrosAndroid()
        {
            //Extension Method
            return lstbook.Where(book => book.Title.Contains("Android"));
            // return from book in lstbook where book.Title.Contains("Android") select book; 
        }

        public IEnumerable<Book> LibrosAnd2005()
        {
            //Extension Method
            return lstbook.Where(book => book.Title.Contains("Android") && book.PublishedDate.Year > 2005);
            // return from book in lstbook where book.Title.Contains("Android")&& book.PublishedDate.Year > 2005 select book; 
        }

        public IEnumerable<Book> LibrosAct250()
        {
            //Extension Method
            return lstbook.Where(book => book.Title.Contains("Action") && book.PageCount > 250);
            // return from book in lstbook where book.Title.Contains("Action")&& && book.PageCount > 250 select book; 
        }

        public bool BookAllStatus()
        {
            //return lstbook.All(book => book.Status.Length > 0);
            return lstbook.All(book => book.Status != string.Empty);
        }
        
        public bool BookAny()
        {
            return lstbook.Any(book => book.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> BookAnyStatus()
        {
            if (BookAny())
            {
                return lstbook.Where(book => book.PublishedDate.Year == 2005);
            }
            else
            {
                return default;
            }
        }

        public IEnumerable<Book> ContainsStatuts()
        {
            //return lstbook.Where(book => book.Title.Contains("Python"));
            return from book in lstbook where book.Title.Contains("Python") select book;
        }
        
        public IEnumerable<Book> OrderByStatus()
        {
            //return lstbook.Where(book => book.Categories.Contains("Java")).OrderBy(book => book.Title);
            return from book in lstbook where book.Categories.Contains("Java") orderby book.Title select book;
        }

        public IEnumerable<Book> OrderDescending()
        {
            //return lstbook.Where (book => book.PageCount > 450).OrderByDescending(book => book.PageCount);
            return from book in lstbook where book.PageCount > 450 orderby book.PageCount descending select book; 
        }

        public IEnumerable<Book> TakeStatus()
        {
            //return lstbook.Where (book => book.PublishedDate.Year < 2024).OrderByDescending(book => book.PublishedDate.Year).Take(3);
            var take =  from book in lstbook where book.PublishedDate.Year < 2024 orderby book.PublishedDate.Year descending select book;
            return take.Take(3);  
        }

        public IEnumerable<Book> SkipStatus()
        {
            //return lstbook.Where (book => book.PageCount > 400).OrderBy(book => book.PageCount).Take(4).Skip(2);
            var skip = from book in lstbook where book.PageCount > 400 orderby book.PageCount select book;
            return skip.Take(4).Skip(2);
        }

        public IEnumerable<Book> Select()
        {
            return lstbook.Take(3).Select(book => new Book{Title = book.Title, PageCount = book.PageCount});
        }

        public int CountStatus()
        {
            return lstbook.Count(book => book.PageCount >= 200 && book.PageCount <= 500);
        }

        public long LongCountStatus()
        {
            return lstbook.LongCount(book => book.PageCount >= 200 && book.PageCount <= 500);
        }

        public DateTime MinStatus()
        {
            return lstbook.Min(book => book.PublishedDate);
        }

        public IEnumerable<Book> MinStatusPublish()
        {
            var fechaPublic = lstbook.Min(libro => libro.PublishedDate);
            return lstbook.Where(libro => libro.PublishedDate == fechaPublic);
        }

        public IEnumerable<Book> MaxStatusPublish()
        {
            var fechaPublic = lstbook.Max(libro => libro.PublishedDate);
            return lstbook.Where(libro => libro.PublishedDate == fechaPublic);
        }

        public Book MinByStatus()
        {
            return lstbook.Where(book => book.PageCount>0).MinBy(myBook => myBook.PageCount) ?? new Book();
        }

        public Book MaxByStatus()
        {
            return lstbook.Where(book => book.PageCount>0).MaxBy(myBook => myBook.PageCount) ?? new Book();
        }

        public int sumStatus()
        {
            return lstbook.Where(book => book.PageCount > 0 && book.PageCount <= 500).Sum(myBook => myBook.PageCount);
        }

        public string Aggregate()
        {
            return lstbook.Where(book => book.PublishedDate.Year > 2015).Aggregate("", (tituloLibros,next) => {
                if (tituloLibros != string.Empty)
                {
                    tituloLibros += " - " + next.Title;
                }
                else
                {
                    tituloLibros += next.Title;
                }
                return tituloLibros;
            });
        }

        public double AverageStatus()
        {
            return lstbook.Average(book => (book.Title ?? string.Empty).Length);
        }

        public IEnumerable<IGrouping<int,Book>> GroupByStatus()
        {
            return lstbook.Where(book => book.PublishedDate.Year >= 2000).GroupBy(myBook => myBook.PublishedDate.Year);
        }

         public ILookup<char,Book> LookupStatus()
        {
            return lstbook.ToLookup(book => book.Title?[0] ?? default(char), book => book);
        }

        public IEnumerable<Book> JoinStatus()
        {
            var Libros2005 = lstbook.Where(b => b.PublishedDate.Year > 2005);
            var Libros500p = lstbook.Where(b => b.PageCount > 500);
            return Libros2005.Join(Libros500p, p => p.Title, x => x.Title,(p,x)=>p);
        }
        
    }
}