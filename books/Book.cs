using System;
class Book
{
    public String UUID {get; set;}
    public String title {get; set;}
    public String author {get; set;}

    public Book(String title, String author) {
        UUID = System.Guid.NewGuid().ToString();
        this.title = title;
        this.author = author;
    }
}