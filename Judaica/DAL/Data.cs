namespace Judaica.DAL
{
    public class Data
    {
        string ConnectionString = "server=DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=Judaica;user id=sa;password=1234; TrustServerCertificate=Yes;";
        private static Data _data;
        private DataLayer DataLayer;

        private Data()
        {
            DataLayer = new DataLayer(ConnectionString);
        }
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
