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

        public int Add(Robot robot)
        {
            _dbContext.Robots.Add(robot);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var robot = GetById(id);

            _dbContext.Robots.Remove(robot);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Robot> GetAll()
        {
            return _dbContext.Robots;
        }

        public Robot GetById(int id)
        {
            var robot = _dbContext.Robots.FirstOrDefault(r => r.Id == id) ?? throw new Exception($"id:{id} Not Found!");
            return robot;
        }

        public int UpDate(Robot robot)
        {
            var check = GetById(robot.Id);
            check.StatusId = robot.StatusId;
            check.Name = robot.Name;

            _dbContext.Robots.Update(check);
            return _dbContext.SaveChanges();
        }
    }
}
