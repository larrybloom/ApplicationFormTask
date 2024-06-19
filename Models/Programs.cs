namespace ApplicationFormTask.Models
{
    public class Programs
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PersonalInformation PersonalInfo { get; set; }
        public List<CustomQuestion> CustomQuestions { get; set; }
    }
}
