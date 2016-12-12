namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OASIS")]
    public partial class OASIS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OASIS()
        {
            BILLINVs = new HashSet<BILLINV>();
            OASISCHANGEs = new HashSet<OASISCHANGE>();
            OASISCOMMS = new HashSet<OASISCOMM>();
        }

        [Key]
        [StringLength(14)]
        public string OASIS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(12)]
        public string OASISVERSION { get; set; }

        [Required]
        [StringLength(5)]
        public string OASISVERSION2 { get; set; }

        [StringLength(16)]
        public string HHA_AGENCY_ID { get; set; }

        [StringLength(16)]
        public string M0010_MEDICARE_ID { get; set; }

        [StringLength(15)]
        public string M0012_MEDICAID_ID { get; set; }

        [StringLength(3)]
        public string M0014_BRANCH_STATE { get; set; }

        [StringLength(10)]
        public string M0016_BRANCH_ID { get; set; }

        [StringLength(20)]
        public string M0020_PAT_ID { get; set; }

        public DateTime? M0030_START_CARE_DT { get; set; }

        public DateTime? M0032_ROC_DT { get; set; }

        [StringLength(12)]
        public string M0040_PAT_FNAME { get; set; }

        [StringLength(1)]
        public string M0040_PAT_MI { get; set; }

        [StringLength(18)]
        public string M0040_PAT_LNAME { get; set; }

        [StringLength(3)]
        public string M0040_PAT_SUFFIX { get; set; }

        [StringLength(3)]
        public string M0050_PAT_ST { get; set; }

        [StringLength(11)]
        public string M0060_PAT_ZIP { get; set; }

        [StringLength(12)]
        public string M0063_MEDICARE_NUM { get; set; }

        [StringLength(9)]
        public string M0064_SSN { get; set; }

        [StringLength(14)]
        public string M0065_MEDICAID_NUM { get; set; }

        public DateTime? M0066_PAT_BIRTH_DT { get; set; }

        [StringLength(1)]
        public string M0069_PAT_GENDER { get; set; }

        [StringLength(10)]
        public string M0072_PHYSICIAN_ID { get; set; }

        [StringLength(14)]
        public string M0072_CONTACT_ID { get; set; }

        [StringLength(2)]
        public string M0080_ASSESSOR_DISCIPLINE { get; set; }

        public DateTime? M0090_INFO_COMPLETED_DT { get; set; }

        [StringLength(2)]
        public string M0100_ASSMT_REASON { get; set; }

        [StringLength(7)]
        public string M0140_ETHNIC { get; set; }

        [StringLength(13)]
        public string M0150_CPAY { get; set; }

        [StringLength(30)]
        public string M0150_CPAY_OTHERTEXT { get; set; }

        [StringLength(12)]
        public string M0175_DC { get; set; }

        [StringLength(30)]
        public string M0175_DC_OTHERTEXT { get; set; }

        public DateTime? M0180_INP_DISCHARGE_DT { get; set; }

        [StringLength(8)]
        public string M0190_14_DAY_INP1_ICD { get; set; }

        [StringLength(8)]
        public string M0190_14_DAY_INP2_ICD { get; set; }

        [StringLength(1)]
        public string M0200_REG_CHG_14_DAYS { get; set; }

        [StringLength(8)]
        public string M0210_CHGREG_ICD1 { get; set; }

        [StringLength(8)]
        public string M0210_CHGREG_ICD2 { get; set; }

        [StringLength(8)]
        public string M0210_CHGREG_ICD3 { get; set; }

        [StringLength(8)]
        public string M0210_CHGREG_ICD4 { get; set; }

        [StringLength(9)]
        public string M0220_PRIOR { get; set; }

        [StringLength(8)]
        public string M0230_PRIMARY_DIAG_ICD { get; set; }

        [StringLength(2)]
        public string M0230_PRIMARY_DIAG_SEVERITY { get; set; }

        [StringLength(8)]
        public string M0240_OTH_DIAG1_ICD { get; set; }

        [StringLength(2)]
        public string M0240_OTH_DIAG1_SEVERITY { get; set; }

        [StringLength(8)]
        public string M0240_OTH_DIAG2_ICD { get; set; }

        [StringLength(2)]
        public string M0240_OTH_DIAG2_SEVERITY { get; set; }

        [StringLength(8)]
        public string M0240_OTH_DIAG3_ICD { get; set; }

        [StringLength(2)]
        public string M0240_OTH_DIAG3_SEVERITY { get; set; }

        [StringLength(8)]
        public string M0240_OTH_DIAG4_ICD { get; set; }

        [StringLength(2)]
        public string M0240_OTH_DIAG4_SEVERITY { get; set; }

        [StringLength(8)]
        public string M0240_OTH_DIAG5_ICD { get; set; }

        [StringLength(2)]
        public string M0240_OTH_DIAG5_SEVERITY { get; set; }

        [StringLength(4)]
        public string M0250_THH { get; set; }

        [StringLength(2)]
        public string M0260_OVERALL_PROGNOSIS { get; set; }

        [StringLength(2)]
        public string M0270_REHAB_PROGNOSIS { get; set; }

        [StringLength(2)]
        public string M0280_LIFE_EXPECTANCY { get; set; }

        [StringLength(6)]
        public string M0290_RSK { get; set; }

        [StringLength(2)]
        public string M0300_CURR_RESIDENCE { get; set; }

        [StringLength(30)]
        public string M0300_CURR_RES_OTHERTEXT { get; set; }

        [StringLength(6)]
        public string M0340_LIV { get; set; }

        [StringLength(5)]
        public string M0350_AP { get; set; }

        [StringLength(2)]
        public string M0360_PRIMARY_CAREGIVER { get; set; }

        [StringLength(2)]
        public string M0370_FREQ_PRM_ASSTANCE { get; set; }

        [StringLength(8)]
        public string M0380_CA { get; set; }

        [StringLength(2)]
        public string M0390_VISION { get; set; }

        [StringLength(2)]
        public string M0400_HEARING { get; set; }

        [StringLength(2)]
        public string M0410_SPEECH { get; set; }

        [StringLength(2)]
        public string M0420_FREQ_PAIN { get; set; }

        [StringLength(1)]
        public string M0430_INTRACT_PAIN { get; set; }

        [StringLength(1)]
        public string M0440_LESION_OPEN_WND { get; set; }

        [StringLength(1)]
        public string M0445_PRESS_ULCER { get; set; }

        [StringLength(2)]
        public string M0450_NBR_PRSULC_STG1 { get; set; }

        [StringLength(2)]
        public string M0450_NBR_PRSULC_STG2 { get; set; }

        [StringLength(2)]
        public string M0450_NBR_PRSULC_STG3 { get; set; }

        [StringLength(2)]
        public string M0450_NBR_PRSULC_STG4 { get; set; }

        [StringLength(1)]
        public string M0450_UNOBS_PRSULC { get; set; }

        [StringLength(2)]
        public string M0460_STG_PRBLM_ULCER { get; set; }

        [StringLength(2)]
        public string M0464_STAT_PRBLM_PRSULC { get; set; }

        [StringLength(1)]
        public string M0468_STASIS_ULCER { get; set; }

        [StringLength(2)]
        public string M0470_NBR_STASULC { get; set; }

        [StringLength(1)]
        public string M0474_UNOBS_STASULC { get; set; }

        [StringLength(2)]
        public string M0476_STAT_PRB_STASULC { get; set; }

        [StringLength(1)]
        public string M0482_SURG_WOUND { get; set; }

        [StringLength(2)]
        public string M0484_NBR_SURGWND { get; set; }

        [StringLength(1)]
        public string M0486_UNOBS_SURGWND { get; set; }

        [StringLength(2)]
        public string M0488_STAT_PRB_SURGWND { get; set; }

        [StringLength(2)]
        public string M0490_WHEN_DYSPNEIC { get; set; }

        [StringLength(4)]
        public string M0500_RESPTX { get; set; }

        [StringLength(2)]
        public string M0510_UTI { get; set; }

        [StringLength(2)]
        public string M0520_UR_INCONT { get; set; }

        [StringLength(2)]
        public string M0530_UR_INCONT_OCCURS { get; set; }

        [StringLength(2)]
        public string M0540_BWL_INCONT { get; set; }

        [StringLength(2)]
        public string M0550_OSTOMY { get; set; }

        [StringLength(2)]
        public string M0560_COG_FUNCTION { get; set; }

        [StringLength(2)]
        public string M0570_WHEN_CONFUSED { get; set; }

        [StringLength(2)]
        public string M0580_WHEN_ANXIOUS { get; set; }

        [StringLength(6)]
        public string M0590_DP { get; set; }

        [StringLength(7)]
        public string M0610_BD { get; set; }

        [StringLength(2)]
        public string M0620_BEH_PROB_FREQ { get; set; }

        [StringLength(1)]
        public string M0630_REC_PSYCH_NURS { get; set; }

        [StringLength(2)]
        public string M0640_PR_GROOMING { get; set; }

        [StringLength(2)]
        public string M0640_CUR_GROOMING { get; set; }

        [StringLength(2)]
        public string M0650_PR_DRESS_UPPER { get; set; }

        [StringLength(2)]
        public string M0650_CUR_DRESS_UPPER { get; set; }

        [StringLength(2)]
        public string M0660_PR_DRESS_LOWER { get; set; }

        [StringLength(2)]
        public string M0660_CUR_DRESS_LOWER { get; set; }

        [StringLength(2)]
        public string M0670_PR_BATHING { get; set; }

        [StringLength(2)]
        public string M0670_CUR_BATHING { get; set; }

        [StringLength(2)]
        public string M0680_PR_TOILETING { get; set; }

        [StringLength(2)]
        public string M0680_CUR_TOILETING { get; set; }

        [StringLength(2)]
        public string M0690_PR_TRANSFERRING { get; set; }

        [StringLength(2)]
        public string M0690_CUR_TRANSFERRING { get; set; }

        [StringLength(2)]
        public string M0700_PR_AMBULATION { get; set; }

        [StringLength(2)]
        public string M0700_CUR_AMBULATION { get; set; }

        [StringLength(2)]
        public string M0710_PR_FEEDING { get; set; }

        [StringLength(2)]
        public string M0710_CUR_FEEDING { get; set; }

        [StringLength(2)]
        public string M0720_PR_PREP_LT_MEALS { get; set; }

        [StringLength(2)]
        public string M0720_CUR_PREP_LT_MEALS { get; set; }

        [StringLength(2)]
        public string M0730_PR_TRANSPORTATION { get; set; }

        [StringLength(2)]
        public string M0730_CUR_TRANSPORTATION { get; set; }

        [StringLength(2)]
        public string M0740_PR_LAUNDRY { get; set; }

        [StringLength(2)]
        public string M0740_CUR_LAUNDRY { get; set; }

        [StringLength(2)]
        public string M0750_PR_HOUSEKEEPING { get; set; }

        [StringLength(2)]
        public string M0750_CUR_HOUSEKEEPING { get; set; }

        [StringLength(2)]
        public string M0760_PR_SHOPPING { get; set; }

        [StringLength(2)]
        public string M0760_CUR_SHOPPING { get; set; }

        [StringLength(2)]
        public string M0770_PR_PHONE_USE { get; set; }

        [StringLength(2)]
        public string M0770_CUR_PHONE_USE { get; set; }

        [StringLength(2)]
        public string M0780_PR_ORAL_MEDS { get; set; }

        [StringLength(2)]
        public string M0780_CUR_ORAL_MEDS { get; set; }

        [StringLength(2)]
        public string M0790_PR_INHAL_MEDS { get; set; }

        [StringLength(2)]
        public string M0790_CUR_INHAL_MEDS { get; set; }

        [StringLength(2)]
        public string M0800_PR_INJECT_MEDS { get; set; }

        [StringLength(2)]
        public string M0800_CUR_INJECT_MEDS { get; set; }

        [StringLength(2)]
        public string M0810_PAT_MGMT_EQUIP { get; set; }

        [StringLength(2)]
        public string M0820_CG_MGMT_EQUIP { get; set; }

        [StringLength(2)]
        public string M0825_THERAPY_NEED { get; set; }

        [StringLength(5)]
        public string M0830_EC { get; set; }

        [StringLength(27)]
        public string M0840_ECR { get; set; }

        [StringLength(2)]
        public string M0855_INPAT_FACILITY { get; set; }

        [StringLength(2)]
        public string M0870_DSCHG_DISP { get; set; }

        [StringLength(3)]
        public string M0880_AFDC { get; set; }

        [StringLength(2)]
        public string M0890_HOSP_RSN { get; set; }

        [StringLength(32)]
        public string M0895_HOSP { get; set; }

        [StringLength(7)]
        public string M0900_NH { get; set; }

        public DateTime? M0903_LAST_HOME_VISIT { get; set; }

        public DateTime? M0906_DC_TRAN_DTH_DT { get; set; }

        [StringLength(1)]
        public string POT_FL_AMPUTATION { get; set; }

        [StringLength(1)]
        public string POT_FL_BOWEL { get; set; }

        [StringLength(1)]
        public string POT_FL_CONTRACTURE { get; set; }

        [StringLength(1)]
        public string POT_FL_HEARING { get; set; }

        [StringLength(1)]
        public string POT_FL_PARALYSIS { get; set; }

        [StringLength(1)]
        public string POT_FL_ENDURANCE { get; set; }

        [StringLength(1)]
        public string POT_FL_AMBULATION { get; set; }

        [StringLength(1)]
        public string POT_FL_SPEECH { get; set; }

        [StringLength(1)]
        public string POT_FL_BLIND { get; set; }

        [StringLength(1)]
        public string POT_FL_DYSPNEA { get; set; }

        [StringLength(1)]
        public string POT_FL_OTHER { get; set; }

        [StringLength(255)]
        public string POT_FL_OTHERTEXT { get; set; }

        [StringLength(1)]
        public string POT_AP_COMPBEDREST { get; set; }

        [StringLength(1)]
        public string POT_AP_BEDREST { get; set; }

        [StringLength(1)]
        public string POT_AP_UPASTOLERATED { get; set; }

        [StringLength(1)]
        public string POT_AP_TRANSFER { get; set; }

        [StringLength(1)]
        public string POT_AP_EXERCISES { get; set; }

        [StringLength(1)]
        public string POT_AP_PARTWEIGHT { get; set; }

        [StringLength(1)]
        public string POT_AP_INDEPENDENT { get; set; }

        [StringLength(1)]
        public string POT_AP_CRUTCHES { get; set; }

        [StringLength(1)]
        public string POT_AP_CANE { get; set; }

        [StringLength(1)]
        public string POT_AP_WHEELCHAIR { get; set; }

        [StringLength(1)]
        public string POT_AP_WALKER { get; set; }

        [StringLength(1)]
        public string POT_AP_NORESTRICT { get; set; }

        [StringLength(1)]
        public string POT_AP_OTHER { get; set; }

        [StringLength(255)]
        public string POT_AP_OTHERTEXT { get; set; }

        [StringLength(1)]
        public string POT_MS_ORIENTED { get; set; }

        [StringLength(1)]
        public string POT_MS_COMATOSE { get; set; }

        [StringLength(1)]
        public string POT_MS_FORGETFUL { get; set; }

        [StringLength(1)]
        public string POT_MS_DEPRESSED { get; set; }

        [StringLength(1)]
        public string POT_MS_DISORIENTED { get; set; }

        [StringLength(1)]
        public string POT_MS_LETHARGIC { get; set; }

        [StringLength(1)]
        public string POT_MS_AGITATED { get; set; }

        [StringLength(1)]
        public string POT_MS_OTHER { get; set; }

        [StringLength(255)]
        public string POT_MS_OTHERTEXT { get; set; }

        [StringLength(1)]
        public string POT_PROGNOSIS { get; set; }

        public int? CORRECTION_NUM { get; set; }

        public DateTime? LOCKDATE { get; set; }

        [StringLength(1)]
        public string SENT { get; set; }

        public DateTime? SENT_DATE { get; set; }

        [StringLength(255)]
        public string SENTUSER { get; set; }

        [StringLength(1)]
        public string HOLD { get; set; }

        public DateTime? HOLD_DATE { get; set; }

        [StringLength(255)]
        public string HOLD_USER { get; set; }

        [StringLength(6)]
        public string HHRG { get; set; }

        [StringLength(5)]
        public string HIPPS { get; set; }

        public decimal? LABORINDEX { get; set; }

        public decimal? NLABORINDEX { get; set; }

        [StringLength(5)]
        public string MSACODE { get; set; }

        public decimal? MSAINDEX { get; set; }

        public decimal? PPSAMT { get; set; }

        [StringLength(1)]
        public string COMPLETED { get; set; }

        [StringLength(14)]
        public string DRORDER_ID { get; set; }

        [StringLength(1)]
        public string RECSTATUS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [StringLength(1)]
        public string EXCLCLAIM { get; set; }

        [StringLength(255)]
        public string EXCLCLAIMUSER { get; set; }

        public DateTime? EXCLCLAIMDATE { get; set; }

        [StringLength(1)]
        public string NOPLANOFCARE { get; set; }

        public decimal? STDPPSAMT { get; set; }

        public decimal? HHRGINDEX { get; set; }

        [StringLength(6)]
        public string M0245_PMT_ICD1 { get; set; }

        [StringLength(6)]
        public string M0245_PMT_ICD2 { get; set; }

        public DateTime? POT_START { get; set; }

        public DateTime? POT_STOP { get; set; }

        [StringLength(1)]
        public string RURALMSA { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [StringLength(2)]
        public string M0110_EPISODE_TIMING { get; set; }

        [StringLength(3)]
        public string M0826_THER_NEED_NUM { get; set; }

        [StringLength(1)]
        public string M0826_THER_NEED_NA { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_A3 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_B3 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_C3 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_D3 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_E3 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_F3 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_A4 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_B4 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_C4 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_D4 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_E4 { get; set; }

        [StringLength(8)]
        public string M0246_PMT_DIAG_ICD_F4 { get; set; }

        public DateTime? M0102_PHYSN_ORDRD_SOCROC_DT { get; set; }

        [StringLength(1)]
        public string M0102_PHYSN_ORDRD_SOCROC_DT_NA { get; set; }

        public DateTime? M0104_PHYSN_RFRL_DT { get; set; }

        [StringLength(8)]
        public string M1010_14_DAY_INP3_ICD { get; set; }

        [StringLength(8)]
        public string M1010_14_DAY_INP4_ICD { get; set; }

        [StringLength(8)]
        public string M1010_14_DAY_INP5_ICD { get; set; }

        [StringLength(8)]
        public string M1010_14_DAY_INP6_ICD { get; set; }

        [StringLength(8)]
        public string M1012_INP_PRCDR1_ICD { get; set; }

        [StringLength(8)]
        public string M1012_INP_PRCDR2_ICD { get; set; }

        [StringLength(8)]
        public string M1012_INP_PRCDR3_ICD { get; set; }

        [StringLength(8)]
        public string M1012_INP_PRCDR4_ICD { get; set; }

        [StringLength(1)]
        public string M1012_INP_NA_ICD { get; set; }

        [StringLength(1)]
        public string M1012_INP_UK_ICD { get; set; }

        [StringLength(8)]
        public string M1016_CHGREG_ICD5 { get; set; }

        [StringLength(8)]
        public string M1016_CHGREG_ICD6 { get; set; }

        [StringLength(1)]
        public string M1016_CHGREG_ICD_NA { get; set; }

        [StringLength(10)]
        public string M1032_HOSP_RISK { get; set; }

        [StringLength(2)]
        public string M1034_PTNT_OVRAL_STUS { get; set; }

        [StringLength(2)]
        public string M1040_INFLNZ_RCVD_AGNCY { get; set; }

        [StringLength(2)]
        public string M1045_INFLNZ_RSN_NOT_RCVD { get; set; }

        [StringLength(1)]
        public string M1050_PPV_RCVD_AGNCY { get; set; }

        [StringLength(2)]
        public string M1055_PPV_RSN_NOT_RCVD_AGNCY { get; set; }

        [StringLength(2)]
        public string M1100_PTNT_LVG_STUTN { get; set; }

        [StringLength(2)]
        public string M1210_HEARG_ABLTY { get; set; }

        [StringLength(2)]
        public string M1220_UNDRSTG_VERBAL_CNTNT { get; set; }

        [StringLength(2)]
        public string M1240_FRML_PAIN_ASMT { get; set; }

        [StringLength(2)]
        public string M1242_PAIN_FREQ_ACTVTY_MVMT { get; set; }

        [StringLength(2)]
        public string M1300_PRSR_ULCR_RISK_ASMT { get; set; }

        [StringLength(1)]
        public string M1302_RISK_OF_PRSR_ULCR { get; set; }

        [StringLength(1)]
        public string M1306_UNHLD_STG2_PRSR_ULCR { get; set; }

        public DateTime? M1307_OLDST_STG2_ONST_DT { get; set; }

        [StringLength(2)]
        public string M1307_OLDST_STG2_AT_DSCHRG { get; set; }

        public int? M1308_NBR_PRSULC_STG2 { get; set; }

        public int? M1308_NBR_STG2_AT_SOC_ROC { get; set; }

        public int? M1308_NBR_PRSULC_STG3 { get; set; }

        public int? M1308_NBR_STG3_AT_SOC_ROC { get; set; }

        public int? M1308_NBR_PRSULC_STG4 { get; set; }

        public int? M1308_NBR_STG4_AT_SOC_ROC { get; set; }

        public int? M1308_NSTG_DRSG { get; set; }

        public int? M1308_NSTG_DRSG_SOC_ROC { get; set; }

        public int? M1308_NSTG_CVRG { get; set; }

        public int? M1308_NSTG_CVRG_SOC_ROC { get; set; }

        public int? M1308_NSTG_DEEP_TISSUE { get; set; }

        public int? M1308_NSTG_DEEP_TISSUE_SOC_ROC { get; set; }

        public decimal? M1310_PRSR_ULCR_LNGTH { get; set; }

        public decimal? M1312_PRSR_ULCR_WDTH { get; set; }

        public decimal? M1314_PRSR_ULCR_DEPTH { get; set; }

        [StringLength(2)]
        public string M1320_STUS_PRBLM_PRSR_ULCR { get; set; }

        [StringLength(2)]
        public string M1330_STAS_ULCR_PRSNT { get; set; }

        [StringLength(2)]
        public string M1332_NUM_STAS_ULCR { get; set; }

        [StringLength(2)]
        public string M1334_STUS_PRBLM_STAS_ULCR { get; set; }

        [StringLength(2)]
        public string M1340_SRGCL_WND_PRSNT { get; set; }

        [StringLength(2)]
        public string M1342_STUS_PRBLM_SRGCL_WND { get; set; }

        [StringLength(1)]
        public string M1350_LESION_OPEN_WND { get; set; }

        [StringLength(2)]
        public string M1500_SYMTM_HRT_FAILR_PTNTS { get; set; }

        [StringLength(6)]
        public string M1510_HRT_FAILR { get; set; }

        [StringLength(2)]
        public string M1615_INCNTNT_TIMING { get; set; }

        [StringLength(2)]
        public string M1730_STDZ_DPRSN_SCRNG { get; set; }

        [StringLength(2)]
        public string M1730_PHQ2_LACK_INTRST { get; set; }

        [StringLength(2)]
        public string M1730_PHQ2_DPRSN { get; set; }

        [StringLength(2)]
        public string M1830_CRNT_BATHG { get; set; }

        [StringLength(2)]
        public string M1840_CUR_TOILTG { get; set; }

        [StringLength(2)]
        public string M1845_CUR_TOILTG_HYGN { get; set; }

        [StringLength(2)]
        public string M1850_CUR_TRNSFRNG { get; set; }

        [StringLength(2)]
        public string M1860_CRNT_AMBLTN { get; set; }

        [StringLength(5)]
        public string HIPPS_VERSION { get; set; }

        [StringLength(1)]
        public string HIPPS_VALIDFLAG { get; set; }

        [StringLength(8)]
        public string M1900_PRIOR_ADLIADL { get; set; }

        [StringLength(2)]
        public string M1910_MLT_FCTR_FALL_RISK_ASMT { get; set; }

        [StringLength(2)]
        public string M2000_DRUG_RGMN_RVW { get; set; }

        [StringLength(1)]
        public string M2002_MDCTN_FLWP { get; set; }

        [StringLength(2)]
        public string M2004_MDCTN_INTRVTN { get; set; }

        [StringLength(2)]
        public string M2010_HIGH_RISK_DRUG_EDCTN { get; set; }

        [StringLength(2)]
        public string M2015_DRUG_EDCTN_INTRVTN { get; set; }

        [StringLength(2)]
        public string M2020_CRNT_MGMT_ORAL_MDCTN { get; set; }

        [StringLength(2)]
        public string M2030_CRNT_MGMT_INJCTN_MDCTN { get; set; }

        [StringLength(4)]
        public string M2040_PRIOR_MGMT { get; set; }

        [StringLength(14)]
        public string M2100_CARE_TYPE_SRC { get; set; }

        [StringLength(2)]
        public string M2110_ADL_IADL_ASTNC_FREQ { get; set; }

        [StringLength(14)]
        public string M2250_PLAN_SMRY { get; set; }

        [StringLength(2)]
        public string M2300_EMER_USE_AFTR_LAST_ASMT { get; set; }

        [StringLength(12)]
        public string M2400_INTRVTN_SMRY { get; set; }

        [StringLength(2)]
        public string M2420_DSCHRG_DISP { get; set; }

        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(8)]
        public string M1309_NBR_NEW_WRS_PRSULC { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINV> BILLINVs { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        public virtual CLTFOLDER CLTFOLDER { get; set; }

        public virtual CONTACT CONTACT { get; set; }

        public virtual DRORDER DRORDER { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual VISIT VISIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASISCHANGE> OASISCHANGEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASISCOMM> OASISCOMMS { get; set; }
    }
}
