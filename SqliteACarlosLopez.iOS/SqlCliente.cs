using Foundation;
using SQLite;
using SqliteACarlosLopez.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]
namespace SqliteACarlosLopez.iOS
{
    class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la base de datos
            var path = Path.Combine(documentsPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}