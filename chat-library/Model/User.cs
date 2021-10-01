using System.Collections.ObjectModel;
using System.ServiceModel;

namespace chat_library
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
        public OperationContext operationContext { get; set; }
    }
}

