using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConnexionBD
{
    public class BD
    {
        private static MySqlConnection _maCnx;
        private static bool _succes;

        public static MySqlConnection maCnx
        {
            get
            {
                return _maCnx;
            }

            set
            {
                _maCnx = value;
            }
        }

        public static bool succes
        {
            get
            {
                return _succes;
            }

            set
            {
                _succes = value;
            }
        }

        //Pour tester:
        //mysql -h 10.1.139.236 -u d8 -p6ABSehdzCDe
        //use based8
        public static void InitConnexion()
        {
            string serveur = "10.1.139.236";
            string login = "d8";
            string passwd = "6ABSehdzCDe";
            string BD = "based8";
            string chaineDeConnexion = $"server={serveur};uid={login};pwd={passwd};database={BD}";

            maCnx = new MySqlConnection(chaineDeConnexion);

            try
            {
                maCnx.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void FermerConnexion()
        {
            try
            {
                maCnx.Close();
                maCnx.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void InsertEnreg(string nomTable, string[] enregistrement)
        {
            string sql = "";

            switch (nomTable)
            {
                case "LIGNE":
                    sql = $"INSERT INTO LIGNE VALUES ({enregistrement[0]}, '{enregistrement[1]}', '{enregistrement[2]}', {enregistrement[3].Replace(",", ".")}, {enregistrement[4]}, {enregistrement[5]})";
                    break;

                case "ARRET":
                    sql = $"INSERT INTO ARRET VALUES ({enregistrement[0]}, '{enregistrement[1]}', '{enregistrement[2]}')";
                    break;

                case "DISTANCE":
                    sql = $"INSERT INTO DISTANCE VALUES ({enregistrement[0]}, {enregistrement[1]}, {enregistrement[2].Replace(",", ".")})";
                    break;

                case "EST_DESSERVI":
                    sql = $"INSERT INTO EST_DESSERVI VALUES ({enregistrement[0]}, {enregistrement[1]}, '{enregistrement[2]}', {enregistrement[2]})";
                    break;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, maCnx);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                succes = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(sql);

                succes = false;
            }
        }

        public static void InsertDonnee(string nomTable, string[][] enregistrements)
        {
            for (int i = 0; i < enregistrements.GetLength(0); i++)
            {
                InsertEnreg(nomTable, enregistrements[i]);
            }
        }

        public static int ObtNbEnreg(string nomTable)
        {
            string req = "";
            int res = 0;

            switch (nomTable)
            {
                case "LIGNE":
                    req = "SELECT COUNT(*) FROM LIGNE";
                    break;

                case "ARRET":
                    req = "SELECT COUNT(*) FROM ARRET";
                    break;

                case "DISTANCE":
                    req = "SELECT COUNT(*) FROM DISTANCE";
                    break;

                case "EST_DESSERVI":
                    req = "SELECT COUNT(*) FROM EST_DESSERVI";
                    break;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    res = rdr.GetInt32(0);
                }
                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }

        public static string[][] ObtDonnLigne()
        {
            string req = "SELECT * FROM LIGNE";
            int nbEnreg = ObtNbEnreg("LIGNE");
            string[][] matrice = new string[nbEnreg][];
            int i = 0;

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    matrice[i] = new string[6];

                    matrice[i][0] = rdr.GetInt32("numLigne").ToString();
                    matrice[i][1] = rdr.GetString("nomLigne");
                    matrice[i][2] = rdr.GetString("freqLigne");
                    matrice[i][3] = rdr.GetInt32("vitMoyLigne").ToString();
                    matrice[i][4] = rdr.GetInt32("numArretDep").ToString();
                    matrice[i][5] = rdr.GetInt32("numArretArr").ToString();

                    i++;
                }
                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return matrice;
        }

        public static string[][] ObtDonnArret()
        {
            string req = "SELECT * FROM ARRET";
            int nbEnreg = ObtNbEnreg("ARRET");
            string[][] matrice = new string[nbEnreg][];
            int i = 0;

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    matrice[i] = new string[3];

                    matrice[i][0] = rdr.GetString("numArret");
                    matrice[i][1] = rdr.GetString("nomArret");
                    matrice[i][2] = rdr.GetString("adrArret");

                    i++;
                }
                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return matrice;
        }

        public static string[][] ObtDonnDistance()
        {
            string req = "SELECT * FROM DISTANCE";
            int nbEnreg = ObtNbEnreg("DISTANCE");
            string[][] matrice = new string[nbEnreg][];
            int i = 0;

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    matrice[i] = new string[3];

                    matrice[i][0] = rdr.GetString("numArret1");
                    matrice[i][1] = rdr.GetString("numArret2");
                    matrice[i][2] = rdr.GetString("distArret");

                    i++;
                }
                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return matrice;
        }

        public static string[][] ObtDonnEstDesservi()
        {
            string req = "SELECT * FROM EST_DESSERVI";
            int nbEnreg = ObtNbEnreg("EST_DESSERVI");
            string[][] matrice = new string[nbEnreg][];
            int i = 0;

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    matrice[i] = new string[4];

                    matrice[i][0] = rdr.GetInt32("numLigne").ToString();
                    matrice[i][1] = rdr.GetInt32("numArret").ToString();
                    matrice[i][2] = rdr.GetString("heurePremPassage");
                    matrice[i][3] = rdr.GetInt32("numArretSuiv").ToString();

                    i++;
                }
                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return matrice;
        }

        public static void SupprEnreg(string nomTable, string[] idEnreg)
        {
            string sql = "";

            switch (nomTable)
            {
                case "LIGNE":
                    sql = $"DELETE FROM LIGNE WHERE numLigne = {idEnreg[0]}";
                    break;

                case "ARRET":
                    sql = $"DELETE FROM ARRET WHERE numArret = {idEnreg[0]}";
                    break;

                case "DISTANCE":
                    sql = $"DELETE FROM EST_DESSERVI WHERE numArret1 = {idEnreg[0]} AND numArret2 = {idEnreg[1]}";
                    break;

                case "EST_DESSERVI":
                    sql = $"DELETE FROM EST_DESSERVI WHERE numLigne = {idEnreg[0]} AND numArret = {idEnreg[1]}";
                    break;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, maCnx);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                succes = true;
            }
            catch (Exception ex)
            {
                succes = false;
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SupprDonnee(string nomTable, string[][] listeID)
        {
            for (int i = 0; i < listeID.GetLength(0); i++)
            {
                SupprEnreg(nomTable, listeID[i]);
            }
        }

        public static void ModifEnreg(string nomTable, string[] enreg, List<string> clePrim)
        {
            string sql;

            switch (nomTable)
            {
                case "LIGNE":
                    sql = $"UPDATE LIGNE SET numLigne = {enreg[0]}, nomLigne = '{enreg[1]}', freqLigne = '{enreg[2]}', vitMoyLigne = {enreg[3].Replace(",", ".")}, numArretDep = {enreg[4]}, numArretArr = {enreg[5]} WHERE numLigne = {clePrim[0]}";
                    break;

                case "ARRET":
                    sql = $"UPDATE ARRET SET numArret = {enreg[0]}, nomArret = '{enreg[1]}', adrArret = '{enreg[2]}' WHERE numArret = {clePrim[0]}";
                    break;

                case "DISTANCE":
                    sql = $"UPDATE DISTANCE SET numArret1 = {clePrim[0]}, numArret2 = {enreg[1]}, distArret = {enreg[2].Replace(",", ".")} WHERE numArret1 = {clePrim[0]} AND numArret2 = {clePrim[1]}";
                    break;

                default:
                    sql = $"UPDATE EST_DESSERVI SET numLigne = {enreg[0]}, numArret = {enreg[1]}, heurePremPassage = '{enreg[2]}', numArretSuiv = {enreg[3]} WHERE numLigne = {clePrim[0]} AND numArret = {clePrim[1]}";
                    break;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, maCnx);
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                succes = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                succes = false;
            }
        }

        public static void ModifDonnee(string nomTable, string[][] enregs, List<List<string>> clePrims)
        {
            for (int i = 0; i < enregs.GetLength(0); i++)
            {
                ModifEnreg(nomTable, enregs[i], clePrims[i]);
            }
        }

        public static void AjoutTerminus(List<string> listArret, int numLigne)
        {
            string req = $"SELECT nomArret FROM LIGNE, ARRET WHERE LIGNE.numArretArr = ARRET.numArret AND LIGNE.numLigne = {numLigne}";

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    listArret.Add(rdr.GetString(0));
                }

                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<string> ObtArret(int numLigne)
        {
            List<string> listArret = new List<string>();

            string req = $"SELECT nomArret FROM LIGNE, EST_DESSERVI, ARRET WHERE LIGNE.numLigne = EST_DESSERVI.numLigne AND EST_DESSERVI.numArret = ARRET.numArret AND LIGNE.numLigne = {numLigne}";

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    listArret.Add(rdr.GetString(0));
                }

                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            AjoutTerminus(listArret, numLigne);

            return listArret;
        }

        public static TimeSpan ObtHeurePremPassage(int numLigne, string nomLigne)
        {
            TimeSpan heurePremPassage = new TimeSpan();

            string req = $"SELECT heurePremPassage FROM EST_DESSERVI WHERE numLigne = {numLigne} AND numArret = (SELECT numArret FROM ARRET WHERE ARRET.nomArret = '{nomLigne}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    heurePremPassage = rdr.GetTimeSpan(0);
                }

                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return heurePremPassage;
        }

        public static TimeSpan ObtFreqLigne(int numLigne)
        {
            TimeSpan freqLigne = new TimeSpan();

            string req = $"SELECT freqLigne FROM LIGNE WHERE numLigne = {numLigne}";

            try
            {
                MySqlCommand cmd = new MySqlCommand(req, maCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    freqLigne = rdr.GetTimeSpan(0);
                }

                rdr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return freqLigne;
        }
    }
}