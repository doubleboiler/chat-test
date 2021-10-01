using System.ServiceModel;

namespace chat_library
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IChatService
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg, int id);
    }
}
