
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

using Model.model;

namespace Persistence
{
    public class CursaRepository : ICursaRepo
    {
        //ILog log = LogManager.GetLogger("mylog");
        SqliteConnectionFactory sqliteConnection;
        public CursaRepository(SqliteConnectionFactory sqliteConnection)
        {
            this.sqliteConnection = sqliteConnection;
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cursa> findAll()
        {
            //  log.Info("Found all races");
            List<Cursa> curse = new List<Cursa>();
            SQLiteConnection connection = sqliteConnection.getConnection();
            string select = "select * from Cursa";
            /*DataSet data = new DataSet();
            var dataAdapter = new SQLiteDataAdapter(select, connection);
            dataAdapter.Fill(data);
            */
            SQLiteCommand sQLiteCommand = new SQLiteCommand(select, connection);
            SQLiteDataReader reader = sQLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                int idCursa = Convert.ToInt32(reader["idCursa"]);
                string capCilindrica = Convert.ToString(reader["capCilindrica"]);
                int numarParticipanti = Convert.ToInt32(reader["numarParticipanti"]);
                Cursa cursa = new Cursa(capCilindrica, idCursa, numarParticipanti);
                curse.Add(cursa);
            }
            return curse;
        }

        //computing for a given race the number of participants
        public int getNumberOfParticipants(int idCursa)
        {
            int numarParticipanti;
            string countParticipant = "select count(*) from Participanti p where p.idCursa == @idCursa";
            SQLiteConnection connection = sqliteConnection.getConnection();
            SQLiteCommand sQLiteCommand = new SQLiteCommand(countParticipant, connection);
            sQLiteCommand.Parameters.AddWithValue("@idCursa", idCursa);
            numarParticipanti = Convert.ToInt32(sQLiteCommand.ExecuteScalar());
            return numarParticipanti;

        }
        public Cursa findOne(int id)
        {
            //log.Info("Found the race bro!");
            SQLiteConnection connection = sqliteConnection.getConnection();
            string select = "select * from Cursa where idCursa = @idCursa";
            /*DataSet data = new DataSet();
            var dataAdapter = new SQLiteDataAdapter(select, connection);
            dataAdapter.Fill(data);
            */
            SQLiteCommand sQLiteCommand = new SQLiteCommand(select, connection);
            /*
             var parameter = sQLiteCommand.CreateParameter();
             parameter.ParameterName="@idCursa";
             parameter.Value = "1" ;
             sQLiteCommand.Parameters.Add(parameter);
             */

            sQLiteCommand.Parameters.AddWithValue("@idCursa", id);
            SQLiteDataReader reader = sQLiteCommand.ExecuteReader();
            reader.Read();
            int idCursa = Convert.ToInt32(reader["idCursa"]);
            string capCilindrica = Convert.ToString(reader["capCilindrica"]);
            int numarParticipanti = Convert.ToInt32(reader["numarParticipanti"]);
            Cursa cursa = new Cursa(capCilindrica, idCursa, numarParticipanti);
            return cursa;

        }

        public Cursa returnCursaByCapacitate(string capacitate)
        {
            Cursa toReturn = null;
            foreach (Cursa c in findAll())
                if (c.CapacitateCilindrica == capacitate)
                    toReturn = c;
            return toReturn;
        }

        public void save(Cursa entity)
        {
            throw new NotImplementedException();
        }
    }
}
