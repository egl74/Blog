using System.Linq;
using System.Web.Mvc;
using Blog.Model;

namespace Blog.Web.Controllers
{
    public class PostItem
    {
        public string Title;
        public string Text;
        public string Name;
        public int CommentsCount;
    }

    public class PostController : Controller
    {
        //
        // GET: /Post/

        private dbModel db = new dbModel();

        public ActionResult Index()
        {
            var model =
                db.Posts.Select(
                    t =>
                        new PostItem
                        {
                            Title = t.Title,
                            Text = t.Text,
                            Name = t.User.FirstName,
                            CommentsCount = t.Comments.Count()
                        }).ToList();
            return View(model);
        }

    }
}
