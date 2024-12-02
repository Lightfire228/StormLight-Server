using System.Collections;

namespace Stormlight.Models;


public class FileTreeNode<T> {
    readonly List<T> _Files = [];
    readonly T?      _Parent;

    readonly List<FileTreeNode<T>> _SubFolders = [];


    public IEnumerable<T> Files  { get => [.._Files]; }
    public T?             Parent { get => _Parent; }

    public IEnumerable<T> IterateAllFiles() {
        foreach (var file in IterateFiles()) {
            yield return file;
        }

        foreach (var folder in IterateFolders()) {
            foreach (var file in folder.IterateAllFiles()) {
                yield return file;
            }
        }
    }

    public IEnumerable<T> IterateFiles() {
        foreach (var file in _Files) {
            yield return file;
        }
    }

    public IEnumerable<FileTreeNode<T>> IterateFolders() {
        foreach (var folder in _SubFolders) {
            yield return folder;
        }
    }


}