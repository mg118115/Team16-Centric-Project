using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team_16_Centric_Project.Models
{
    public class ValuesRecognition
    {
        public int valuesRecognitionID { get; set; }
        public char value { get; set; }
        public string description { get; set; }

        public ICollection<RecognitionDetail> RecognitionDetail { get; set; }
    }
    public class RecognitionDetail
    {
        public int RecognitionDetailID { get; set; }
        [Display(Name = "Number of Recognitions Received")]
        public int numberRecognitions { get; set; }

        // the next two properties link the orderDetail to the Order
        [Display(Name = "Core Value Exhibited")]
        public int recognitionID { get; set; }
       
        public virtual Recognition Recognition { get; set; }
        // the next two properties link the orderDetail to the Product
        [Display(Name = "Employee Name")]
        public int employeeRecognitionID { get; set; }
        public virtual EmployeeRecognition EmployeeRecognition { get; set; }
    }
}