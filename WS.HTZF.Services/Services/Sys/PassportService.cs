using AutoMapper;
using System.Threading.Tasks;
using WS.HTZF.Application.Authentication;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Handlers;
using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Core.Repositories;

namespace WS.HTZF.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PassportService : BaseService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHandler passwordHandler;
        private readonly IJwtHandler jwtHandler;

        /// <summary>
        /// ctor.
        /// </summary>
        public PassportService(IAccountRepository accountRepository,
            IPasswordHandler passwordHandler,
            IJwtHandler jwtHandler,
            IMapper mapper) : base(mapper)
        {
            _accountRepository = accountRepository;
            this.passwordHandler = passwordHandler;
            this.jwtHandler = jwtHandler;
        }
        /// <summary>
        /// Regiester 
        /// </summary>
        /// <param name="newAccount"></param>
        /// <returns></returns>
        public async Task RegisterAppUserAsync(NewAccountDto newAccount)
        {
            var entity = base.Map<NewAccountDto, Account>(newAccount);
            entity.Password = passwordHandler.GenerateEncryptPassword(newAccount.Password);
            await _accountRepository.InsertAsync(entity);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<WebToken> SingInAppUserAsync(string userName, string password)
        {
            var appuser = await _accountRepository.SingleOrDefaultAsync(x => string.Equals(x.UserName, userName));
            if (appuser == null)
                throw new NotFoundException($"{userName}没有此账号或已被删除!");

            var verifyPwd = passwordHandler.VerifyHashedPassword(appuser.Password, password);

            if (!verifyPwd)
                throw new InvalidArgumentException($"{userName}账号的密码不正确!");

            if (appuser.IsDisplay)
                throw new FriendlyException($"抱歉{userName}账号已被停用!");

            var jwt = jwtHandler.CreateToken(appuser.Id.ToString());

            return jwt;
        }
    }
}
