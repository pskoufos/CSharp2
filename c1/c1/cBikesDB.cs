using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyDatabases 
{
    public class cBikesDB
    {
        private const string constr = @"Data Source=KAVA\SQLEXPRESS2012;Initial Catalog=Bikes;User ID=1;Password=1";


        public void ShowTblStores()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Database Reader ....");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql = "Select * from sales.stores";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlDataReader dr =  cmd.ExecuteReader();
                        var values =new Object [dr.FieldCount];
                        Console.WriteLine("Start ......."); 
                        while (dr.Read())
                        {
                            dr.GetValues (values);
                            Console.WriteLine(String.Join('\t' , values));
                        }
                        Console.WriteLine("End .......");
                        dr.Close();
                    }//  using command
                    con.Close();
                }//using connection
            }//try
            catch (Exception ex )
            {

                Console.WriteLine(ex.Message); 
            }//catch
            finally
            {
                Console.WriteLine("\nPress a key to Return....");
                Console.ReadKey();
            }


        }//showTable


        public void TabletoXml()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Table to XML....");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql = "Select * from sales.stores";
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                    {
                        DataSet dsStores = new  DataSet();
                        adapter.Fill(dsStores);
                        dsStores.WriteXml(@"c:\temp\stores.xml", XmlWriteMode.WriteSchema);
                        dsStores.Clear();
                        Console.WriteLine("\nXML file saved....");
                    }//  using adapter
                    con.Close();
                }//using connection
            }//try
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }//catch
            finally
            {
                Console.WriteLine("\nPress a key to Return....");
                Console.ReadKey();
            }


        }//showTable


    }//class
}//namespace
