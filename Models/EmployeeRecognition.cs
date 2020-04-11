using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team_16_Centric_Project.Models
{
    public class EmployeeRecognition
    {
        
        public int employeeRecognitionID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        public ICollection<Recognition> Recognition { get; set; }
    }
    public class Recognition
    {
        [Key]
        public int recognitionID { get; set; }
        public string description { get; set; }
        public DateTime recognitionDate { get; set; }
        // add any other fields as appropriate
        //Order is on the "one" side of a one-to-many relationship with OrderDetail
        //and we indicate that with an ICollection
        public ICollection<RecognitionDetail> RecognitionDetail { get; set; }
        //Order is on the Many side of the one-to-many relation between Customer
        //and Order and we represent that relationship like this
        public int employeeRecognitionID { get; set; }
        public virtual EmployeeRecognition EmployeeRecognition { get; set; }
    }
}