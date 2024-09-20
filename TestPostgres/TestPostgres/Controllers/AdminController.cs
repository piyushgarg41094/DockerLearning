using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestPostgres.Controllers
{
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private readonly AdminDbContext _dbContext;
        public AdminController(AdminDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("regions")]
        public async Task<List<Region>> GetRegions()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        [HttpGet("schools")]
        public async Task<List<School>> GetSchools()
        {
            return await _dbContext.Schools.ToListAsync();
        }

        [HttpGet("SchoolUnderRegion/{regionId}")]
        public async Task<List<Region>> GetRegions(int regionId)
        {
            var schoolsUnderRegion = await _dbContext.Regions.Where(r => r.RegionId == regionId).Include(x => x.School).Select(y => y).ToListAsync();
            return schoolsUnderRegion;
        }

        [HttpPost("addschool")]
        public async Task addSchools(School school)
        {
            await _dbContext.Schools.AddAsync(school);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPost("addregion")]
        public async Task addRegion(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPost("{regionId}/{regionName}")]
        public async Task addRegionThroughStoredProcedure(int regionId, string regionName)
        {
            var conn = _dbContext.Database.GetDbConnection();

            try
            {
                await conn.OpenAsync();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "call Insert_Test(@p1, @p2)";
                    cmd.CommandType = System.Data.CommandType.Text;

                    var param1 = cmd.CreateParameter();
                    param1.ParameterName = "@p1";
                    param1.Value = regionId;
                    cmd.Parameters.Add(param1);

                    var param2 = cmd.CreateParameter();
                    param2.ParameterName = "@p2";
                    param2.Value = regionName;
                    cmd.Parameters.Add(param2);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
