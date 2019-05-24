using DbUp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practice30._04._2019
{
    class Program
    {
        static void Main(string[] args)
        {
            InitNew initNew = new InitNew();
            InitComment initComment = new InitComment();
            NewsRepository newsRepository = new NewsRepository();
            CommentRepository commentRepository = new CommentRepository();
            News news = new News();
            Comments comments = new Comments();
            var connectionStringConfiguration = ConfigurationManager.ConnectionStrings["appConnection"];
            var connectionString = connectionStringConfiguration.ConnectionString;

            #region Migration
            EnsureDatabase.For.SqlDatabase(connectionString);
            var upgrader = DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful) throw new Exception("failed");
            else
            {
                #endregion
                Console.WriteLine("1 - Новости" +
                    "\n2 - Комментарии");
                if (int.TryParse(Console.ReadLine(), out int resultOfChoose))
                {
                    switch (resultOfChoose)
                    {
                        case 1:
                            Console.WriteLine("1 - Добавить новость" +
                                "\n4 - Просмотреть все новости");
                            if (int.TryParse(Console.ReadLine(), out int resultOfChoose2))
                            {
                                switch (resultOfChoose2)
                                {
                                    case 1:
                                        initNew.InitNews(news);
                                        newsRepository.Add(connectionString, @"insert into News values(NEWID(), @Author, @Text, @PublishDate)", news);
                                        break;
                                    case 4:
                                        var allNews = newsRepository.GetAllStudents(connectionString, "select * from News");
                                        foreach (var newsInDB in allNews)
                                        {
                                            Console.WriteLine($"{newsInDB.Author} опубликовал новость {newsInDB.Text} - {newsInDB.PublishDate}");
                                        }
                                        break;
                                }
                            }
                            break;
                        case 2:
                            int numOfNews = 1;
                            Console.WriteLine("1 - Добавить комментарий");
                            if (int.TryParse(Console.ReadLine(), out int resultOfChoose3))
                            {
                                switch (resultOfChoose3)
                                {
                                    case 1:
                                        List<News> allNews = newsRepository.GetAllStudents(connectionString, "select * from News");
                                        foreach (var newsInDB in allNews)
                                        {
                                            Console.WriteLine($"{numOfNews++}.{newsInDB.Author} опубликовал новость {newsInDB.Text} - {newsInDB.PublishDate}");
                                        }
                                        Console.WriteLine("к какой новости вы хотите оставить комментарий: ");
                                        if (int.TryParse(Console.ReadLine(), out int numOfNew))
                                        {
                                            foreach(var s in allNews) {
                                                int index = allNews.IndexOf(s);
                                                object val = allNews.ToList().ElementAt(index);
                                                Console.WriteLine(val);
                                                initComment.AddComment(comments);
                                                commentRepository.Add(connectionString, $"insert into Comments values(NEWID(), @Author, @Comment, @CommentDate, IdNew = {numOfNew})", comments);
                                            }

                                        }
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}