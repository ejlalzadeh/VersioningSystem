namespace VersioningSystem.Model
{
    internal class Version
    {
        private uint _major;
        private uint _minor;
        private uint _patch;

        public Version(uint major, uint minor, uint patch)
        {
            Validate(major, minor, patch);

            _major = major; _minor = minor; _patch = patch;
        }

        public Version(string versionAsString)
        {
            if (string.IsNullOrWhiteSpace(versionAsString))
            {
                _major = 0; _minor = 0; _patch = 1;
            }
            else
            {
                List<string> parts = versionAsString.Split('.').ToList();

                if (!parts.Any() || parts.Any(part => !int.TryParse(part, out int _)))
                    throw new ArgumentException("Error occurred while parsing version!");

                uint major = uint.Parse(parts[0]);
                uint minor = parts.Count > 1 ? uint.Parse(parts[1]) : 0;
                uint patch = parts.Count > 2 ? uint.Parse(parts[2]) : 0;

                Validate(major, minor, patch);

                _major = major; _minor = minor; _patch = patch;
            }
        }

        public Version Major()
        {
            return new Version(_major + 1, 0, 0);
        }

        public Version Minor()
        {
            return new Version(_major, _minor + 1, 0);
        }

        public Version Patch()
        {
            return new Version(_major, _minor, _patch + 1);
        }

        public override string ToString()
        {
            return $"{_major}.{_minor}.{_patch}";
        }

        private void Validate(uint major, uint minor, uint patch)
        {
            if (major == 0 && minor == 0 && patch == 0)
                throw new Exception("Invalid version number");
        }
    }
}
