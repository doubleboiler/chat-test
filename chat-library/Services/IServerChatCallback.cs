using System.ServiceModel;

namespace chat_library
{
    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string msg);
    }
}
