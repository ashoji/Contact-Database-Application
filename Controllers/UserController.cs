using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    /// <summary>
    /// ユーザー関連のアクションのコントローラー。
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// ユーザーの静的リスト。
        /// </summary>
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        /// <summary>
        /// ユーザーのインデックスページのビューを返します。
        /// </summary>
        public ActionResult Index()
        {
            return View(userlist);
        }

        /// <summary>
        /// 特定のユーザーの詳細ページのビューを返します。
        /// </summary>
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// ユーザー作成ページのビューを返します。
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新しいユーザーをリストに追加し、インデックスページにリダイレクトします。
        /// </summary>
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// 特定のユーザーの編集ページのビューを返します。
        /// </summary>
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// ユーザーの詳細を更新し、インデックスページにリダイレクトします。
        /// </summary>
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // 必要に応じて更新する他のフィールドを追加します
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// 特定のユーザーの削除ページのビューを返します。
        /// </summary>
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// ユーザーをリストから削除し、インデックスページにリダイレクトします。
        /// </summary>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            userlist.Remove(user);
            return RedirectToAction("Index");
        }
    }
}