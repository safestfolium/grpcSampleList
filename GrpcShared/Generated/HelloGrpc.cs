using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcShared.Generated
{
    public static class Greeter
    {
        public static readonly string ServiceName = "hello.Greeter";

        public static readonly Method<HelloRequest, HelloReply> SayHelloMethod = new Method<HelloRequest, HelloReply>(
            MethodType.Unary,
            ServiceName,
            "SayHello",
            new Marshaller<HelloRequest>(
                request => request.ToByteArray(),
                bytes => HelloRequest.ParseFrom(bytes)),
            new Marshaller<HelloReply>(
                reply => reply.ToByteArray(),
                bytes => HelloReply.ParseFrom(bytes)));

        public abstract class GreeterBase
        {
            public abstract Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);
        }

        public class GreeterClient : ClientBase<GreeterClient>
        {
            public GreeterClient(Channel channel) : base(channel) { }

            protected GreeterClient() { }

            protected GreeterClient(ClientBaseConfiguration configuration) : base(configuration) { }

            public virtual HelloReply SayHello(HelloRequest request, Metadata headers = null, DateTime? deadline = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                return CallInvoker.BlockingUnaryCall(SayHelloMethod, null, new CallOptions(headers, deadline, cancellationToken), request);
            }

            public virtual AsyncUnaryCall<HelloReply> SayHelloAsync(HelloRequest request, Metadata headers = null, DateTime? deadline = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                return CallInvoker.AsyncUnaryCall(SayHelloMethod, null, new CallOptions(headers, deadline, cancellationToken), request);
            }

            protected override GreeterClient NewInstance(ClientBaseConfiguration configuration)
            {
                return new GreeterClient(configuration);
            }
        }

        public static ServerServiceDefinition BindService(GreeterBase impl)
        {
            return ServerServiceDefinition.CreateBuilder()
                .AddMethod(SayHelloMethod, impl.SayHello)
                .Build();
        }
    }
}