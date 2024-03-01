using System.ServiceModel;
using System.ServiceModel.Channels;
using EverQuest_Game_API.Interface;

namespace EverQuest_Game_API
{
    public class ServiceFactory
    {
        private List<ChannelFactory> channelList = new List<ChannelFactory>();
        private IGame gameInstance = null;
        public IGame Game
        {
            get
            {
                if (gameInstance == null)
                {
                    var security = new NetTcpSecurity();
                    security.Mode = SecurityMode.None;

                    var binding = new NetTcpBinding();
                    binding.Name = "vqNetTcpBinding";
                    binding.TransferMode = TransferMode.Buffered;
                    binding.MaxBufferSize = 30000000;
                    binding.MaxConnections = 500;
                    binding.MaxReceivedMessageSize = 30000000;
                    binding.Security =security;

                    var endpoint = new EndpointAddress("net.tcp://localhost:5101/GameSvc");
                    var cfGame = new ChannelFactory<IGame>(binding, endpoint);
                    channelList.Add(cfGame);
                    gameInstance = cfGame.CreateChannel();
                }
                return gameInstance;
            }
        }
    }
}
