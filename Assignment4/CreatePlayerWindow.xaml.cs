using System;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for CreatePlayerWindow.xaml
    /// </summary>
    public partial class CreatePlayerWindow
    {
        public int Players { get; set; }
        public int Decks { get; set; }
        //Singleton pattern for creating a new window, so only one gets created.
        private static CreatePlayerWindow? instance;
        //Event for other classes to subscribe and notify when an event has happened.
        public event EventHandler OnSomethingHappend;
        private CreatePlayerWindow()
        {
            InitializeComponent();
        }

        public static CreatePlayerWindow Instance
        {
            get
            {
                instance ??= new CreatePlayerWindow();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private void CreatePlayerButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Players = Int32.Parse(decksBox.Text);
                this.Decks = Int32.Parse(playersBox.Text);
            }
            catch (Exception)
            {

                
            }
            OnSomethingHappend?.Invoke(this, EventArgs.Empty);
            this.Hide();
        }
    }
}
