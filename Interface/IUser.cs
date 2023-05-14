using SampleApi.Models;
using SampleApi.Response;

namespace SampleApi.Interface
{
    public interface IUser
    {
        public Task<SignUpResponse> PostUserInfoAsync(SignUpRequest user);
    }
}
