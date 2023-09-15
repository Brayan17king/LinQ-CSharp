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
            // return from book in lstbook where book.Title.Contains("Android")&& book.PublishedDate.Year > 2005; 
        }

        public IEnumerable<Book> LibrosAct250()
        {
            //Extension Method
            return lstbook.Where(book => book.Title.Contains("Action") && book.PageCount > 250);
            // return from book in lstbook where book.Title.Contains("Action")&& && book.PageCount > 250; 
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
            return listbook.where(book => book.Title.Contains("Python"));
        }
        
    }

}