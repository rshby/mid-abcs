using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inquiry.Models.DTO
{
   [GraphQLName("cif_response")]
   public class DataCifResponse
   {
      [DefaultValue(null)]
      [GraphQLName("cif_num")]
      public string? CifNum { get; set; }

      [DefaultValue(null)]
      [GraphQLName("branch_no")]
      public string? BranchNo { get; set; }

      [DefaultValue(null)]
      [GraphQLName("nama_cetakan")]
      public string? NamaCetakan { get; set; }

      [DefaultValue(null)]
      [GraphQLName("negara")]
      public string? Negara { get; set; }

      [DefaultValue(null)]
      [GraphQLName("federal_wh_code")]
      public string? FederalWhCode { get; set; }

      [DefaultValue(null)]
      [GraphQLName("no_id")]
      public string? NoId { get; set; }

      [DefaultValue(null)]
      [GraphQLName("npwp")]
      public string? Npwp { get; set; }

      [DefaultValue(null)]
      [GraphQLName("nama_sesuai_id")]
      public string? NamaSesuaiId { get; set; }

      [DefaultValue(null)]
      [GraphQLName("nama_lengkap")]
      public string? NamaLengkap { get; set; }

      [DefaultValue(null)]
      [GraphQLName("jenis_kelamin")]
      public string? JenisKelamin { get; set; }

      [DefaultValue(null)]
      [GraphQLName("kewarganegaraan")]
      public string? Kewarganegaraan { get; set; }

      [DefaultValue(null)]
      [GraphQLName("tempat_lahir")]
      public string? TempatLahir { get; set; }

      [DefaultValue(null)]
      [GraphQLName("tanggal_lahir")]
      public string? TanggalLahir { get; set; }

      [DefaultValue(null)]
      [GraphQLName("jenis_kartu_identitas")]
      public string? JenisKartuIdentitas { get; set; }

      [DefaultValue(null)]
      [GraphQLName("agama")]
      public string? Agama { get; set; }

      [DefaultValue(null)]
      [GraphQLName("status_perkawinan")]
      public string? StatusPerkawinan { get; set; }

      [DefaultValue(null)]
      [GraphQLName("alamat_id_1")]
      public string? AlamatId1 { get; set; }

      [DefaultValue(null)]
      [GraphQLName("kelurahan_id")]
      public string? KelurahanId { get; set; }

      [DefaultValue(null)]
      [GraphQLName("kecamatan_id")]
      public string? KecamatanId { get; set; }

      [DefaultValue(null)]
      [GraphQLName("kota_id")]
      public string? KotaId { get; set; }

      [DefaultValue(null)]
      [GraphQLName("propinsi_id")]
      public string? PropinsiId { get; set; }

      [DefaultValue(null)]
      [GraphQLName("no_hp")]
      public string? NoHp { get; set; }

      [DefaultValue(null)]
      [GraphQLName("rekening")]
      public List<DataRekeningResponse>? Rekening { get; set; }
   }
}
