using System;
class BorrowedBook
{
    public String bookUUID {get;}
    public String bookTitle {get;}
    public String bookAuthor {get;}
    public ulong BorrowPassedTimeInDays {get; set;}

    public BorrowedBook(Book book) {
        this.bookUUID = book.UUID;
        this.bookTitle = book.title;
        this.bookAuthor = book.author;
        this.BorrowPassedTimeInDays = 0;
    }

    public BorrowedBook(Book book, ulong borrowPassedTimeInSecondes) {
        this.bookUUID = book.UUID;
        this.bookTitle = book.title;
        this.bookAuthor = book.author;
        this.BorrowPassedTimeInDays = borrowPassedTimeInSecondes;
    }
}