using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingroomAdminWebApp.Core
{
    public class Korisnik
    {
        String iBrojKorRacuna;
        String iLozinka;

        public Korisnik(String pBrojKorisnickogRacuna, String pLozinka)
        {
            iBrojKorRacuna = pBrojKorisnickogRacuna;
            iLozinka = pLozinka;
        }
    }
    public class KorisnikService
    {
        public Boolean authenticate(String pBrojKorisnickogRacuna, String pLozinka)
        {
            Boolean authSuccess = false;

            if(pBrojKorisnickogRacuna == null || pLozinka == null) {
                return authSuccess;
            }
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SRAdminConnectionString"].ConnectionString;

            string tSql = "SELECT " +
                                "BROJ_KOR_RACUNA, " +
                                "LOZINKA " +
                          "FROM KORISNIK " +
                                "WHERE BROJ_KOR_RACUNA = @pBrojKorisnickogRacuna " +
                                "AND LOZINKA = @pLozinka";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(tSql, connection);
                command.Parameters.Add("@pBrojKorisnickogRacuna", SqlDbType.VarChar).Value = pBrojKorisnickogRacuna;
                command.Parameters.Add("@pLozinka", SqlDbType.VarChar).Value = pLozinka;

                try {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read()) {

                        String tmpBrojKorRacuna = dataReader["BROJ_KOR_RACUNA"].ToString();
                        String tmpLozinka = dataReader["LOZINKA"].ToString();
                        Korisnik tmpKorisnik = new Korisnik(tmpBrojKorRacuna, tmpLozinka);
                        authSuccess = true;
                    }
                }
                catch (Exception pExc) {
                    Console.WriteLine(pExc.Message);
                }
            }

            return authSuccess;
        }
    }
}
