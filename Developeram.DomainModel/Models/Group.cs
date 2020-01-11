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
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

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
        public DateTime CreateTime { get; set; }


        public virtual IEnumerable<Article> Articles { get; set; }

    }
}
