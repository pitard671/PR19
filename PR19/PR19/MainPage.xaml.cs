using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PR19
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void PostUserRegistration(object sender, EventArgs e)
        {
            var user = new User { Login = eLogin.Text, Password = ePassword.Text, Surname = eSurname.Text, Name = eName.Text, Patronimyc = ePatronimyc.Text };
            string json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://lab20.somee.com/api/Users/Registration/");
            request.Method = HttpMethod.Post;
            request.Content = content;
            HttpResponseMessage response = await client.SendAsync(request);

        }

        private async void GetUser(object sender, EventArgs e)
        {
            var user = new User { Login = eLogin.Text, Password = ePassword.Text };
            string json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://lab20.somee.com/api/Users/Autorization/");
            request.Method = HttpMethod.Post;
            request.Content = content;
            HttpResponseMessage response = await client.SendAsync(request);
        }
    }

    internal class User
    {
        public object Login { get; set; }
        public object Password { get; set; }
        public string Surname { get; internal set; }
        public string Name { get; internal set; }
        public string Patronimyc { get; internal set; }
    }
}
