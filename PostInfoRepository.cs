using SampleApi.DBContext;
using SampleApi.Interface;
using SampleApi.Models;
using SampleApi.Response;

namespace SampleApi
{
    public class PostInfoRepository : IUser
    {
        public readonly UserDBContext _context;

        public PostInfoRepository(UserDBContext context)
        {
            _context = context;
        }
        public async Task<SignUpResponse> PostUserInfoAsync(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            response.IsSuccess = true;
            response.Message = "User successfully added";
            var resource = _context.Users.ToList().Any(x => x.Username == request.Username || x.EmailAddress == request.EmailAddress);
            //var resource = CheckIfEntityRecordExists(request);
            try
            {
                if (resource)
                {
                    response.IsSuccess = false;
                    response.Message = "User already exist";
                    return response;
                }
                _context.Add(request);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
            }
            return response;
        }

        /*private bool CheckIfEntityRecordExists(SignUpRequest request)
        {
            var retVal = false;
            using (var db = new UserDBContext())
            {
                retVal = db.Users.ToList().Any(x => x.Username == request.Username || x.EmailAddress == request.EmailAddress);
            }
            return retVal;
        }*/
    }
}
