using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
  public  class ModelProject
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double TimeToStart { get; set; }
        public int Credits { get; set; }
        public bool IsActive { get; set; }
    }
}
