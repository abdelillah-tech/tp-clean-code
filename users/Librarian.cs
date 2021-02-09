class Librarian : User
{
    private readonly IRepository _librarianActions;
    public Librarian(IRepository librarianActions) : base()
    {
        _librarianActions = librarianActions;
    }
    public bool save(Book book) {
        return _librarianActions.save(book);
    }
    public bool remove(Book book) {
        return _librarianActions.remove(book);
    }
}