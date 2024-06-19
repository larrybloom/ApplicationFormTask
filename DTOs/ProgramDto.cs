namespace ApplicationFormTask.DTOs
{
    public class ProgramDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PersonalInformationDto PersonalInfo { get; set; }
        public List<CustomQuestionDto> CustomQuestions { get; set; }
    }
}
