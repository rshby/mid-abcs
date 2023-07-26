using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sa_inquiry.Models.Entity
{
   [Table("ABCS_M_DDMAST")]
   [GraphQLName("abcs_m_ddmast")]
   public class ABCS_M_DDMAST
   {
      [Required]
      [Column("ACCOUNTNUMBER", Order = 1)]
      [MaxLength(50)]
      [GraphQLName("accountnumber")]
      public string? AccountNumber { get; set; }

      [Column("ACCOUNTTYPE", Order = 2)]
      [MaxLength(1)]
      [GraphQLName("accounttype")]
      public string? AccountType { get; set; }

      [Column("CIFNUM", Order = 3)]
      [MaxLength(10)]
      [GraphQLName("cifnum")]
      public string? CifNum { get; set; }

      [Column("CBAL", Order = 4)]
      [MaxLength(50)]
      [GraphQLName("cbal")]
      public string? Cbal { get; set; }

      [Column("HOLD", Order = 5)]
      [MaxLength(50)]
      [GraphQLName("hold")]
      public string? Hold { get; set; }

      [Column("SHORTNAME", Order = 6)]
      [MaxLength(100)]
      [GraphQLName("shortname")]
      public string? ShortName { get; set; }

      [Column("PRODUCTTYPE", Order = 7)]
      [MaxLength(5)]
      [GraphQLName("producttype")]
      public string? ProductType { get; set; }

      [Column("CURRENCY", Order = 8)]
      [MaxLength(5)]
      [GraphQLName("currency")]
      public string? Currency { get; set; }

      [Column("STATUS", Order = 9)]
      [MaxLength(1)]
      [GraphQLName("status")]
      public string? Status { get; set; }

      [Column("RATE", Order = 10)]
      [MaxLength(10)]
      [GraphQLName("rate")]
      public string? Rate { get; set; }

      [Column("PVAR", Order = 11)]
      [MaxLength(50)]
      [GraphQLName("pvar")]
      public string? PVAR { get; set; }

      [Column("PVARCODE", Order = 12)]
      [MaxLength(50)]
      [GraphQLName("pvarcode")]
      public string? PvarCode { get; set; }

      [Column("INTCYCLE", Order = 13)]
      [MaxLength(50)]
      [GraphQLName("intcycle")]
      public string? IntCycle { get; set; }

      [Column("SVCCYCLE", Order = 14)]
      [MaxLength(50)]
      [GraphQLName("svccycle")]
      public string? SvcCycle { get; set; }

      [Column("OPENDAT6", Order = 15)]
      [MaxLength(12)]
      [GraphQLName("opendat6")]
      public string? OpenDat6 { get; set; }

      [Column("OPENDAT7", Order = 16)]
      [MaxLength(100)]
      [GraphQLName("opendat7")]
      public string? OpenDat7 { get; set; }

      [Column("UID", Order = 17)]
      [MaxLength(20)]
      [GraphQLName("uid")]
      public string? Uid { get; set; }

      [Column("YBAL", Order = 18)]
      [MaxLength(50)]
      [GraphQLName("ybal")]
      public string? Ybal { get; set; }

      [Column("ACCRUE", Order = 19)]
      [MaxLength(50)]
      [GraphQLName("accrue")]
      public string? Accrue { get; set; }

      [Column("ODACCRUE", Order = 20)]
      [MaxLength(50)]
      [GraphQLName("odaccrue")]
      public string? OdAccrue { get; set; }

      [Column("LASTTRANDATE", Order = 21)]
      [MaxLength(50)]
      [GraphQLName("lasttrandate")]
      public string? LastTranDate { get; set; }

      [Column("LASTTRANDATE7", Order = 22)]
      [MaxLength(50)]
      [GraphQLName("lasttrandate7")]
      public string? LastTranDate7 { get; set; }

      [Column("DATELASTINTPAID6", Order = 23)]
      [MaxLength(50)]
      [GraphQLName("datelastintpaid6")]
      public string? DateLastIntPaid6 { get; set; }

      [Column("DATELASTINTPAID7", Order = 24)]
      [MaxLength(50)]
      [GraphQLName("datelastintpaid7")]
      public string? DateLastIntPaid7 { get; set; }

      [Column("GROUPCODE", Order = 25)]
      [MaxLength(50)]
      [GraphQLName("groupcode")]
      public string? GroupCode { get; set; }

      [Column("DTLM6", Order = 26)]
      [MaxLength(50)]
      [GraphQLName("dtlm6")]
      public string? Dtlm6 { get; set; }

      [Column("DTLM7", Order = 27)]
      [MaxLength(50)]
      [GraphQLName("dtlm7")]
      public string? Dtlm7 { get; set; }

      [Column("TMLM", Order = 28)]
      [MaxLength(50)]
      [GraphQLName("tmlm")]
      public string? Tmlm { get; set; }

      [Column("UIDLM", Order = 29)]
      [MaxLength(50)]
      [GraphQLName("uidlm")]
      public string? Uidlm { get; set; }

      [Column("SIDLM", Order = 30)]
      [MaxLength(50)]
      [GraphQLName("sidlm")]
      public string? Sidlm { get; set; }

      [Column("TAX", Order = 31)]
      [MaxLength(2)]
      [GraphQLName("tax")]
      public string? Tax { get; set; }

      [Column("SKB", Order = 32)]
      [MaxLength(1)]
      [GraphQLName("skb")]
      public string? Skb { get; set; }

      [Column("ADDR", Order = 33)]
      [MaxLength(1)]
      [GraphQLName("addr")]
      public string? Addr { get; set; }

      [Column("TAXACCRUE", Order = 34)]
      [MaxLength(50)]
      [GraphQLName("taxaccrue")]
      public string? TaxAccrue { get; set; }

      [Column("MINIMUMBALANCEDAYS", Order = 35)]
      [MaxLength(10)]
      [GraphQLName("minimumbalancedays")]
      public string? MinimumBalanceDays { get; set; }

      [Column("ZEROBALANCEDAYS", Order = 36)]
      [MaxLength(10)]
      [GraphQLName("zerobalancedays")]
      public string? ZeroBalanceDays { get; set; }

      [Column("QQNAME", Order = 37)]
      [MaxLength(50)]
      [GraphQLName("qqname")]
      public string? QQName { get; set; }

      [Column("KODEFO", Order = 38)]
      [MaxLength(50)]
      [GraphQLName("kodefo")]
      public string? KodeFo { get; set; }

      [Column("RELATION", Order = 39)]
      [MaxLength(50)]
      [GraphQLName("relation")]
      public string? Relation { get; set; }

      [Column("CIFRELATION", Order = 40)]
      [MaxLength(50)]
      [GraphQLName("cifrelation")]
      public string? CifRelation { get; set; }

      [Column("ACCRUETEMP", Order = 41)]
      [MaxLength(500)]
      [GraphQLName("accruetemp")]
      public string? AccrueTemp { get; set; }

      [Column("RATETEMP", Order = 42)]
      [MaxLength(500)]
      [GraphQLName("ratetemp")]
      public string? RateTemp { get; set; }

      [Column("ARRCBALTEMP", Order = 43)]
      [MaxLength(500)]
      [GraphQLName("arrcbaltemp")]
      public string? ArrCbalTemp { get; set; }

      [Column("ARRRATETEMP", Order = 44)]
      [MaxLength(500)]
      [GraphQLName("arrratetemp")]
      public string? ArrRateTemp { get; set; }

      [Column("CLOSINGDATE6", Order = 45)]
      [MaxLength(50)]
      [GraphQLName("closingdate6")]
      public string? ClosingDate6 { get; set; }

      [Column("CLOSINGDATE7", Order = 46)]
      [MaxLength(50)]
      [GraphQLName("closingdate7")]
      public string? ClosingDate7 { get; set; }

      [Column("INTTYPE", Order = 47)]
      [MaxLength(50)]
      [GraphQLName("inttype")]
      public string? IntType { get; set; }

      [Column("EXPDATE", Order = 48)]
      [MaxLength(50)]
      [GraphQLName("expdate")]
      public string? ExpDate { get; set; }

      [Column("ACCOUNTNUMBERHOLD", Order = 49)]
      [MaxLength(50)]
      [GraphQLName("accountnumberhold")]
      public string? AccountNumberHold { get; set; }

      [Column("PRODUCTCODEOLD", Order = 50)]
      [MaxLength(50)]
      [GraphQLName("productcodeold")]
      public string? ProductCodeOld { get; set; }

      [Column("CIFNUMOLD", Order = 51)]
      [MaxLength(50)]
      [GraphQLName("cifnumold")]
      public string? CifNumOld { get; set; }

      [Column("BRANCHOLD", Order = 52)]
      [MaxLength(50)]
      [GraphQLName("branchold")]
      public string? BranchOld { get; set; }

      [Column("NIK", Order = 53)]
      [MaxLength(50)]
      [GraphQLName("nik")]
      public string? Nik { get; set; }

      [Column("BIRTHDATE", Order = 54)]
      [MaxLength(100)]
      [GraphQLName("birthdate")]
      public string? BirthDate { get; set; }

      [Column("JENIS_KELAMIN", Order = 55)]
      [MaxLength(50)]
      [GraphQLName("jenis_kelamin")]
      public string? JenisKelamin { get; set; }
   }
}
