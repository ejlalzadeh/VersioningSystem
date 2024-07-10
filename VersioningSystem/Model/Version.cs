namespace VersioningSystem.Model
{
    internal class Version
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public int Patch { get; private set; }


        public Version(int major, int minor, int patch)
        {
            if (major < 0 || minor < 0 || patch < 0)
                throw new Exception("Invalid version number");

            Major = major; Minor = minor; Patch = patch;
        }

        public Version(string versionAsString)
        {
            if (string.IsNullOrWhiteSpace(versionAsString))
            {
                Major = 0; Minor = 0; Patch = 1;
            }
            else
            {
                List<string> parts = versionAsString.Split('.').ToList();

                if (!parts.Any() || parts.Any(part => !int.TryParse(part, out int _)))
                    throw new ArgumentException("Error occurred while parsing version!");

                Major = int.Parse(parts[0]);
                Minor = parts.Count > 1 ? int.Parse(parts[1]) : 0;
                Patch = parts.Count > 2 ? int.Parse(parts[2]) : 0;
            }
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }
    }
}
