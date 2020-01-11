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

        [Display(Name = "")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Title { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [AllowHtml]
        public string ShortText { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [AllowHtml]
        public string FullText { get; set; }

        [Display(Name = "")]
        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaDescription { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaOwner { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaKeywords { get; set; }

        [Display(Name = "")]
        public string ImageName { get; set; }


        public int GroupId { get; set; }
        public virtual Group Group { get; set; }


    }
}
