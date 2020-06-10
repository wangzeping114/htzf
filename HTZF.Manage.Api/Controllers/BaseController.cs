using System.Linq;
using System.Web.Http;
using WS.HTZF.Application.Authentication;
using WS.HTZF.Utilities.Helper;

namespace HTZF.Manage.Api.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// 获取当前的用户账号Id
        /// </summary>
        protected int UserId
        {
            get
            {
                var authorizationHeader = base.Request.Headers.Authorization;
                var accessToken = authorizationHeader.Parameter;
                var subject= LazyFactory<JwtHandler>.Instance.GetTokenPayload(accessToken).Subject;
                return int.Parse(subject);
            }
        }
        /// <summary>
        /// 获取当前用户给角色Id
        /// </summary>
        protected int RoleId
        {
            get
            {
                var authorizationHeader = base.Request.Headers.Authorization;
                var accessToken = authorizationHeader.Parameter;
                var Cliams = LazyFactory<JwtHandler>.Instance.GetTokenPayload(accessToken).Claims;
                var roleid = Cliams.Select((t, v) =>
                {
                    if (t.Key == "RoleId")
                    {
                        return  int.Parse(t.Value);
                    }
                    else
                    {
                        return 0;
                    }
                }).FirstOrDefault();
                return roleid;
            }
        }
    }
}