using System.Linq;
using LinQ_CSharp;
using LinQ_CSharp.Entities;
internal class Program
{
    private static void Main(string[] args)
    {
        LinqQueries queries = new LinqQueries();
        // ImprimirValores(queries.AllCollection());
        // ImprimirValores(queries.LibrosDespues2000());
        //ImprimirValores(queries.LibrosAndroid());
        //ImprimirValores(queries.LibrosAnd2005());
        // ImprimirValores(queries.LibrosAct250());
        // Console.WriteLine(queries.BookAllStatus() ? "Todos los Libros contienen el Status" : "Almenos uno de los Libros no Contiene el status");
        //ImprimirValores(queries.BookAnyStatus());
        //ImprimirValores(queries.ContainsStatuts());
        //ImprimirValores(queries.OrderByStatus());
        //ImprimirValores(queries.OrderDescending());
        //ImprimirValores(queries.TakeStatus());
        //ImprimirValores (queries.SkipStatus());
        //ImprimirValores(queries.Select());
        //Console.WriteLine(queries.CountStatus());
        //Console.WriteLine(queries.LongCountStatus());
        //ImprimirValores(queries.MinStatusPublish());
        //ImprimirValores(queries.MaxStatusPublish());
        Console.WriteLine(queries.MinByStatus());
        Console.WriteLine(queries.MaxByStatus());
        
    }

    private static void ImprimirValores(IEnumerable<Book> books)
    {
        if (books != null)
        {
            int registros = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0, -70} {1, 7} {2, 20}", "Titulo", "Nro Paginas", "Fecha Publicación");
            foreach (Book book in books)
            {
                Console.ForegroundColor = ConsoleColor.White;
                registros += 1;
                Console.WriteLine("{0, -70} {1, 7} {2, 20}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay ningun libro con esas condiciones");
        }
    Console.ForegroundColor = ConsoleColor.Gray;
    }
}
 