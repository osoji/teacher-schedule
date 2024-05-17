using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RankenSchedule.UI.Models.DomainModels
{
    public class Day
    {
        public Day()=> Classes = new HashSet<Class>();

        public int DayId { get; set; }

        [StringLength(10)]
        [Required()]
        public string Name { get; set; } = string.Empty;

        public ICollection<Class> Classes { get; set; }
    }
}
