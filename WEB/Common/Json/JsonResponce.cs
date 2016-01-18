using System;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using CommonLib;

namespace WEB
{
    [Serializable]
    public class JsonResponce<TResult>
    {
        #region 属性
        /// <summary>
        /// 响应状态
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }
        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// 响应正文
        /// </summary>
        [JsonProperty("result")]
        public TResult Result { get; set; }
        #endregion

        #region 实例化
        public static JsonResponce<TResult> New(TResult result, string message = "", int status = 0)
        {
            return new JsonResponce<TResult>
            {
                Status = status,
                Message = message,
                Result = result
            };
        }
        #endregion

        #region ContentResult
        public ContentResult AsContentResult(Encoding contentEncoding = null, string contentType = "")
        {
            if (contentEncoding.IsNullOrEmpty())
                contentEncoding = Encoding.Default;
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(this),
                ContentEncoding = contentEncoding,
                ContentType = contentType
            };
        }
        #endregion

        #region JsonResult
        public JsonResult AsJsonResult(JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.AllowGet, Encoding contentEncoding = null, string contentType = "")
        {
            if (contentEncoding.IsNullOrEmpty())
                contentEncoding = Encoding.Default;
            return new JsonResult
            {
                Data = this,
                JsonRequestBehavior = jsonRequestBehavior,
                ContentEncoding = contentEncoding,
                ContentType = contentType
            };
        }
        #endregion
    }

    public static class JsonResponce
    {
        #region 实例化
        public static JsonResponce<TResult> New<TResult>(TResult result, string message = "", int status = 0)
        {
            return new JsonResponce<TResult>
            {
                Status = status,
                Message = message,
                Result = result
            };
        }
        #endregion
    }
}
