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
    
    public partial class photo
    {
        public photo()
        {
            this.phototags = new HashSet<phototag>();
        }
    
        public int PhotoId { get; set; }
        public Nullable<int> userId { get; set; }
        public string url { get; set; }
        public string location { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    
        public virtual ICollection<phototag> phototags { get; set; }
        public virtual user user { get; set; }
    }
}
