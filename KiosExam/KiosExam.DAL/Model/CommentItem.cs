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
    public class CommentItem
    {
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public Owner owner { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CommentItem"/> is edited.
        /// </summary>
        /// <value>
        ///   <c>true</c> if edited; otherwise, <c>false</c>.
        /// </value>
        public bool edited { get; set; }
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int score { get; set; }
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public int creation_date { get; set; }
        /// <summary>
        /// Gets or sets the post identifier.
        /// </summary>
        /// <value>
        /// The post identifier.
        /// </value>
        public int post_id { get; set; }
        /// <summary>
        /// Gets or sets the comment identifier.
        /// </summary>
        /// <value>
        /// The comment identifier.
        /// </value>
        public int comment_id { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string body { get; set; }
        /// <summary>
        /// Gets or sets the reply to user.
        /// </summary>
        /// <value>
        /// The reply to user.
        /// </value>
        public ReplyToUser reply_to_user { get; set; }
    }
}
