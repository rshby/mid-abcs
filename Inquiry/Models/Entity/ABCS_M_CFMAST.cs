using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inquiry.Models.Entity
{
   [Table("abcs_m_cfmast")]
   [GraphQLName("abcs_m_cfmast")]
   public class ABCS_M_CFMAST
   {
      [Required]
      [Column("CIFNUM")]
      [MaxLength(50)]
      [GraphQLName("cif_num")]
      public string? CifNum { get; set; }

      [Column("BRANCH_NO")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("branch_no")]
      public string? BranchNo { get; set; }

      [Column("NAMA_CETAKAN")]
      [MaxLength(500)]
      [DefaultValue(null)]
      [GraphQLName("nama_cetakan")]
      public string? NamaCetakan { get; set; }

      [Column("NEGARA")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("negara")]
      public string? Negara { get; set; }

      [Column("FEDERAL_WH_CODE")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("federal_wh_code")]
      public string? FederalWhCode { get; set; }

      [Column("NO_ID")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("no_id")]
      public string? NoId { get; set; }

      [Column("NPWP")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("npwp")]
      public string? Npwp { get; set; }

      [Column("NAMA_SESUAI_ID")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_sesuai_id")]
      public string? NamaSesuaiId { get; set; }

      [Column("NAMA_LENGKAP")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_lengkap")]
      public string? NamaLengkap { get; set; }

      [Column("JENIS_KELAMIN")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_kelamin")]
      public string? JenisKelamin { get; set; }

      [Column("KEWARGANEGARAAN")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kewarganegaraan")]
      public string? Kewarganegaraan { get; set; }

      [Column("TEMPAT_LAHIR")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tempat_lahir")]
      public string? TempatLahir { get; set; }

      [Column("TANGGAL_LAHIR")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_lahir")]
      public string? TanggalLahir { get; set; }

      [Column("JENIS_KARTU_IDENTITAS")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_kartu_identitas")]
      public string? JenisKartuIdentitas { get; set; }

      [Column("AGAMA")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("agama")]
      public string? Agama { get; set; }

      [Column("STATUS_PERKAWINAN")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("status_perkawinan")]
      public string? StatusPerkawinan { get; set; }

      [Column("ALAMAT_ID_1")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_id_1")]
      public string? AlamatId1 { get; set; }

      [Column("KELURAHAN_ID")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kelurahan_id")]
      public string? KelurahanId { get; set; }

      [Column("KECAMATAN_ID")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kecamatan_id")]
      public string? KecamatanId { get; set; }

      [Column("KOTA_ID")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kota_id")]
      public string? KotaId { get; set; }

      [Column("PROPINSI_ID")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("propinsi_id")]
      public string? PropinsiId { get; set; }

      [Column("NO_HP")]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("no_hp")]
      public string? NoHp { get; set; }
   }
}
