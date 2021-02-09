using System.Collections.Generic;
using System;
interface IBorrowEngineCommands
{
    public String borrowTheBook(IListUserBorrowedBooks borrowedBooks,
                                BorrowedBook borrowedBook);
    public String returnTheBook(IListUserBorrowedBooks borrowedBooks,
                                BorrowedBook borrowedBook);
}