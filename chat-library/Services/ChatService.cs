using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;

namespace chat_library
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private ObservableCollection<User> Users = new ObservableCollection<User>();
        private int _nextId = 1;

        public int Connect(string name)
        {
            User user = new User()
            {
                Id = _nextId,
                Name = name,
                operationContext = OperationContext.Current
            };

            _nextId++;

            SendMessage(": " + user.Name + " connected to chat.", 0);
            Users.Add(user);
            return user.Id;
        }

        public void Disconnect(int id)
        {
            var user = Users.FirstOrDefault(i => i.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                SendMessage(": " + user.Name + " leave chat.", 0);
            }
        }

        public void SendMessage(string msg, int id)
        {
            foreach (var item in Users)
            {
                string answer = DateTime.Now.ToShortTimeString();

                var user = Users.FirstOrDefault(i => i.Id == id);
                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }
                answer += msg;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MessageCallback(answer);
            }
        }
    }
}
