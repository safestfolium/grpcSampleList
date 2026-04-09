using System.Threading.Tasks;
using Grpc.Core;
using GrpcShared.Generated;

namespace GrpcServer.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply
            {
                Message = string.Format("Hello, {0}! You are authorized.", request.Name)
            };
            return Task.FromResult<HelloReply>(reply);
        }
    }
}
