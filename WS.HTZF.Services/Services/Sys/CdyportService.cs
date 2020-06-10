using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Resources;
using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Core.Repositories;

namespace WS.HTZF.Application.Services.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class CdyportService : BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public CdyportService(IMapper mapper,
            ICdyDetailRespository cdyDetailRespository,
            ICdyRespository cdyRespository,
            ICdyPirtureRespository cdyPirtureRespository,
            ICategoryRespository categoryRespository
           ) : base(mapper)
        {
            CdyDetailRespository = cdyDetailRespository;
            CdyRespository = cdyRespository;
            CdyPirtureRespository = cdyPirtureRespository;
            CategoryRespository = categoryRespository;
        }
        private ICdyDetailRespository CdyDetailRespository { get; }
        private ICdyRespository CdyRespository { get; }
        private ICdyPirtureRespository CdyPirtureRespository { get; }
        private ICategoryRespository CategoryRespository { get; }

        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<CategoryRescource>> GetCategories(string name)
        {
            var models = new List<Category>();
            if (name == "!")
            {

                models = await CategoryRespository.GetAllListAsync();
            }
            else
            {
                models = await CategoryRespository.GetAllListAsync(x => x.Name.Contains(name));
            }
            return Map<List<Category>, List<CategoryRescource>>(models);
        }
        /// <summary>
        /// 根据Id查询分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryRescource> GetCategoryById(int id)
        {
            var model = await CategoryRespository.SingleOrDefaultAsync(c => c.Id == id);
            if (model == null)
                throw new FriendlyException("该分类不存在了");
            return Map<Category, CategoryRescource>(model);
        }

        /// <summary>
        /// 更新分类实体
        /// </summary>
        /// <returns></returns>
        public async Task UpdateCategoryAsync(ModifiyCategoryDto modifiyCategoryDto)
        {
            var model = Map<ModifiyCategoryDto, Category>(modifiyCategoryDto);
            await CategoryRespository.UpdateAsync(model);
            await CategoryRespository.UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        ///删除分类 
        /// </summary>
        /// <returns></returns>
        public async Task DeleteCategoryById(int id)
        {
            var model = await CategoryRespository.SingleOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                throw new FriendlyException("该分类已经不存在了");
            }
            if (model.Commoditys.Count > 0)
            {
                throw new InvalidArgumentException("删除失败,该分类下面有商品");
            }
            await CategoryRespository.DeleteAsync(id);
            await CategoryRespository.UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 新增分类
        /// </summary>
        /// <returns></returns>
        public async Task AddCategoryAsync(AddCategoryDto addCategoryDto)
        {
            var mapModel = Map<AddCategoryDto, Category>(addCategoryDto);
            await CategoryRespository.InsertAsync(mapModel);
            await CategoryRespository.UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 根据Id查询商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CdyRescource> GetCdyById(int id)
        {
            var model = await CdyRespository.SingleOrDefaultAsync(c => c.Id == id);
            if (model == null)
                throw new FriendlyException("该商品不存在了");
            return Map<Commodity, CdyRescource>(model);
        }

        /// <summary>
        /// 查询商品列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<CdyRescource>> GetCdyListByName(string name)
        {
            var models = new List<Commodity>();
            if (name == "!")
            {

                models = await CdyRespository.GetAllListAsync();
            }
            else
            {
                models = await CdyRespository.GetAllListAsync(x => x.TitileOrName.Contains(name));
            }
            return Map<List<Commodity>, List<CdyRescource>>(models);
        }
        /// <summary>
        /// 更新商品列表
        /// </summary>
        /// <returns></returns>
        public async Task UpdateCdyAsync(ModifyCdyDto dto)
        {
            var existmodel = await CdyRespository.SingleOrDefaultAsync(c => c.Id == dto.Id);
            if (existmodel == null)
            {
                throw new FriendlyException("该商品不存在了!");
            }
            var model = Map<ModifyCdyDto, Commodity>(dto, existmodel);
            await CdyRespository.UpdateAsync(model);
            await CdyRespository.UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 新增商品列表
        /// </summary>
        /// <returns></returns>
        public async Task AddCdyAsync(AddCdyDto addCdyDto)
        {
            var existmodel= await CdyRespository.SingleOrDefaultAsync(c => c.TitileOrName == addCdyDto.TitileOrName.Trim());
            if (existmodel != null)
            {
                throw new FriendlyException("该商品已经添加了!");
            }
            var model = Map<AddCdyDto, Commodity>(addCdyDto);
            await CdyRespository.InsertAsync(model);
            await CdyRespository.UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCdy(int id)
        {
            var existmodel = await CdyRespository.SingleOrDefaultAsync(c => c.Id ==id);
            if (existmodel == null)
            {
                throw new FriendlyException("该商品不存在了!");
            }
            await CategoryRespository.DeleteAsync(id);
            await CategoryRespository.UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 添加商品详情
        /// </summary>
        /// <returns></returns>
        public async Task AddCdyDetail(SaveCdyDetailDto saveCdyDetailDto)
        {
            var existmodel = await CdyRespository.SingleOrDefaultAsync(c => c.Id == saveCdyDetailDto.CommdiyId);
            if (existmodel == null)
            {
                throw new FriendlyException("该商品不存在了!");
            }
            var model = Map<SaveCdyDetailDto, CommodityDetail>(saveCdyDetailDto);
            await CdyDetailRespository.InsertAsync(model);
            await CdyDetailRespository.UnitOfWork.SaveChangesAsync();
        }
        /// <summary>
        /// 修改商品详情
        /// </summary>
        /// <returns></returns>
        public async Task UpdateCdyDetail(SaveCdyDetailDto saveCdyDetailDto)
        {
            var existmodel = await CdyDetailRespository.SingleOrDefaultAsync(c => c.Id == saveCdyDetailDto.CommdiyId);
            if (existmodel == null)
            {
                throw new FriendlyException("该商品不存在了!");
            }
            var model = Map<SaveCdyDetailDto, CommodityDetail>(saveCdyDetailDto);

            //删除图片
            await CdyPirtureRespository.ExecuteSqlCommandAsync($"DELETE FROM `wshtzf`.`tws_commoditydetailpirture` WHERE  CommodityDetailId={saveCdyDetailDto.CommdiyId}");

            //删除商品详情
            await CdyDetailRespository.DeleteAsync(existmodel);

            //插入商品详情
            await CdyDetailRespository.InsertAsync(model);

            await CdyDetailRespository.UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 根据商品Id查询商品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<CdyDetailResource> GetCdyDetailById(int Id)
        {

            var model = await CdyDetailRespository.SingleOrDefaultAsync(c => c.Id == Id);
            if (model == null) throw new FriendlyException("该商品详情不存在了");
            return Map<CommodityDetail, CdyDetailResource>(model);
        }
    }
}
