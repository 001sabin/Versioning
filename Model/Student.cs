using System.ComponentModel.DataAnnotations;

namespace Versioning.Model
{
    public class Student
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public int Age { get; set; }
    }
}
