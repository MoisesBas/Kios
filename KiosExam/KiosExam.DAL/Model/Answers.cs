using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.DAL.Model
{
    public class Answers
    {
        public List<Comment> comments { get; set; }
        public Owner2 owner { get; set; }
        public bool is_accepted { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public int creation_date { get; set; }
        public int answer_id { get; set; }
        public int question_id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

}
