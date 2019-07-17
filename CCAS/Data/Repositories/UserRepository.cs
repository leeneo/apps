/*
 * Author:  leeneo
 * Contact: leenoe@xingzhihen.com
 */

using CCAS.Data.Interfaces;
using CCAS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCAS.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Db _dbContext = null;

        public UserRepository(Db dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal> AddAsync(User user)
        {
            if (null == user)
                //return JsonConvert.SerializeObject(new Results(-1));
                return -1;
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Userid;
        }

        public async Task DeleteAsync(decimal id)
        {
            var wxParameter = await _dbContext.User
                .SingleOrDefaultAsync(b => b.Userid == id);

            if (wxParameter != null)
            {
                _dbContext.User.Remove(wxParameter);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetAsync(decimal id)
        {
            return await _dbContext.User.Where(b => b.Userid == id).SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.User.ToListAsync();
        }

        /// <summary>
        /// 传入修改后的实体直接保存以达到更新的效果
        /// Demo:wxParameters old=new wxParameters();old.Name="new Name";_wxParametersRepository.UpdateAsync(old);
        /// </summary>
        /// <param name="newWxParameter">新的实体</param>
        /// <returns></returns>
        public async Task UpdateAsync(User newWxParameter)
        {
            if (null == newWxParameter)
                return;
            //_dbContext.WxParameters.Add(wxParameter);      //据说Add或Find方法触发实体更新
            await _dbContext.SaveChangesAsync();
        }
    }
}
