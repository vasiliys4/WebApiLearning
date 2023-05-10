namespace WebApiLearning.Models
{
    
    public class Car
    {
        public int Id { get; set; }
        public string? CarName { get; set; }
        public int MaxSpeed { get; set; }
        public virtual Motor? Motor { get; set; }
    }
}
