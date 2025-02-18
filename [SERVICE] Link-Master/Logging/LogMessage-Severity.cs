﻿using System;

namespace Link_Master
{
    internal struct xLogMessage
    {
        internal xLogMessage(xLogSeverity severity, String source, String message, Exception exception = null)
        {
            Severity = severity;
            Source = source;
            Message = message;
            Exception = exception;
        }

        internal xLogSeverity Severity;

        internal String Source;
        internal String Message;

        internal Exception Exception;
    }

    public enum xLogSeverity
    {
        ///<summary>Logs that contain the most severe level of error. This type of error indicates that immediate attention may be required.</summary>
        Critical = 0,
        ///<summary>Logs that highlight when the flow of execution is stopped due to a failure.</summary>
        Error = 1,
        ///<summary>Logs that highlight an abnormal activity in the flow of execution.</summary>
        Warning = 2,
        ///<summary>Logs that track the general flow of the application.</summary>
        Info = 3,
        ///<summary>Logs that are used for interactive investigation during development.</summary>
        Verbose = 4,
        ///<summary>Logs that contain the most detailed messages.</summary>
        Debug = 5,
        ///<summary>Logs that highlight an abnormal activity in the flow of execution. This type of error indicates that immediate attention may be required.</summary>
        Alert = 6,
    }
}