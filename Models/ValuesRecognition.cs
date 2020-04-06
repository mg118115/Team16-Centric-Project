using System;
using System.Collections.Generic;
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
        public int qtyOrdered { get; set; }
        public decimal price { get; set; }
        // the next two properties link the orderDetail to the Order
        public int recognitionID { get; set; }
        public virtual Recognition Recognition { get; set; }
        // the next two properties link the orderDetail to the Product
        public int employeeRecognitionID { get; set; }
        public virtual EmployeeRecognition EmployeeRecognition { get; set; }
    }
}