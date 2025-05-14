public interface ILogin{
    public bool checkUserInDb(LoginDetailsModel model);
    LoginDetailsModel findUserRole(LoginDetailsModel model);
    // public Pro
}