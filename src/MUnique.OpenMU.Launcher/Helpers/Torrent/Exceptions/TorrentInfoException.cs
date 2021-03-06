﻿using System;
using System.Runtime.Serialization;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.Exceptions
{
    [Serializable]
    public class TorrentInfoException : Exception
    {
        #region Protected Constructors

        protected TorrentInfoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Constructors

        #region Public Constructors

        public TorrentInfoException()
        {
        }

        public TorrentInfoException(string message)
            : base(message)
        {
        }

        public TorrentInfoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }
}