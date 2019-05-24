using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice30._04._2019
{
    public class InitNew
    {
        public void InitNews(News news)
        {
            Console.WriteLine("Введите автора новости: ");
            news.Author = Console.ReadLine();
            Console.WriteLine("Введите текст новости: ");
            news.Text = Console.ReadLine();
            news.PublishDate = DateTime.Now;

        }
    }
}
