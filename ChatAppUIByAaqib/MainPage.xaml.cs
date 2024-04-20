using Microsoft.Maui.Controls;

namespace ChatAppUIByAaqib
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();


            // Add some initial messages to the chat UI
            // These are sample messages for demonstration purposes

            AddMessageToChat("You", "Hey Aaqib! Are you up for watching today's football match?");
            AddMessageToChat("Aaqib", "Hey there! Yes, I'm definitely in. Which teams are playing?");
            AddMessageToChat("You", "It's the Real Madrid vs. Barcelona match, it's going to be intense.");
            AddMessageToChat("Aaqib", "Wow, that's a classic rivalry. Which team do you support?");
            AddMessageToChat("You", "I'm a Barcelona fan, how about you?");
            AddMessageToChat("Aaqib", "I support Real Madrid, let's see who comes out on top!");
            AddMessageToChat("You", "Yes, it's a crucial match in terms of points.");
            AddMessageToChat("Aaqib", "Absolutely, and watching Messi and Ronaldo's performances will be worth it.");
            AddMessageToChat("You", "Definitely, I'm looking forward to Messi's dribbling and Ronaldo's finishing.");
            AddMessageToChat("Aaqib", "We'll discuss the match afterwards, see which team delivers.");
            AddMessageToChat("You", "Yes, it's a crucial match in terms of points.");
            AddMessageToChat("Aaqib", "Absolutely, and watching Messi and Ronaldo's performances will be worth it.");
            AddMessageToChat("You", "Definitely, I'm looking forward to Messi's dribbling and Ronaldo's finishing.");
            AddMessageToChat("Aaqib", "We'll discuss the match afterwards, see which team delivers.");
            AddMessageToChat("You", "By the way, have you checked out the latest transfer news?");
            AddMessageToChat("Aaqib", "Not yet, what's the scoop?");
            AddMessageToChat("You", "There are talks of some big signings for both teams.");
            AddMessageToChat("Aaqib", "That sounds exciting! Any rumors about who might be joining?");
            AddMessageToChat("You", "Barcelona is rumored to be eyeing a top striker, while Real Madrid is looking to strengthen their midfield.");
            AddMessageToChat("Aaqib", "Interesting! Let's see if these rumors turn out to be true.");
            AddMessageToChat("You", "Definitely, it could add a new dynamic to both teams.");
            AddMessageToChat("Aaqib", "After the match, we'll have plenty to discuss with both the game and potential transfers.");


            // Automatically scroll to the bottom of the chat after adding messages
            scrollDown();
        }

        // Method triggered when the Send button is clicked
        private void SendMessage_Clicked(object sender, EventArgs e)
        {
            string messageText = MessageEntry.Text;
            if (!string.IsNullOrWhiteSpace(messageText))
            {
                AddMessageToChat("You", messageText); // Add the user's message to the chat UI
                MessageEntry.Text = ""; // Clear the input field after sending
            }
        }

        // Method to add a message to the chat UI
        private async void AddMessageToChat(string sender, string message)
        {
            // Create a stack layout for the message
            var messageStackLayout = new StackLayout
            {
                Margin = new Thickness(10, 5, 10, 5),
                HorizontalOptions = sender == "You" ? LayoutOptions.End : LayoutOptions.Start,
                BackgroundColor = sender == "You" ? Color.FromHex("#EFEFEF") : Color.FromHex("#DCF8C6")
            };

            // Create a label for the message text
            var messageLabel = new Label
            {
                Padding = 5,
                Text = message,
                HorizontalOptions = sender == "You" ? LayoutOptions.End : LayoutOptions.Start,
                TextColor = Color.FromHex("#000000"), // You can adjust the text color here
                FontSize = 16, // Optional: Adjust the font size as needed
                FontAttributes = FontAttributes.None // Optional: Remove any font attributes
            };

            // Add the label to the message stack layout
            messageStackLayout.Children.Add(messageLabel);

            // Add the message stack layout to the chat UI
            ChatStackLayout.Children.Add(messageStackLayout);

            // Automatically scroll to the bottom of the chat
            scrollDown();
        }

        // Method to scroll the chat UI to the bottom
        void scrollDown()
        {
            var timer = new Timer((object obj) => {
                MainThread.BeginInvokeOnMainThread(() => ChatScrollView.ScrollToAsync(ChatStackLayout, ScrollToPosition.End, false));
            }, null, 1, Timeout.Infinite);
        }
    }
   
}
