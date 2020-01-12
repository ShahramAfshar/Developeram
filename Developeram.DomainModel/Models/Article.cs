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
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان آدرس")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string TitleUrl { get; set; }

        [Display(Name = "متن کوتاه")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string ShortText { get; set; }

        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string FullText { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "متا توضیحات")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaDescription { get; set; }

        [Display(Name = "متاسازنده")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaOwner { get; set; }

        [Display(Name = "متا کلمه کلید")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaKeywords { get; set; }

        [Display(Name = "عکس")]
        public string ImageName { get; set; }


        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag>  Tags { get; set; }


    }
}
