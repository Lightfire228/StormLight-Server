using StormLight.Models.Dto;

using SysPath = System.IO.Path;

namespace StormLight.FileManager.FlatFiles;

public class UserPath {

    public UserPath(params string[] path) {
        Path = SysPath.Join(path);
    }

    // TODO: config
    public static readonly string FOLDER_PATH = "/home/cass/Code/Personal/StormLight/StormLight-Server/test_folder";

    public const StringComparison Compare = StringComparison.OrdinalIgnoreCase;


    public string Path { get; init; }

    public string SystemPath => SysPath.Join(FOLDER_PATH, Path);

    public string GetSharedParent(UserPath path2) {
        List<string> shared = ["/"];

        List<string> self  = [.. Path      .Split(SysPath.DirectorySeparatorChar)];
        List<string> other = [.. path2.Path.Split(SysPath.DirectorySeparatorChar)];

        for (int i = 0; i < self.Count && i < other.Count; i++) {
            if (!string.Equals(self[i], other[i], Compare)) {
                break;
            }
            shared.Add(self[i]);
        }

        return SysPath.Join([.. shared]);
    }

    public static UserPath FromSystemPath(string path) {

        if (!path.StartsWith(FOLDER_PATH, Compare)) {
            throw new ArgumentException($"The given path '{path}' does not match the configured storage path");
        }

        int start = FOLDER_PATH.Split(SysPath.DirectorySeparatorChar).Length;

        return new UserPath(
            SysPath.Join(
                path
                    .Split(SysPath.DirectorySeparatorChar)
                    .Skip(start)
                    .ToArray()
                )
            )
        ;

    }

}
