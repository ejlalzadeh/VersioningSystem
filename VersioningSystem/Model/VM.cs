namespace VersioningSystem.Model;

public class VM
{
    private Version _currentVersion;
    private readonly List<Version> _versionHistory;

    public VM(string initialVersion)
    {
        _currentVersion = new Version(initialVersion);
        _versionHistory = new List<Version>();
    }

    public VM Major()
    {
        _versionHistory.Add(_currentVersion);

        int major = _currentVersion.Major + 1;
        _currentVersion = new Version(major, 0, 0);

        return this;
    }

    public VM Minor()
    {
        _versionHistory.Add(_currentVersion);

        int minor = _currentVersion.Minor + 1;
        _currentVersion = new Version(_currentVersion.Major, minor, 0);

        return this;
    }

    public VM Patch()
    {
        _versionHistory.Add(_currentVersion);

        int patch = _currentVersion.Patch + 1;
        _currentVersion = new Version(_currentVersion.Major, _currentVersion.Minor, patch);

        return this;
    }

    public VM Rollback()
    {
        if (!_versionHistory.Any())
            throw new Exception("Cannot Rollback!");

        Version previousVersion = _versionHistory.Last();
        _currentVersion = previousVersion;
        _versionHistory.Remove(previousVersion);

        return this;
    }

    public string Release() => _currentVersion.ToString();
}