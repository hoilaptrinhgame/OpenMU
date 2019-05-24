﻿using DefensiveProgrammingFramework;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.PeerWireProtocol.EventArgs
{
    /// <summary>
    ///     The peer communication error event arguments.
    /// </summary>
    public sealed class PeerCommunicationErrorEventArgs : System.EventArgs
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PeerCommunicationErrorEventArgs" /> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="isFatal">if set to <c>true</c> the error is fatal.</param>
        public PeerCommunicationErrorEventArgs(string errorMessage, bool isFatal)
        {
            errorMessage.CannotBeNullOrEmpty();

            ErrorMessage = errorMessage;
            IsFatal = isFatal;
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="PeerCommunicationErrorEventArgs" /> class from being created.
        /// </summary>
        private PeerCommunicationErrorEventArgs()
        {
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the error message.
        /// </summary>
        /// <value>
        ///     The error message.
        /// </value>
        public string ErrorMessage { get; }

        /// <summary>
        ///     Gets a value indicating whether the error is fatal.
        /// </summary>
        /// <value>
        ///     <c>true</c> if is fatal; otherwise, <c>false</c>.
        /// </value>
        public bool IsFatal { get; }

        #endregion Public Properties
    }
}