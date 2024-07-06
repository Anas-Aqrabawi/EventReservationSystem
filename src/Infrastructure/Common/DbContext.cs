using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace SampleProject.Infrastructure.Common;
public class DbContext: IDbContext
{
    private DbConnection? _connection; // used to communicate with the database inside the Backend
    private readonly IConfiguration _configuration;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new OracleConnection(_configuration["ConnectionStrings:EventReservationCS"]);
                _connection.Open();
            }

            else if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }
    }
}
