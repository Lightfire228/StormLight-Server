using Stormlight.Models;
using Stormlight.Models.Api;

namespace Stormlight.Server;

public static class FilesApi {

    public static readonly string BASE_FOLDER = "/home/cass/Code/Personal/StormLight/StormLight-Server/src";

    public static FileTreeNode<FileListing> GetFiles() {

        List<string> listing = GetAllFiles(BASE_FOLDER);

        return listing.Select(GetListing).ToList();
    }

    static FileListing GetListing(string path) => new(path) {};

    static List<string> GetAllFiles(string path) =>
        Directory
            .EnumerateFileSystemEntries(path, "*.*", SearchOption.AllDirectories)
            .ToList()
    ;



    
}