using StormLight.Models.Dto;

namespace StormLight.FileManager.FlatFiles;

public class FlatFileManager
    : IFileManager
{

    public FolderListingDto GetFolderListing(string path, FolderListingOpts opts) =>
        GetFolderListing(new UserPath(path), opts)
    ;

    FolderListingDto GetFolderListing(UserPath path, FolderListingOpts opts) {

        FolderListingDto folder = new()
        {
            Path    = path.Path,
            Folders = Directory
                .EnumerateDirectories(path.SystemPath)
                .Select(p => UserPath.FromSystemPath(p).Path)
            ,
            Files = Directory
                .EnumerateFiles(path.SystemPath)
                .Select(p => new FileListingDto() {
                    Name = Path.GetFileName(p)
                })
        };

        return folder;

    }

    
}