using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2ExamenC
{
    public partial class App : Application
    {
        static Controllers.DBProc dbProc;

        public static Controllers.DBProc Instancia
        {
            get
            {
                if (dbProc == null)
                {
                    string dbname = "PersonaDB.db3";
                    String dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    String dbfull = Path.Combine(dbpath, dbname);
                    dbProc = new Controllers.DBProc(dbfull);

                }
                return dbProc;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PagePerson());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
