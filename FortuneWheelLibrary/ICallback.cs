using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel; 
namespace FortuneWheelLibrary
{
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void SendAllMessages(Player[] messages);
    }
}
