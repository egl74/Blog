using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model;
using System.Data.Entity.Validation;


class Program
{
    static void Main(string[] args)
    {
        var context = new dbModel();
        //AddTestData(context);
        ViewAllUsersAndTheirCities(context);
        ViewMostCommentedPostTitle(context);
        Console.WriteLine(GetNumberOfPostsByUserId(context, 10));
        Console.ReadKey();
    }

    static void AddTestData(dbModel context)
    {
        //if (!context.CableSweepDebug.Any(rec => /* CHECK TO SEE IF SQL ALREADY RUN */ ))
        //{
            //var sql = System.IO.File.ReadAllText(System.IO.Path.Combine(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName) + "\\Blog\\Blog.Model\\script1.sql");
            //context.Database.ExecuteSqlCommand(sql);
        //}
        try
        //using (var context = new dbModelForBlog())
        {            
            var lA = new City
            {
                Name = "Los Angeles",
            };
            var nY = new City
            {
                Name = "New York City",
            };
            var sF = new City
            {
                Name = "San Francisco",
            };
            var chic = new City
            {
                Name = "Chicago",
            };
            context.Cities.Add(lA);
            context.Cities.Add(nY);
            context.Cities.Add(sF);
            context.Cities.Add(chic);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                Console.WriteLine(ec.InnerException);
            }
            var mick = new User
            {
                FirstName = "Mick",
                LastName = "McCarthy",
                Login = "mick@gmail.com",
                Password = "Mick123",
            };
            var carl = new User
            {
                FirstName = "Carl",
                LastName = "Rinaldo",
                Login = "carl@gmail.com",
                Password = "Carl123",
            };
            var ronnie = new User
            {
                FirstName = "Ronnie",
                LastName = "Hamilton",
                Login = "ronnie@gmail.com",
                Password = "Ronnie123",
            };
            var sebastian = new User
            {
                FirstName = "Sebastian",
                LastName = "Novakovic",
                Login = "seb@gmail.com",
                Password = "Seb123",
            };
            var theo = new User
            {
                FirstName = "Theo",
                LastName = "Jonsson",
                Login = "theo@gmail.com",
                Password = "theo123",
            };
            var hannu = new User
            {
                FirstName = "Hannu",
                LastName = "Pikkarainen",
                Login = "hannu@gmail.com",
                Password = "hannu123",
            };
            var will = new User
            {
                FirstName = "Will",
                LastName = "Materazzi",
                Login = "will@gmail.com",
                Password = "Will123",
            };
            var tony = new User
            {
                FirstName = "Tony",
                LastName = "O'Brien",
                Login = "tony@gmail.com",
                Password = "tony123",
            };
            var jeff = new User
            {
                FirstName = "Jeff",
                LastName = "Mitchell",
                Login = "jeff@gmail.com",
                Password = "jeff123",
            };
            var frank = new User
            {
                FirstName = "Frank",
                LastName = "Livingstone",
                Login = "frank@gmail.com",
                Password = "frank123",
            };
            lA.Users.Add(mick);
            sF.Users.Add(will);
            nY.Users.Add(theo);
            lA.Users.Add(frank);
            chic.Users.Add(ronnie);
            chic.Users.Add(hannu);
            lA.Users.Add(sebastian);
            nY.Users.Add(tony);
            nY.Users.Add(jeff);
            nY.Users.Add(carl);
            context.SaveChanges();
            /*
            context.Users.Add(mick);
            context.Users.Add(carl);
            context.Users.Add(ronnie);
            context.Users.Add(sebastian);
            context.Users.Add(theo);
            context.Users.Add(hannu);
            context.Users.Add(will);
            context.Users.Add(tony);
            context.Users.Add(jeff);
            context.Users.Add(frank);*/
            
            var tagAndroid = new Tag
            {
                Id = 741,
                Name = "Android",
            };
            var tagOs = new Tag
            {
                Id = 121,
                Name = "Операционные системы",
            };
            var tagPhotoTechs = new Tag
            {
                Id = 358,
                Name = "Фототехника",
            };
            var tagIos = new Tag
            {
                Id = 974,
                Name = "Разработка под iOS",
            };
            var tagWin = new Tag
            {
                Id = 401,
                Name = "Windows",
            };
            context.Tags.Add(tagAndroid);
            context.Tags.Add(tagIos);
            context.Tags.Add(tagOs);
            context.Tags.Add(tagPhotoTechs);
            context.Tags.Add(tagWin);
            context.SaveChanges();
            var post1 = new Post
            {
                Tags = { tagAndroid, tagOs },
                Title = "Китай представил собственную операционную систему",
                Text = "Китайская национальная операционная система China Operating System", 
            };
            var post2 = new Post
            {
                Tags = {tagWin, tagOs},
                Title = "R.I.P. Windows XP",
                Text ="… Помните свои первые ощущения от Windows XP?»",
            };
            var post3 = new Post
            {
                Tags = { tagWin, tagOs },
                Title = "В следующем обновлении Windows 8.1 можно",
                Text = "ожидать после ввода привычной кнопки «Пуск» обратно в строй.",
            };
            var post4 = new Post
            {
                Tags = { tagPhotoTechs, tagAndroid },
                Title = "Эффект параллакса (3D) с помощью Lens Blur в Google Camera",
                Text = "компания Google делает магию программными способами.",
            };
            var post5 = new Post
            {
                Tags = { tagIos, tagOs },
                Title = "Вышла iOS 7.1.1",
                Text = "Улучшено распознавание отпечатков пальцев Touch ID;",
            };
            jeff.Posts.Add(post1);
            hannu.Posts.Add(post2);
            carl.Posts.Add(post3);
            theo.Posts.Add(post4);
            hannu.Posts.Add(post5);

            context.SaveChanges();

            var comment1 = new Comment
            {
                
                TextOfComment = "новая, одобренная правительством",
                Date = new DateTime(2014, 1, 20, 23, 5, 0),
            };
            var comment2 = new Comment
            {
                TextOfComment = "Может, так и есть. Следить будут за трафиком на операторе ;)",
                Date = new DateTime(2014, 1, 20, 23, 9, 0),
            };
            var comment3 = new Comment
            {
                TextOfComment = "Стоит вспомнить успехи нашей академией наук и как-то не хочется смеяться…",
                Date = new DateTime(2014, 1, 20, 23, 15, 0),
            };
            var comment4 = new Comment
            {
                TextOfComment = "Эта опция уже есть в 8.1 и возможно и в 8.",
                Date = new DateTime(2014, 1, 31, 14, 0, 0),
            };
            var comment5 = new Comment
            {
                TextOfComment = "Вот тут возникает самый главный вопрос: означает-ли, что мы вернёмся к привычной кнопке?",
                Date = new DateTime(2014, 2, 2, 15, 14, 0),
            };
            var comment6 = new Comment
            {
                TextOfComment = "Но wifi так же глючит и отваливается в iphone 4s, говорят меня надо на iphone 5. Хитрый багомаркетинг",
                Date = new DateTime(2014, 4, 23, 10, 1, 0),
            };
            
            post1.Comments.Add(comment1);
            post1.Comments.Add(comment2);
            post4.Comments.Add(comment3);
            post3.Comments.Add(comment4);
            post3.Comments.Add(comment5);
            post5.Comments.Add(comment6);

            ronnie.Comments.Add(comment1);
            sebastian.Comments.Add(comment2);
            mick.Comments.Add(comment3);
            tony.Comments.Add(comment4);
            will.Comments.Add(comment5);
            jeff.Comments.Add(comment6);

            context.SaveChanges();
            
            
        }
        catch (DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
            throw;
        }
    }

    static void ViewAllUsersAndTheirCities(dbModel context)
    {
        List<User> userList = context.Users.ToList();
        foreach (User user in userList)
        {
            Console.WriteLine(user.FirstName + "  " + user.LastName + " " + user.City.Name);
        }
    }

    static void ViewMostCommentedPostTitle(dbModel context)
    {
        List<Post> postList = context.Posts.ToList();
        int temp = 0;
        string title = null;
        foreach (Post post in postList)
        {
            if (post.Comments.Count > temp)
            {
                temp = post.Comments.Count;
                title = post.Title;
            }
        }
        Console.WriteLine("The most commented post " + title + " has " + temp + " comments");
    }

    static int GetNumberOfPostsByUserId(dbModel context, int userid)
    {
        List<User> userList = context.Users.ToList();
        
        /*foreach (User user in userList)
        {
            if (user.FirstName == firstname)
            {
                return user.Posts.Count;
            }
        }
        return 0;*/
        return (from user in userList where user.Id == userid select user.Posts.Count).FirstOrDefault();
    }
}
