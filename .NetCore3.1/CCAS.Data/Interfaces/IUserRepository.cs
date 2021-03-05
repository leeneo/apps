/*
 * Author:  leeneo
 * Contact: leenoe@xingzhihen.com
 * 若要使用DI功能，请把.net 框架升级到.net 4.6 以上或.net core
 */

using CCAS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCAS.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<decimal> AddAsync(Users user);
        Task DeleteAsync(decimal uid);
        Task<Users> GetAsync(decimal uid);
        Task<List<Users>> GetAllAsync();
        Task UpdateAsync(Users user);
    }
}
