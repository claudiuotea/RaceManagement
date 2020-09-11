using Networking;
using Persistence;
using Services;
using System;
using System.Net.Sockets;
using System.Threading;
using static Networking.ServerUtils;

namespace Server
{


    class StartServer
    {
        static void Main(string[] args)
        {
            SqliteConnectionFactory sqliteConnection = new SqliteConnectionFactory("database");
            IUserRepo userRepo = new UserRepository(sqliteConnection);
            ICursaRepo cursaRepository = new CursaRepository(sqliteConnection);
            IEchipaRepo echipaRepository = new EchipaRepository(sqliteConnection);
            IParticipantRepo participantRepo = new ParticipantRepository(sqliteConnection);
            IServices serviceImpl = new ServerImpl(cursaRepository, echipaRepository, participantRepo, userRepo);

            // IChatServer serviceImpl = new ChatServerImpl();
            SerialChatServer server = new SerialChatServer("127.0.0.1", 55555, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }

        public class SerialChatServer : ConcurrentServer
        {
            private IServices server;
            private AppClientObjectWorker worker;
            public SerialChatServer(string host, int port, IServices server) : base(host, port)
            {
                this.server = server;
                Console.WriteLine("SerialChatServer...");
            }
            protected override Thread createWorker(TcpClient client)
            {
                worker = new AppClientObjectWorker(server, client);
                return new Thread(new ThreadStart(worker.run));
            }
        }
    }
}
