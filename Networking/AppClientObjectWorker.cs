using Model.model;
using Networking.DTOUtils;
using Services;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Networking
{
	public class AppClientObjectWorker : IAppObserver//,Runnable
	{
		private IServices server;
		private TcpClient connection;

		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;
		public AppClientObjectWorker(IServices server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{

				stream = connection.GetStream();
				formatter = new BinaryFormatter();
				connected = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		public virtual void run()
		{
			while (connected)
			{
				try
				{
					object request = formatter.Deserialize(stream);
					object response = handleRequest((Request)request);
					if (response != null)
					{
						sendResponse((Response)response);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.StackTrace);
				}

				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error " + e);
			}
		}

		private void sendResponse(Response response)
		{
			Console.WriteLine("sending response " + response);
			formatter.Serialize(stream, response);
			stream.Flush();

		}

		private object handleRequest(Request request)
		{
			Response response = null;
			if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq = (LoginRequest)request;
				UserDTO udto = logReq.Userdto;
				User user = transformer.getFromDTO(udto);
				try
				{
					lock (server)
					{
						server.login(user, this);
					}
					return new OkResponse();
				}
				catch (AppException e)
				{
					connected = false;
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("Logout request");
				LogoutRequest logReq = (LogoutRequest)request;
				UserDTO udto = logReq.Userdto;
				User user = transformer.getFromDTO(udto);
				try
				{
					lock (server)
					{

						server.logout(user, this);
					}
					connected = false;
					return new OkResponse();

				}
				catch (AppException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if(request is GetCurseRequest)
			{
				Console.WriteLine("Get curse request....");
				Cursa[] curse;
				try
				{
					lock (server)
					{
						curse = server.getAllRaces();
					}
					CursaDTO[] cursa = transformer.getDTO(curse);
					return new GetCursaResponse(cursa);
				}
				catch(Exception ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}
			if(request is GetParticipantsRequest)
			{
				Console.WriteLine("Get participants request.....");
				Participant[] part;

				GetParticipantsRequest req = (GetParticipantsRequest)request;
				String teamName = req.Team;
				try
				{
					lock (server)
					{
						part = server.getParticipantsByTeam(teamName);
					}

					ParticipantDTO[] parts = transformer.getDTO(part);
					return new GetParticipantsResponse(parts);
				}
				catch(Exception ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}
			if(request is SaveParticipantRequest)
			{
				Console.WriteLine("Save participant request......");

				String nume, echipa, cc;
				SaveParticipantRequest save = (SaveParticipantRequest)request;
				nume = save.Name; echipa = save.Team; cc = save.CC;

				try
				{
					lock (server)
					{
						server.saveParticipant(cc, echipa, nume);
					}
					return new OkResponse();
				}
				catch (Exception ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}
			if(request is GetEchipeRequest)
			{
				Console.WriteLine("Getting teams request......");
				Echipa[] echipa;
				try
				{
					lock (server)
					{
						 echipa = server.getAllTeams();


					}
					return new GetEchipeResponse(transformer.getDTO(echipa));
				}
				catch(Exception ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}
			return null;
		}

		public void updateCurse(int idCursa)
		{

			sendResponse(new ParticipantAdded(idCursa));
		}
	}
}
