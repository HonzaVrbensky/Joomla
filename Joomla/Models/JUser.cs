using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Joomla2._0.Models
{
    public class JUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public ICollection<Article> Articles { get; set; }
    }
}
