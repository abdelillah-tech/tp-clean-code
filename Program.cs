using System.Collections.Generic;
using System;

namespace tp_library_management
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryManagement = new LibraryManagement();
            libraryManagement.execute();
        } 
    }

    class LibraryManagement
    {
        public void execute()
        {
            IRepository bookLibrary = ListLibrayRepository.GetInstance();

            Librarian librarian = new Librarian(bookLibrary);
            Guest guest = new Guest(bookLibrary);
            Member member = new Member(bookLibrary);

            var testBookOne = new Book("Kahina", "Gisele Halimi");
            var testBookTwo = new Book("Power", "Robert Green");
            var testBookThree = new Book("Ainsi parlait zarathoustra","Frediric Neitch");
            var testBookFour = new Book("discoure sur l'art et la science", "jean jack rousseau");
            var testBookFive = new Book("l'etranger", "albert camus");

            librarian.save(testBookOne);
            librarian.save(testBookTwo);
            librarian.save(testBookThree);
            librarian.save(testBookFour);
            librarian.save(testBookFive);

            printLibrary(guest.getAllBooks());

            var testBorrowBookOne = new BorrowedBook(testBookOne, 4*7);
            var testBorrowBookTwo = new BorrowedBook(testBookTwo, 3*7);
            var testBorrowBookThree = new BorrowedBook(testBookThree, 2*7);
            var testBorrowBookFour = new BorrowedBook(testBookFour, 1*7);
            var testBorrowBookFive = new BorrowedBook(testBookFive, 1);

            member.borrowTheBook(testBorrowBookOne);
            member.borrowTheBook(testBorrowBookTwo);
            member.borrowTheBook(testBorrowBookThree);
            member.borrowTheBook(testBorrowBookFour);
            member.borrowTheBook(testBorrowBookFive);

            member.returnTheBook(testBorrowBookFive);
            member.returnTheBook(testBorrowBookThree);
            

            printLibrary(member.getAlllBooks());

            librarian.remove(testBookOne);
            printLibrary(member.getAlllBooks());



        }

        public void printLibrary(IEnumerable<Book> bookLibrary) 
        {
            Console.WriteLine($"Library :");
            foreach(var book in bookLibrary) {
                printBook(book);
            }
        }

        public void printBook(Book book) 
        {
            Console.WriteLine($"{book.UUID}, {book.title}, {book.author}");
        }
    }
}
