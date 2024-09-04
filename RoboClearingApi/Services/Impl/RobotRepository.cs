using RoboClearingApi.Contexts;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Services.Impl
{
    public class RobotRepository : IRobotRepository
    {
        private readonly RoboClearingPostgreSqlDBContext _dbContext;

        public RobotRepository(RoboClearingPostgreSqlDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Robot robot)
        {
            await _dbContext.Robots.AddAsync(robot);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var robot = await _dbContext.Robots.FindAsync(id) ?? throw new Exception($"id:{id} Not Found!");
            _dbContext.Robots.Remove(robot);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Robot>> GetAll()
        {
            return await Task.Run(() => _dbContext.Robots);
        }

        public async Task<Robot> GetById(int id)
        {
            return await _dbContext.Robots.FindAsync(id) ?? throw new Exception($"id:{id} Not Found!");
        }

        public async Task<int> UpDate(Robot robot)
        {
            var check = await _dbContext.Robots.FindAsync(robot.Id) ?? throw new Exception($"id:{robot.Id} Not Found!");
            check.Status = robot.Status;
            check.Name = robot.Name;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
