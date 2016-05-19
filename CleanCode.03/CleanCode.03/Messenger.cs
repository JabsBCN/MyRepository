namespace CleanCode._03
{
    using System;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The messeger class
    /// </summary>
    public static class Messenger
    {
        /// <summary>
        /// The status of the messenger
        /// </summary>
        public static int Status { get; set; }


        /// <summary>
        /// Send Messages
        /// </summary>
        /// <param name="client"></param>
        public static void SendMessage(Client client, string message)
        {
            try
            {
                doSending(client, message); // Send a message to the client
            }
            catch (SocketException e)
            {
                // normal. someone's stopped the request.
            }
        }

        /// <summary>
        /// Send messages to a determinate client
        /// </summary>
        private static void doSending(Client client, string message)
        {
            string pattern = @"(\p{Sc}\s?)?(\d+\.?((?<=\.)\d+)?)(?(1)|\s?\p{Sc})?";
           
            string replacement = "$2";

            Regex rgx = new Regex(pattern);

            string result = rgx.Replace(client.Salary.ToString(), replacement);  // format of the message text

            var messageToSend = ToSpacedText(message); // text to spaced text

            Console.WriteLine($"....Sending a message to {client.FullName} with salary {result} in dolars: {messageToSend}");
        }

        /// <summary>
        /// Validate the socket
        /// </summary>
        public static void ValidateSocket()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove the connection
        /// </summary>
        public static void RemoveConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Message to spaced text
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string ToSpacedText(string message)
        {
            return Regex.Replace(
                Regex.Replace(message,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                    ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
                );
        }
    }
}