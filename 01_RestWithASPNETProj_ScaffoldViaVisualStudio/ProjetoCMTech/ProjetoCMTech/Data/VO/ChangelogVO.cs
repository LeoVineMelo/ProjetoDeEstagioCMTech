using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    public class ChangelogVO
    {

        public long Id { get; set; }

        public string Type { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Checksum { get; set; }

        public string InstalledBy { get; set; }

        public string InstalledOn { get; set; }

        public string Success { get; set; }
    }
}
