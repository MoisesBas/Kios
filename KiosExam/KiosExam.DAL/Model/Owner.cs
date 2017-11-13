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
    public class Owner
    {
        /// <summary>
        /// Gets or sets the reputation.
        /// </summary>
        /// <value>
        /// The reputation.
        /// </value>
        public int reputation { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int user_id { get; set; }
        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>
        /// The type of the user.
        /// </value>
        public string user_type { get; set; }
        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        /// <value>
        /// The profile image.
        /// </value>
        public string profile_image { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string display_name { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string link { get; set; }
        /// <summary>
        /// Gets or sets the accept rate.
        /// </summary>
        /// <value>
        /// The accept rate.
        /// </value>
        public int? accept_rate { get; set; }
    }
}
