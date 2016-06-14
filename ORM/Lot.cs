//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lot
    {
        public Lot()
        {
            this.BetHistories = new HashSet<BetHistory>();
            this.LotProperties = new HashSet<LotProperty>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> user_seller_id { get; set; }
        public int primaryCoast { get; set; }
        public System.DateTime beginDate { get; set; }
        public System.DateTime endDate { get; set; }
        public int isActive { get; set; }
        public Nullable<int> currentCoast { get; set; }
        public Nullable<int> user_bet_id { get; set; }
    
        public virtual ICollection<BetHistory> BetHistories { get; set; }
        public virtual ICollection<LotProperty> LotProperties { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
