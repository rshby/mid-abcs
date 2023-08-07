﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_accont.Models.Entity
{
   [Table("ABCS_M_LNMEMO")]
   [GraphQLName("abcs_m_lnmemo")]
   public class ABCS_M_LNMEMO
   {
      [Required]
      [Column("ACCOUNTNUMBER")]
      [MaxLength(50)]
      [GraphQLName("account_number")]
      public string? AccountNumber { get; set; }
   }
}
