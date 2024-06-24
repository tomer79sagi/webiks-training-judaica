namespace Judaica.DAL
{
    public class Data
    {
        string ConnectionString = "server=DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=Judaica;user id=sa;password=1234; TrustServerCertificate=Yes;";
        static Data _data;
        private Data()
        {
            DataLayer = new DataLayer(ConnectionString);
        }
        private DataLayer DataLayer;
        public static DataLayer Get
        {
            get
            {
                if (_data == null) _data = new Data();
                return _data.DataLayer;
            }
        }
    }
}
