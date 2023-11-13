using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class ChangelogRepositoryImplemetation : IChangelogRepository
    {
        private PostgreSQLContext _context;

        public ChangelogRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Changelog> FindAll()
        {
           
            return _context.Changelogs.ToList();
        }



        public Changelog FindByID(long id) => _context.Changelogs.SingleOrDefault(p => p.Id.Equals(id));

        public Changelog Create(Changelog changelog)
        {
            try
            {
                _context.Add(changelog);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return changelog;
        }
       public Changelog Update(Changelog changelog)
        {
            if(!Exists(changelog.Id)) return null;

            var result = _context.Changelogs.FirstOrDefault(p => p.Id.Equals(changelog.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(changelog);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return changelog;
        }
        public void Delete(long id)
        {
            var result = _context.Changelogs.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Changelogs.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

 
 

        public bool Exists(long id)
        {
            return _context.Changelogs.Any(p => p.Id.Equals(id));
        }
    }
}
