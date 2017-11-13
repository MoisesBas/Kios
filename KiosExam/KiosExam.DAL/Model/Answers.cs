using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.DAL.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Answers
    {
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public List<Comment> comments { get; set; }
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public Owner2 owner { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is accepted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is accepted; otherwise, <c>false</c>.
        /// </value>
        public bool is_accepted { get; set; }
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int score { get; set; }
        /// <summary>
        /// Gets or sets the last activity date.
        /// </summary>
        /// <value>
        /// The last activity date.
        /// </value>
        public int last_activity_date { get; set; }
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public int creation_date { get; set; }
        /// <summary>
        /// Gets or sets the answer identifier.
        /// </summary>
        /// <value>
        /// The answer identifier.
        /// </value>
        public int answer_id { get; set; }
        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public int question_id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string title { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string body { get; set; }
    }

}
