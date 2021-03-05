/*
 * Author:  leeneo
 * Contact: leenoe@xingzhihen.com
 */

using CCAS.Data.Interfaces;
using CCAS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCAS.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _dbContext = null;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal> AddAsync(Users user)
        {
            if (null == user)
                //return JsonConvert.SerializeObject(new Results(-1));
                return -1;
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteAsync(decimal id)
        {
            var wxParameter = await _dbContext.Users
                .SingleOrDefaultAsync(b => b.Id == id);

            if (wxParameter != null)
            {
                _dbContext.Users.Remove(wxParameter);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Users> GetAsync(decimal id)
        {
            return await _dbContext.Users.Where(b => b.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        /// <summary>
        /// 传入修改后的实体直接保存以达到更新的效果
        /// Demo:wxParameters old=new wxParameters();old.Name="new Name";_wxParametersRepository.UpdateAsync(old);
        /// </summary>
        /// <param name="newWxParameter">新的实体</param>
        /// <returns></returns>
        public async Task UpdateAsync(Users newWxParameter)
        {
            if (null == newWxParameter)
                return;
            //_dbContext.WxParameters.Add(wxParameter);      //据说Add或Find方法触发实体更新
            await _dbContext.SaveChangesAsync();
        }


        Task<Users> IUserRepository.GetAsync(decimal uid)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Users>> IUserRepository.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

    }
}
