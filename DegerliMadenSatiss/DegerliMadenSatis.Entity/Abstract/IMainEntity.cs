﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Entity.Abstract
{
    public interface IMainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
