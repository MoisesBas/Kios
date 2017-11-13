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
    public class Item
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public List<string> tags { get; set; }
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public Owner owner { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is answered.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is answered; otherwise, <c>false</c>.
        /// </value>
        public bool is_answered { get; set; }
        /// <summary>
        /// Gets or sets the view count.
        /// </summary>
        /// <value>
        /// The view count.
        /// </value>
        public int view_count { get; set; }
        /// <summary>
        /// Gets or sets the answer count.
        /// </summary>
        /// <value>
        /// The answer count.
        /// </value>
        public int answer_count { get; set; }
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
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public int question_id { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string link { get; set; }
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
        /// <summary>
        /// Gets or sets the body markdown.
        /// </summary>
        /// <value>
        /// The body markdown.
        /// </value>
        public string body_markdown { get; set; }
        /// <summary>
        /// Gets or sets the last edit date.
        /// </summary>
        /// <value>
        /// The last edit date.
        /// </value>
        public int? last_edit_date { get; set; }       
    }
}
