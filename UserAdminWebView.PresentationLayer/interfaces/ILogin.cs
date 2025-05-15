public interface ILogin{
    bool checkPassword(LoginDetailsModel model);
    public bool checkUserInDb(LoginDetailsModel model);
    bool createNewUser(UserDetailsViewModel model);
    LoginDetailsModel findUserRole(LoginDetailsModel model);
    // public Pro
}