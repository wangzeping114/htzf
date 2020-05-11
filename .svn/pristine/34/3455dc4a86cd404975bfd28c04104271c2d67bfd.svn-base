using AutoMapper;

namespace WS.HTZF.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseService
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        protected TDestination MapTo<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        protected TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        protected void Map(object source, object destination)
        {
            _mapper.Map(source, destination);
        }
    }
}