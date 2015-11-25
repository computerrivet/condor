namespace TheDrillBookCloud.Lib.Email.Models
{
    public class CoachInviteEmailTemplateModel
    {
        public string FullName { get; set; }
        public string ManagerName { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public int CoachID { get; set; }
    }
}