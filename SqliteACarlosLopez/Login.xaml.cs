using SQLite;
using SqliteACarlosLopez.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteACarlosLopez
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;

        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante>SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contrasenia = ? ", usuario, contrasenia);
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(databasePath);

                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtConstraseña.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta","Datos erroneos","ok");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }

        }
    }
}