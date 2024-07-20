namespace FirstApp.Helpers
{
    public class SqliteHelper<T> where T: DataBaseModels, new()
    {
        private SQLiteConnection _connection;
        protected SQLiteConnection Database
        {
            get
            {
                var database = _connection;
                database.CreateTable<T>();
                return database;
            }
        }
        protected SqliteHelper(IPath path)
        {
            var dbPath = path.GetDatabasePath();
            _connection = new SQLiteConnection(dbPath);
        }
        public List<T> GetAllData() => Database.Table<T>().ToList();

        public int Add(T row) {
            Database.Insert(row);
            return row.Id;
        }

        public int Update(T row) => Database.Update(row);

        public int Delete(T row) => Database.Delete(row);

        public T Get (int id) => Database.Table<T>().Where(x=> x.Id == id).FirstOrDefault();

    }
}
