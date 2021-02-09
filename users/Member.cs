using System.Collections.Generic;
using System;
class Member : User
{
    private readonly IRepository _memberActions;
    private IListUserBorrowedBooks _personalLibrary = new ListUserBorrowedBooks();
    private readonly IBorrowEngineCommands _borrowEngine = BorrowEngine.GetInstance();
    public Member(IRepository memberActions) : base()
    {
        _memberActions = memberActions;
    }

    public IEnumerable<Book> getAlllBooks() {
        return _memberActions.getAll();
    }
    public Book getBook(String id) {
        return _memberActions.getOne(id);
    }

    public void borrowTheBook(BorrowedBook book) {
        Console.WriteLine(_borrowEngine.borrowTheBook(_personalLibrary ,book));
    }

    public void returnTheBook(BorrowedBook book) {
        Console.WriteLine(_borrowEngine.returnTheBook(_personalLibrary ,book));
    }

}