﻿using System.Web.Http;
using System.Web.Http.Controllers;
using WS.HTZF.Application.Authentication;
using WS.HTZF.Core.Enums;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Utilities.Helper;

namespace WS.HTZF.MvcApp.Filter
{
    public class PermissionAuthorize: AuthorizeAttribute
    {
        /// <summary>
        /// Customer Authoreize 
        /// </summary>
        private Permission[] permissionActions { get; }
        private string actionName { get; }
        public PermissionAuthorize(string actionName, params Permission[] permissionActions)
        {
            this.permissionActions = permissionActions;
            this.actionName = actionName;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //不管什么方式的授权，它都会要在头部上加上Authorization 以保证我们的服务器来识别
            var authorizationHeader = actionContext.Request.Headers.Authorization;
            //前端没有加Authorization 则抛出异常 ExceptionFilterAttribute 去处理这个异常
            if (authorizationHeader == null)
            {
                //base.IsAuthorized(actionContext);
                throw new AuthorizeFailException("Permission Authorize Fail Exception");
            }
            //如果有 存在我们可以拿到这个accessToken 解析这个accessToken 获取到AppId-》这个用户
            //然后在数据库中创建一个Permission 角色表 来查询出这个用户是否拥有这个权限，如果没有您也可以
            //已相同的方式throw 一个异常方式返回给前端来告诉前端没有这个权限
            var accessToken = authorizationHeader.Parameter;
            //这里我时已Jwt方式来授权的所以我需要解析我的accessToken来获取appId,当然你也可以用Basic授权验证或者其他方式
            var tokenPayload = LazyFactory<JwtHandler>.Instance.GetTokenPayload(accessToken);
            var userId = tokenPayload.Subject; //这里是当前请求者的APPID，你可以拿着这个appId去DB或缓存中查。。
            
        }
    }
}