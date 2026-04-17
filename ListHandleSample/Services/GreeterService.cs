using System.Threading.Tasks;
using Grpc.Core;
using Hello;

namespace ListHandleSample.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var tcs = new TaskCompletionSource<HelloReply>();
            tcs.SetResult(new HelloReply
            {
                Message = string.Format("Hello, {0}! You are an authorized client.", request.Name)
            });
            return tcs.Task;
        }
    }
}
