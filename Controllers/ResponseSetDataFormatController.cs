using Microsoft.AspNetCore.Mvc;
using MusicDemo.Models;
using System.Xml;

namespace MusicDemo.Controllers
{
    /// <summary>
    /// 响应数据格式设置 （ xml
    /// 默认 application/json
    /// json 默认使用的是 System.Text.JSON
    /// 
    /// 替换成 NewtonSoft.dll
    /// 
    /// builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver()
    /// {
    ///     NamingStrategy = new DefaultNamingStrategy()
    /// });
    /// 
    /// 换成NewtonsoftJson后，之前的AddJsonOptions便不再适用了，需要在AddNewtonsoftJson类进行设置
    /// 
    /// 添加xml支持
    /// builder.Services.AddControllers().AddXmlSerializerFormatters();
    /// 或
    /// AddNewtonsoftJson(....).AddXmlSerializerFormatters();
    /// 
    /// 详见：https://docs.microsoft.com/zh-cn/aspnet/core/web-api/advanced/formatting?view=aspnetcore-6.0
    /// 
    /// </summary>
    [ApiController]
    [Route("api/responseSetDataFormat")]
    [Produces("application/xml")] // 类级节点配置，
    public class ResponseSetDataFormatController : Controller
    {
        private readonly ILogger<ResponseSetDataFormatController> _logger;

        public ResponseSetDataFormatController (ILogger<ResponseSetDataFormatController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("returnXmlData")]
        //[Produces("application/xml")] // 序列化返回参数为 xml 格式 方法级别
        public IActionResult ReturnXmlData([FromBody] XmlDocument xmlDocument)
        {
            return new OkObjectResult(xmlDocument);
        }
    }   
}
