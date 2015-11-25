namespace TheDrillBookCloud.Lib.Email.Models
{
    public class AsstManagerInviteEmailTemplateModel
    {
        public string FullName { get; set; }
        public string CoachName { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public int AssistantCoachID { get; set; }
    }
}