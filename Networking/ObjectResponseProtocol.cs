using Model.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Networking
{
	public interface Response
	{

	}

	[Serializable]
	public class OkResponse : Response
	{

	}

	[Serializable]
	public class ErrorResponse : Response
	{
		private string message;

		public ErrorResponse(string message)
		{
			this.message = message;
		}

		public virtual string Message
		{
			get
			{
				return message;
			}
		}
	}

	[Serializable]
	public class GetCursaResponse : Response
	{
		CursaDTO[] curse;

		public GetCursaResponse(CursaDTO[] curse)
		{
			this.curse = curse;
		}

		public CursaDTO[] Curse
		{
			get { return curse; }
		}
	}
	[Serializable]
	public class GetParticipantsResponse:Response
	{
		ParticipantDTO[] part;

		public GetParticipantsResponse(ParticipantDTO[] part)
		{
			this.part = part;
		}

		public ParticipantDTO[] Participanti
		{
			get { return part; }
		}
	}
	[Serializable]
	public class GetEchipeResponse:Response
	{
		EchipaDTO[] echipe;

		public GetEchipeResponse(EchipaDTO[] echipe)
		{
			this.echipe = echipe;
		}

		public EchipaDTO[] Echipe
		{
			get { return echipe; }
		}
	}
}
