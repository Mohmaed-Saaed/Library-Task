namespace library_task
{
    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public bool Available { get; set; }
        public Book(string title, string author, string ISBN, bool available = true)
        {
            Title = title;
            Author = author;
            this.ISBN = ISBN;
            Available = available;
        }
    }
    class Library
    {
        List<Book> books = new List<Book>();
        public void addBook(Book book)
        {
            books.Add(book);
        }
        public string SearchForBook(string bookTitleOrAutherName)
        {
            string availability;
            foreach (Book book in books)
            {
                if (book.Title == bookTitleOrAutherName || book.Author == bookTitleOrAutherName)
                {
                    if(book.Available)
                        availability = "Available";
                     else
                        availability = "Not Availalble";
                    
                    return $"Book Name Is {book.Title}, The Author Is {book.Author}, ISBN IS {book.ISBN} And The Book Is {availability}";
                }
            }
            return $"The Book You Are Looking For [ {bookTitleOrAutherName} ] Is Not Found";
        }

        public string BorrowBook(string bookTitle)
        {
            foreach (Book book in books)
            {
                if (book.Title == bookTitle && book.Available)
                {
                    book.Available = false;
                    return "Book Borrowed Successfully.";
                }
            }
            return "The Book Is Not In The Library.";
        }
        public string ReturnBook(string bookTitle)
        {
            foreach (Book book in books)
            {
                if (book.Title == bookTitle && !book.Available)
                {
                    book.Available = true;
                    return "Book Returned Successfully.";
                }
            }
            return "The Is Already In The Library.";
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Library library = new Library();

                library.addBook(new Book("The Great Gatsby", "F. Scott Filzgerald", "9876543218567", true));
                library.addBook(new Book("To Kill a Mockingbird", "Harper Lee", "9988776611225", true));
                library.addBook(new Book("1984", "George Orwell", "3322188376514", false));

                Console.WriteLine(library.SearchForBook("1984"));
                Console.WriteLine(library.SearchForBook("2121"));

                Console.WriteLine(library.BorrowBook("To Kill a Mockingbird"));
                Console.WriteLine(library.BorrowBook("To Kill a Mockingbird"));

                Console.WriteLine(library.ReturnBook("To Kill a Mockingbird"));
                Console.WriteLine(library.ReturnBook("To Kill a Mockingbird"));
            }
        }
    }
}
