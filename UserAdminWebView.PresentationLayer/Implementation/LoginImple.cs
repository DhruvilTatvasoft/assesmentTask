public class LoginImple : ILogin
{

    private UserAdminWebViewContext _context;
    public LoginImple(UserAdminWebViewContext context){
        _context = context;
    }

    public bool checkPassword(LoginDetailsModel model)
    {
        LoginDetails logger = _context.LoginDetails.FirstOrDefault(user => user.email == model.email);
        if (logger != null)
        {
            return false;
        }
        else
        {
            return true;
        }
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

    public bool createNewUser(UserDetailsViewModel model)
    {
        UserDetails user = new UserDetails();
        UserDetails existinguser = _context.UserDetails.FirstOrDefault(User => User.email == model.email);
        if (existinguser == null)
        {
            user.email = model.email;
            user.name = model.name;
            user.phonenumber = model.phonenumber;
            user.collegeName = model.collegeName;
            user.password = model.password;
            user.Roleid = 2;
            LoginDetails logger = new LoginDetails();
            logger.email = model.email;
            logger.password = model.password;
            _context.UserDetails.Add(user);
            _context.LoginDetails.Add(logger);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public LoginDetailsModel findUserRole(LoginDetailsModel model)
    {
        LoginDetailsModel Model = model;
        UserDetails user = _context.UserDetails.FirstOrDefault(user=>user.email == model.email);
        Roles role = _context.Roles.FirstOrDefault(role=>role.id == user.Roleid);
        Model.role = role;
        return Model;
    }
}