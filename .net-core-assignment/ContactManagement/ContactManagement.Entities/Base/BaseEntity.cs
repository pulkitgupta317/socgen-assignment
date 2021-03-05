﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactManagement.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get; set;
        }

        public DateTime CreatedOn
        {
            get; set;
        }

        public DateTime UpdatedOn
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }
    }
}
