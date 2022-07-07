using QandQ.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandQ.Entities
{
    public class MovieRateAndNote : BaseEntity
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("MovieId")]

        public Movie Movie { get; set; }
        public int Rate { get; set; }
        public string Note { get; set; }
    }
}
