using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = 
                new SqlConnection("Data Source=MRLEE\\MYSERVER; initial catalog=TestDB; user id=sa; password=bc140401880");
            SqlCommand cmd = new SqlCommand("select * from LoginS", con);
            con.Open();
            using (con)
            {
                cmd.ExecuteNonQuery();
                //SqlDataReader dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    if (dr.HasRows)
                //    {
                //        Console.WriteLine(dr[0]);
                //        Console.WriteLine(dr["email"]);
                //        Console.WriteLine(dr[2]);
                //    }
                //}
            }

            Console.ReadKey();

        }
    }
}
