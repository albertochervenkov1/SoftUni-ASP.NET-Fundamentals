using Microsoft.AspNetCore.Routing.Constraints;

namespace ForumApp.Constants
{
    /// <summary>
    /// Data layer constants
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Post constants
        /// </summary>
        public static class Post
        {
            public const int TITLE_MAX_LENGTH = 50;
            public const int CONTENT_MAX_LENGTH=1500;
        }
    }
}
