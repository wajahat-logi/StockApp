using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Modal.Common
{
    public class CommonModel
    {
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Id { get; set; }

        public CommonModel()
        {
            Id = 0;
            CreatedOn = DateTime.Now;
            CreatedBy = Id;
            UpdatedBy = Id;
            UpdatedOn = DateTime.Now;
        }

    }
}
