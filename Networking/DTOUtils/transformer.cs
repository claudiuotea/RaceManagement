using Model.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Networking.DTOUtils
{
    class transformer
    {
        public static Cursa getFromDTO(CursaDTO cursadto)
        {
            string capCilindrica = cursadto.CapacitateCilindrica;
            int idCursa = cursadto.Id;
            int nrPart = cursadto.NumarParticipanti;
            return new Cursa(capCilindrica, idCursa, nrPart);
        }
        public static Participant getFromDTO(ParticipantDTO participantdto)
        {
            int idParticipant = participantdto.Id;
            int idCursa = participantdto.IdCursa;
            int? idEchipa = participantdto.IdEchipa;
            string numeParticipant = participantdto.NumeParticipant;
            string capCilindrica = participantdto.CapCilindrica;
            string numeEchipa = participantdto.NumeEchipa;
            return new Participant(idParticipant, idCursa, idEchipa, numeParticipant, capCilindrica, numeEchipa);
        }
        public static Echipa getFromDTO(EchipaDTO echipadto)
        {
            int idEchipa = echipadto.Id;
            string numeEchipa = echipadto.NumeEchipa;
            return new Echipa(idEchipa, numeEchipa);
        }
        public static User getFromDTO(UserDTO userDTO)
        {
            string username = userDTO.Username;
            string password = userDTO.Password;

            return new User(username, password);
        }

        public static UserDTO getDTO(User user)
        {
            string username = user.Username;
            string password = user.Password;

            return new UserDTO(username, password);
        }
        public static CursaDTO getDTO(Cursa cursa)
        {
            string capCilindrica = cursa.CapacitateCilindrica;
            int idCursa = cursa.Id;
            int nrPart = cursa.NumarParticipanti;
            return new CursaDTO(capCilindrica, idCursa, nrPart);

        }
        public static ParticipantDTO getDTO(Participant participant)
        {
            int idParticipant = participant.Id;
            int idCursa = participant.IdCursa;
            int? idEchipa = participant.IdEchipa;
            string numeParticipant = participant.NumeParticipant;
            string capCilindrica = participant.CapCilindrica;
            string numeEchipa = participant.NumeEchipa;
            return new ParticipantDTO(idParticipant, idCursa, idEchipa, numeParticipant, capCilindrica, numeEchipa);

        }
        public static EchipaDTO getDTO(Echipa echipa)
        {
            int idEchipa = echipa.Id;
            string numeEchipa = echipa.NumeEchipa;
            return new EchipaDTO(idEchipa, numeEchipa);
        }

        public static ParticipantDTO[] getDTO(Participant[] participants)
        {
            ParticipantDTO[] participantDTO = new ParticipantDTO[participants.Length];
            for (int i = 0; i < participants.Length; i++)
                participantDTO[i] = getDTO(participants[i]);
            return participantDTO;
        }

        public static EchipaDTO[] getDTO(Echipa[] echipe)
        {
            EchipaDTO[] teams = new EchipaDTO[echipe.Length];
            for (int i = 0; i < echipe.Length; i++)
                teams[i] = getDTO(echipe[i]);
            return teams;
        }

        public static Echipa[] getFromDTO(EchipaDTO[] echipe)
        {
            Echipa[] teams = new Echipa[echipe.Length];
            for (int i = 0; i < echipe.Length; i++)
                teams[i] = getFromDTO(echipe[i]);
            return teams;
        }

        public static Participant[] getFromDTO(ParticipantDTO[] participants)
        {
            Participant[] participanti = new Participant[participants.Length];
            for (int i = 0; i < participants.Length; i++)
                participanti[i] = getFromDTO(participants[i]);
            return participanti;
        }
        public static Cursa[] getFromDTO(CursaDTO[] curse)
        {
            Cursa[] races = new Cursa[curse.Length];
            for (int i = 0; i < curse.Length; i++)
                races[i] = getFromDTO(curse[i]);
            return races;
        }

        public static CursaDTO[] getDTO(Cursa[] curse)
        {
            CursaDTO[] curseDTO = new CursaDTO[curse.Length];
            for (int i = 0; i < curse.Length; i++)
                curseDTO[i] = getDTO(curse[i]);
            return curseDTO;
        }
    }
}
