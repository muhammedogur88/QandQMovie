using QandQ.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandQ.DTOs
{
    public class MovieRateAndNoteDto
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        public int Rate { get; set; }
        public string Note { get; set; } = String.Empty;
    }
}
