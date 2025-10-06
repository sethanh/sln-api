using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Common.Constants.Envs
{
    public class EnvConstants
    {
        public readonly static string MANAGEMENT_CONNECTION = "MANAGEMENT_CONNECTION";
        public readonly static string PAYMENT_CONNECTION = "PAYMENT_CONNECTION";
        public readonly static string JWT_SECRET = "JWT_SECRET";
        public readonly static string IS_PRODUCTION = "IS_PRODUCTION";
        public readonly static string APP_NAME = "APP_NAME";
        public readonly static string GOOGLE_CLIENT_ID = "GOOGLE_CLIENT_ID";
        public readonly static string REDIS_CACHE_CONNECTION = "REDIS_CACHE_CONNECTION";
        public readonly static string REDIS_CACHE_INSTANCE_NAME = "REDIS_CACHE_INSTANCE_NAME";
        public readonly static string REDIS_CACHE_CHANNEL_PREFIX = "REDIS_CACHE_CHANNEL_PREFIX";
        public readonly static string PUBLISHER_REDIS_CONNECTION = "PUBLISHER_REDIS_CONNECTION";
        public readonly static string PUBLISHER_REDIS_PORT = "PUBLISHER_REDIS_PORT";
        public readonly static string PUBLISHER_REDIS_CHANNEL = "PUBLISHER_REDIS_CHANNEL";
        public readonly static string PUBLISHER_CONNECTION = "PUBLISHER_CONNECTION";
        public readonly static string PUBLISHER_MONGODB = "PUBLISHER_MONGODB";
        public readonly static string PUBLISHER_REALTIME_SERVER = "PUBLISHER_REALTIME_SERVER";
        public readonly static string KAFKA_GROUP_ID = "KAFKA_GROUP_ID";
        public readonly static string KAFKA_BOOTSTRAP_SERVER = "KAFKA_BOOTSTRAP_SERVER";
        public readonly static string KAFKA_TOPIC_PREFIX = "KAFKA_TOPIC_PREFIX";
    }
}