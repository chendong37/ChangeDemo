using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Change.Web
{
    public class Result {
        public int errno;
        public string data;

        public override string ToString() {
            return "{\"errno\": 0,\"data\": [\""+data+"\"]}";
        }
    }

    public partial class up : Page,IHttpHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public new void ProcessRequest(HttpContext context)
        {
            var files = context.Request.Files;
            if (files.Count <= 0)
            {
                return;
            }

            HttpPostedFile file = files[0];

            if (file == null)
            {
                context.Response.Write("error|file is null");
                return;
            }
            else
            {
                
                string path = context.Server.MapPath("~/UploadFiles/");  //存储图片的文件夹
                string originalFileName = file.FileName;
                string fileExtension = originalFileName.Substring(originalFileName.LastIndexOf('.'), originalFileName.Length - originalFileName.LastIndexOf('.'));
                string currentFileName = (new Random()).Next() + fileExtension;  //文件名中不要带中文，否则会出错
                                                                                 //生成文件路径
                string imagePath = path + currentFileName;
                //保存文件
                file.SaveAs(imagePath);

                //获取图片url地址
                string imgUrl = "/UploadFiles/" + currentFileName;

                //返回图片url地址
                Result msg = new Result();
                msg.errno = 0;
                msg.data = imgUrl;
                //Json
                //object JSONObj = JsonConvert.SerializeObject(msg);
                context.Response.Write(msg.ToString());
                context.Response.End();
                return;
            }

        }
        public new bool  IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}