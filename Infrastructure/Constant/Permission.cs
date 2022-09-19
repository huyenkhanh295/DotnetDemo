namespace Infrastructure.Constant
{
    public struct Permission
    {
        public struct User
        {
            public const string None = "None";
            public const string View = "ViewUser";
            public const string Create = "CreateUser";
            public const string Update = "UpdateUser";
            public const string Delete = "DeleteUser";
        }

        public struct Role
        {
            public const string View = "ViewRole";
            public const string Create = "CreateRole";
            public const string Update = "UpdateRole";
            public const string Delete = "DeleteRole";
        }
    }
}
