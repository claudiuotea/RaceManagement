using Model.model;
using Persistence;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerImpl : IServices
    {
        private ICursaRepo cursaRepository;
        private IEchipaRepo echipaRepository;
        private IParticipantRepo participantRepository;
        private IUserRepo userRepository;
        private Validator validator;
        private readonly IDictionary<String, IAppObserver> loggedClients;

        public ServerImpl(ICursaRepo cursaRepository, IEchipaRepo echipaRepository, IParticipantRepo participantRepository, IUserRepo userRepository)
        {
            this.cursaRepository = cursaRepository;
            this.echipaRepository = echipaRepository;
            this.participantRepository = participantRepository;
            this.userRepository = userRepository;
            this.validator = new Validator();
            loggedClients = new Dictionary<String, IAppObserver>();
        }

        public Cursa[] getAllRaces()
        {
            return getListOfRaces();
        }

        private Cursa[] getListOfRaces()
        {
            IEnumerable<Cursa> curse = cursaRepository.findAll();
            List<Cursa> cursa = new List<Cursa>();
            foreach (Cursa c in curse)
                cursa.Add(c);
            setNumberOfParticipants(cursa);
            return cursa.ToArray();

        }

        private void setNumberOfParticipants(List<Cursa> cursa)
        {
            foreach(Cursa c in cursa)
            {
                c.NumarParticipanti = getNumberOfParticipants(c);
            }
        }

        public void notifyParticipantAdded(int idCursa)
        { 
            foreach(IAppObserver client in loggedClients.Values)
            {
                
                Task.Run(() => client.updateCurse(idCursa));
            
            }
        }
        private int getNumberOfParticipants(Cursa c)
        {
            return cursaRepository.getNumberOfParticipants(c.Id);
        }

        public Echipa[] getAllTeams()
        {
            IEnumerable<Echipa> echipe = echipaRepository.findAll();

            List<Echipa> echipa = new List<Echipa>();

            foreach(Echipa e in echipe)
            {
                echipa.Add(e);
            }

            return echipa.ToArray();
        }

        public Participant[] getParticipantsByTeam(string teamName)
        {
            if (teamName == null || teamName == "")
                teamName = "Fara echipa";
            Echipa e = echipaRepository.findTeamByName(teamName);
            if (e == null)
                throw new Exception("Echipa invalida");
            IEnumerable<Participant> participants = participantRepository.getParticipantsByTeam(e.Id);

            List<Participant> participants1 = new List<Participant>();
            foreach(Participant p in participants)
            {
                //setez cap cilindrica
                Cursa c = cursaRepository.findOne(p.IdCursa);
                p.CapCilindrica = c.CapacitateCilindrica;
                participants1.Add(p);
                
            }
            
            return participants1.ToArray();
        }

        public void login(User user, IAppObserver client)
        {
            User findUser = userRepository.findUser(user.Username, user.Password);
            if (findUser != null)
            {
                if (loggedClients.ContainsKey(user.Username))
                    throw new AppException("User already logged in!");
                loggedClients.Add(user.Username, client);
            }
            else
                throw new AppException("Authentication failed.");

        }

        public void logout(User user, IAppObserver client)
        {
            if (loggedClients.ContainsKey(user.Username))
                loggedClients.Remove(user.Username);
            else throw new AppException("User not logged in!");
        }

        public void saveParticipant(string capCilindrica, string numeEchipa, string nume)
        {
            Cursa c = cursaRepository.returnCursaByCapacitate(capCilindrica);
            Echipa e = echipaRepository.findTeamByName(numeEchipa);

            Participant p = new Participant(c.Id, e.Id, nume);
            validator.validate(p);
            participantRepository.save(p);
            notifyParticipantAdded(p.IdCursa);
        }
    }
}
