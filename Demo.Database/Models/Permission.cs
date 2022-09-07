namespace Demo.Database.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string PermissionName { get; set; } = null!;
        public string PermissionCode { get; set; } = null!;
        public int PermissionOrder { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public int? Status { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
