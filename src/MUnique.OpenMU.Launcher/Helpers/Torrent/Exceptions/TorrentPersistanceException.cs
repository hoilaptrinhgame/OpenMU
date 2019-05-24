using System;
using System.Runtime.Serialization;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.Exceptions
{
    [Serializable]
    public class TorrentPersistanceException : Exception
    {
        #region Protected Constructors

        protected TorrentPersistanceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Constructors

        #region Public Constructors

        public TorrentPersistanceException()
        {
        }

        public TorrentPersistanceException(string message)
            : base(message)
        {
        }

        public TorrentPersistanceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }
}