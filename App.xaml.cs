namespace squispe5A
{
    public partial class App : Application
    {
        public static Repository.PersonRepository personRepo { get; set; }
        public App(Repository.PersonRepository personRepository)
        {
            InitializeComponent();
            personRepo = personRepository;

            MainPage = new Views.vHome();
        }
    }
}
