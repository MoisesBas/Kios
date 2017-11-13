using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.DAL.Model
{
    public class QuestionObject
    {
        public List<Item> items { get; set; }

        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
        public int page { get; set; }
        public int page_size { get; set; }
        public int total { get; set; }
        public string type { get; set; }
    }
}
