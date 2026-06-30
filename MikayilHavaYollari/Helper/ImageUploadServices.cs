namespace MikayilHavaYollari.Helper
{
    public  class ImageUploadServices
    {
        public static string SaveFile(string rootpath, string folderNames, IFormFile file)
        {
            string name = file.FileName;
            name = name.Length > 64 ? name.Substring(name.Length - 64, 64) : name;
            name = Guid.NewGuid().ToString() + name;
            string path = Path.Combine(rootpath, folderNames, name);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return name;
        }
        public static void DeleteFile(string rootpath, string folderNames, string Image)
        {
            string DeletPath = Path.Combine(rootpath, folderNames, Image);
            if (System.IO.File.Exists(DeletPath))
            {
                System.IO.File.Delete(DeletPath);
            }
        }
    }
}
