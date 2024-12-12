using System.ComponentModel.DataAnnotations;

namespace Web_Application_API.Model
{
    public class InsertRequest
    {
        [Required]
        public string RunType { get; set; }
        [Required]
        public string Release { get; set; }
        [Required]
        public string KB { get; set; }
        [Required]
        public string Build { get; set; }
        [Required]
        public string MachinePool { get; set; }
    }
}
