using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace ConsotoUniWebApp
{
    public static class ConsotoUniApiAppServiceExtensions
    {
        public static ConsotoUniApi CreateConsotoUniApi(this IAppServiceClient client)
        {
            return new ConsotoUniApi(client.CreateHandler());
        }

        public static ConsotoUniApi CreateConsotoUniApi(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new ConsotoUniApi(client.CreateHandler(handlers));
        }

        public static ConsotoUniApi CreateConsotoUniApi(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new ConsotoUniApi(uri, client.CreateHandler(handlers));
        }

        public static ConsotoUniApi CreateConsotoUniApi(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new ConsotoUniApi(rootHandler, client.CreateHandler(handlers));
        }
    }
}
