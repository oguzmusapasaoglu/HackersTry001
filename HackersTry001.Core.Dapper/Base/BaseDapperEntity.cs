﻿using Dapper.Contrib.Extensions;

namespace HackersTry001.Core.Dapper.Base
{
    public class BaseDapperEntity
    {
        [Key]
        public int ID { get; set; }
        public int Status { get; set; }
    }
  
    public class ExtendBaseDapperEntity : BaseDapperEntity
    {
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
    }
}
