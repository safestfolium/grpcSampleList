using System;
using System.Threading;
using Grpc.Core;
using Grpc.Core.Interceptors;
using GrpcWhitelistSample.Core;
using GrpcWhitelistSample.Services;
using Hello;

namespace GrpcWhitelistSample
{
    public static class GrpcServer
    {
        private static Server _server;
        private static Thread _thread;
        public const int Port = 50051;

        public static void Start()
        {
            _thread = new Thread(RunServer);
            _thread.IsBackground = true;
            _thread.Start();
        }

        private static void RunServer()
        {
            var interceptor = new WhitelistInterceptor();
            var service = new GreeterService();
            var intercepted = Greeter.BindService(service).Intercept(interceptor);

            _server = new Server
            {
                Services = { intercepted },
                Ports = { new ServerPort("0.0.0.0", Port, ServerCredentials.Insecure) }
            };
            _server.Start();

            // Keep alive until shutdown
            _server.ShutdownTask.Wait();
        }

        public static void Stop()
        {
            if (_server != null)
            {
                _server.ShutdownAsync().Wait();
            }
        }
    }
}
