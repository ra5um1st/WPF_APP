//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_APP
{
    using System;
    using System.Collections.Generic;
    
    public partial class persons
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> Gender_id { get; set; }
        public Nullable<int> Telephone { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    
        public virtual genders genders { get; set; }
        public virtual users users { get; set; }
    }
}