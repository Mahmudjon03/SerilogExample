using Domain.Enums;
using Domain.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Data;

public class DataContext
{
    private readonly string _connect;

    public DataContext(string connect) => _connect = connect;

    public DataContext()
    {
        _connect =@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;";
    }

    protected virtual SqlObjects? Exec(string sql, SqlParameter[] sqlParam, TypeReturn typeReturn, TypeCommand typeCommand)
    {
        SqlConnection sqlConnection = new SqlConnection(_connect);
        sqlConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

        if (typeCommand == TypeCommand.SqlQuery)
        {
            sqlCommand.CommandType = CommandType.Text;
        }
        else
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        if (sqlParam != null)
        {
            for (int i = 0; i < sqlParam.Length; i++)
            {
                sqlCommand.Parameters.Add(sqlParam[i]);
            }
        }

        if (typeReturn == TypeReturn.Empty)
        {
            sqlCommand.ExecuteNonQuery();
            return null;
        }

        if (typeReturn == TypeReturn.SqlDataReader)
        {
            return new SqlObjects()
            {
                Connection = sqlConnection,
                Command = sqlCommand,
                Reader = sqlCommand.ExecuteReader()
            };
        }

        if (typeReturn == TypeReturn.DataTable)
        {
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);

            return new SqlObjects()
            {
                Connection = sqlConnection,
                Command = sqlCommand,
                DataTable = dataTable,
                Reader = sqlDataReader
            };
        }

        if (typeReturn == TypeReturn.DataSet)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            return new SqlObjects()
            {
                Connection = sqlConnection,
                Command = sqlCommand,
                DataSet = ds
            };
        }
        throw new ShukrMoliyaException("Unknown error");
    }

    public class SqlObjects : IDisposable
    {
        private SqlConnection? _connection;
        private SqlCommand? _command;
        private SqlDataReader? _reader;
        private DataTable? _dataTable;
        private DataSet? _dataSet;
        private bool _disposed;

        public DataSet? DataSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }

        public SqlConnection? Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public SqlCommand? Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public SqlDataReader? Reader
        {
            get { return _reader; }
            set { _reader = value; }
        }

        public DataTable? DataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; }
        }

        public SqlObjects()
        {
            _disposed = false;
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _connection?.Dispose();
                _command?.Dispose();
                _dataTable?.Dispose();
                _dataSet?.Dispose();
            }

            _reader?.Close();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SqlObjects()
        {
            Dispose(false);
        }
    }
}