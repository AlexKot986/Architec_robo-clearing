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

        public int Add(RoboStatus roboStatus)
        {
            var status = _dbContext.RoboStatuses.FirstOrDefault(rs => rs.Title == roboStatus.Title);
            if (status != null)
                throw new Exception("Title is already exist!");
            _dbContext.RoboStatuses.Add(roboStatus);
            return _dbContext.SaveChanges();          
        }

        public int Delete(int id)
        {
            var roboStatus = GetById(id);
            
            _dbContext.RoboStatuses.Remove(roboStatus);
            return _dbContext.SaveChanges();           
        }

        public IEnumerable<RoboStatus> GetAll()
        {
            return _dbContext.RoboStatuses;        }

        public RoboStatus GetById(int id)
        {
            var roboStatus = _dbContext.RoboStatuses.FirstOrDefault(rs => rs.Id == id) ?? throw new Exception($"id:{id} Not Found!");
            return roboStatus;
        }

        public int UpDate(RoboStatus roboStatus)
        {
            _dbContext.RoboStatuses.Update(roboStatus);
            return _dbContext.SaveChanges();
        }
    }
}
