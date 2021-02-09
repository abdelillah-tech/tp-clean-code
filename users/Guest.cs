using System;
using System.Collections.Generic;
class Guest : User
{
    private readonly IRepository _userActions;
    public Guest(IRepository userActions) : base()
    {
        _userActions = userActions;
    }

    public IEnumerable<Book> getAllBooks() {
        return _userActions.getAll();
    }

    public Book getBook(String id) {
        return _userActions.getOne(id);
    }
}