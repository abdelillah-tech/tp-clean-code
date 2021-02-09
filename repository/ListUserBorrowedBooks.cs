using System;
using System.Collections.Generic;

class ListUserBorrowedBooks : IListUserBorrowedBooks
{
    private List<BorrowedBook> books = new List<BorrowedBook>();
    public ListUserBorrowedBooks(){}   
    public IEnumerable<BorrowedBook> getAll() {
        return books;
    }
    public BorrowedBook getOne(String id) {
        foreach(var book in books) {
            if(book.bookUUID == id) {
                return book;
            }
        }
        return null;
    }
    public bool save(BorrowedBook borrowedBook) {
        if (books.Contains(borrowedBook)){
            return false;
        }
        books.Add(borrowedBook);
        return true;
        
    }
    public bool remove(BorrowedBook borrowedBook) {
        if (books.Contains(borrowedBook)){
            books.Remove(borrowedBook);
            return true;
        }
        return false;
    }  
}