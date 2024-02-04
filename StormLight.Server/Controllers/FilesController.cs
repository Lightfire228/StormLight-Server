using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StormLight.FileManager.FlatFiles;
using StormLight.Models.Dto;

namespace StormLight.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class FilesController
    : ControllerBase 
{

    [HttpGet("getFolderListing")]
    public ActionResult<FolderListingDto> GetFolderListing(string path) {

        try {
            return new FlatFileManager().GetFolderListing(path, new());
        }
        catch (DirectoryNotFoundException) {
            return NotFound();
        }

    }
}