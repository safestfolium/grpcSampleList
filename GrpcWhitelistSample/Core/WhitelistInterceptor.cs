using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace GrpcWhitelistSample.Core
{
    public class WhitelistInterceptor : Interceptor
    {
        private static string ExtractIp(string peer)
        {
            // peer format: "ipv4:1.2.3.4:port"
            if (string.IsNullOrEmpty(peer)) return peer;
            if (peer.StartsWith("ipv4:") || peer.StartsWith("ipv6:"))
            {
                string withoutPrefix = peer.Substring(peer.IndexOf(':') + 1);
                int lastColon = withoutPrefix.LastIndexOf(':');
                if (lastColon >= 0)
                    return withoutPrefix.Substring(0, lastColon);
                return withoutPrefix;
            }
            return peer;
        }

        private void CheckAccess(ServerCallContext context)
        {
            string ip = ExtractIp(context.Peer);
            if (!WhitelistStore.IsWhitelistEnabled())
            {
                WhitelistStore.RecordAttempt(ip, true);
                return;
            }
            var allowed = WhitelistStore.GetAllowedClients();
            bool isAllowed = allowed.Contains(ip);
            WhitelistStore.RecordAttempt(ip, isAllowed);
            if (!isAllowed)
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied,
                    string.Format("Client IP '{0}' is not whitelisted.", ip)));
            }
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            CheckAccess(context);
            return continuation(request, context);
        }

        public override Task ServerStreamingServerHandler<TRequest, TResponse>(
            TRequest request,
            IServerStreamWriter<TResponse> responseStream,
            ServerCallContext context,
            ServerStreamingServerMethod<TRequest, TResponse> continuation)
        {
            CheckAccess(context);
            return continuation(request, responseStream, context);
        }

        public override Task ClientStreamingServerHandler<TRequest, TResponse>(
            IAsyncStreamReader<TRequest> requestStream,
            ServerCallContext context,
            ClientStreamingServerMethod<TRequest, TResponse> continuation)
        {
            CheckAccess(context);
            return continuation(requestStream, context);
        }

        public override Task DuplexStreamingServerHandler<TRequest, TResponse>(
            IAsyncStreamReader<TRequest> requestStream,
            IServerStreamWriter<TResponse> responseStream,
            ServerCallContext context,
            DuplexStreamingServerMethod<TRequest, TResponse> continuation)
        {
            CheckAccess(context);
            return continuation(requestStream, responseStream, context);
        }
    }
}
