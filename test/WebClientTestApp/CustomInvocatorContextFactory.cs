﻿using Microsoft.AspNetCore.Hosting;
using NetCoreStack.WebSockets;
using NetCoreStack.WebSockets.ProxyClient;
using System;

namespace WebClientTestApp
{
    public class CustomInvocatorContextFactory : IClientInvocatorContextFactory<AnotherEndpointWebSocketCommandInvocator>
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomInvocatorContextFactory(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public InvocatorContext CreateInvocatorContext()
        {
            return new InvocatorContext(typeof(AnotherEndpointWebSocketCommandInvocator),
                Environment.MachineName,
                "localhost:5003",
                uriPath: "ws",
                query: "connectionId=" + Guid.NewGuid().ToString("N"));
        }
    }
}