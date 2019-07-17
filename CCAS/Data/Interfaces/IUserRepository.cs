/*
 * Author:  leeneo
 * Contact: leenoe@xingzhihen.com
 * 若要使用DI功能，请把.net 框架升级到.net 4.6 以上或.net core
 */

using CCAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCAS.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<decimal> AddAsync(User user);
        Task DeleteAsync(decimal uid);
        Task<User> GetAsync(decimal uid);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(User user);
    }
}
