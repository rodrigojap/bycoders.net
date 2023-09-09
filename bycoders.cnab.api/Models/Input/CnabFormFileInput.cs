using System.ComponentModel.DataAnnotations;

namespace bycoders.cnab.api.Models.Input
{
    public class CnabFormFileInput
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório Fornecer um arquivo")]
        public IFormFile FormFile { get; set; }
    }
}
