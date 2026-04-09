using Grpc.Core;
using Grpc.Core.Interceptors;
using GrpcServer.Core;
using GrpcServer.Services;
using GrpcShared.Generated;

namespace GrpcServer
{
    public class GrpcServerHost
    {
        public const int Port = 50051;

        private Server _server;

        public void Start()
        {
            _server = new Server
            {
                Services = { Greeter.BindService(new GreeterService()).Intercept(new WhitelistInterceptor()) },
                Ports = { new ServerPort("0.0.0.0", Port, ServerCredentials.Insecure) }
            };
            _server.Start();
        }

        public void Stop()
        {
            if (_server != null)
            {
                _server.ShutdownAsync().Wait(3000);
                _server = null;
            }
        }
    }
}
