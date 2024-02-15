using System.ComponentModel.DataAnnotations;

/// <summary>
///		Bamboo-card WebApi Project
/// </summary>
/// <Version>
///		Author					Date			ChangeHistory
///		Zarmeen Zahid 			FEB 15,2024	    Creation
namespace hackerNewsBusiness.Models
{
    public class Storymodel
    {
        public string title { get; set; }
        public string url { get; set; }
        public string postedby { get; set; }
        public DateTime time { get; set; }
        public string score { get; set; }

        public string commentcount { get; set; }
    }    
}
