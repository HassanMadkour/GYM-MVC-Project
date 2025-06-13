using Microsoft.AspNetCore.Http;

namespace GYM_MVC.Core.Helper {

    public enum UploadImageStatus {
        Success,
        FormatError,
        SizeError,
        Error,
    }

    public class ImageHandler {

        public static async Task<UploadImageStatus> UploadImage(IFormFile image) {
            try {
                var allowedSize = 5 * 1024 * 1024;

                if (image.Length > allowedSize)
                    return UploadImageStatus.SizeError;
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(image.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                    return UploadImageStatus.FormatError;

                var fileName = $"{DateTime.Now}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create)) {
                    await image.CopyToAsync(stream);
                }
                return UploadImageStatus.Success;
            } catch (Exception) {
                return UploadImageStatus.Error;
            }
        }
    }
}