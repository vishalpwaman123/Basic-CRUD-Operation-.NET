using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Application_API.Data
{
    public class CrudDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public string RunType { get; set; }
        [Required]
        public string Release {  get; set; }
        [Required]
        public string KB { get; set; }
        [Required]
        public string Build { get; set; }
        [Required]
        public string MachinePool { get; set; }
    }
}
