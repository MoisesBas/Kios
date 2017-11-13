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
    public class AnswerObject
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<Answers> items { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has more.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has more; otherwise, <c>false</c>.
        /// </value>
        public bool has_more { get; set; }
        /// <summary>
        /// Gets or sets the quota maximum.
        /// </summary>
        /// <value>
        /// The quota maximum.
        /// </value>
        public int quota_max { get; set; }
        /// <summary>
        /// Gets or sets the quota remaining.
        /// </summary>
        /// <value>
        /// The quota remaining.
        /// </value>
        public int quota_remaining { get; set; }
    }
}
