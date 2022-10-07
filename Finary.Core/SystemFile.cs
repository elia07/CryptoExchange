//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finary.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class SystemFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SystemFile()
        {
            this.FileData = new HashSet<FileData>();
            this.User = new HashSet<User>();
        }
    
        public long xID { get; set; }
        public string xFileExtention { get; set; }
        public string xContentType { get; set; }
        public string xFileName { get; set; }
        public System.DateTime xAddingDate { get; set; }
        public string xMD5 { get; set; }
        public bool xIsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileData> FileData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}
