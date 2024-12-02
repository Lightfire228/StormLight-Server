namespace Stormlight.Models;

using SysPath = System.IO.Path;

// paths should be idempotent
public class Path {

    List<string> Parts     { get; set; } = [];
    
    string       Separator { get; set; } = SysPath.PathSeparator.ToString();


    public Path(string path) {
        Parts = [.. path.Split(Separator)];
    }

    public Path(IEnumerable<string> path) {
        Parts = [.. path];
    }

    public override string ToString() =>
        SysPath.Combine([..Parts])
    ;

    public string Name { get => Parts.Last(); }

    public Path LeftStrip(Path parent) {

        List<string> result = [];

        int i = -1;
        foreach(var part in Parts) {
            i++;

            string parentPart = 
                (parent.Parts.Count() > i)? parentPart = parent.Parts[i]
                                          : ""
            ;

            if (part == parentPart) {
                continue;
            }
            
            result.Add(part);
        }

        return new(result);

    }

}

