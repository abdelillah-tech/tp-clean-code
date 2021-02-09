using System.Linq;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;
using System;
class BorrowEngine : IBorrowEngineCommands
{
    private BorrowEngine(){}
    private static BorrowEngine _instance;
    public static BorrowEngine GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BorrowEngine();
        }
        return _instance;
    }
    private const int timeLimitInSeconds = 4 * 7;
    public Boolean isNumberOfBooksLessThenThree(IListUserBorrowedBooks borrowedBooks) {
        if(borrowedBooks.getAll().Count() < 3) return true;
        return false;
    }

    public Boolean isPeriodOfTimeRespected(BorrowedBook borrowedBook) {
        if(borrowedBook.BorrowPassedTimeInDays >= timeLimitInSeconds) {
            return false;
        }
        return true;
    }

    public String borrowTheBook(IListUserBorrowedBooks borrowedBooks,
                                BorrowedBook borrowedBook) {
        String numberOfBookIssueMessage = $"You have reached the maximum of books return some if you want to borrow {borrowedBook.bookTitle}";
        String periodOfTimeIssueMessage = $"You can't borrow {borrowedBook.bookTitle} due to exceeded time limit on at least one borrow";

        if(!isNumberOfBooksLessThenThree(borrowedBooks) && !isPeriodOfTimeRespected(borrowedBook)) {
            return $"{numberOfBookIssueMessage} and {periodOfTimeIssueMessage}";
        }

        if(!isNumberOfBooksLessThenThree(borrowedBooks)) {
            return numberOfBookIssueMessage;
        }

        if(!isPeriodOfTimeRespected(borrowedBook)) {
            return periodOfTimeIssueMessage;
        }

        borrowedBooks.save(borrowedBook);
        return $"{borrowedBook.bookTitle} borrowed";
    }

    public String returnTheBook(IListUserBorrowedBooks borrowedBooks,
                                BorrowedBook borrowedBook) {
        if(borrowedBooks.getOne(borrowedBook.bookUUID) != null) {
            borrowedBooks.remove(borrowedBook);
            return $"{borrowedBook.bookTitle} returned";
        }
        return "no such a book in your collection";
    }
}