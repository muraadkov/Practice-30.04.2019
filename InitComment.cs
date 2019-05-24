using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice30._04._2019
{
    public class InitComment
    {
        public void AddComment(Comments comment)
        {
            Console.WriteLine("Ваше имя: ");
            comment.Author = Console.ReadLine();
            Console.WriteLine("Комментарий: ");
            comment.Comment = Console.ReadLine();
            comment.CommentDate = DateTime.Now;
        }
    }
}
