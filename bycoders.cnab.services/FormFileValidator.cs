using Microsoft.AspNetCore.Http;

namespace bycoders.cnab.services
{
    public interface IFormFileValidator
    {
        void Validate(IFormFile formFile);
    }

    public class FormFileValidator : IFormFileValidator
    {
        private string[] ACCEPTED_EXTENSION = new string[] { ".txt" };

        public void Validate(IFormFile formFile)
        {
            var FormExtension = Path.GetExtension(formFile.FileName);

            if (!ACCEPTED_EXTENSION.Contains(FormExtension)) 
            {
                throw new ArgumentException($"Não é aceito o formato {FormExtension}. Envie um arquivo '.txt'");
            }
        }
    }
}
