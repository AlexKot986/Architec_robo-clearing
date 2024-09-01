using Microsoft.EntityFrameworkCore;
using RoboClearingApi.Contexts;
using RoboClearingApi.Models.Domain;
using RoboClearingApi.Models.Responses;

namespace RoboClearingApi.Services.Impl
{

    public class RoboStatusRepository : IRoboStatusRepository
    {
        private readonly RoboClearingPostgreSqlDBContext _dbContext;

        public RoboStatusRepository(RoboClearingPostgreSqlDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(RoboStatus roboStatus)
        {
            var status = await _dbContext.RoboStatuses.FindAsync(roboStatus.Title);
            if (status != null)
                throw new Exception("Title is already exist!");
            await _dbContext.RoboStatuses.AddAsync(roboStatus);
            return await _dbContext.SaveChangesAsync();          
        }

        public async Task<int> Delete(int id)
        {
            var roboStatus = await _dbContext.RoboStatuses.FindAsync(id) ?? throw new Exception($"id:{id} Not Found!");
            
            _dbContext.RoboStatuses.Remove(roboStatus);
            return await _dbContext.SaveChangesAsync();           
        }

        public async Task<IEnumerable<RoboStatus>> GetAll()
        {
            return await Task.Run(() => _dbContext.RoboStatuses);
        }

        public async Task<RoboStatus> GetById(int id)
        {
            return await _dbContext.RoboStatuses.FindAsync(id) ?? throw new Exception($"id:{id} Not Found!");
        }

        public async Task<int> UpDate(RoboStatus roboStatus)
        {
            var status = await _dbContext.RoboStatuses.FindAsync(roboStatus.Id) ?? throw new Exception($"id:{roboStatus.Id} Not Found!");
            status.Title = roboStatus.Title;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
