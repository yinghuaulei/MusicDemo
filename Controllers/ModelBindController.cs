using Microsoft.AspNetCore.Mvc;
using MusicDemo.Models;

namespace MusicDemo.Controllers
{
    /// <summary>
    /// 参数模型绑定
    /// 参数模型验证
    /// FromQuery
    /// FromRoute
    /// FromForm
    /// FromBody
    /// FromHandler
    /// 默认情况下，ASP.NET Core是处理的JSON数据格式，如果想要使用其他类型，如xml，则需要通过制定Program.cs指定输入类型，然后在对应的方法上通过Consumes来执行Content-Type类型
    /// </summary>
    [ApiController]
    [Route("api/modelBind")]
    public class ModelBindController : Controller
    {
        private readonly ILogger<ModelBindController> _logger;

        public ModelBindController(ILogger<ModelBindController> logger)
        {
            _logger = logger;
        }

        #region 参数模型绑定

        [HttpGet]
        [Route("fromQuery")]
        public string FromQuery([FromQuery] string param)
        {
            _logger.LogInformation("param:" + param);
            return param;
        }

        // FromRoute 不能定义 Route，因为route必须是显式的，
        // [Route("{param}")]
        [HttpGet("{param}")]
        public string FromRoute([FromRoute] string param)
        {
            _logger.LogInformation("param:" + param);
            return param;
        }

        // [HttpGet]
        // FromForm 不允许 httpget、httppost
        // 已尝试可用 put、head
        // 接收方式 未知
        //[HttpHead]
        //public void FromForm([FromForm] Music form)
        //{
        //    _logger.LogInformation($"id:{form.Id}, url: {form.Url}, title:{form.Url}");
        //}

        // [HttpGet]
        // frombody 不允许 httpget
        [HttpPost]
        [Route("fromBody")]
        public JsonResult FromBody([FromBody] Music body)
        {
            _logger.LogInformation($"id:{body.Id}, url: {body.Url}, title:{body.Url}");
            return Json(body);
        }

        #endregion

        #region 参数验证

        [HttpPost]
        [Route("checkParam")]
        public JsonResult CheckParam([FromBody] Music body)
        {
            _logger.LogInformation($"id:{body.Id}, url: {body.Url}, title:{body.Title}, length:{body.Length}");
            return Json(body);
        }

        #endregion
    }
}
