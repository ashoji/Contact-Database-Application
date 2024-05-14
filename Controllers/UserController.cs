using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    /// <summary>
    /// ���[�U�[�֘A�̃A�N�V�����̃R���g���[���[�B
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// ���[�U�[�̐ÓI���X�g�B
        /// </summary>
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        /// <summary>
        /// ���[�U�[�̃C���f�b�N�X�y�[�W�̃r���[��Ԃ��܂��B
        /// </summary>
        public ActionResult Index()
        {
            return View(userlist);
        }

        /// <summary>
        /// ����̃��[�U�[�̏ڍ׃y�[�W�̃r���[��Ԃ��܂��B
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
        /// ���[�U�[�쐬�y�[�W�̃r���[��Ԃ��܂��B
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// �V�������[�U�[�����X�g�ɒǉ����A�C���f�b�N�X�y�[�W�Ƀ��_�C���N�g���܂��B
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
        /// ����̃��[�U�[�̕ҏW�y�[�W�̃r���[��Ԃ��܂��B
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
        /// ���[�U�[�̏ڍׂ��X�V���A�C���f�b�N�X�y�[�W�Ƀ��_�C���N�g���܂��B
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
                // �K�v�ɉ����čX�V���鑼�̃t�B�[���h��ǉ����܂�
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// ����̃��[�U�[�̍폜�y�[�W�̃r���[��Ԃ��܂��B
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
        /// ���[�U�[�����X�g����폜���A�C���f�b�N�X�y�[�W�Ƀ��_�C���N�g���܂��B
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