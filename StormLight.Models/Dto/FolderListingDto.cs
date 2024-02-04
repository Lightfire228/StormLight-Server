namespace StormLight.Models.Dto;

public class FolderListingDto {
    public string Path { get; set; } = "/";

    public IEnumerable<FileListingDto> Files   { get; set; } = [];
    public IEnumerable<string>         Folders { get; set; } = [];
}
