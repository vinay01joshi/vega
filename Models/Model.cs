namespace vega.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Association
        public Make Make { get; set; }

        // Forgeinkey property
        public int MakeId { get; set; }
    }
}