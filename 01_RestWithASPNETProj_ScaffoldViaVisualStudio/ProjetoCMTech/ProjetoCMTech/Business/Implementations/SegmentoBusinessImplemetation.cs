using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class SegmentoBusinessImplemetation : ISegmentoBusiness
    {
        private readonly ISegmentoRepository _repository;

        private readonly SegmentoCoverter _coverter;

        public SegmentoBusinessImplemetation(ISegmentoRepository repository)
        {
            _repository = repository;

            _coverter = new SegmentoCoverter();
        }
       public List<SegmentoVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public SegmentoVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public SegmentoVO Create(SegmentoVO segmento)
        {

            var segmentoEntity = _coverter.Parse(segmento);
            segmentoEntity = _repository.Create(segmentoEntity);
            return _coverter.Parse(segmentoEntity);
        }
       public SegmentoVO Update(SegmentoVO segmento)
        {
            var segmentoEntity = _coverter.Parse(segmento);
            segmentoEntity = _repository.Update(segmentoEntity);
            return _coverter.Parse(segmentoEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
