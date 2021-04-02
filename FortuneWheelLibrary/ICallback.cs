using System.ServiceModel; 
namespace FortuneWheelLibrary
{
    [ServiceContract]
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void PlayersUpdated(Player[] messages);
    }
}
