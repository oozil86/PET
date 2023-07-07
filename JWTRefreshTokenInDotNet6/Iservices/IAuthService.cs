

namespace GraduationProject.Iservices;

public interface IAuthService
{
    Task<AuthModel> RegisterAsync(RegisterModel model);
    Task<AuthModel> GetTokenAsync(TokenRequestModel model);
    Task<string> AddRoleAsync(AddRoleModel model);
    Task<AuthModel> RefreshTokenAsync(string token);
    Task<bool> RevokeTokenAsync(string token);
    Task<bool> ChangePassword([FromBody] ChangePasswordViewModel model);
    Task<AuthModel> GetUserProfile(string id);
    //
    Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model);
    Task<UserManagerResponse> ForgetPasswordAsync(string email);


}