using QandQ.Entities.Base;

namespace QandQ.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public string RefreshToken { get; set; } = string.Empty;
        //public DateTime TokenCreated { get; set; }
        //public DateTime TokenExpires { get; set; }
        public virtual ICollection<MovieRateAndNote> MovieRateAndNote { get; set; } = new List<MovieRateAndNote>();

    }
}
