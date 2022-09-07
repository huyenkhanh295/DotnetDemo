namespace Demo.Database.Models
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? Status { get; set; }
        public string? Description { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpired { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
