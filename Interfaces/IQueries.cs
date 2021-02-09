using System;
using System.Collections.Generic;
interface IQueries<T>
{
    public IEnumerable<T> getAll();
    public T getOne(String id);
}