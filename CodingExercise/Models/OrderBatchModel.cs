using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Models
{ 
    public class OrderBatchModel
    {
        public ScheduleModel Schedule { get; set; }
        public string OrderNo { get; set; }
    }
}
