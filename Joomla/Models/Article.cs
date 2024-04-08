using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Joomla2._0.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Createdat { get; set; }
        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public JUser Author { get; set; }
    }
}
