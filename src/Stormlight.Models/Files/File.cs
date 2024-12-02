namespace Stormlight.Models.Files;

public class File(Path path) {

    public File(string path) : this(new Path(path)) {}

    public Path Path { get; protected set; } = path;
}