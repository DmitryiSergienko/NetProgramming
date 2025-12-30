namespace UDP_Demo.Client
{
    public class User
    {
        int? _id;
        string? _firstname;
        string? _lastname;
        string? _patronomyc;

        public User(int id, string firstname, string lastname, string patronomyc)
        {
            _id = id;
            _firstname = firstname;
            _lastname = lastname;
            _patronomyc = patronomyc;
        }

        public override string ToString()
        {
            return $"{_id}:{_firstname}:{_lastname}:{_patronomyc}";
        }
    }
}