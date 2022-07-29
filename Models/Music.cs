using System.ComponentModel.DataAnnotations;

namespace MusicDemo.Models
{
    public class Music : IValidatableObject // 自定义数据验证，继承接口 IValidatableObject
    {
        public long Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        // 数据验证
        // 详情数据验证参见：https://docs.microsoft.com/zh-cn/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
        [Range(1, 1000000, ErrorMessage = "长度必须大于0，小于1000000")]
        public int Length { get; set; }

        /// <summary>
        /// 歌名 ：Numb
        /// </summary>
        public string MusicName { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MusicName == "Numb")
            {
                yield return new ValidationResult("I'm tired of being what you want me to be");
            }
        }
    }
}
