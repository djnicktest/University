using System.ComponentModel.DataAnnotations;


namespace University.BL.DTOs
{
    public class CourseDTO//No hay necesidad  de decir si son llaves primarias, foraneas...
    {
        [Required(ErrorMessage = "The field ID is required")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The field Title is required")]
        [StringLength(50)]//aca lanza un mensaje para que solo reciba el titulo hasta 50 caracteres
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Credits is required")]
        public int Credits { get; set; }
    }
}
