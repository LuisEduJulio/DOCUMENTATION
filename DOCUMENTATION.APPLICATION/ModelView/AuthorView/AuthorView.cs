using DOCUMENTATION.CORE.Enums;
using System;

namespace DOCUMENTATION.APPLICATION.ModelView.AuthorView
{
    public class AuthorView
    {
        public AuthorView(string name, string description, bool admin, EAvatar eAvatar, DateTime? updated)
        {
            Name = name;
            Description = description;
            Admin = admin;
            EAvatar = eAvatar;
            Updated = updated;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Admin { get; set; }
        public EAvatar EAvatar { get; set; }
        public DateTime? Updated { get; set; }
    }
}