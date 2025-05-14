public class LoginImple : ILogin
{

    private UserAdminWebViewContext _context;
    public LoginImple(UserAdminWebViewContext context){
        _context = context;
    }
    public bool checkUserInDb(LoginDetailsModel model)
    {
        LoginDetails logger = _context.LoginDetails.FirstOrDefault(log=>log.email == model.email && log.password == model.password);
        if(logger != null){
            return true;
        }
        else{
            return false;
        }
    }

    public LoginDetailsModel findUserRole(LoginDetailsModel model)
    {
        LoginDetailsModel Model = model;
        ProfileDetails user = _context.ProfileDetails.FirstOrDefault(user=>user.email == model.email);
        Roles role = _context.Roles.FirstOrDefault(role=>role.id == user.Roleid);
        Model.role = role;
        return Model;
    }
}