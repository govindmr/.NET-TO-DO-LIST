using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDOListModel
{
    public class ToDOListEntity
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int SortOrder { get; set; }
    }
}
