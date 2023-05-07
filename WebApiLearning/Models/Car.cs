namespace WebApiLearning.Models
{
    
    public class Car
    {
        public int CarId { get; set; }
        public string? CarName { get; set; }
        public int MaxSpeed { get; set; }
        public Motor? Motor { get; set; }
    }
}
