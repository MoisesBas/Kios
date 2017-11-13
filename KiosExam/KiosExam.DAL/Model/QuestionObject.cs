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
    public class QuestionObject
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<Item> items { get; set; }

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
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int page { get; set; }
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int page_size { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int total { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string type { get; set; }
    }
}
