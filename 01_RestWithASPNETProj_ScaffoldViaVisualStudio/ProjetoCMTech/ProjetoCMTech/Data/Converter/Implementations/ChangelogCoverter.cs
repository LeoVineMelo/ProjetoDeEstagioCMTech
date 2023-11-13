using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class ChangelogCoverter : IParser<ChangelogVO, Changelog>, IParser<Changelog, ChangelogVO>
    {
        public Changelog Parse(ChangelogVO origin)
        {
            if (origin == null) return null;
            return new Changelog
            {
                Id = origin.Id,
                Type = origin.Type,
                Version = origin.Version,
                Description = origin.Description,
                Name = origin.Name,
                Checksum = origin.Checksum,
                InstalledBy = origin.InstalledBy,
                InstalledOn = origin.InstalledOn,
                Success = origin.Success,
            };
        }
        public ChangelogVO Parse(Changelog origin)
        {
            if (origin == null) return null;
            return new ChangelogVO
            {
                Id = origin.Id,
                Type = origin.Type,
                Version = origin.Version,
                Description = origin.Description,
                Name = origin.Name,
                Checksum = origin.Checksum,
                InstalledBy = origin.InstalledBy,
                InstalledOn = origin.InstalledOn,
                Success = origin.Success,
            };
        }

        public List<ChangelogVO> Parse(List<Changelog> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Changelog> Parse(List<ChangelogVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
