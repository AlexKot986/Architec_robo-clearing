using RoboClearingApi.Contexts;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Services.NotImpl;

public class TypeOfClearingRepository(RoboClearingPostgreSqlDBContext _dbContext)
{
   public async Task<int> CreateTypes()
   {
      var check = _dbContext.Types;
      if (check.Any()) throw new Exception("Types already exist");
      List<TypeOfClearing> types =
      [
         new TypeOfClearing { Title = "Dry clearing" },
         new TypeOfClearing { Title = "Wet clearing" }
      ];
        
      await _dbContext.Types.AddRangeAsync(types);
      return await _dbContext.SaveChangesAsync();
   }
}