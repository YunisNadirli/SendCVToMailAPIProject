using dlt_CV_sender_email.Exceptions;

namespace dlt_CV_sender_email.Services
{
    public class FileService
    {
        public string Upload(IFormFile file)
        {
			try
			{
                //Check extention
                string extention = Path.GetExtension(file.FileName).ToLower();
                if (extention != ".pdf") throw new InvalidExtentionException($"{extention} is invalid");
                //Check size
                long size = file.Length;
                if (size > 10 * 1024 * 1024) throw new BigSizeException($"File size could not more than 10 mb");
                //Upload file
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                var filename = Guid.NewGuid().ToString();
                using FileStream stream = new FileStream(Path.Combine(path, filename), FileMode.Create);
                return Path.Combine(path, filename);
            }
			catch (Exception e)
			{
                return e.Message;
			}
        }
    }
}
