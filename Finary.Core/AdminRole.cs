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
    
    public partial class AdminRole
    {
        public long xID { get; set; }
        public long xAdminID { get; set; }
        public byte xSectionType { get; set; }
        public string xCrudPermission { get; set; }
    
        public virtual Admin Admin { get; set; }
    }
}