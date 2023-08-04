using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inq_cif.Models
{
   [Table("ABCS_M_CFMAST")]
   [GraphQLName("abcs_m_cfmast")]
   public class ABCS_M_CFMAST
   {
      [Required]
      [Column("CIFNUM", Order = 1)]
      [MaxLength(50)]
      [GraphQLName("cif_num")]
      public string? CifNum { get; set; }

      [Column("BRANCH_NO", Order = 2)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("branch_no")]
      public string? BranchNo { get; set; }

      [Column("TITLE_BEFORE_NAME", Order = 3)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("title_before_name")]
      public string? TitleBeforeName { get; set; }

      [Column("TITLE_AFTER_NAME", Order = 4)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("title_after_name")]
      public string? TitleAfterName { get; set; }

      [Column("NAMA_CETAKAN", Order = 5)]
      [MaxLength(500)]
      [DefaultValue(null)]
      [GraphQLName("nama_cetakan")]
      public string? NamaCetakan { get; set; }

      [Column("NEGARA", Order = 6)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("negara")]
      public string? Negara { get; set; }

      [Column("FEDERAL_WH_CODE", Order = 7)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("federal_wh_code")]
      public string? FederalWhCode { get; set; }

      [Column("NO_ID", Order = 8)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("no_id")]
      public string? NoId { get; set; }

      [Column("NPWP", Order = 9)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("npwp")]
      public string? NPWP { get; set; }

      [Column("EMAIL", Order = 10)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("email")]
      public string? Email { get; set; }

      [Column("TRANSAKSI_NORMAL_PERHARI", Order = 11)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("transaksi_normal_perhari")]
      public string? TransaksiNormalPerhari { get; set; }

      [Column("SUMBER_UTAMA", Order = 12)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("sumber_utama")]
      public string? SumberUtama { get; set; }

      [Column("ERROR_MESSAGE", Order = 13)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("error_message")]
      public string? ErrorMessage { get; set; }

      [Column("PENGHASILAN_PERBULAN", Order = 14)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("penghasilan_perbulan")]
      public string? PenghasilanPerbulan { get; set; }

      [Column("NAMA_BANK_1", Order = 15)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_bank_1")]
      public string? NamaBank1 { get; set; }

      [Column("JENIS_BANK_1", Order = 16)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_bank_1")]
      public string? JenisBank1 { get; set; }

      [Column("NAMA_BANK_2", Order = 17)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_bank_2")]
      public string? NamaBank2 { get; set; }

      [Column("JENIS_BANK_2", Order = 18)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_bank_2")]
      public string? JenisBank2 { get; set; }

      [Column("LOKASI_DATI_2", Order = 19)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("lokasi_dati_2")]
      public string? LokasiDati2 { get; set; }

      [Column("NAMA_SESUAI_ID", Order = 20)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_sesuai_id")]
      public string? NamaSesuaiId { get; set; }

      [Column("NAMA_LENGKAP", Order = 21)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_lengkap")]
      public string? NamaLengkap { get; set; }

      [Column("JENIS_KELAMIN", Order = 22)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_kelamin")]
      public string? JenisKelamin { get; set; }

      [Column("KEWARGANEGARAAN", Order = 23)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kewarganegaraan")]
      public string? Kewarganegaraan { get; set; }

      [Column("TEMPAT_LAHIR", Order = 24)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tempat_lahir")]
      public string? TempatLahir { get; set; }

      [Column("TANGGAL_LAHIR", Order = 25)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_lahir")]
      public string? TanggalLahir { get; set; }

      [Column("NAMA_GADIS_IBU_KANDUNG", Order = 26)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_gadis_ibu_kandung")]
      public string? NamaGadisIbuKandung { get; set; }

      [Column("JENIS_KARTU_IDENTITAS", Order = 27)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_kartu_identitas")]
      public string? JenisKartuIdentitas { get; set; }

      [Column("TANGGAL_ID_TERBIT", Order = 28)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_id_terbit")]
      public string? TanggalIdTerbit { get; set; }

      [Column("TANGGAL_ID_EXPIRED", Order = 29)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_id_expired")]
      public string? TanggalIdExpired { get; set; }

      [Column("PENDIDIKAN_TERAKHIR", Order = 30)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("pendidikan_terakhir")]
      public string? PendidikanTerakhir { get; set; }

      [Column("AGAMA", Order = 31)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("agama")]
      public string? Agama { get; set; }

      [Column("STATUS_PERKAWINAN", Order = 32)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("status_perkawinan")]
      public string? StatusPerkawinan { get; set; }

      [Column("ALAMAT_ID_1", Order = 33)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_id_1")]
      public string? AlamatId1 { get; set; }

      [Column("ALAMAT_ID_2", Order = 34)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_id_2")]
      public string? AlamatId2 { get; set; }

      [Column("RT_ID", Order = 35)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("rt_id")]
      public string? RtId { get; set; }

      [Column("RW_ID", Order = 36)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("rw_id")]
      public string? RwId { get; set; }

      [Column("KODE_POS_ID", Order = 37)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kode_pos_id")]
      public string? KodePosId { get; set; }

      [Column("KELURAHAN_ID", Order = 38)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kelurahan_id")]
      public string? KelurahanId { get; set; }

      [Column("KECAMATAN_ID", Order = 39)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kecamatan_id")]
      public string? KecamatanId { get; set; }

      [Column("KOTA_ID", Order = 40)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kota_id")]
      public string? KotaId { get; set; }

      [Column("PROPINSI_ID", Order = 41)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("propinsi_id")]
      public string? PropinsiId { get; set; }

      [Column("ALAMAT_DOMISILI_1", Order = 42)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_domisili_1")]
      public string? AlamatDomisili1 { get; set; }

      [Column("ALAMAT_DOMISILI_2", Order = 43)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_domisili_2")]
      public string? AlamatDomisili2 { get; set; }

      [Column("RT_DOMISILI", Order = 44)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("rt_domisili")]
      public string? RtDomisili { get; set; }

      [Column("RW_DOMISILI", Order = 45)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("rw_domisili")]
      public string? RwDomisili { get; set; }

      [Column("KODE_POS_DOMISILI", Order = 46)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kode_pos_domisili")]
      public string? KodePosDomisili { get; set; }

      [Column("KELURAHAN_DOMISILI", Order = 47)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kelurahan_domisili")]
      public string? KelurahanDomisili { get; set; }

      [Column("KECAMATAN_DOMISILI", Order = 48)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kecamatan_domisili")]
      public string? KecamatanDomisili { get; set; }

      [Column("KOTA_DOMISILI", Order = 49)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kota_domisili")]
      public string? KotaDomisili { get; set; }

      [Column("PROPINSI_DOMISILI", Order = 50)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("propinsi_domisili")]
      public string? PropinsiDomisili { get; set; }

      [Column("NO_TELP", Order = 51)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("no_telp")]
      public string? NoTelp { get; set; }

      [Column("NO_HP", Order = 52)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("no_hp")]
      public string? NoHp { get; set; }

      [Column("JENIS_NASABAH_TERKAIT", Order = 53)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_nasabah_terkait")]
      public string? JenisNasabahTerkait { get; set; }

      [Column("JENIS_NASABAH_PRIORITAS", Order = 54)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_nasabah_prioritas")]
      public string? JenisNasabahPrioritas { get; set; }

      [Column("JENIS_PEKERJAAN", Order = 55)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_pekerjaan")]
      public string? JenisPekerjaan { get; set; }

      [Column("NAMA_TEMPAT_KERJA", Order = 56)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("nama_tempat_kerja")]
      public string? NamaTempatKerja { get; set; }

      [Column("BIDANG_PEKERJAAN", Order = 57)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("bidang_pekerjaan")]
      public string? BidangPekerjaan { get; set; }

      [Column("JABATAN", Order = 58)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jabatan")]
      public string? Jabatan { get; set; }

      [Column("GOLONGAN_DEBITUR", Order = 59)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("golongan_debitur")]
      public string? GolonganDebitur { get; set; }

      [Column("LAMA_BEKERJA", Order = 60)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("lama_bekerja")]
      public string? LamaBekerja { get; set; }

      [Column("ALAMAT_TEMPAT_KERJA_1", Order = 61)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_tempat_kerja_1")]
      public string? AlamatTempatKerja1 { get; set; }

      [Column("ALAMAT_TEMPAT_KERJA_2", Order = 62)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_tempat_kerja_2")]
      public string? AlamatTempatKerja2 { get; set; }

      [Column("RT_TEMPAT_KERJA", Order = 63)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("rt_tempat_kerja")]
      public string? RtTempatKerja { get; set; }

      [Column("RW_TEMPAT_KERJA", Order = 64)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("rw_tempat_kerja")]
      public string? RwTempatKerja { get; set; }

      [Column("KODE_POS_TEMPAT_KERJA", Order = 65)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kode_pos_tempat_kerja")]
      public string? KodePosTempatKerja { get; set; }

      [Column("KELURAHAN_TEMPAT_KERJA", Order = 66)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kelurahan_tempat_kerja")]
      public string? KelurahanTempatKerja { get; set; }

      [Column("KECAMATAN_TEMPAT_KERJA", Order = 67)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kecamatan_tempat_kerja")]
      public string? KecamatanTempatKerja { get; set; }

      [Column("KOTA_TEMPAT_KERJA", Order = 68)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("kota_tempat_kerja")]
      public string? KotaTempatKerja { get; set; }

      [Column("PROPINSI_TEMPAT_KERJA", Order = 69)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("propinsi_tempat_kerja")]
      public string? PropinsiTempatKerja { get; set; }

      [Column("TELP_KANTOR", Order = 70)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("telp_kantor")]
      public string? TelpKantor { get; set; }

      [Column("FACS_KANTOR", Order = 71)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("facs_kantor")]
      public string? FacsKantor { get; set; }

      [Column("ALAMAT_SURAT_MENYURAT", Order = 72)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("alamat_surat_menyurat")]
      public string? AlamatSuratMenyurat { get; set; }

      [Column("TUJUAN_PEMBUKAAN_REKENING", Order = 73)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tujuan_pembukaan_rekening")]
      public string? TujuanPembukaanRekening { get; set; }

      [Column("PENERBIT_1", Order = 74)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("penerbit_1")]
      public string? Penerbit1 { get; set; }

      [Column("TIPE_KARTU_1", Order = 75)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tipe_kartu_1")]
      public string? TipeKartu1 { get; set; }

      [Column("PENERBIT_2", Order = 76)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("penerbit_2")]
      public string? Penerbit2 { get; set; }

      [Column("TIPE_KARTU_2", Order = 77)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tipe_kartu_2")]
      public string? TipeKartu2 { get; set; }

      [Column("KETERANGAN_PENDIDIKAN", Order = 78)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("keterangan_pendidikan")]
      public string? KeteranganPendidikan { get; set; }

      [Column("KETERANGAN_AGAMA", Order = 79)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("keterangan_agama")]
      public string? KeteranganAgama { get; set; }

      [Column("PBO_NAME", Order = 80)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("pbo_name")]
      public string? PboName { get; set; }

      [Column("PBO_TELP", Order = 81)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("pbo_telp")]
      public string? PboTelp { get; set; }

      [Column("KETERANGAN_PEKERJAAN", Order = 82)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("keterangan_pekerjaan")]
      public string? KeteranganPekerjaan { get; set; }

      [Column("KET_BID_PEKERJAAN", Order = 83)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ket_bid_pekerjaan")]
      public string? KetBidPekerjaan { get; set; }

      [Column("KETERANGAN_JABATAN", Order = 84)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("keterangan_jabatan")]
      public string? KeteranganJabatan { get; set; }

      [Column("KET_TUJ_BUKA_REK", Order = 85)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ket_tuj_buka_rek")]
      public string? KetTujBukaRek { get; set; }

      [Column("KET_SUMBER_UTAMA", Order = 86)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ket_sumber_utama")]
      public string? KetSumberUtama { get; set; }

      [Column("KET_JENIS_PROD_BANK_1", Order = 87)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ket_jenis_prod_bank_1")]
      public string? KetJenisProdBank1 { get; set; }

      [Column("KET_JENIS_PROD_BANK_2", Order = 88)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("ket_jenis_prod_bank_2")]
      public string? KetJenisProdBank2 { get; set; }

      [Column("JENIS_BADANUSAHA", Order = 89)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("jenis_badan_usaha")]
      public string? JenisBadanUsaha { get; set; }

      [Column("NAMA_BADANUSAHA", Order = 90)]
      [MaxLength(500)]
      [DefaultValue(null)]
      [GraphQLName("nama_badan_usaha")]
      public string? NamaBadanUsaha { get; set; }

      [Column("BIDANG_USAHA", Order = 91)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("bidang_usaha")]
      public string? BidangUsaha { get; set; }

      [Column("BENTUK_BADANUSAHA", Order = 92)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("bentuk_badan_usaha")]
      public string? BentukBadanUsaha { get; set; }

      [Column("TEMPAT_PENDIRIAN", Order = 93)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tempat_pendirian")]
      public string? TempatPendirian { get; set; }

      [Column("TIPE_ID", Order = 94)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tipe_id")]
      public string? TipeId { get; set; }

      [Column("TANGGAL_TERBIT", Order = 95)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_terbit")]
      public string? TanggalTerbit { get; set; }

      [Column("TANGGAL_KADALUARSA", Order = 96)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_kadaluarsa")]
      public string? TanggalKadaluarsa { get; set; }

      [Column("NO_AKTA_PENDIRIAN", Order = 97)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("no_akta_pendirian")]
      public string? NoAktaPendirian { get; set; }

      [Column("TANGGAL_AKTA_PENDIRIAN", Order = 98)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_akta_pendirian")]
      public string? TanggalAktaPendirian { get; set; }

      [Column("NO_AKTA_PERUBAHAN", Order = 99)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("no_akta_perubahan")]
      public string? NoAktaPerubahan { get; set; }

      [Column("TANGGAL_AKTA_PERUBAHAN", Order = 100)]
      [MaxLength(50)]
      [DefaultValue(null)]
      [GraphQLName("tanggal_akta_perubahan")]
      public string? TanggalAktaPerubahan { get; set; }
   }
}
