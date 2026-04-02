using System;
using Grpc.Core;
using Grpc.Core.Interceptors;
using GrpcShared;

namespace GrpcServer.Core
{
    public class WhitelistInterceptor : Interceptor
    {
        public override TResponse BlockingUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            BlockingUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            return continuation(request, context);
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            return continuation(request, context);
        }

        public override System.Threading.Tasks.Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            EnforceWhitelist(context);
            return continuation(request, context);
        }

        private static void EnforceWhitelist(ServerCallContext context)
        {
            string ip = ExtractIp(context.Peer);

            if (!WhitelistStore.WhitelistEnabled)
            {
                WhitelistStore.RecordAttempt(ip, true);
                return;
            }

            bool allowed = WhitelistStore.GetAllowedClients().Contains(ip);
            WhitelistStore.RecordAttempt(ip, allowed);

            if (!allowed)
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied,
                    string.Format("Client IP '{0}' is not whitelisted.", ip)));
            }
        }

        private static string ExtractIp(string peer)
        {
            // peer format: "ipv4:1.2.3.4:port"
            if (string.IsNullOrEmpty(peer)) return peer;
            if (peer.StartsWith("ipv4:") || peer.StartsWith("ipv6:"))
            {
                // remove prefix "ipv4:" or "ipv6:"
                string withoutPrefix = peer.Substring(peer.IndexOf(':') + 1);
                // find last colon to strip port
                int lastColon = withoutPrefix.LastIndexOf(':');
                if (lastColon >= 0)
                    return withoutPrefix.Substring(0, lastColon);
                return withoutPrefix;
            }
            return peer;
        }
    }
}
