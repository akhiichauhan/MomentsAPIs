//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moments.Data.MySqlDataSource.ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class person
    {
        public person()
        {
            this.users = new HashSet<user>();
            this.phototags = new HashSet<phototag>();
            this.photopersonmappings = new HashSet<photopersonmapping>();
        }
    
        public int personId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual ICollection<user> users { get; set; }
        public virtual ICollection<phototag> phototags { get; set; }
        public virtual ICollection<photopersonmapping> photopersonmappings { get; set; }
    }
}
