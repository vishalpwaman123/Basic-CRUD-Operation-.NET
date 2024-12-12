using Web_Application_API.Data;
using Web_Application_API.Model;

namespace Web_Application_API.Repository
{
    public interface ICrudRepository
    {
        Task<BasicResponse> Insert(InsertRequest request);
        Task<BasicResponse> Update(UpdateRequest request);
        Task<BasicResponse> Delete(int Id);
        Task<List<CrudDetail>> Get();
    }
}
