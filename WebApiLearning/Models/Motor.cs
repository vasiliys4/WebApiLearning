using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLearning.Models
{
    public class Motor
    {
        [ForeignKey("Car")]
        public int Id { get; set; }
        public string? MotorName { get; set; }
        public string? MotorType { get; set; }       
        public int CarId { get; set; }
        //public virtual Car Car { get; set; }
    }
}
