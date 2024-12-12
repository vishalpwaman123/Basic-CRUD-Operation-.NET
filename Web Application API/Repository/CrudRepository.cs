using Microsoft.EntityFrameworkCore;
using Web_Application_API.Data;
using Web_Application_API.Model;

namespace Web_Application_API.Repository
{
    public class CrudRepository : ICrudRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CrudRepository(ApplicationDbContext dbContext) { _dbContext = dbContext; }
        public async Task<BasicResponse> Delete(int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                CrudDetail? crudDetail = await _dbContext.CrudDetail.FindAsync(Id);
                if (crudDetail is null)
                {
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }
                _dbContext.CrudDetail.Remove(crudDetail);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) { response.IsSuccess = false; response.Message = ex.Message; }
            return response;
        }

        public async Task<List<CrudDetail>> Get()
        {
            List<CrudDetail> response = new List<CrudDetail>();
            try
            {
                return await _dbContext.CrudDetail.ToListAsync();
            }
            catch (Exception ex) { }
            return response;
        }

        public async Task<BasicResponse> Insert(InsertRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                CrudDetail detail = new CrudDetail()
                {
                    RunType = request.RunType,
                    Release = request.Release,
                    KB = request.KB,
                    Build = request.Build,
                    MachinePool = request.MachinePool,
                };
                await _dbContext.CrudDetail.AddAsync(detail);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex) { response.IsSuccess = false; response.Message = ex.Message; }
            return response;
        }

        public async Task<BasicResponse> Update(UpdateRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                var crudData = await _dbContext.CrudDetail.FindAsync(request.Id);
                if (crudData is null)
                {
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }
                crudData.RunType = request.RunType;
                crudData.Release = request.Release;
                crudData.KB = request.KB;
                crudData.Build = request.Build;
                crudData.MachinePool = request.MachinePool;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) { response.IsSuccess = false; response.Message = ex.Message; }
            return response;
        }
    }
}
