using Tesla.App;
using Tesla.Utils;
using Tesla.Model;
using System.Web.Mvc;

namespace Tesla.Web.Areas.SystemSecurity.Controllers
{
    public class DbBackupController : BaseController
    {
        private DbBackupApp dbBackupApp = new DbBackupApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string queryJson)
        {
            var data = dbBackupApp.GetList(queryJson);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysDbBackup model)//TODO:待测试
        {
            model.F_FilePath = Server.MapPath("~/Resource/DbBackup/" + model.F_FileName + ".bak");
            model.F_FileName = model.F_FileName + ".bak";
            dbBackupApp.SubmitForm(model);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("删除失败");
            }

            dbBackupApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult ClearData()
        {
            int result = dbBackupApp.ClearData();
            return Auto(result);
        }

        [HttpPost]
        [HandlerAuthorize]
        public void DownloadBackup(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return;
            }

            var data = dbBackupApp.GetForm(keyValue);
            string filename = Server.UrlDecode(data.F_FileName);
            string filepath = Server.MapPath(data.F_FilePath);
            if (FileDownHelper.IsFileExists(filepath))
            {
                FileDownHelper.DownLoadOld(filepath, filename);
            }
        }
    }
}
