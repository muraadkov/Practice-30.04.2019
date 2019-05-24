using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice30._04._2019
{
    public class Comments
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; }
        public string Author { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid IdNew { get; set; } = Guid.NewGuid();
    }
}
