using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IService
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    namespace ServiceReservasi1
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
        public class Service1 : IService1
        {
            string constring = "Data Source=LAPTOP-S802VNAP;Initial Catalog=-nama Database-;Persist Security info=true;User Id=sa;Password=123;";
            SqlConnection connection;
            SqlCommand com; //untuk mengkoneksikan database ke studio

            public string deletpemesanan(string IDPemesanan)
            {
                throw new NotImplementedException();
            }

            public List<DetailLokasi> DetailLokasi()
            {
                List<DetailLokasi> LokasiFull = new List<DetailLokasi>();
                try
                {
                    string sql = "select ID_lokasi, Nama_lokasi, Dekskripsi_full, kuota from dbo.Lokasi";
                    connection = new SqlConnection(constring);
                    com = new SqlCommand(sql, connection);
                    connection.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        DetailLokasi data = new DetailLokasi();

                        data.IDLokasi = reader.GetString(0);
                        data.NamaLokasi = reader.GetString(1);
                        data.DeskripsiFull = reader.GetString(2);
                        data.kuota = reader.GetInt32(3);

                        LokasiFull.Add(data);
                    }
                    connection.Close();
                }
                catch (Exception e) { Console.WriteLine(e); }

                return LokasiFull;
            }

            public string editpemesanan(string IDPemesanan, string NamaCustomer)
            {
                throw new NotImplementedException();
            }

            public string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelepon, int JUmlahPemesanan, string IDLokasi)
            {
                string a = "gagal";
                try
                {
                    string sql = "insert into dbo.pemesanan values (" + IDPemesanan + "', '" + NamaCustomer + "', '" + NoTelepon + "'," + JUmlahPemesanan + "'," + IDLokasi + "')" +
                        "where ID_resevasi = '" + IDPemesanan + "' ";
                    connection = new SqlConnection(constring);
                    com = new SqlCommand(sql, connection);
                    connection.Open();
                    com.ExecuteNonQuery();
                    connection.Close();


                    a = "sukses";
                }
                catch (Exception es)
                {
                    Console.WriteLine(es);
                }
                return a;

            }



            public List<pemesanan> pemesanan()
            {
                List<pemesanan> pemesanans = new List<pemesanan>();
                try
                {
                    string sql = "select ID_resevasi, nama_customer, No_telpon" +
                        "jumlah_pemesanan, Nama_Lokasi from dbo.pemesanan p join dbo.Lokasi 1 on p.ID_lokasi =1.ID_lokasi";
                    connection = new SqlConnection(constring);
                    com = new SqlCommand(sql, connection);
                    connection.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        pemesanan data = new pemesanan();
                        data.IDPemesanan = reader.GetString(0);
                        data.NamaCustomer = reader.GetString(1);
                        data.NoTelpon = reader.GetString(2);
                        data.JumlahPemesanan = reader.GetInt32(3);
                        data.Lokasi = reader.GetString(4);
                        pemesanans.Add(data);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return pemesanans;
            }

            public List<CekLokasi> ReviewLokasi()
            {
                throw new NotImplementedException();
            }
        }
    }
}