using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Klarity;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Klarity
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            // Get the username and password from input fields
            string username = usernameEntry?.Text?.Trim();
            string password = passwordEntry?.Text;

            // Input validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }

            // Call the API to authenticate the user
            bool isAuthenticated = await AuthenticateUserAsync(username, password, 0); // Pass userId as 2 for testing

            if (isAuthenticated)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                ((App)Application.Current).NavigateToMainTabbedPage(); // Replace with your navigation logic
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }

        private async Task<bool> AuthenticateUserAsync(string username, string password, int userId)
        {
            string apiUrl = "https://10.0.2.2:5143/api/Users/login"; // Replace localhost with 10.0.2.2 for the emulator

            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    // Create the payload
                    var payload = new
                    {
                        userId = userId,
                        username = username,
                        passwordHash = password
                    };

                    // Serialize the payload to JSON
                    string jsonPayload = JsonConvert.SerializeObject(payload);

                    // Log payload for debugging
                    Console.WriteLine("Payload: " + jsonPayload);

                    // Create HTTP content with the serialized payload
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Add headers if needed
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Send POST request to the API
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Read and log the response body
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Body: " + responseBody);

                    // Ensure the response is successful
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"API Error: {response.StatusCode}");
                        return false;
                    }

                    // Deserialize the response to check authentication status
                    var result = JsonConvert.DeserializeObject<AuthResponse>(responseBody);

                    return result != null && result.IsAuthenticated;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling API: {ex.Message}");
                return false;
            }
        }

        private HttpClient GetHttpClient()
        {
            // HttpClientHandler to bypass SSL validation for development purposes
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };

            return new HttpClient(handler);
        }

        // Class to handle API response
        private class AuthResponse
        {
            public bool IsAuthenticated { get; set; }
            public string Message { get; set; } // Optional: For displaying a response message
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Sign Up", "Sign Up functionality will be available soon.", "OK");
        }
    }
}
