

namespace devexus
{
    class Person
    {
        private string ssn;
        private string firstname;
        private string surname;
        private string phone;
        private string city;

        public Person(string ssn, string firstname, string surname, string phone, string city)
        {
            this.ssn = ssn;
            this.firstname = firstname;
            this.surname = surname;
            this.phone = phone;
            this.city = city;
        }

        public string Ssn
        {
            get { return this.ssn; }
        }

        public string Firstname
        {
            get { return this.firstname; }
        }

        public string Surname
        {
            get { return this.surname; }
        }

        public string Phone
        {
            get { return this.phone; }
        }

        public string City
        {
            get { return this.city; }
        }
    }
}


