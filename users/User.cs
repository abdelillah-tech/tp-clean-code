using System.Collections.Generic;
using System;
class User
{
    private readonly String _UUID;
    public User() {
        _UUID = System.Guid.NewGuid().ToString();
    }
}