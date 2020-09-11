using Model.model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ParticipantRepository : IParticipantRepo
    {
        SqliteConnectionFactory sqliteConnection;

        //ILog log = LogManager.GetLogger("mylog");
        public ParticipantRepository(SqliteConnectionFactory sqliteConnection)
        {
            this.sqliteConnection = sqliteConnection;
        }
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> findAll()
        {
            string findAllQuerry = "select * from Participanti";
            List<Participant> participanti = new List<Participant>();

            SQLiteConnection connection = sqliteConnection.getConnection();
            SQLiteCommand command = new SQLiteCommand(findAllQuerry, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Participant p;
                if (reader["idEchipa"] != DBNull.Value)
                    p = new Participant(Convert.ToInt32(reader["idCursa"]), Convert.ToInt32(reader["idEchipa"]), Convert.ToString(reader["nume"]));
                else
                    p = new Participant(Convert.ToInt32(reader["idCursa"]), null, Convert.ToString(reader["nume"]));
                participanti.Add(p);
            }
            return participanti;
        }

        public Participant findOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> getParticipantsByTeam(int idEchipa)
        {
            List<Participant> participants = new List<Participant>();
            foreach (var p in findAll())
                if (p.IdEchipa == idEchipa)
                    participants.Add(p);
            return participants;

        }

        public void save(Participant entity)
        {
            //  log.Info("Participant Saved!");
            SQLiteConnection connection = sqliteConnection.getConnection();
            string insert = "insert into Participanti(idCursa,idEchipa,nume) values (@idCursa,@idEchipa,@nume)";
            /*DataSet data = new DataSet();
            var dataAdapter = new SQLiteDataAdapter(select, connection);
            dataAdapter.Fill(data);
            */
            SQLiteCommand sQLiteCommand = new SQLiteCommand(insert, connection);
            sQLiteCommand.Parameters.AddWithValue("@idCursa", entity.IdCursa);
            sQLiteCommand.Parameters.AddWithValue("@idEchipa", entity.IdEchipa);
            sQLiteCommand.Parameters.AddWithValue("@nume", entity.NumeParticipant);

            sQLiteCommand.ExecuteNonQuery();
            Console.WriteLine("!@ did i t");
        }
    }
}
