using Model.model;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class AppController : IAppObserver
    {
        public event EventHandler<AppEventArgs> updateEvent;//ctrl calls when recv an upd
        private readonly IServices server;
        private User currentUser;

        public AppController(IServices server)
        {
            this.server = server;
            this.currentUser = null;
        }

        public void login(String userId, String pass)
        {
            //preia datele din window si le trimite la server pentru validare
            User user = new User(userId, pass);
            server.login(user, this);
            Console.WriteLine("Login succeded...");
            currentUser = user;
            Console.WriteLine("Current user {0}", user);
        }

        public void logout()
        {
            Console.WriteLine("Controller logout");
            server.logout(currentUser, this);
            currentUser = null;
        }

        public IList<Cursa> getCurse()
        {
            Cursa[] curse =  server.getAllRaces();
            IList<Cursa> cursa = new List<Cursa>();

            foreach(Cursa c in curse)
            {
                cursa.Add(c);
            }

            return cursa;
        }



        public void saveParticipant(string capCilindrica, string numeEchipa, string nume)
        {
            try
            {
                server.saveParticipant(capCilindrica, numeEchipa, nume);
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        protected virtual void OnUserEvent(AppEventArgs eventArgs)
        {
            if (updateEvent == null) return;
            updateEvent(this, eventArgs);
            Console.WriteLine("update event called");
        }

        public IList<Echipa> getEchipe()
        {
            Echipa[] echipe=  server.getAllTeams();
            IList<Echipa> echipa = new List<Echipa>();

            foreach(Echipa e in echipe)
            {
                echipa.Add(e);
            }

            return echipa;
        }

        public IList<Participant> getParticipantsByTeam(String teamName)
        {

            try
            {
                Participant[] part = server.getParticipantsByTeam(teamName);
                IList<Participant> participants = new List<Participant>();

                foreach (Participant p in part)
                    participants.Add(p);
                return participants;
            }
            catch(AppException ex)
            {
                throw ex;
            }
            

            return null;
        }

        public void updateCurse(int idCursa)
        {
            AppEventArgs appEventArgs = new AppEventArgs(AppEvent.ParticipantAdded, idCursa);
            OnUserEvent(appEventArgs);
        }
    }
}
