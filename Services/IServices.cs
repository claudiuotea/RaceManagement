using Model.model;
using System;

namespace Services
{
    public interface IServices
    {
        Cursa[] getAllRaces();

        //Integer getNumberOfParticipants(Cursa cursa);

        //void setNumberOfParticipants(Cursa[] curse);


        Participant[] getParticipantsByTeam(String teamName);

        void saveParticipant(String capCilindrica, String numeEchipa, String nume);


        //Cursa findOneRace(Integer idCursa);


        //Echipa[] getAllTeams();


        //Cursa getCursaByCapacitate(String capacitate);


        //Echipa findTeamByName(String teamName) throws SQLException ;

        void login(User user, IAppObserver client);

        void logout(User user, IAppObserver client);

        Echipa[] getAllTeams();
    }
}
