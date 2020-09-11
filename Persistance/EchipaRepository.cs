using Model.model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class EchipaRepository : IEchipaRepo
    {
        //ILog log = LogManager.GetLogger("mylog");
        SqliteConnectionFactory sqliteConnection;

        public EchipaRepository(SqliteConnectionFactory sqliteConnection)
        {
            this.sqliteConnection = sqliteConnection;
        }
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Echipa> findAll()
        {
            //log.Info("Found all teams!");
            List<Echipa> echipe = new List<Echipa>();
            SQLiteConnection connection = sqliteConnection.getConnection();
            string select = "select * from Echipa";
            /*DataSet data = new DataSet();
            var dataAdapter = new SQLiteDataAdapter(select, connection);
            dataAdapter.Fill(data);
            */
            SQLiteCommand sQLiteCommand = new SQLiteCommand(select, connection);
            SQLiteDataReader reader = sQLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                int idEchipa = Convert.ToInt32(reader["idEchipa"]);
                string numeEchipa = Convert.ToString(reader["numeEchipa"]);
                Echipa echipa = new Echipa(idEchipa, numeEchipa);
                echipe.Add(echipa);
            }
            return echipe;
        }

        public Echipa findOne(int id)
        {
            throw new NotImplementedException();
        }

        public Echipa findTeamByName(string teamName)
        {
            Echipa toReturn = null;
            foreach (Echipa e in findAll())
                if (e.NumeEchipa == teamName)
                    toReturn = e;
            return toReturn;
        }



        public void save(Echipa entity)
        {
            throw new NotImplementedException();
        }
    }
}
