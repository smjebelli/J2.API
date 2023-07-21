namespace J2.API.Dto
{
    public class AddUserToRoleDto
    {
        public string UserName { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
