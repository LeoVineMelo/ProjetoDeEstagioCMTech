using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("changelog")]
    public class Changelog
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("version")]
        public string Version { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("checksum")]
        public string Checksum { get; set; }
        [Column("installed_by")]
        public string InstalledBy { get; set; }
        [Column("installed_on")]
        public string InstalledOn { get; set; }
        [Column("success")]
        public string Success { get; set; }
    }
}
