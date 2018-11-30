using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CodePuzzle
{
    class ConectData
    {
        public static SqlConnection conn = new SqlConnection(@" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\data_code.mdf;Integrated Security=True");
    }
}
