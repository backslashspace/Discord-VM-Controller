﻿using System;
using System.IO;
using System.Runtime.Serialization;

namespace LogViewer
{
    internal static partial class Program
    {
        [DataContract(Name = "ConsoleMessage", Namespace = "")]
        internal readonly struct ConsoleMessage
        {
            internal ConsoleMessage(String source, String message, LogSeverity severity, DateTime timeStamp)
            {
                Source = source;
                Message = message;
                Severity = severity;
                TimeStamp = timeStamp;
            }

            [DataMember]
            internal readonly String Source;

            [DataMember]
            internal readonly String Message;

            [DataMember]
            internal readonly LogSeverity Severity;

            [DataMember]
            internal readonly DateTime TimeStamp;
        }

        internal enum LogSeverity
        {
            Critical = 0,
            Error = 1,
            Warning = 2,
            Info = 3,
            Verbose = 4,
            Debug = 5
        }

        private static Object Deserialize(ref Byte[] data, Type type)
        {
            using MemoryStream stream = new();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            DataContractSerializer deserializer = new(type);

            return deserializer.ReadObject(stream);
        }
    }
}