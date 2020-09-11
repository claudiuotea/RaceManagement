using Model.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Networking
{
    public interface Request
    {

    }

    [Serializable]
    public class LoginRequest : Request
    {
        private UserDTO userdto;

        public LoginRequest(UserDTO userdto)
        {
            this.userdto = userdto;
        }

        public UserDTO Userdto
        {
            get { return userdto; }
            set { userdto = value; }
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        private UserDTO userdto;

        public LogoutRequest(UserDTO userdto)
        {
            this.userdto = userdto;
        }

        public UserDTO Userdto
        {
            get { return userdto; }
            set { userdto = value; }
        }
    }
    [Serializable]
    public class GetCurseRequest : Request
    {
        
    }
    [Serializable]
    public class GetParticipantsRequest : Request
    {
        String teamName;

        public GetParticipantsRequest(string teamName)
        {
            this.teamName = teamName;
        }

        public String Team
        {
            get { return teamName; }
        }
    }
    [Serializable]
    public class SaveParticipantRequest : Request
    {
        String capCilindrica, teamName, nume;

        public SaveParticipantRequest(string capCilindrica, string teamName, string nume)
        {
            this.capCilindrica = capCilindrica;
            this.teamName = teamName;
            this.nume = nume;
        }

        public String CC
        {
            get { return capCilindrica; }
        }

        public String Name
        {
            get { return nume; }
        }

        public String Team
        {
            get { return teamName; }
        }
    }

    [Serializable]
    public class GetEchipeRequest : Request
    {

    }
}
