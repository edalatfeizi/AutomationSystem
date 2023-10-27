

namespace Automation.Infrastructure.Common;

public static class FileCommons
{
    public static string GetCurrentDirectory()
    {
        var result = Directory.GetCurrentDirectory();
        return result;
    }
    public static string GetStaticContentDirectory()
    {
        var result = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\StaticContent\\");
        if (!Directory.Exists(result))
        {
            Directory.CreateDirectory(result);
        }
        return result;
    }
    public static string GetFilePath(string fileName)
    {
        var staticContentDir = GetStaticContentDirectory();
        var result = Path.Combine(staticContentDir, fileName);
        return result;
    }
}
