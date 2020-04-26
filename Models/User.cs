using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Team_16_Centric_Project.Models
{
    public class User
    {
        public int userId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]

        public string Email { get; set; }


       
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Business Unit")]
        public string businessUnit { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime hireDate { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}