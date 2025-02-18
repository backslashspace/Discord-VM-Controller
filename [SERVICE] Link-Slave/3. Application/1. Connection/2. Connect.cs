﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Link_Slave.Worker
{
    internal static partial class Client
    {
        private static Boolean Connect()
        {
            IPEndPoint remoteEndpoint = new(CurrentConfig.ServerIP, CurrentConfig.TcpPort);

            Log.FastLog("Connection", $"Attempting to connect to [{CurrentConfig.ServerIP}:{CurrentConfig.TcpPort}]", xLogSeverity.Info);

            while (!WorkerThread.Worker_WasCanceled)
            {
                try
                {
                    socket.Connect(remoteEndpoint);

                    Log.FastLog("Connection", $"Established a connection [{CurrentConfig.ServerIP}:{CurrentConfig.TcpPort}]", xLogSeverity.Info);

                    return true;
                }
                catch (SocketException)
                {
                    Task.Delay(1024).Wait();
                }
            }

            Log.FastLog("Connection", $"Canceled in connecting state", xLogSeverity.Info);

            return false;
        }
    }
}