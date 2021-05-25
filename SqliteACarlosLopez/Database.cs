using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SqliteACarlosLopez
{
    public interface Database
    {
        //Método de conexión
        SQLiteAsyncConnection GetConnection();
    }
}
