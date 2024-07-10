namespace VersioningSystem.Model;

public class VM
{
    private Version _currentVersion;
    private readonly Stack<Version> _versionHistory;

    public VM(string initialVersion)
    {
        _currentVersion = new Version(initialVersion);
        _versionHistory = new Stack<Version>();
    }

    public VM Major()
    {
        _versionHistory.Push(_currentVersion);
        _currentVersion = _currentVersion.Major();
        return this;
    }

    public VM Minor()
    {
        _versionHistory.Push(_currentVersion);
        _currentVersion = _currentVersion.Minor();
        return this;
    }

    public VM Patch()
    {
        _versionHistory.Push(_currentVersion);
        _currentVersion = _currentVersion.Patch();
        return this;
    }

    public VM Rollback()
    {
        if (!_versionHistory.Any())
            throw new Exception("Cannot Rollback!");

        Version previousVersion = _versionHistory.Pop();
        _currentVersion = previousVersion;

        return this;
    }

    public string Release() => _currentVersion.ToString();
}