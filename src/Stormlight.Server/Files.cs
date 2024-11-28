using Stormlight.Models.Api;

namespace Stormlight.Server;

public static class FilesApi {

    public static readonly string BASE_FOLDER = "/home/cass/Code/Personal/StormLight/StormLight-Server/src";

    public static List<FileListing> GetFiles() {

        List<string> listing = [
            ..Directory.EnumerateFileSystemEntries(BASE_FOLDER, "*.*", SearchOption.AllDirectories)
        ];

        return listing.Select(GetListing).ToList();
    }

    static FileListing GetListing(string path) {

        string type = "File";

        if (Directory.Exists(path)) {
            type = "Folder";
        }

        return new() {
            Name = path,
            Type = type,
        };
    }

    
}