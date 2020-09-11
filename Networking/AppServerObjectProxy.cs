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
	public class AppServerObjectProxy : IServices
	{
		private string host;
		private int port;

		private IAppObserver client;

		private NetworkStream stream;

		private IFormatter formatter;
		private TcpClient connection;

		private Queue<Response> responses;
		private volatile bool finished;
		private EventWaitHandle _waitHandle;
		public AppServerObjectProxy(string host, int port)
		{
			this.host = host;
			this.port = port;
			responses = new Queue<Response>();
		}


		public void updateCurse(Cursa[] curse)
		{
			throw new NotImplementedException();
		}

		private void closeConnection()
		{
			finished = true;
			try
			{
				stream.Close();
				//output.close();
				connection.Close();
				_waitHandle.Close();
				client = null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void sendRequest(Request request)
		{
			try
			{
				formatter.Serialize(stream, request);
				stream.Flush();
			}
			catch (Exception e)
			{
				throw new AppException("Error sending object " + e);
			}

		}

		private Response readResponse()
		{
			Response response = null;
			try
			{
				_waitHandle.WaitOne();
				lock (responses)
				{
					//Monitor.Wait(responses); 
					response = responses.Dequeue();

				}


			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
			return response;
		}
		private void initializeConnection()
		{
			try
			{
				connection = new TcpClient(host, port);
				stream = connection.GetStream();
				formatter = new BinaryFormatter();
				finished = false;
				_waitHandle = new AutoResetEvent(false);
				startReader();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}
		private void startReader()
		{
			Thread tw = new Thread(run);
			tw.Start();
		}


		private void handleUpdate(UpdateResponse update)
		{
			if (update is ParticipantAdded)
			{
				ParticipantAdded upd = (ParticipantAdded)update;

				try
				{

					client.updateCurse(upd.IdCursa);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

			}
		}

		public virtual void run()
		{
			while (!finished)
			{
				try
				{
					object response = formatter.Deserialize(stream);
					Console.WriteLine("response received " + response);
					if (response is UpdateResponse)
					{
						handleUpdate((UpdateResponse)response);
					}
					else
					{

						lock (responses)
						{


							responses.Enqueue((Response)response);

						}
						_waitHandle.Set();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Reading error " + e);
				}

			}
		}

		public Cursa[] getAllRaces()
		{
			Console.WriteLine("Proxy---sending race request...");
			Request request = new GetCurseRequest();

			sendRequest(request);

			Response response = readResponse();
			
			if(response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new AppException(err.Message);
			}

			GetCursaResponse cursaResponse = (GetCursaResponse)response;
			Cursa[] curse = transformer.getFromDTO(cursaResponse.Curse);
			return curse;
		}

		public Participant[] getParticipantsByTeam(string teamName)
		{
			Console.WriteLine("Prxy----sending participants request....");

			Request request = new GetParticipantsRequest(teamName);

			sendRequest(request);

			Response response = readResponse();

			if(response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new AppException(err.Message);
			}

			GetParticipantsResponse resp = (GetParticipantsResponse)response;

			ParticipantDTO[] participants= resp.Participanti;
			Participant[] participants1 = transformer.getFromDTO(participants);

			return participants1;
		}

		public void saveParticipant(string capCilindrica, string numeEchipa, string nume)
		{
			Console.WriteLine("Proxy --- sending save request....");

			Request request = new SaveParticipantRequest(capCilindrica, numeEchipa, nume);

			sendRequest(request);

			Response response = readResponse();

			if(response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new AppException(err.Message);
			}

			Console.WriteLine("-----Participant saved-----");
		}

		public void login(User user, IAppObserver client)
		{
			Console.WriteLine("Client == null: " + (client == null));
			initializeConnection();
			Console.WriteLine("Proxy: sending login request..");
			UserDTO userDTO = transformer.getDTO(user);
			sendRequest(new LoginRequest(userDTO));
			Console.WriteLine("Proxy: getting response..");
			Response response = readResponse();
			Console.WriteLine(response);
			if (response != null)
			{
				if (response is OkResponse)
				{
					this.client = client;
					Console.WriteLine("PROXY: Client saved");

					return;
				}

				if (response is ErrorResponse)
				{
					ErrorResponse err = (ErrorResponse)response;
					closeConnection();
					throw new AppException(err.Message);
				}
			}
		}

		public void logout(User user, IAppObserver client)
		{
			Console.WriteLine("Proxy: sending logout request....");
			UserDTO userDTO = transformer.getDTO(user);
			sendRequest(new LogoutRequest(userDTO));
			Response response = readResponse();
			closeConnection();
			if(response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new AppException(err.Message);
			}
		}

		public Echipa[] getAllTeams()
		{
			Console.WriteLine("Proxy: sending team request.....");

			Request request = new GetEchipeRequest();

			sendRequest(request);

			Response response = readResponse();

			if(response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new AppException(err.Message);
			}

			GetEchipeResponse resp = (GetEchipeResponse)response;
			Echipa[] echipe = transformer.getFromDTO(resp.Echipe);
			return echipe;

 		}
	}
}
