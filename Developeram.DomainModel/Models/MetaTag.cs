using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developeram.DomainModel.Models
{
   public class MetaTag
    {

        [Display(Name = "متا کلمه کلید")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaKeywords { get; set; }


        [Display(Name = "متا نویسنده ")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaAuthor { get; set; }

        [Display(Name = "متا مالک ")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string MetaOwner { get; set; }


    }
}
