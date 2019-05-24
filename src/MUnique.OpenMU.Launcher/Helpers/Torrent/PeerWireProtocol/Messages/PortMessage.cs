﻿using System.Net;
using DefensiveProgrammingFramework;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.PeerWireProtocol.Messages
{
    /// <summary>
    ///     The port message.
    /// </summary>
    public class PortMessage : PeerMessage
    {
        #region Public Fields

        /// <summary>
        ///     The message unique identifier.
        /// </summary>
        public const byte MessageId = 9;

        #endregion Public Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PortMessage" /> class.
        /// </summary>
        /// <param name="port">The port.</param>
        public PortMessage(ushort port)
        {
            ((int) port).MustBeGreaterThanOrEqualTo(IPEndPoint.MinPort);
            ((int) port).MustBeLessThanOrEqualTo(IPEndPoint.MaxPort);

            Port = port;
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="PortMessage" /> class from being created.
        /// </summary>
        private PortMessage()
        {
        }

        #endregion Private Constructors

        #region Private Fields

        /// <summary>
        ///     The message unique identifier length in bytes.
        /// </summary>
        private const int MessageIdLength = 1;

        /// <summary>
        ///     The message length in bytes.
        /// </summary>
        private const int MessageLength = 3;

        /// <summary>
        ///     The message length in bytes.
        /// </summary>
        private const int MessageLengthLength = 4;

        /// <summary>
        ///     The message length in bytes.
        /// </summary>
        private const int PayloadLength = 2;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        ///     Gets the length in bytes.
        /// </summary>
        /// <value>
        ///     The length in bytes.
        /// </value>
        public override int Length => MessageLengthLength + MessageIdLength + PayloadLength;

        /// <summary>
        ///     Gets the port.
        /// </summary>
        /// <value>
        ///     The port.
        /// </value>
        public ushort Port { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Decodes the message.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="offsetFrom">The offset.</param>
        /// <param name="offsetTo">The offset to.</param>
        /// <param name="message">The message.</param>
        /// <param name="isIncomplete">if set to <c>true</c> the message is incomplete.</param>
        /// <returns>
        ///     True if decoding was successful; false otherwise.
        /// </returns>
        public static bool TryDecode(byte[] buffer, ref int offsetFrom, int offsetTo, out PortMessage message, out bool isIncomplete)
        {
            int messageLength;
            byte messageId;
            ushort port;

            message = null;
            isIncomplete = false;

            if (buffer != null &&
                buffer.Length >= offsetFrom + MessageLengthLength + MessageIdLength + PayloadLength &&
                offsetFrom >= 0 &&
                offsetTo >= offsetFrom &&
                offsetTo <= buffer.Length)
            {
                messageLength = ReadInt(buffer, ref offsetFrom);
                messageId = ReadByte(buffer, ref offsetFrom);
                port = (ushort) ReadShort(buffer, ref offsetFrom);

                if (messageLength == MessageLength &&
                    messageId == MessageId &&
                    port >= IPEndPoint.MinPort &&
                    port <= IPEndPoint.MaxPort)
                {
                    if (offsetFrom <= offsetTo)
                    {
                        message = new PortMessage(port);
                    }
                    else
                    {
                        isIncomplete = true;
                    }
                }
            }

            return message != null;
        }

        /// <summary>
        ///     Encodes the message.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>
        ///     The encoded peer message.
        /// </returns>
        public override int Encode(byte[] buffer, int offset)
        {
            buffer.CannotBeNullOrEmpty();
            offset.MustBeGreaterThanOrEqualTo(0);
            offset.MustBeLessThan(buffer.Length);

            var written = offset;

            Write(buffer, ref written, MessageLength);
            Write(buffer, ref written, MessageId);
            Write(buffer, ref written, Port);

            return CheckWritten(written - offset);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var msg = obj as PortMessage;

            return msg == null ? false : Port == msg.Port;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return Port.GetHashCode();
        }

        /// <summary>
        ///     Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"PortMessage: Port = {Port}";
        }

        #endregion Public Methods
    }
}