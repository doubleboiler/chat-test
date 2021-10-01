using System.Windows;
using System.Windows.Input;

namespace chat_client_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ServiceChat.IChatServiceCallback
    {
        private bool _isConnected = false;
        private ServiceChat.ChatServiceClient client;

        private int _id;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void ConnectUser()
        {
            if (!_isConnected)
            {
                client = new ServiceChat.ChatServiceClient(new System.ServiceModel.InstanceContext(this));
                _id = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                bConnDicon.Content = "Disconnect";
                _isConnected = true;
            }
        }

        void DisconnectUser()
        {
            if (_isConnected)
            {
                client.Disconnect(_id);
                client = null;
                tbUserName.IsEnabled = true;
                bConnDicon.Content = "Connect";
                _isConnected = false;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMsg(tbMessage.Text, _id);
                    tbMessage.Text = string.Empty;
                }
            }
        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
        }
    }
}
