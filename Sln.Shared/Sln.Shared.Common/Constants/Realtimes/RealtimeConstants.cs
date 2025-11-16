using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Common.Constants.Realtimes
{
    public class RealtimeMethods
    {
        public const string Update = "Update";
        public const string Remove = "Remove";
        public const string Subscribe = "Subscribe";
    }

    public class RealTimeJobs
    {
        public const string MESSAGE_REFRESH = "MESSAGE_REFRESH";
        public const string NOTIFY = "NOTIFY";
    }

    public class RealtimeEvents
    {
        public const string DataFetched = "DataFetched";
        public const string DataModified = "DataModified";
        public const string DataAdded = "DataAdded";
        public const string DataRemoved = "DataRemoved";
        public const string ChildDataFetched = "ChildDataFetched";
        public const string ChildDataModified = "ChildDataModified";
        public const string ChildDataAdded = "ChildDataAdded";
        public const string ChildDataRemoved = "ChildDataRemoved";
        public const string Error = "Error";
    }
}