using StormLight.Models.Dto;

namespace StormLight.FileManager;

public interface IFileManager {

    public FolderListingDto GetFolderListing(string path, FolderListingOpts opts);
}