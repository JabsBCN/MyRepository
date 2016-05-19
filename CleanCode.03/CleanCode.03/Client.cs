namespace CleanCode._03
{
    using System;

    /// <summary>
    /// The Client
    /// </summary>
    public class Client
    {
        private string fullName;
        private int status;
        private int birthYear;
        private string salary;

        /// <summary>
        /// The client's first name
        /// </summary>
        public string FullName
        {
            get { return fullName ?? string.Empty; } // set firstName to empty
            set { fullName = value; }
        }

        /// <summary>
        /// The client's status
        /// </summary>
        public int Status
        {
            get { return status < 0 ? 0 : status; } // set status to 0
            set { status = value; }
        }

        /// <summary>
        /// The client's birthyear
        /// </summary>
        public int BirthYear
        {
            get { return birthYear < 0 ? 0 : birthYear; } // set birthYear to 0
            set { birthYear = value; }
        }

        /// <summary>
        /// The client's salary
        /// </summary>
        public string Salary
        {
            get { return salary ?? string.Empty; } // set salary to 0
            set { salary = value; }
        }

        // Default constructor
        public Client()
        {

        }

        /// <summary>
        /// Calculate client's age
        /// </summary>
        /// <returns></returns>
        public int Age()
        {
            return DateTime.Now.Year - birthYear;
        }

        public void Remove()
        {
            this.BirthYear = 0;
            this.Salary = "0";
            this.status = 0;
            this.FullName = string.Empty;
        }
    }
}