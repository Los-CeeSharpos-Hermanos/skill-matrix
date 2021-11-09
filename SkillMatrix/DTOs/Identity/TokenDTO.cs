namespace SkillMatrix.Application.DTOs.Identity
{
    public class TokenDTO
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string ValidAt { get; set; }
    }
}
