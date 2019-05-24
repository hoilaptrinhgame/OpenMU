using DefensiveProgrammingFramework;
using MUnique.OpenMU.Launcher.Helpers.Torrent.PeerWireProtocol.Messages;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.PeerWireProtocol.EventArgs
{
    /// <summary>
    ///     The peer message received event arguments.
    /// </summary>
    public sealed class PeerMessgeReceivedEventArgs : System.EventArgs
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PeerMessgeReceivedEventArgs" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PeerMessgeReceivedEventArgs(PeerMessage message)
        {
            message.CannotBeNull();

            Message = message;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public PeerMessage Message { get; }

        #endregion Public Properties
    }
}