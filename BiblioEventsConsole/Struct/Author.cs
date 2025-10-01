namespace BiblioEventsConsole.Struct
{

    public struct Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        public Author(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns>
        /// A string representation of the author.
        /// </returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName}, born on {BirthDate:yyyy-MM-dd}";
        }
    }
}