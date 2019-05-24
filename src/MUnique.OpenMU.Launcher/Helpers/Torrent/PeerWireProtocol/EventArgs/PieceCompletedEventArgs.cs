﻿using DefensiveProgrammingFramework;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.PeerWireProtocol.EventArgs
{
    /// <summary>
    ///     The piece completed event arguments.
    /// </summary>
    public sealed class PieceCompletedEventArgs : System.EventArgs
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PieceCompletedEventArgs" /> class.
        /// </summary>
        /// <param name="pieceIndex">Index of the piece.</param>
        /// <param name="pieceData">The piece data.</param>
        public PieceCompletedEventArgs(int pieceIndex, byte[] pieceData)
        {
            pieceIndex.MustBeGreaterThanOrEqualTo(0);
            pieceData.CannotBeNullOrEmpty();

            PieceIndex = pieceIndex;
            PieceData = pieceData;
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="PieceCompletedEventArgs" /> class from being created.
        /// </summary>
        private PieceCompletedEventArgs()
        {
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the piece data.
        /// </summary>
        /// <value>
        ///     The piece data.
        /// </value>
        public byte[] PieceData { get; }

        /// <summary>
        ///     Gets the index of the piece.
        /// </summary>
        /// <value>
        ///     The index of the piece.
        /// </value>
        public int PieceIndex { get; }

        #endregion Public Properties
    }
}