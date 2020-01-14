using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Developeram.DomainModel.Models
{
    public class Group:MetaTag
    {
        [Key]
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان آدرس")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string TitleUrl { get; set; }

        [Display(Name = "توضیح کوتاه")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string ShortText { get; set; }

        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string FullText { get; set; }

        [Display(Name = "نام عکس")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "لینک کوتاه")]
        public string ShortLink { get; set; }

        public virtual IEnumerable<Article> Articles { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    }
}
