namespace CleanCode._03
{
    using System;

    /// Author: Xavi Garcia
    /// Created: 19/05/2016
    /// File: Program.cs
    /// <summary>
    /// This program allows you to modify the properties of a client 
    /// and also send messages to it depending of the status of the
    /// client and some other parameters.
    /// </summary>
    public class Program
    {
        private static double baseSalary = 50035.50;

        static void Main(string[] args)
        {
            // Start Client Initialization

            var client = new Client // instanciate a new client
            {
                FullName = "Murdock Barrakus",
                BirthYear = 1986,
                Salary = baseSalary.ToString(),
                Status = 2
            };


            // Initialize client message
            string message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor \n\r" +
                             "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud \n\r" +
                             "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in \n\r" +
                             "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. \n\r" +
                             "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n\r";

            // End Client Initialization

            // Start Process client

            if (client.Status == 2) // Assure user's status is activated
            {
                var clientAge = client.Age();

                // XGV-19/05/2016: We're checking only the client age because is the only requierement so far
                if (clientAge > 25)  // Client age is > 30
                {
                    double salaryCalculated =  baseSalary * 0.88; // Increases client salary 0.88%
                    client.Salary = $"{salaryCalculated}€";
                    Console.WriteLine($"The Client has a salary of {client.Salary}");

                    // XGV-19/05/2016: When we've the socket specifications we'll implement this code
                    //if (Messenger.Status == 1)
                    //{
                    //    Messenger.ValidateSocket();
                    //    Messenger.RemoveConnection();
                    //}

                    Messenger.SendMessage(client, message);
                    //client.Remove();
                }
            }

            // End Process client
        }
    }
}
