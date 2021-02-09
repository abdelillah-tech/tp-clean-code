using System;
using System.Collections.Generic;
class ListLibrayRepository : IRepository
{
    List<Book> _books = new List<Book>();
    private ListLibrayRepository(){}
    private static ListLibrayRepository _instance;
    public static ListLibrayRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ListLibrayRepository();
        }
        return _instance;
    }
    
    public IEnumerable<Book> getAll() {
        return _books;
    }
    public Book getOne(String id) {
        foreach(var book in _books) {
            if(book.UUID == id) {
                return book;
            }
        }
        return null;
    }
    public bool save(Book book) {
        if (!_books.Contains(book)){
            _books.Add(book);
            return true;
        }
        return false;
    }
    public bool remove(Book book) {
        if (_books.Contains(book)){
            _books.Remove(book);
            return true;
        }
        return false;
    }
}