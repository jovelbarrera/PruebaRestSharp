using System;

using Xamarin.Forms;

namespace PruebaRestSharp
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			Entry username = new Entry ();
			username.Placeholder = "Usuario";

			Entry password = new Entry ();
			password.Placeholder = "Contraseña";
			password.IsPassword = true;

			Button button = new Button ();
			button.Text = "Iniciar sesión";
			button.Clicked += async (object sender, EventArgs e) => {
				App.eventItem = await EventService.Instance.GetEventItem( );//username.Text, password.Text );
				System.Diagnostics.Debug.WriteLine(App.eventItem.title);
				if( App.eventItem == null ) {

					DisplayAlert("Error","No funciona ","OK");
				}
				else {
					DisplayAlert("OK","Funcionó! "+App.eventItem.title+"-","OK");
				}
			};

			Content = new StackLayout { 
				Children = {
					username,
					password,
					button
				}
			};
		}
	}
}


