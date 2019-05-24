using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice30._04._2019
{
    public class News
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Comments> Comment { get; set; }
    }
}
