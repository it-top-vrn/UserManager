using System.Data;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChainOfAuthorizationLib.DataBase
{
    public class ConnStr
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }

        public override string ToString()
        {
            return $"Server={Server};Database={Database};Uid={Uid};Pwd={Pwd};";
        }
    }
    
    public class DB
    {
        private MySqlConnection _db;
        private MySqlCommand _command;

        public DB()
        {
            using var file = new FileStream("config.json", FileMode.Open);
            var connStr = JsonSerializer.DeserializeAsync<ConnStr>(file).Result;

            _db = new MySqlConnection(connStr.ToString());
            _command = new MySqlCommand {Connection = _db};
        }

        public async Task<Account> GetAccountAsync(string login)
        {
            await _db.OpenAsync();
            
            _command.CommandText = $"SELECT id, login, password, is_active FROM tab_accounts WHERE login = '{login}'";

            var result = await _command.ExecuteReaderAsync();

            if (!result.HasRows)
            {
                return null;
            }

            await result.ReadAsync();

            return new Account
            {
                Id = result.GetInt32("id"),
                Login = result.GetString("login"),
                Password = result.GetString("password"),
                IsActive = result.GetBoolean("is_active")
            };
        }
    }
}