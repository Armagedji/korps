using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace Practice6.Models
{
    public class AchievementListModel
    {
        public IEnumerable<Achievement_type> Achievement_types { get; set; }
        public SelectList ach_types { get; set; }
    }
}
