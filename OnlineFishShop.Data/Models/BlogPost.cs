using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineFishShop.Data.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<BlogComment> Comments { get; set; }
    }
}
