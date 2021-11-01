﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Net;

namespace BrakePedal.Http
{
    public class HttpRequestKey : IThrottleKey
    {
        public HttpRequest Request { get; private set; }
        public IPAddress ClientIp { get; protected set; }
        public string RequestUri { get; protected set; }
        public string HttpMethod { get; protected set; }

        public virtual object[] Values
        {
            get
            {
                return new object[]
                {
                    ClientIp,
                    HttpMethod,
                    RequestUri
                };
            }
        }

        public virtual void Initialize(HttpRequest request)
        {
            Request = request;

            ClientIp = GetClientIp(request);
            RequestUri = request.GetDisplayUrl();
            HttpMethod = request.Method;
        }

        private static IPAddress GetClientIp(HttpRequest request)
        {
            //if (Request.Properties.ContainsKey("MS_HttpContext"))
            //{
            //    return IPAddress.Parse(((HttpContextBase)Request.Properties["MS_HttpContext"]).Request.UserHostAddress);
            //}

            //if (Request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            //{
            //    return
            //        IPAddress.Parse(
            //            ((RemoteEndpointMessageProperty)Request.Properties[RemoteEndpointMessageProperty.Name]).Address);
            //}

            return request.HttpContext.Connection.RemoteIpAddress;

            throw new InvalidOperationException("Ip not found");
        }
    }
}