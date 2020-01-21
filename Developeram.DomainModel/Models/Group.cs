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
        [Display(Name = "عنوان گروه")]
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MinLength(3, ErrorMessage = "فیلد{0} نمی تواند کمتر {1} کاراکتر باشد")]
        [MaxLength(30, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        public string Title { get; set; }


        public virtual ICollection<Article>  Articles { get; set; }
    }
}
