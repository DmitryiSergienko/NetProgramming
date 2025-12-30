namespace UDP_Demo.Server
{
    public class User
    {
        string? _id;
        string? _firstname;
        string? _lastname;
        string? _patronomyc;

        public User(string id, string firstname, string lastname, string patronomyc)
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