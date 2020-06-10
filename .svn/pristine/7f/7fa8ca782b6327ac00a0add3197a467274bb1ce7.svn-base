using HTZF.Manage.Api.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Resources;
using WS.HTZF.Application.Services.Sys;
using WS.HTZF.Core.Enums;
using WS.HTZF.Core.HttpController;

namespace HTZF.Manage.Api.Controllers
{
    /// <summary>
    /// 商品分类，图片，详情管理
    /// </summary>
    [RoutePrefix("manage/cdyprot")]
    public class CdyprotController : BaseController
    {
        private readonly CdyportService cdyportService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdyportService"></param>
        public CdyprotController(CdyportService cdyportService)
        {
            this.cdyportService = cdyportService;
        }

        ///// <summary>
        ///// 根据分类名称查询分类列表
        ///// </summary>
        ///// <param name="name">分类名</param>
        ///// <returns>分类列表</returns>
        [HttpGet]
        [Route("getcatoriesByName")]
        [PermissionAuthorize("getcatoriesByName", Permission.Query)]
        public async Task<ApiResult<List<CategoryRescource>>> GetCatoriesByName(string name)
        {
            var models = await cdyportService.GetCategories(name);
            return new ApiResult<List<CategoryRescource>>(models);
        }
        /// <summary>
        /// 根据Id查询分类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getcategoryById/{Id}")]
        [PermissionAuthorize("getcategoryById",Permission.Query)]
        public async Task<ApiResult<CategoryRescource>> GetCategoryById(int Id)
        {
            var result = await cdyportService.GetCategoryById(Id);
            return new ApiResult<CategoryRescource>(result);
        }
        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="addCategoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addCategory")]
        [PermissionAuthorize("addCategory", Permission.Add)]
        public async Task<ApiResult> AddCategory(AddCategoryDto addCategoryDto)
        {
            await cdyportService.AddCategoryAsync(addCategoryDto);
            return ApiResult.Success;
        }

        /// <summary>
        /// 修改分类实体
        /// </summary>
        /// <param name="modifiyCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateCategory")]
        [PermissionAuthorize("updateCategory", Permission.Update)]
        public async Task<ApiResult> UpdateCategory(ModifiyCategoryDto modifiyCategory)
        {
            await cdyportService.UpdateCategoryAsync(modifiyCategory);
            return ApiResult.Success;
        }

        /// <summary>
        /// 根据Id删除分类
        /// </summary>
        /// <param name="modifiyCategory"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delCategorybyId/{categoryid}")]
        [PermissionAuthorize("delCategorybyId", Permission.Delete)]
        public async Task<ApiResult> DeleteCategoryById(int categoryid)
        {
            await cdyportService.DeleteCategoryById(categoryid);
            return ApiResult.Success;
        }
        /// <summary>
        /// 根据商品名称查询商品列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getcdyByName")]
        [PermissionAuthorize("getcdyByName", Permission.Query)]
        public async Task<ApiResult<List<CdyRescource>>> GetcdyListByName(string name)
        {
            var models = await cdyportService.GetCdyListByName(name);
            return new ApiResult<List<CdyRescource>>(models);
        }

        [HttpGet]
        [Route("getcdyById/{id}")]
        [PermissionAuthorize("getcdyById", Permission.Query)]
        public async Task<ApiResult<CdyRescource>> GetcdyById(int id)
        {
            var model = await cdyportService.GetCdyById(id);
            return new ApiResult<CdyRescource>(model);
        }

        /// <summary>
        /// 修改商品实体
        /// </summary>
        /// <param name="modifyCdyDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updatecdy")]
        [PermissionAuthorize("updatecdy",Permission.Update)]
        public async Task<ApiResult> UpdateCdy(ModifyCdyDto modifyCdyDto)
        {
            await cdyportService.UpdateCdyAsync(modifyCdyDto);
            return ApiResult.Success;
        }
        /// <summary>
        /// 新增商品实体
        /// </summary>
        /// <param name="addCdyDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addcdy")]
        [PermissionAuthorize("addcdy",Permission.Add)]
        public async Task<ApiResult> AddCdy(AddCdyDto addCdyDto)
        {
            await cdyportService.AddCdyAsync(addCdyDto);
            return ApiResult.Success;
        }

        /// <summary>
        /// 新增商品详情
        /// </summary>
        /// <param name="saveCdyDetail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addcdyDetail")]
        [PermissionAuthorize("addcdyD", Permission.Add)]
        public async Task<ApiResult> AddCdyDetail(SaveCdyDetailDto saveCdyDetail)
        {
            await cdyportService.AddCdyDetail(saveCdyDetail);
            return ApiResult.Success;
        }

        /// <summary>
        /// 更新商品详情
        /// </summary>
        /// <param name="saveCdyDetail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updatecdyDetail")]
        [PermissionAuthorize("updatecdyD",Permission.Update)]
        public async Task<ApiResult> UpdateCdyDetail(SaveCdyDetailDto saveCdyDetail)
        {
            await cdyportService.UpdateCdyDetail(saveCdyDetail);
            return ApiResult.Success;
        }

        /// <summary>
        /// 根据商品ID获取商品详情
        /// </summary>
        /// <param name="commdiyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCdyDById/{commdiyId}")]
        [PermissionAuthorize("getCdyDById", Permission.Query)]
        public async Task<ApiResult<CdyDetailResource>> GetCdyDById(int commdiyId)
        {
            var model = await cdyportService.GetCdyDetailById(commdiyId);
            return new ApiResult<CdyDetailResource>(model);
        }
     }
}
