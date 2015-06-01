using System;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp.Portable;

namespace PruebaRestSharp
{
	public class EventService
	{
		private static EventService instance;
		public static EventService Instance {
			get {
				if (instance == null) {
					instance = new EventService ();
					instance.client = new RestClient (Settings.BaseUrl + "1/classes/Event/");
				}

				return instance;
			}	
		}

		private RestClient client;

		public async Task<EventItem> GetEventItem( )//string username, string password ) 
		{
			try {
				RestRequest request = new RestRequest ("2yHLWDUlv3", HttpMethod.Get);
				//request.AddParameter( "username", username, ParameterType.GetOrPost );
				//request.AddParameter( "password", password, ParameterType.GetOrPost );
//				request.AddHeader ("Content-Type", "application/json");
//				request.AddHeader ("X-Parse-Application-Id", "QRTKWPeHWwe6EqL7GXybi6R0kV4Vqj8XLSeXii18");
//				request.AddHeader ("X-Parse-REST-API-Key", "4u2nyYR7pPrhXrdbXWHcd7BXDofOtNzren8Gmy7P");

				var response = await client.Execute<EventItem> (request);

				if (response.StatusCode == System.Net.HttpStatusCode.OK) {
					return response.Data;
				} else {
					return null;
				}
			}
			catch (Exception e) {
				return null;
			}
		}

//		public async Task<EventItem> Me()
//		{
//			try {
//				RestRequest request = new RestRequest ("me", HttpMethod.Get);
//				// User.Id constains the session id and not the user id for this instance
//				request.AddParameter( "sid", App.CurrentUser.Id, ParameterType.GetOrPost);
//				var response = await client.Execute<EventItem> (request );
//
//				if (response.StatusCode == System.Net.HttpStatusCode.OK) {
//					return response.Data;
//				} else {
//					return null;
//				}
//			}
//			catch (Exception e) {
//				return null;
//			}
//		}
	}
}

