using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Stormlight.Models;
using Stormlight.Models.Api;

using SysPath = System.IO.Path;

namespace Stormlight.Server;

public static class FilesApi {

    public static readonly string BASE_FOLDER   = "/home/cass/Code/Personal/StormLight/StormLight-Server/test_fs/";
    public static readonly string UPLOAD_FOLDER = SysPath.Combine(BASE_FOLDER, "upload/");
    public static readonly string FILES_FOLDER  = SysPath.Combine(BASE_FOLDER, "files/");

    // public static FileTreeNode<FileListing> GetFiles() {

    //     List<string> listing = GetAllFiles(BASE_FOLDER);

    //     return listing.Select(GetListing).ToList();
    // }

    // static FileListing GetListing(string path) => new(path) {};

    // static List<string> GetAllFiles(string path) =>
    //     Directory
    //         .EnumerateFileSystemEntries(path, "*.*", SearchOption.AllDirectories)
    //         .ToList()
    // ;



    public static async Task<IResult> FileUpload(
        [FromForm] IFormFile    formFile, 
                   HttpContext  context
    ) {

        CheckFolders();

        Guid guid = Guid.NewGuid();

        string path = SysPath.Combine(BASE_FOLDER, UPLOAD_FOLDER, $"{guid}");

        using (var stream = File.Create(path)) {
            await formFile.CopyToAsync(stream);
        }

        return Results.Ok(guid);
    }

    static void CheckFolders() {
        if (!Directory.Exists(BASE_FOLDER)) {
            throw new ArgumentException($"Base folder '{BASE_FOLDER}' does not exist");
        }

        Directory.CreateDirectory(UPLOAD_FOLDER);
        Directory.CreateDirectory(FILES_FOLDER);
    }
    
}