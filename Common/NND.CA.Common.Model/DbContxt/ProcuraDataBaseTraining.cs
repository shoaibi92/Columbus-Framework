namespace NND.CA.Common.Model.DbContxt
{
    using System.Data.Entity;

    public partial class ProcuraDataBaseTraining : DbContext
    {
        public ProcuraDataBaseTraining()
            : base("name=ProcuraDataBaseTraining")
        {
        }

        public virtual DbSet<ACCESSLIST> ACCESSLISTs { get; set; }
        public virtual DbSet<ACTIVITY> ACTIVITies { get; set; }
        public virtual DbSet<ALLERGy> ALLERGIES { get; set; }
        public virtual DbSet<ARCHIVEDCLT> ARCHIVEDCLTS { get; set; }
        public virtual DbSet<ASSCHOICE> ASSCHOICES { get; set; }
        public virtual DbSet<ASSESSMD> ASSESSMDS { get; set; }
        public virtual DbSet<ASSESSMENT> ASSESSMENTS { get; set; }
        public virtual DbSet<ASSESSOASI> ASSESSOASIS { get; set; }
        public virtual DbSet<ASSESSRAI> ASSESSRAIs { get; set; }
        public virtual DbSet<ASSGROUP> ASSGROUPS { get; set; }
        public virtual DbSet<ASSQADEPEND> ASSQADEPENDS { get; set; }
        public virtual DbSet<ASSQDEPEND> ASSQDEPENDS { get; set; }
        public virtual DbSet<ASSQMDSHCDEPEND> ASSQMDSHCDEPENDS { get; set; }
        public virtual DbSet<ASSQPATHDEPEND> ASSQPATHDEPENDS { get; set; }
        public virtual DbSet<ASSQUEST> ASSQUESTS { get; set; }
        public virtual DbSet<ASSQUESTSX> ASSQUESTSXes { get; set; }
        public virtual DbSet<ASSSECT> ASSSECTS { get; set; }
        public virtual DbSet<ASSSECTSLAYOUT> ASSSECTSLAYOUTS { get; set; }
        public virtual DbSet<AUTOORDPLAN> AUTOORDPLANs { get; set; }
        public virtual DbSet<AUTOORDPLANSERV> AUTOORDPLANSERVS { get; set; }
        public virtual DbSet<AVDAY> AVDAYS { get; set; }
        public virtual DbSet<AVONETIME> AVONETIMES { get; set; }
        public virtual DbSet<AVROTATE> AVROTATEs { get; set; }
        public virtual DbSet<AVROTEMP> AVROTEMPs { get; set; }
        public virtual DbSet<BILLANSI> BILLANSIs { get; set; }
        public virtual DbSet<BILLBATCH> BILLBATCHes { get; set; }
        public virtual DbSet<BILLEDX> BILLEDXes { get; set; }
        public virtual DbSet<BILLING> BILLINGs { get; set; }
        public virtual DbSet<BILLINV> BILLINVs { get; set; }
        public virtual DbSet<BILLINVNOTE> BILLINVNOTES { get; set; }
        public virtual DbSet<BILLPMI> BILLPMIs { get; set; }
        public virtual DbSet<BILLPMT> BILLPMTS { get; set; }
        public virtual DbSet<BILLREC> BILLRECS { get; set; }
        public virtual DbSet<BILLRECVAL> BILLRECVALs { get; set; }
        public virtual DbSet<BILLSUMREC> BILLSUMRECs { get; set; }
        public virtual DbSet<BILLTABLE> BILLTABLES { get; set; }
        public virtual DbSet<BILLUB92> BILLUB92 { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CATRULE> CATRULES { get; set; }
        public virtual DbSet<CL_REFNOS> CL_REFNOS { get; set; }
        public virtual DbSet<CLAIMBATCH> CLAIMBATCHes { get; set; }
        public virtual DbSet<CLIENT> CLIENTS { get; set; }
        public virtual DbSet<CLNTNOTE> CLNTNOTES { get; set; }
        public virtual DbSet<CLNTRESORC> CLNTRESORCs { get; set; }
        public virtual DbSet<CLTACTC> CLTACTCs { get; set; }
        public virtual DbSet<CLTACTV> CLTACTVs { get; set; }
        public virtual DbSet<CLTALLERGy> CLTALLERGIES { get; set; }
        public virtual DbSet<CLTASSAN> CLTASSANS { get; set; }
        public virtual DbSet<CLTASSCHAN> CLTASSCHANS { get; set; }
        public virtual DbSet<CLTASSESS> CLTASSESSes { get; set; }
        public virtual DbSet<CLTASSLOG> CLTASSLOGs { get; set; }
        public virtual DbSet<CLTASSLOGCHG> CLTASSLOGCHGs { get; set; }
        public virtual DbSet<CLTASSLOGDATA> CLTASSLOGDATAs { get; set; }
        public virtual DbSet<CLTASSMED> CLTASSMEDS { get; set; }
        public virtual DbSet<CLTATTRIB> CLTATTRIBs { get; set; }
        public virtual DbSet<CLTCHANx> CLTCHANGES { get; set; }
        public virtual DbSet<CLTDEPT> CLTDEPTs { get; set; }
        public virtual DbSet<CLTDIAG> CLTDIAGs { get; set; }
        public virtual DbSet<CLTDOC> CLTDOCS { get; set; }
        public virtual DbSet<CLTDOCSX> CLTDOCSXes { get; set; }
        public virtual DbSet<CLTFOLDER> CLTFOLDERS { get; set; }
        public virtual DbSet<CLTLANG> CLTLANGs { get; set; }
        public virtual DbSet<CLTLOG> CLTLOGs { get; set; }
        public virtual DbSet<CLTLOGCHG> CLTLOGCHGs { get; set; }
        public virtual DbSet<CLTLOGMEMO> CLTLOGMEMOes { get; set; }
        public virtual DbSet<CLTMEDENTRy> CLTMEDENTRIES { get; set; }
        public virtual DbSet<CLTMED> CLTMEDS { get; set; }
        public virtual DbSet<CLTPATHCOSTEP> CLTPATHCOSTEPS { get; set; }
        public virtual DbSet<CLTPATHFOCU> CLTPATHFOCUS { get; set; }
        public virtual DbSet<CLTPATHITEM> CLTPATHITEMS { get; set; }
        public virtual DbSet<CLTPATHITEMSX> CLTPATHITEMSXes { get; set; }
        public virtual DbSet<CLTPATHVISITNOTE> CLTPATHVISITNOTES { get; set; }
        public virtual DbSet<CLTPATHVISIT> CLTPATHVISITS { get; set; }
        public virtual DbSet<CLTPATHWAY> CLTPATHWAYS { get; set; }
        public virtual DbSet<CLTRULE> CLTRULES { get; set; }
        public virtual DbSet<CLTSERV> CLTSERVS { get; set; }
        public virtual DbSet<CLTSTATE> CLTSTATES { get; set; }
        public virtual DbSet<CLTSUBCAT> CLTSUBCATS { get; set; }
        public virtual DbSet<CLTSUPER> CLTSUPERS { get; set; }
        public virtual DbSet<CLTSUPREQ> CLTSUPREQs { get; set; }
        public virtual DbSet<CLTSYNCH> CLTSYNCHes { get; set; }
        public virtual DbSet<CLTSYNCHERR> CLTSYNCHERRs { get; set; }
        public virtual DbSet<CLTSYNCHREC> CLTSYNCHRECS { get; set; }
        public virtual DbSet<CLTVISITOR> CLTVISITORS { get; set; }
        public virtual DbSet<CLTVITAL> CLTVITALS { get; set; }
        public virtual DbSet<CONNOTE> CONNOTES { get; set; }
        public virtual DbSet<CONSUBCAT> CONSUBCATS { get; set; }
        public virtual DbSet<CONTACT> CONTACTS { get; set; }
        public virtual DbSet<COORD> COORDS { get; set; }
        public virtual DbSet<DASHBRDDETAIL> DASHBRDDETAILS { get; set; }
        public virtual DbSet<DASHBRDGROUP> DASHBRDGROUPS { get; set; }
        public virtual DbSet<DASHBRDKPI> DASHBRDKPIS { get; set; }
        public virtual DbSet<DASHBRDMETRICDISPLAY> DASHBRDMETRICDISPLAYs { get; set; }
        public virtual DbSet<DASHBRDMETRICKPI> DASHBRDMETRICKPIS { get; set; }
        public virtual DbSet<DASHBRDMETRIC> DASHBRDMETRICS { get; set; }
        public virtual DbSet<DASHBRDMETRICSCORE> DASHBRDMETRICSCORES { get; set; }
        public virtual DbSet<DASHBRDMETRICSERy> DASHBRDMETRICSERIES { get; set; }
        public virtual DbSet<DASHBRD> DASHBRDS { get; set; }
        public virtual DbSet<DATEDNOTE> DATEDNOTES { get; set; }
        public virtual DbSet<DBCOMPONENT> DBCOMPONENTS { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<DEPTAGREE> DEPTAGREEs { get; set; }
        public virtual DbSet<DEPTAREA> DEPTAREAS { get; set; }
        public virtual DbSet<DEPTASSESS> DEPTASSESSes { get; set; }
        public virtual DbSet<DEPTAVROT> DEPTAVROTs { get; set; }
        public virtual DbSet<DEPTBILLTABLE> DEPTBILLTABLES { get; set; }
        public virtual DbSet<DEPTNUM> DEPTNUMS { get; set; }
        public virtual DbSet<DEPTPERIOD> DEPTPERIODs { get; set; }
        public virtual DbSet<DEPTPLAN> DEPTPLANS { get; set; }
        public virtual DbSet<DEPTREF> DEPTREFS { get; set; }
        public virtual DbSet<DEPTSCHGROUP> DEPTSCHGROUPS { get; set; }
        public virtual DbSet<DEPTSERV> DEPTSERVs { get; set; }
        public virtual DbSet<DEPTSRVREQ> DEPTSRVREQs { get; set; }
        public virtual DbSet<DEPTSTATU> DEPTSTATUS { get; set; }
        public virtual DbSet<DIAGGROUP> DIAGGROUPS { get; set; }
        public virtual DbSet<DIAGNOSI> DIAGNOSIS { get; set; }
        public virtual DbSet<DIETTYPE> DIETTYPEs { get; set; }
        public virtual DbSet<DISTRICT> DISTRICTS { get; set; }
        public virtual DbSet<DOCTYPEDEPT> DOCTYPEDEPTS { get; set; }
        public virtual DbSet<DOCTYPE> DOCTYPES { get; set; }
        public virtual DbSet<DONOTSEND> DONOTSENDS { get; set; }
        public virtual DbSet<DRORDER> DRORDERS { get; set; }
        public virtual DbSet<DRORDERSLOG> DRORDERSLOGs { get; set; }
        public virtual DbSet<DRORDERSLOGDATA> DRORDERSLOGDATAs { get; set; }
        public virtual DbSet<EBILLFORMAT> EBILLFORMATS { get; set; }
        public virtual DbSet<EDCCALL> EDCCALLS { get; set; }
        public virtual DbSet<EDCEXCEPT> EDCEXCEPTS { get; set; }
        public virtual DbSet<EDCVARIANCE> EDCVARIANCES { get; set; }
        public virtual DbSet<EDCVISITDETAIL> EDCVISITDETAILS { get; set; }
        public virtual DbSet<EDCVISIT> EDCVISITS { get; set; }
        public virtual DbSet<EMPATTRIB> EMPATTRIBs { get; set; }
        public virtual DbSet<EMPCAT> EMPCATS { get; set; }
        public virtual DbSet<EMPCHANx> EMPCHANGES { get; set; }
        public virtual DbSet<EMPCONTACT> EMPCONTACTS { get; set; }
        public virtual DbSet<EMPDATE> EMPDATES { get; set; }
        public virtual DbSet<EMPDIST> EMPDISTs { get; set; }
        public virtual DbSet<EMPDOC> EMPDOCS { get; set; }
        public virtual DbSet<EMPDOCSX> EMPDOCSXes { get; set; }
        public virtual DbSet<EMPFOLDER> EMPFOLDERS { get; set; }
        public virtual DbSet<EMPFRMAN> EMPFRMANS { get; set; }
        public virtual DbSet<EMPFRMCHAN> EMPFRMCHANS { get; set; }
        public virtual DbSet<EMPFRMLOG> EMPFRMLOGs { get; set; }
        public virtual DbSet<EMPFRMLOGCHG> EMPFRMLOGCHGs { get; set; }
        public virtual DbSet<EMPFRMLOGDATA> EMPFRMLOGDATAs { get; set; }
        public virtual DbSet<EMPFRM> EMPFRMS { get; set; }
        public virtual DbSet<EMPLANG> EMPLANGs { get; set; }
        public virtual DbSet<EMPLDEPT> EMPLDEPTs { get; set; }
        public virtual DbSet<EMPLNOTE> EMPLNOTES { get; set; }
        public virtual DbSet<EMPLOG> EMPLOGs { get; set; }
        public virtual DbSet<EMPLOGCHG> EMPLOGCHGs { get; set; }
        public virtual DbSet<EMPLOGMEMO> EMPLOGMEMOes { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual DbSet<EMPREFNO> EMPREFNOS { get; set; }
        public virtual DbSet<EMPROUTE> EMPROUTES { get; set; }
        public virtual DbSet<EMPSERV> EMPSERVS { get; set; }
        public virtual DbSet<EMPSTATE> EMPSTATES { get; set; }
        public virtual DbSet<EMPSUBCAT> EMPSUBCATS { get; set; }
        public virtual DbSet<EMPSUPER> EMPSUPERS { get; set; }
        public virtual DbSet<EMPSUPREQ> EMPSUPREQs { get; set; }
        public virtual DbSet<EQUIPPRE> EQUIPPRES { get; set; }
        public virtual DbSet<ERRORRPT> ERRORRPTS { get; set; }
        public virtual DbSet<EXPMILEAGE> EXPMILEAGEs { get; set; }
        public virtual DbSet<EXPPAYROLL> EXPPAYROLLs { get; set; }
        public virtual DbSet<FRMCONTACT> FRMCONTACTs { get; set; }
        public virtual DbSet<FUNDBATCH> FUNDBATCHes { get; set; }
        public virtual DbSet<FUNDCCTYPE> FUNDCCTYPEs { get; set; }
        public virtual DbSet<FUNDCLTREF> FUNDCLTREFs { get; set; }
        public virtual DbSet<FUNDDEPT> FUNDDEPTs { get; set; }
        public virtual DbSet<FUNDEBTYPE> FUNDEBTYPEs { get; set; }
        public virtual DbSet<FUNDEPTPER> FUNDEPTPERs { get; set; }
        public virtual DbSet<FUNDERREF> FUNDERREFS { get; set; }
        public virtual DbSet<FUNDER> FUNDERS { get; set; }
        public virtual DbSet<FUNDERSERV> FUNDERSERVs { get; set; }
        public virtual DbSet<FUNDORDVAL> FUNDORDVALs { get; set; }
        public virtual DbSet<FUNDRULE> FUNDRULES { get; set; }
        public virtual DbSet<GEODATA> GEODATAs { get; set; }
        public virtual DbSet<GROUP> GROUPS { get; set; }
        public virtual DbSet<GRPACCESS> GRPACCESSes { get; set; }
        public virtual DbSet<GRPASSESS> GRPASSESSes { get; set; }
        public virtual DbSet<HAZARD> HAZARDS { get; set; }
        public virtual DbSet<HHRGWEIGHT> HHRGWEIGHTS { get; set; }
        public virtual DbSet<ICDGEM> ICDGEMs { get; set; }
        public virtual DbSet<INFCONTACT> INFCONTACTs { get; set; }
        public virtual DbSet<INFCONTACTCHAR> INFCONTACTCHARS { get; set; }
        public virtual DbSet<INVALIDPASS> INVALIDPASSes { get; set; }
        public virtual DbSet<INVFORMAT> INVFORMATS { get; set; }
        public virtual DbSet<INVGROUP> INVGROUPS { get; set; }
        public virtual DbSet<INVPERIOD> INVPERIODS { get; set; }
        public virtual DbSet<INVRUN> INVRUNS { get; set; }
        public virtual DbSet<KITCHDIST> KITCHDISTs { get; set; }
        public virtual DbSet<KITCHEN> KITCHENS { get; set; }
        public virtual DbSet<LABORAGREE> LABORAGREEs { get; set; }
        public virtual DbSet<LBREMPCAT> LBREMPCATS { get; set; }
        public virtual DbSet<LBRGRP> LBRGRPS { get; set; }
        public virtual DbSet<LBRPAYTAB> LBRPAYTABS { get; set; }
        public virtual DbSet<LBRRULE> LBRRULES { get; set; }
        public virtual DbSet<LBRSTAT> LBRSTATS { get; set; }
        public virtual DbSet<LOGUSER> LOGUSERs { get; set; }
        public virtual DbSet<LOOKUP> LOOKUPS { get; set; }
        public virtual DbSet<LOOKUPVAL> LOOKUPVALS { get; set; }
        public virtual DbSet<MATCHRULEDEPT> MATCHRULEDEPTS { get; set; }
        public virtual DbSet<MATCHRULE> MATCHRULES { get; set; }
        public virtual DbSet<MD> MDS { get; set; }
        public virtual DbSet<MDSCAP> MDSCAPS { get; set; }
        public virtual DbSet<MDSCHANGE> MDSCHANGEs { get; set; }
        public virtual DbSet<MDSHC_A> MDSHC_A { get; set; }
        public virtual DbSet<MDSHC_AA> MDSHC_AA { get; set; }
        public virtual DbSet<MDSHC_B> MDSHC_B { get; set; }
        public virtual DbSet<MDSHC_BB> MDSHC_BB { get; set; }
        public virtual DbSet<MDSHC_C> MDSHC_C { get; set; }
        public virtual DbSet<MDSHC_CC> MDSHC_CC { get; set; }
        public virtual DbSet<MDSHC_D> MDSHC_D { get; set; }
        public virtual DbSet<MDSHC_E> MDSHC_E { get; set; }
        public virtual DbSet<MDSHC_F> MDSHC_F { get; set; }
        public virtual DbSet<MDSHC_G> MDSHC_G { get; set; }
        public virtual DbSet<MDSHC_H> MDSHC_H { get; set; }
        public virtual DbSet<MDSHC_I> MDSHC_I { get; set; }
        public virtual DbSet<MDSHC_J> MDSHC_J { get; set; }
        public virtual DbSet<MDSHC_K> MDSHC_K { get; set; }
        public virtual DbSet<MDSHC_L> MDSHC_L { get; set; }
        public virtual DbSet<MDSHC_M> MDSHC_M { get; set; }
        public virtual DbSet<MDSHC_N> MDSHC_N { get; set; }
        public virtual DbSet<MDSHC_O> MDSHC_O { get; set; }
        public virtual DbSet<MDSHC_P> MDSHC_P { get; set; }
        public virtual DbSet<MDSHC_Q> MDSHC_Q { get; set; }
        public virtual DbSet<MDSHC_X> MDSHC_X { get; set; }
        public virtual DbSet<MDSHCCAP> MDSHCCAPS { get; set; }
        public virtual DbSet<MDSLOG> MDSLOGs { get; set; }
        public virtual DbSet<MDSNOTE> MDSNOTES { get; set; }
        public virtual DbSet<MEALDI> MEALDIS { get; set; }
        public virtual DbSet<MEALITEM> MEALITEMS { get; set; }
        public virtual DbSet<MEALPACK> MEALPACKS { get; set; }
        public virtual DbSet<MEALPLAN> MEALPLANs { get; set; }
        public virtual DbSet<MEALPLANDAY> MEALPLANDAYs { get; set; }
        public virtual DbSet<MEALSCHED> MEALSCHEDs { get; set; }
        public virtual DbSet<MEALSCHEDMEAL> MEALSCHEDMEALS { get; set; }
        public virtual DbSet<MEALSORT> MEALSORTs { get; set; }
        public virtual DbSet<MEALTAB> MEALTABS { get; set; }
        public virtual DbSet<MEALVISITMEAL> MEALVISITMEALS { get; set; }
        public virtual DbSet<MEALVISIT> MEALVISITS { get; set; }
        public virtual DbSet<MEDICATION> MEDICATIONs { get; set; }
        public virtual DbSet<MESSAGEBU> MESSAGEBUS { get; set; }
        public virtual DbSet<MESSAGEBUSDETAIL> MESSAGEBUSDETAILs { get; set; }
        public virtual DbSet<MESSAGEBUSSUB> MESSAGEBUSSUBS { get; set; }
        public virtual DbSet<MESSCONT> MESSCONTs { get; set; }
        public virtual DbSet<MSACODE> MSACODES { get; set; }
        public virtual DbSet<NND_MonthRevBenchmarks> NND_MonthRevBenchmarks { get; set; }
        public virtual DbSet<NND_NPI_NPS_Uploads> NND_NPI_NPS_Uploads { get; set; }
        public virtual DbSet<NND_OnCallContactList> NND_OnCallContactList { get; set; }
        public virtual DbSet<NND_Report_Summary_DateMaster> NND_Report_Summary_DateMaster { get; set; }
        public virtual DbSet<NND_Report_Summary_IntakeCount> NND_Report_Summary_IntakeCount { get; set; }
        public virtual DbSet<NND_Report_Summary_Master> NND_Report_Summary_Master { get; set; }
        public virtual DbSet<NND_Stats> NND_Stats { get; set; }
        public virtual DbSet<NND_StatsDeptStartDate> NND_StatsDeptStartDate { get; set; }
        public virtual DbSet<NOTEPROGRESS> NOTEPROGRESSes { get; set; }
        public virtual DbSet<NOTETEMPLATE> NOTETEMPLATES { get; set; }
        public virtual DbSet<NOTETYPE> NOTETYPES { get; set; }
        public virtual DbSet<NOTETYPETPLATE> NOTETYPETPLATES { get; set; }
        public virtual DbSet<NUMBER> NUMBERS { get; set; }
        public virtual DbSet<NUTRITION> NUTRITIONS { get; set; }
        public virtual DbSet<OASIS> Oases { get; set; }
        public virtual DbSet<OASISCHANGE> OASISCHANGEs { get; set; }
        public virtual DbSet<OASISCOMM> OASISCOMMS { get; set; }
        public virtual DbSet<ORDCALC> ORDCALCs { get; set; }
        public virtual DbSet<ORDCALCINVGRP> ORDCALCINVGRPs { get; set; }
        public virtual DbSet<ORDCCRULE> ORDCCRULES { get; set; }
        public virtual DbSet<ORDCHART> ORDCHARTs { get; set; }
        public virtual DbSet<ORDDATE> ORDDATES { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<ORDEXCEED> ORDEXCEEDs { get; set; }
        public virtual DbSet<ORDPLAN> ORDPLANs { get; set; }
        public virtual DbSet<ORDPLANCANCEL> ORDPLANCANCELs { get; set; }
        public virtual DbSet<ORDPLANSERV> ORDPLANSERVS { get; set; }
        public virtual DbSet<ORDRULE> ORDRULES { get; set; }
        public virtual DbSet<ORDSTATHIST> ORDSTATHISTs { get; set; }
        public virtual DbSet<OUTCOME> OUTCOMES { get; set; }
        public virtual DbSet<OUTTABLE> OUTTABLES { get; set; }
        public virtual DbSet<OVERSERV> OVERSERVs { get; set; }
        public virtual DbSet<PARTNER> PARTNERS { get; set; }
        public virtual DbSet<PARTNERXML> PARTNERXMLs { get; set; }
        public virtual DbSet<PATHCAT> PATHCATS { get; set; }
        public virtual DbSet<PATHITEM> PATHITEMS { get; set; }
        public virtual DbSet<PATHSTEPITEMLINK> PATHSTEPITEMLINKS { get; set; }
        public virtual DbSet<PATHSTEPITEM> PATHSTEPITEMS { get; set; }
        public virtual DbSet<PATHSTEP> PATHSTEPS { get; set; }
        public virtual DbSet<PATHVCODE> PATHVCODES { get; set; }
        public virtual DbSet<PATHVCODETABLE> PATHVCODETABLES { get; set; }
        public virtual DbSet<PATHVSUBCODE> PATHVSUBCODES { get; set; }
        public virtual DbSet<PATHWAYDEPT> PATHWAYDEPTS { get; set; }
        public virtual DbSet<PATHWAY> PATHWAYS { get; set; }
        public virtual DbSet<PATHWAYSTEP> PATHWAYSTEPS { get; set; }
        public virtual DbSet<PAYLEVEL> PAYLEVELS { get; set; }
        public virtual DbSet<PAYRECORD> PAYRECORDS { get; set; }
        public virtual DbSet<PAYRECVAL> PAYRECVALs { get; set; }
        public virtual DbSet<PAYTABLE> PAYTABLES { get; set; }
        public virtual DbSet<PLANNER> PLANNERS { get; set; }
        public virtual DbSet<PORTALACCESSRIGHT> PORTALACCESSRIGHTS { get; set; }
        public virtual DbSet<PORTALGROUPACCESS> PORTALGROUPACCESSes { get; set; }
        public virtual DbSet<PORTALGROUP> PORTALGROUPS { get; set; }
        public virtual DbSet<PORTALUSERCHANx> PORTALUSERCHANGES { get; set; }
        public virtual DbSet<PORTALUSERDEPT> PORTALUSERDEPTS { get; set; }
        public virtual DbSet<PORTALUSEREVENT> PORTALUSEREVENTS { get; set; }
        public virtual DbSet<PORTALUSERGROUP> PORTALUSERGROUPS { get; set; }
        public virtual DbSet<PORTALUSERROLE> PORTALUSERROLES { get; set; }
        public virtual DbSet<PORTALUSER> PORTALUSERS { get; set; }
        public virtual DbSet<PORTALUSERSESSION> PORTALUSERSESSIONS { get; set; }
        public virtual DbSet<POSITION> POSITIONS { get; set; }
        public virtual DbSet<PPSDIAG> PPSDIAGS { get; set; }
        public virtual DbSet<PPSINDEX> PPSINDEXes { get; set; }
        public virtual DbSet<PROTRANSLATE> PROTRANSLATEs { get; set; }
        public virtual DbSet<RAI_ASSESS> RAI_ASSESS { get; set; }
        public virtual DbSet<RAI_CHANGE> RAI_CHANGE { get; set; }
        public virtual DbSet<RAI_DATA> RAI_DATA { get; set; }
        public virtual DbSet<RAI_LOG> RAI_LOG { get; set; }
        public virtual DbSet<RAI_NOTES> RAI_NOTES { get; set; }
        public virtual DbSet<RAI_SECTION> RAI_SECTION { get; set; }
        public virtual DbSet<RATECHART> RATECHARTs { get; set; }
        public virtual DbSet<RATECODE> RATECODES { get; set; }
        public virtual DbSet<REMINDER> REMINDERS { get; set; }
        public virtual DbSet<REMOTETEAM> REMOTETEAMS { get; set; }
        public virtual DbSet<REPORTTEMPLATE> REPORTTEMPLATES { get; set; }
        public virtual DbSet<REQDEF> REQDEFS { get; set; }
        public virtual DbSet<RESOURCE> RESOURCES { get; set; }
        public virtual DbSet<RESVI> RESVIS { get; set; }
        public virtual DbSet<ROUTEDAY> ROUTEDAYS { get; set; }
        public virtual DbSet<ROUTEDDEF> ROUTEDDEFS { get; set; }
        public virtual DbSet<ROUTE> ROUTES { get; set; }
        public virtual DbSet<ROUTESCHED> ROUTESCHEDs { get; set; }
        public virtual DbSet<ROUTESDEF> ROUTESDEFS { get; set; }
        public virtual DbSet<RPTFIELD> RPTFIELDS { get; set; }
        public virtual DbSet<RPTFOLDER> RPTFOLDERS { get; set; }
        public virtual DbSet<RPTITEM> RPTITEMS { get; set; }
        public virtual DbSet<RPTJOIN> RPTJOINS { get; set; }
        public virtual DbSet<RPTTABLE> RPTTABLES { get; set; }
        public virtual DbSet<RPTUSERFOLD> RPTUSERFOLDs { get; set; }
        public virtual DbSet<RULE> RULES { get; set; }
        public virtual DbSet<RULESET> RULESETS { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULES { get; set; }
        public virtual DbSet<SCHGROUPCLTREVIEW> SCHGROUPCLTREVIEWs { get; set; }
        public virtual DbSet<SCHGROUPCLT> SCHGROUPCLTS { get; set; }
        public virtual DbSet<SCHGROUPCLTSTATE> SCHGROUPCLTSTATES { get; set; }
        public virtual DbSet<SCHGROUPEMP> SCHGROUPEMPS { get; set; }
        public virtual DbSet<SCHGROUP> SCHGROUPS { get; set; }
        public virtual DbSet<SERVICE> SERVICES { get; set; }
        public virtual DbSet<SERVREQ> SERVREQS { get; set; }
        public virtual DbSet<SERVREQTAB> SERVREQTABs { get; set; }
        public virtual DbSet<SERVTABLE> SERVTABLES { get; set; }
        public virtual DbSet<SHIFTCODE> SHIFTCODES { get; set; }
        public virtual DbSet<SPCNTTYPE> SPCNTTYPEs { get; set; }
        public virtual DbSet<SQLtracePOCDec172013> SQLtracePOCDec172013 { get; set; }
        public virtual DbSet<STATDEF> STATDEFS { get; set; }
        public virtual DbSet<STATHOLID> STATHOLIDS { get; set; }
        public virtual DbSet<SUBCATEGORY> SUBCATEGORies { get; set; }
        public virtual DbSet<SUPERTYPE> SUPERTYPES { get; set; }
        public virtual DbSet<SUPERVISOR> SUPERVISORS { get; set; }
        public virtual DbSet<SYNCSERVER> SYNCSERVERs { get; set; }
        public virtual DbSet<SYNCSERVERLOG> SYNCSERVERLOGs { get; set; }
        public virtual DbSet<SYSAPP> SYSAPPS { get; set; }
        public virtual DbSet<SYSAPPSDEPT> SYSAPPSDEPTs { get; set; }
        public virtual DbSet<SYSAPPSLOG> SYSAPPSLOGs { get; set; }
        public virtual DbSet<SYSDOC> SYSDOCS { get; set; }
        public virtual DbSet<SYSDOCSX> SYSDOCSXes { get; set; }
        public virtual DbSet<SYSHASH> SYSHASHes { get; set; }
        public virtual DbSet<SYSNEXTKEY> SYSNEXTKEYS { get; set; }
        public virtual DbSet<SYSREF> SYSREFS { get; set; }
        public virtual DbSet<SYSTEM> SYSTEMs { get; set; }
        public virtual DbSet<SYSTEMLOG> SYSTEMLOGs { get; set; }
        public virtual DbSet<TIMECHANGE> TIMECHANGEs { get; set; }
        public virtual DbSet<TIMEDUTY> TIMEDUTies { get; set; }
        public virtual DbSet<TIMELOG> TIMELOGs { get; set; }
        public virtual DbSet<TIMEPERIOD> TIMEPERIODs { get; set; }
        public virtual DbSet<TRANSBATCH> TRANSBATCHes { get; set; }
        public virtual DbSet<TRXBATCH> TRXBATCHes { get; set; }
        public virtual DbSet<TRXBATCHFUNDER> TRXBATCHFUNDERS { get; set; }
        public virtual DbSet<TRXBATCHTRX> TRXBATCHTRXes { get; set; }
        public virtual DbSet<TRXBATCHTRXDET> TRXBATCHTRXDETs { get; set; }
        public virtual DbSet<TRXTYPE> TRXTYPES { get; set; }
        public virtual DbSet<USERACCESS> USERACCESSes { get; set; }
        public virtual DbSet<USERDEPT> USERDEPTs { get; set; }
        public virtual DbSet<USERGROUP> USERGROUPS { get; set; }
        public virtual DbSet<USERLOG> USERLOGs { get; set; }
        public virtual DbSet<USERNOTE> USERNOTES { get; set; }
        public virtual DbSet<USERPLAN> USERPLANS { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<USERSTATU> USERSTATUS { get; set; }
        public virtual DbSet<USERSYNCH> USERSYNCHes { get; set; }
        public virtual DbSet<USERSYNCHREC> USERSYNCHRECS { get; set; }
        public virtual DbSet<USERVIPCLIENT> USERVIPCLIENTS { get; set; }
        public virtual DbSet<VALIDSUPER> VALIDSUPERs { get; set; }
        public virtual DbSet<VALOUTTAB> VALOUTTABS { get; set; }
        public virtual DbSet<VISITOFFERLIST> VISITOFFERLISTS { get; set; }
        public virtual DbSet<VISITOFFER> VISITOFFERS { get; set; }
        public virtual DbSet<VISIT> VISITS { get; set; }
        public virtual DbSet<WFACTION> WFACTIONS { get; set; }
        public virtual DbSet<WFALERTACTION> WFALERTACTIONS { get; set; }
        public virtual DbSet<WFALERTDEPT> WFALERTDEPTS { get; set; }
        public virtual DbSet<WFALERT> WFALERTS { get; set; }
        public virtual DbSet<WFALERTTASK> WFALERTTASKS { get; set; }
        public virtual DbSet<WFCONDITION> WFCONDITIONS { get; set; }
        public virtual DbSet<WFEVENT> WFEVENTS { get; set; }
        public virtual DbSet<WFTASKDET> WFTASKDETS { get; set; }
        public virtual DbSet<WFTASK> WFTASKS { get; set; }
        public virtual DbSet<XMLTRX> XMLTRXes { get; set; }
        public virtual DbSet<FROM_NND_Report_Client_Stats> FROM_NND_Report_Client_Stats { get; set; }
        public virtual DbSet<NND_BACKUP_PORTALUSERS> NND_BACKUP_PORTALUSERS { get; set; }
        public virtual DbSet<NND_CallForwardActive> NND_CallForwardActive { get; set; }
        public virtual DbSet<NND_CallForwardHistory> NND_CallForwardHistory { get; set; }
        public virtual DbSet<NND_CallForwardSchedule> NND_CallForwardSchedule { get; set; }
        public virtual DbSet<NND_CallForwardSettings> NND_CallForwardSettings { get; set; }
        public virtual DbSet<NND_CallMeAlert> NND_CallMeAlert { get; set; }
        public virtual DbSet<NND_CallMeInvestigated> NND_CallMeInvestigated { get; set; }
        public virtual DbSet<NND_CallMeReport_temp> NND_CallMeReport_temp { get; set; }
        public virtual DbSet<NND_CallMeTollFrees> NND_CallMeTollFrees { get; set; }
        public virtual DbSet<NND_CallMeUserAssigned> NND_CallMeUserAssigned { get; set; }
        public virtual DbSet<NND_CallMeUserStatus> NND_CallMeUserStatus { get; set; }
        public virtual DbSet<NND_CallsWaiting> NND_CallsWaiting { get; set; }
        public virtual DbSet<NND_CompetitorBenchmarks> NND_CompetitorBenchmarks { get; set; }
        public virtual DbSet<NND_CRM_Area> NND_CRM_Area { get; set; }
        public virtual DbSet<NND_CRM_ContactDepts> NND_CRM_ContactDepts { get; set; }
        public virtual DbSet<NND_CRM_Contacts> NND_CRM_Contacts { get; set; }
        public virtual DbSet<NND_CRM_ContactTypes> NND_CRM_ContactTypes { get; set; }
        public virtual DbSet<NND_CRM_Departments> NND_CRM_Departments { get; set; }
        public virtual DbSet<NND_DatedNoteAlert> NND_DatedNoteAlert { get; set; }
        public virtual DbSet<NND_DatedNoteExcludedDepts> NND_DatedNoteExcludedDepts { get; set; }
        public virtual DbSet<NND_DatedNoteExcludedUsers> NND_DatedNoteExcludedUsers { get; set; }
        public virtual DbSet<NND_DatedNoteInvestigated> NND_DatedNoteInvestigated { get; set; }
        public virtual DbSet<NND_DatedNotesRTActiveDepts> NND_DatedNotesRTActiveDepts { get; set; }
        public virtual DbSet<NND_DatedNoteUserAssigned> NND_DatedNoteUserAssigned { get; set; }
        public virtual DbSet<NND_DeptPostalLookup> NND_DeptPostalLookup { get; set; }
        public virtual DbSet<NND_DeptTerritories> NND_DeptTerritories { get; set; }
        public virtual DbSet<NND_FinDashboardRevActuals> NND_FinDashboardRevActuals { get; set; }
        public virtual DbSet<NND_FinDashboardRevBenchmarks> NND_FinDashboardRevBenchmarks { get; set; }
        public virtual DbSet<NND_FinDashboardTierSorting> NND_FinDashboardTierSorting { get; set; }
        public virtual DbSet<NND_FPGroupLocations> NND_FPGroupLocations { get; set; }
        public virtual DbSet<NND_FPGroups> NND_FPGroups { get; set; }
        public virtual DbSet<NND_FPGroupUsers> NND_FPGroupUsers { get; set; }
        public virtual DbSet<NND_FPNPI> NND_FPNPI { get; set; }
        public virtual DbSet<NND_HiddenCallMeClients> NND_HiddenCallMeClients { get; set; }
        public virtual DbSet<NND_HiddenCallMeClientsTracking> NND_HiddenCallMeClientsTracking { get; set; }
        public virtual DbSet<NND_MSG_CarrierDomains> NND_MSG_CarrierDomains { get; set; }
        public virtual DbSet<NND_MSG_CourtesyFollowUp> NND_MSG_CourtesyFollowUp { get; set; }
        public virtual DbSet<NND_MSG_CourtesyFollowUp_HideHistory> NND_MSG_CourtesyFollowUp_HideHistory { get; set; }
        public virtual DbSet<NND_MSG_EMPEmailAddresses> NND_MSG_EMPEmailAddresses { get; set; }
        public virtual DbSet<NND_MSG_ErrorLookup> NND_MSG_ErrorLookup { get; set; }
        public virtual DbSet<NND_MSG_EventLog> NND_MSG_EventLog { get; set; }
        public virtual DbSet<NND_MSG_EventLogCodes> NND_MSG_EventLogCodes { get; set; }
        public virtual DbSet<NND_MSG_Feedback> NND_MSG_Feedback { get; set; }
        public virtual DbSet<NND_MSG_Inbox> NND_MSG_Inbox { get; set; }
        public virtual DbSet<NND_MSG_Inbox_AssignHistory> NND_MSG_Inbox_AssignHistory { get; set; }
        public virtual DbSet<NND_MSG_Inbox_HideHistory> NND_MSG_Inbox_HideHistory { get; set; }
        public virtual DbSet<NND_MSG_Inbox_Replies> NND_MSG_Inbox_Replies { get; set; }
        public virtual DbSet<NND_MSG_MatchResult> NND_MSG_MatchResult { get; set; }
        public virtual DbSet<NND_MSG_Planner> NND_MSG_Planner { get; set; }
        public virtual DbSet<NND_MSG_Planner_AssignHistory> NND_MSG_Planner_AssignHistory { get; set; }
        public virtual DbSet<NND_MSG_Reminders> NND_MSG_Reminders { get; set; }
        public virtual DbSet<NND_MSG_SentItems> NND_MSG_SentItems { get; set; }
        public virtual DbSet<NND_MSG_SentItems_MultiVisit> NND_MSG_SentItems_MultiVisit { get; set; }
        public virtual DbSet<NND_MSG_SentItems_Recipients> NND_MSG_SentItems_Recipients { get; set; }
        public virtual DbSet<NND_MSG_SentItems_Visits> NND_MSG_SentItems_Visits { get; set; }
        public virtual DbSet<NND_MSG_Settings> NND_MSG_Settings { get; set; }
        public virtual DbSet<NND_MSG_SMS> NND_MSG_SMS { get; set; }
        public virtual DbSet<NND_MSG_SMS_Recipients> NND_MSG_SMS_Recipients { get; set; }
        public virtual DbSet<NND_MSG_TextingUserAssigned> NND_MSG_TextingUserAssigned { get; set; }
        public virtual DbSet<NND_MSG_UnattachedSentItems> NND_MSG_UnattachedSentItems { get; set; }
        public virtual DbSet<NND_NPIClientDataUpload> NND_NPIClientDataUpload { get; set; }
        public virtual DbSet<NND_NPIDNC> NND_NPIDNC { get; set; }
        public virtual DbSet<NND_NPIEmployeeDataUpload> NND_NPIEmployeeDataUpload { get; set; }
        public virtual DbSet<NND_NPIListen360Clients> NND_NPIListen360Clients { get; set; }
        public virtual DbSet<NND_NPIListen360Employees> NND_NPIListen360Employees { get; set; }
        public virtual DbSet<NND_PlannerAlert> NND_PlannerAlert { get; set; }
        public virtual DbSet<NND_PlannerInvestigated> NND_PlannerInvestigated { get; set; }
        public virtual DbSet<NND_PlannerUserAssigned> NND_PlannerUserAssigned { get; set; }
        public virtual DbSet<NND_ProcuraQbFPSetup> NND_ProcuraQbFPSetup { get; set; }
        public virtual DbSet<NND_Report_AppReportRequests> NND_Report_AppReportRequests { get; set; }
        public virtual DbSet<NND_Report_AppReportsCollection> NND_Report_AppReportsCollection { get; set; }
        public virtual DbSet<NND_Report_AppSettings> NND_Report_AppSettings { get; set; }
        public virtual DbSet<NND_Report_Client_Counts> NND_Report_Client_Counts { get; set; }
        public virtual DbSet<NND_Report_CSC_Cancelations_Temp> NND_Report_CSC_Cancelations_Temp { get; set; }
        public virtual DbSet<NND_REPORT_DeptPostalCodes> NND_REPORT_DeptPostalCodes { get; set; }
        public virtual DbSet<NND_Report_EmployeeUsers> NND_Report_EmployeeUsers { get; set; }
        public virtual DbSet<NND_Report_StarWars> NND_Report_StarWars { get; set; }
        public virtual DbSet<NND_Report_StarWars_DatedNotes> NND_Report_StarWars_DatedNotes { get; set; }
        public virtual DbSet<NND_Report_StarWars_Prepped> NND_Report_StarWars_Prepped { get; set; }
        public virtual DbSet<NND_RPT_CallMeInvestigatedCount> NND_RPT_CallMeInvestigatedCount { get; set; }
        public virtual DbSet<NND_RPT_CallMeSignInCount> NND_RPT_CallMeSignInCount { get; set; }
        public virtual DbSet<NND_TempNPSContactCount> NND_TempNPSContactCount { get; set; }
        public virtual DbSet<NND_Territories> NND_Territories { get; set; }
        public virtual DbSet<NND_VAN_VISITS> NND_VAN_VISITS { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<tblCaringConsult> tblCaringConsults { get; set; }
        public virtual DbSet<temp_save_Billrecs> temp_save_Billrecs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCESSLIST>()
                .Property(e => e.ACCESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACCESSLIST>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ACCESSLIST>()
                .Property(e => e.ACCESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ACCESSLIST>()
                .Property(e => e.PARENTDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ACTIVITY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.SERVICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFCOMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.BILLSUB)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.PRICETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.FIXEDPRICE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.HOURPRICE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.BILLDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.PAYDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFMON)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFTUES)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFWED)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFTHURS)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFFRI)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFSATUR)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DEFSUN)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.FREQTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.DAYFREQ)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.OTHFRQTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.GOALTAB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.OUTTABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.USEBILLREC)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ASSENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ASSDURATIONS)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ASSFREQ)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ASSCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ASSDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ASSGOAL)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.ASSOUTCOME)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .Property(e => e.AUXCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVITY>()
                .HasMany(e => e.CLTACTCs)
                .WithRequired(e => e.ACTIVITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACTIVITY>()
                .HasMany(e => e.CLTACTVs)
                .WithRequired(e => e.ACTIVITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.ALERGY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.INTERVENT)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.DEGREE)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<ALLERGy>()
                .HasMany(e => e.CLTALLERGIES)
                .WithRequired(e => e.ALLERGy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.AARCHIVE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.ALASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.AFIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.AMIDDLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.AARCHIVEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.ADBVERSION)
                .IsUnicode(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.ACLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ARCHIVEDCLT>()
                .Property(e => e.ACOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.CHOICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACSORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACWEIGHT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACUSERTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACDEFAULT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACEXCEPT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACRECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .Property(e => e.ACREFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSCHOICE>()
                .HasMany(e => e.EMPFRMCHANS)
                .WithRequired(e => e.ASSCHOICE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSESSMD>()
                .Property(e => e.ASSMDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMD>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMD>()
                .Property(e => e.RFA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMD>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMD>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMD>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ANAME)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ASORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.AREFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ASYSDEFINED)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ARECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ARECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ALLOWORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.CATLOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.LOCKVALUE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.FINALDOCS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .Property(e => e.ARECSUBTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSMENT>()
                .HasMany(e => e.ASSESSRAIs)
                .WithRequired(e => e.ASSESSMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSESSMENT>()
                .HasMany(e => e.ASSQUESTS)
                .WithOptional(e => e.ASSESSMENT)
                .HasForeignKey(e => e.QFLOWASSESS_ID);

            modelBuilder.Entity<ASSESSMENT>()
                .HasMany(e => e.CLTASSESSes)
                .WithRequired(e => e.ASSESSMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSESSMENT>()
                .HasMany(e => e.EMPFRMS)
                .WithRequired(e => e.ASSESSMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSESSOASI>()
                .Property(e => e.ASSOASIS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSOASI>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSOASI>()
                .Property(e => e.RFA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSOASI>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSOASI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSOASI>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSRAI>()
                .Property(e => e.ASSRAI_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSRAI>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSRAI>()
                .Property(e => e.RFA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSRAI>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSRAI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSESSRAI>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSGROUP>()
                .Property(e => e.AGROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSGROUP>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSGROUP>()
                .Property(e => e.AGNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ASSGROUP>()
                .Property(e => e.AGLOWVALUE)
                .HasPrecision(20, 4);

            modelBuilder.Entity<ASSGROUP>()
                .Property(e => e.AGHIGHVALUE)
                .HasPrecision(20, 4);

            modelBuilder.Entity<ASSQADEPEND>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQADEPEND>()
                .Property(e => e.DQUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQADEPEND>()
                .Property(e => e.CHOICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQADEPEND>()
                .Property(e => e.DEXPRESS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQADEPEND>()
                .Property(e => e.DVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQDEPEND>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQDEPEND>()
                .Property(e => e.DQUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQDEPEND>()
                .Property(e => e.DEXPRESS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQDEPEND>()
                .Property(e => e.DVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQDEPEND>()
                .HasMany(e => e.ASSQADEPENDS)
                .WithRequired(e => e.ASSQDEPEND)
                .HasForeignKey(e => new { e.QUESTION_ID, e.DQUESTION_ID });

            modelBuilder.Entity<ASSQMDSHCDEPEND>()
                .Property(e => e.ASSQMDSHC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQMDSHCDEPEND>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQMDSHCDEPEND>()
                .Property(e => e.DRECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQMDSHCDEPEND>()
                .Property(e => e.DEXPRESS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQMDSHCDEPEND>()
                .Property(e => e.DVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQMDSHCDEPEND>()
                .Property(e => e.CAP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQMDSHCDEPEND>()
                .Property(e => e.MDSQUEST_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQPATHDEPEND>()
                .Property(e => e.ASSQPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQPATHDEPEND>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQPATHDEPEND>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQPATHDEPEND>()
                .Property(e => e.DEXPRESS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQPATHDEPEND>()
                .Property(e => e.DVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQPATHDEPEND>()
                .Property(e => e.DRECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQPATHDEPEND>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.SECTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QINSTRUCT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QSORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QCTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QMASK)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QREQUIRED)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QMINVALUE)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QMAXVALUE)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QCUSTNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QREFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QCHLAYOUT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QWHOLENUMS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QFREEFORM)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QALLOWTIME)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QWEIGHTED)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QDEPENDS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QLIBRARY)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QSEPARATOR)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QVALUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QSYSDEFINED)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QRECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QRECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.SERVICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.PRINTPOT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QMDSHCDEPENDS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QCOPY)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QALLOWEDIT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QALLOWLOAD)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QSHRINKFIT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QMAXSIZE)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QPATHDEPENDS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.QFLOWASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.GUIDELINES)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUEST>()
                .HasMany(e => e.ASSQDEPENDS)
                .WithRequired(e => e.ASSQUEST)
                .HasForeignKey(e => e.DQUESTION_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSQUEST>()
                .HasMany(e => e.ASSQDEPENDS1)
                .WithRequired(e => e.ASSQUEST1)
                .HasForeignKey(e => e.QUESTION_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSQUEST>()
                .HasOptional(e => e.ASSQUESTSX)
                .WithRequired(e => e.ASSQUEST)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ASSQUEST>()
                .HasMany(e => e.CLTASSANS)
                .WithRequired(e => e.ASSQUEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSQUEST>()
                .HasMany(e => e.CLTASSESSes)
                .WithOptional(e => e.ASSQUEST)
                .HasForeignKey(e => e.PQUESTION_ID);

            modelBuilder.Entity<ASSQUEST>()
                .HasMany(e => e.EMPFRMANS)
                .WithRequired(e => e.ASSQUEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASSQUEST>()
                .HasMany(e => e.EMPFRMS)
                .WithOptional(e => e.ASSQUEST)
                .HasForeignKey(e => e.PQUESTION_ID);

            modelBuilder.Entity<ASSQUEST>()
                .HasMany(e => e.NOTETYPES)
                .WithMany(e => e.ASSQUESTS)
                .Map(m => m.ToTable("ASSNOTETYPES").MapLeftKey("QUESTION_ID").MapRightKey("TYPE_ID"));

            modelBuilder.Entity<ASSQUESTSX>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUESTSX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSQUESTSX>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SECTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SINTRO)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SSORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SCUSTNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SREFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SRECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.OASISGROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.MDSGROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.GROUPLAYOUT)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.FCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.DCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECT>()
                .Property(e => e.SGUIDELINES)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECTSLAYOUT>()
                .Property(e => e.LAYOUT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECTSLAYOUT>()
                .Property(e => e.SECTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ASSSECTSLAYOUT>()
                .Property(e => e.LPERCENT)
                .HasPrecision(9, 4);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.AUTOPLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.SERVTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.PLANCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.FREQTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.FREQUNIT)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.FREQVALUEMIN)
                .HasPrecision(9, 4);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.FREQVALUE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.FREQUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.FREQVISITS)
                .HasPrecision(9, 4);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.CUSTOMPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLAN>()
                .Property(e => e.SERVAUTH)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLANSERV>()
                .Property(e => e.AUTOPLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLANSERV>()
                .Property(e => e.SERVTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AUTOORDPLANSERV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVDAY>()
                .Property(e => e.DAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVDAY>()
                .Property(e => e.ROTATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVDAY>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<AVDAY>()
                .Property(e => e.AVAILABLE)
                .IsUnicode(false);

            modelBuilder.Entity<AVDAY>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVDAY>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.AVONE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.AVAILABLE)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVONETIME>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.ROTATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.ROTPATTERN)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.EMPSPEC)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTATE>()
                .HasMany(e => e.AVDAYS)
                .WithRequired(e => e.AVROTATE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AVROTATE>()
                .HasMany(e => e.AVROTEMPs)
                .WithRequired(e => e.AVROTATE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AVROTATE>()
                .HasMany(e => e.DEPTAVROTs)
                .WithRequired(e => e.AVROTATE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.ROTATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.EMPSPEC)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.AVROTEMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<AVROTEMP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.BILLINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2000B_SBR01)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2000B_SBR02)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2000B_SBR03)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2000B_SBR04)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2000B_SBR09)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_NM103)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_NM104)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_NM105)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_NM109)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_N301)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_N302)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_N401)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_N402)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010BA_N403)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010CA_NM103)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010CA_NM104)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2010CA_NM105)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CLM05)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CLM07)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CLM08)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CLM09)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CLM18)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CLM20)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CL102)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_CL103)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.PORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.SORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.TORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_HI01_2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.REMARKS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.CLAIMTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.CLAIMCONTROLNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.SERVAUTH)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_REMARKCODES)
                .IsUnicode(false);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.L2300_MOA01)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLANSI>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLBATCH>()
                .Property(e => e.BATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLBATCH>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<BILLBATCH>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<BILLBATCH>()
                .Property(e => e.CALCUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLBATCH>()
                .HasMany(e => e.FUNDBATCHes)
                .WithRequired(e => e.BILLBATCH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.BILLINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.RECCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.PT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.CAF_NO)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.REQCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.PROVIDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.DC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.UNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.RATE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.EDXTIME)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.EDXSERVICE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.ACTIVITIES)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.BATCHNO)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLEDX>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLING_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.SOURCEORD)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.TARGETORD)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.RECREASON)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLUNIT)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.ADJCOMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.ADJMASTREC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.VSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.SUMMARY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.INVOICED)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.CLOSED)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.EXPORTAR)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.TAX1)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.TAX2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.AUX_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.BILLTYPE2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.OSOURCEORD)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.SRCPERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.CNTRRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.SRCBILLING_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .Property(e => e.EXPORTAP)
                .IsUnicode(false);

            modelBuilder.Entity<BILLING>()
                .HasMany(e => e.BILLING1)
                .WithOptional(e => e.BILLING2)
                .HasForeignKey(e => e.SRCBILLING_ID);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.BILLINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.TRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.OASIS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.INVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.INVSUBTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.INVSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.PAYMETHOD)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.SENT)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.EXPORTAR)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.AUXFLAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.AUTHREASON)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.GROUPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.REFNUMBER2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.CLAIMBATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.RECEIPTNUM)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.CASGROUPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.CASCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.CASUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLINV>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINV>()
                .HasOptional(e => e.BILLANSI)
                .WithRequired(e => e.BILLINV)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BILLINV>()
                .HasOptional(e => e.BILLEDX)
                .WithRequired(e => e.BILLINV)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BILLINV>()
                .HasOptional(e => e.BILLPMI)
                .WithRequired(e => e.BILLINV)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BILLINV>()
                .HasMany(e => e.BILLPMTS)
                .WithRequired(e => e.BILLINV)
                .HasForeignKey(e => e.PAYMENT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILLINV>()
                .HasMany(e => e.BILLPMTS1)
                .WithRequired(e => e.BILLINV1)
                .HasForeignKey(e => e.INVOICE_ID);

            modelBuilder.Entity<BILLINV>()
                .HasOptional(e => e.BILLUB92)
                .WithRequired(e => e.BILLINV)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BILLINVNOTE>()
                .Property(e => e.BILLINVNOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINVNOTE>()
                .Property(e => e.BILLINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINVNOTE>()
                .Property(e => e.INVSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINVNOTE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINVNOTE>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINVNOTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINVNOTE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMI>()
                .Property(e => e.BILLINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMI>()
                .Property(e => e.VENDERID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMI>()
                .Property(e => e.SERVICECODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMI>()
                .Property(e => e.QUANTITY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLPMI>()
                .Property(e => e.SERVICEACT)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMI>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMT>()
                .Property(e => e.BILLPMT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMT>()
                .Property(e => e.INVOICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMT>()
                .Property(e => e.PAYMENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMT>()
                .Property(e => e.BILLING_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMT>()
                .Property(e => e.SVCBILLCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLPMT>()
                .Property(e => e.SVCUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.SERVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.BILLCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.BILLRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.BILLUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.USEEMPPAY)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.REVCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.EXPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.STATCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.STATRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.STATUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.STATEMPPAY)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.STATREV)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.STATEXP)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.LIVEIN)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.USEPAYOVER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.USETAX1)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.USETAX2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.EMPPAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.AUXCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.REQCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.MASTACCT)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.TRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.ESTCOST)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.RATEGROUPER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.DISCIPLINE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.PARENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.EXPIRED)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.CNTRRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.CNTRSTATRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.USECLIENTRATES)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.BILLRECS1)
                .WithOptional(e => e.BILLREC1)
                .HasForeignKey(e => e.PARENT_ID);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.BILLRECVALs)
                .WithRequired(e => e.BILLREC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.FUNDDEPTs)
                .WithOptional(e => e.BILLREC)
                .HasForeignKey(e => e.DEFRBRATE);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.FUNDDEPTs1)
                .WithOptional(e => e.BILLREC1)
                .HasForeignKey(e => e.DEFEBRATE);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.FUNDDEPTs2)
                .WithOptional(e => e.BILLREC2)
                .HasForeignKey(e => e.DEFCCRATE);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.FUNDDEPTs3)
                .WithOptional(e => e.BILLREC3)
                .HasForeignKey(e => e.DEFORRATE);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.FUNDDEPTs4)
                .WithOptional(e => e.BILLREC4)
                .HasForeignKey(e => e.DEFRATE);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.ORDERS)
                .WithOptional(e => e.BILLREC)
                .HasForeignKey(e => e.DEFRATE);

            modelBuilder.Entity<BILLREC>()
                .HasMany(e => e.RATECHARTs)
                .WithRequired(e => e.BILLREC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.BILLVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.LOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.BILLCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.BILLRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.BILLUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.REVCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.EXPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.USEEMPPAY)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.OTFACTOR)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.PREMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.PREMRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.PREMUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLRECVAL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.SUMMARY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.SUMMFORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTSDUR)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTSUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTSAMT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.ORDMAX)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTDUR)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTHUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTVUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.ORDCCMAX)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTAMT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTTAX1)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTTAX2)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTAHUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTAVUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTADJ)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTATAX1)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTATAX2)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTCAHUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTCAVUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTCADJ)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTCATAX1)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTCATAX2)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.BILLCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.CCVALUE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.CCVALTOT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.LTCAMOUNT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.CCNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.CARELEVEL)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.PROVID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.AUTHHOURS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.SOCVALUE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.SOCCOLLECT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.RELATION)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.RECIPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.CLTSSN)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.CTRTRATE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.INVOICED)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.EXPORTAR)
                .IsUnicode(false);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTCNTRTAX1)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.TOTCNTRTAX2)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BILLSUMREC>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLTABLE>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLTABLE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLTABLE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BILLTABLE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLTABLE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLTABLE>()
                .HasMany(e => e.BILLRECS)
                .WithRequired(e => e.BILLTABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILLTABLE>()
                .HasMany(e => e.FUNDDEPTs)
                .WithOptional(e => e.BILLTABLE)
                .HasForeignKey(e => e.RATETABLE);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.BILLINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL02)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL04_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL05_TAX)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL07_COVD)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL08_NCD)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL09_CID)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL10_LRD)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL11)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL12_LAST)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL12_FIRST)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL12_MIDDLE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL13_ADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL13_ADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL13_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL13_STATE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL13_ZIP)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL22_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL24_CC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL25_CC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL26_CC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL27_CC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL28_CC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL29_CC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL30_CC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL31)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL32A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL32B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL33A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL33B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL34A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL34B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL35A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL35B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL36A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL36B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_FIRST)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_LAST)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_ADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_ADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_STATE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_ZIP)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39A_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39B_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39C_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39C_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39D_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL39D_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40A_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40B_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40C_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40C_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40D_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL40D_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41A_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41A_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41B_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41B_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41C_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41C_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41D_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL41D_AMT)
                .HasPrecision(9, 2);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL56)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL57)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL67_PRIDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL68_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL69_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL70_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL71_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL72_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL73_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL74_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL75_OTHDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL78)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL84_REMARKS)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<BILLUB92>()
                .Property(e => e.FL38_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.DEPTSPECIFIC)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.SUBCATEGORies)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CATRULE>()
                .Property(e => e.EMPCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CATRULE>()
                .Property(e => e.RULE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CATRULE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CL_REFNOS>()
                .Property(e => e.REFNUM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CL_REFNOS>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CL_REFNOS>()
                .Property(e => e.NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CL_REFNOS>()
                .Property(e => e.NUMVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CL_REFNOS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CL_REFNOS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.CLAIMBATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.BNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.BTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.BFORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.SENTUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMBATCH>()
                .Property(e => e.TRANSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.MIDDLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.ALIAS)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PERMADDR_1)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PERMADDR_2)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PERM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PERM_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PERM_POST)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PERM_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.HOME_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.WORK_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.MARITAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PRIDOCTOR)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PRIDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.REFERRAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.REF_REASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CURR_ADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CURR_ADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CURR_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CURR_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CURR_POST)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CURR_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.AREA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_ADDR_1)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_ADDR_2)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_POST)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_PHONE1)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_EXT1)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMP_PHONE2)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.OCCUPATION)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.DIRCHOME)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.RES_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.LIVING_ARR)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EQUIPPRES)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PRICONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PRILANG)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.WORKEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.NOTIFYUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.DIRPHOME)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.SAMEASPERM)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMPPROV)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMPPLACE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.ATTENDANCE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.ALERT_TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PIN)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.REFUSAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CURRESTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.MAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.VITALS)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CHECKEDOUT)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CHKOUTUSER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.ETHNICITY)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CCELL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CPAGER)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.RELATED)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.CONSENTGIVEN)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.ESTBIRTHDATE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.COUNTRYOFBIRTH)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.REFRESTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.TIMEZONE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.TIMEZONEDAYSAVINGS)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.TZID)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.BILLINGs)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.BILLINVs)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.CLTDIAGs)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.CLTPATHWAYS)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.EMPSERVS)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.FRMCONTACTs)
                .WithRequired(e => e.CLIENT)
                .HasForeignKey(e => e.CLIENT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.HAZARDS)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.INFCONTACTs)
                .WithRequired(e => e.CLIENT)
                .HasForeignKey(e => e.CLIENT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.INFCONTACTs1)
                .WithOptional(e => e.CLIENT1)
                .HasForeignKey(e => e.CLTREL_ID);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.Oases)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.OVERSERVs)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.RATECHARTs)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.SCHEDULES)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.SHIFTCODES)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.SYNCSERVERLOGs)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.WFTASKS)
                .WithOptional(e => e.CLIENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLNTNOTE>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTNOTE>()
                .Property(e => e.NOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTNOTE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTNOTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.CLTVISITOR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.RES_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.TSCHEDHRS)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.TTKHRS)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.TTKPERHRS)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.RELATION)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLNTRESORC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.CLTACTC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.ACTIVITY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.BILLDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.PAYDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.DETDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.CHANGED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.FREQTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.SUNDAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.MONDAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.TUESDAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.WEDNESDAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.THURSDAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.FRIDAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.SATURDAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.DAYFREQ)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.OTHUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.GOALID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.GOALDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.GOALCOMM)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.GOALSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.OUTID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.OUTDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.OUTCOMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.OUTSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.HISTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.HISTOUT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.CLTACTV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.ACTIVITY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.BILLDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.PAYDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.CVSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTACTV>()
                .Property(e => e.CVSTATUSREASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.CLTALGY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.ALERGY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.INTERVENT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.DEGREE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.INTRVNOTES)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.INFCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.FUNCTDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.FURTHEVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.FUNCTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.INFDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.DNOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTALLERGy>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CAVALUETEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CAVALUETEXT2)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CAVALUEMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CAVALUENUM)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CAVALUENUM2)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CAAUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSAN>()
                .HasMany(e => e.CLTASSCHANS)
                .WithRequired(e => e.CLTASSAN)
                .HasForeignKey(e => new { e.CLTASS_ID, e.QUESTION_ID });

            modelBuilder.Entity<CLTASSCHAN>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSCHAN>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSCHAN>()
                .Property(e => e.CHOICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSCHAN>()
                .Property(e => e.CACTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSCHAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSCHAN>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CAASSSTATE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CAREFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CAASSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CAASSESSOR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CASCORE)
                .HasPrecision(20, 4);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CALEVEL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.REQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CARECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CACUSTOMSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.CLTPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.PCLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .Property(e => e.PQUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSESS>()
                .HasMany(e => e.CLTASSESS1)
                .WithOptional(e => e.CLTASSESS2)
                .HasForeignKey(e => e.PCLTASS_ID);

            modelBuilder.Entity<CLTASSLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOG>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOG>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGCHG>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGCHG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGCHG>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGCHG>()
                .Property(e => e.OLDVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGCHG>()
                .Property(e => e.NEWVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGCHG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGCHG>()
                .HasOptional(e => e.CLTASSLOGDATA)
                .WithRequired(e => e.CLTASSLOGCHG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLTASSLOGDATA>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGDATA>()
                .Property(e => e.OLDTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSLOGDATA>()
                .Property(e => e.NEWTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSMED>()
                .Property(e => e.CLTASSMED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSMED>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSMED>()
                .Property(e => e.CLTMED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTASSMED>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTATTRIB>()
                .Property(e => e.ATTRB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTATTRIB>()
                .Property(e => e.LOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTATTRIB>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTATTRIB>()
                .Property(e => e.DISLIKE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTATTRIB>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTATTRIB>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTATTRIB>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTCHANx>()
                .Property(e => e.CHANGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTCHANx>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTCHANx>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTCHANx>()
                .Property(e => e.USERDATA)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.CLTVISITOR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.CLTCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DEFORDER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.TRANSPAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.TRANSTIME)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.TRACKHRS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.TRACKHRWKD)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.TRACKVISIT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.TRKEMPPAY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DEBITLEAVE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.TRACKATTND)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DIRDEFHRS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.COSTCENTRE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.LEAVECODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.LEAVEDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.ATTENDCMT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.PENDING)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.PENDSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.PENDREASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.PENDTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.FREQUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DISSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DISTRICT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DIETTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.PACKAGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DEFSERVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.CHKCONFLICTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.CV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.VIPCLIENT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DEPTRSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.DEPTRREASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.CLNTRESORCs)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLTVISITOR_ID, e.DEPT_ID });

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.CLTSERVS)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLIENT_ID, e.DEPT_ID });

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.CLTSTATES)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLIENT_ID, e.DEPT_ID });

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.CLTSUPERS)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLTVISITOR_ID, e.DEPT_ID });

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.CLTSUPREQs)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLTVISITOR_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLIENT_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.SCHGROUPCLTS)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLIENT_ID, e.DEPT_ID });

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.USERVIPCLIENTS)
                .WithRequired(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLIENT_ID, e.DEPT_ID });

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.VISITS)
                .WithOptional(e => e.CLTDEPT)
                .HasForeignKey(e => new { e.CLIENT_ID, e.DEPT_ID });

            modelBuilder.Entity<CLTDEPT>()
                .HasMany(e => e.EMPCATS)
                .WithMany(e => e.CLTDEPTs)
                .Map(m => m.ToTable("ATTEMPCATS").MapLeftKey(new[] { "CLTVISITOR_ID", "DEPT_ID" }).MapRightKey("EMPCAT_ID"));

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.CLTDIAG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.DIAGNOS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.DNOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.SEVCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.HISTOUTCOM)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.HISTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.DISCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.CODETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.INTERVENT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.ONSET)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.DEPTDIAG)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDIAG>()
                .HasMany(e => e.RAI_ASSESS)
                .WithMany(e => e.CLTDIAGs)
                .Map(m => m.ToTable("RAI_DIAGS").MapLeftKey("CLTDIAG_ID").MapRightKey("RAI_ASSESS_ID"));

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.CLTDOC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.DEFDOC)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.REFVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.RECNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.DOCTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOC>()
                .HasOptional(e => e.CLTDOCSX)
                .WithRequired(e => e.CLTDOC)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLTDOCSX>()
                .Property(e => e.CLTDOC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOCSX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOCSX>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOCSX>()
                .Property(e => e.COMPRESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTDOCSX>()
                .Property(e => e.COMPRESSTYPEX)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.PARENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTFOLDER>()
                .HasMany(e => e.CLTFOLDERS1)
                .WithOptional(e => e.CLTFOLDER1)
                .HasForeignKey(e => e.PARENT_ID);

            modelBuilder.Entity<CLTLANG>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLANG>()
                .Property(e => e.LANG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLANG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLANG>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLANG>()
                .Property(e => e.LCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.RECINFO)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGCHG>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGCHG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGCHG>()
                .Property(e => e.FIELDLABEL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGCHG>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGCHG>()
                .Property(e => e.OLDVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGCHG>()
                .Property(e => e.NEWVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGCHG>()
                .HasOptional(e => e.CLTLOGMEMO)
                .WithRequired(e => e.CLTLOGCHG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLTLOGMEMO>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGMEMO>()
                .Property(e => e.OLDMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<CLTLOGMEMO>()
                .Property(e => e.NEWMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.CLTMEDENTRY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.CLTMED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.DOSAGE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.DOSSTR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.DOSUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.FREQUENCY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.ROUTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.ADMINBY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.ADMINSITE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.ADMINISTERED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMEDENTRy>()
                .Property(e => e.ADMINCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.CLTMED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.MED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.DOSAGE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.MANAGEABIL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.REMINDER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.MEDUSE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.FUNCTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.FUNCTDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.INFCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.SUPPDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.FURTHEVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.DNOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.DOCTOR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.PHARMACY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.REVIEW)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.ROUTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.FREQUENCY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.HISTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.HISTOUTCOM)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.DOSUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.PRESAMT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.PRESSTR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.MEDSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.MEDDB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.DISCUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.ADMINSITE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTMED>()
                .HasMany(e => e.CLTASSMEDS)
                .WithRequired(e => e.CLTMED)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLTMED>()
                .HasMany(e => e.MDS)
                .WithMany(e => e.CLTMEDS)
                .Map(m => m.ToTable("MDSMEDS").MapLeftKey("CLTMED_ID").MapRightKey("MDS_ID"));

            modelBuilder.Entity<CLTMED>()
                .HasMany(e => e.RAI_ASSESS)
                .WithMany(e => e.CLTMEDS)
                .Map(m => m.ToTable("RAI_MEDS").MapLeftKey("CLTMED_ID").MapRightKey("RAI_ASSESS_ID"));

            modelBuilder.Entity<CLTPATHCOSTEP>()
                .Property(e => e.CLTPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHCOSTEP>()
                .Property(e => e.STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHCOSTEP>()
                .Property(e => e.RECREASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHCOSTEP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHCOSTEP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHFOCU>()
                .Property(e => e.CLTPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHFOCU>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHFOCU>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.PATHITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.PATHVISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.COMPLETE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.OPATHVISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.OSTEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEM>()
                .Property(e => e.VSUBCODE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEMSX>()
                .Property(e => e.CLTPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEMSX>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEMSX>()
                .Property(e => e.RECACTION)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEMSX>()
                .Property(e => e.STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEMSX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHITEMSX>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.PATHNOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.PATHVISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.COPYTONEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.FOLLOWUP)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISITNOTE>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.PATHVISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.CLTPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.RECREASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.STARTUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.STOPUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .Property(e => e.MERGE_STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHVISIT>()
                .HasMany(e => e.CLTPATHITEMS)
                .WithOptional(e => e.CLTPATHVISIT)
                .HasForeignKey(e => e.PATHVISIT_ID);

            modelBuilder.Entity<CLTPATHVISIT>()
                .HasMany(e => e.CLTPATHITEMS1)
                .WithOptional(e => e.CLTPATHVISIT1)
                .HasForeignKey(e => e.OPATHVISIT_ID);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.CLTPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.PATHWAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.RECREASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.STARTUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.STOPUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.NEXTACTION)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.COSTEPSEXIST)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.MERGESTEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.DPATHWAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTPATHWAY>()
                .HasMany(e => e.PATHITEMS)
                .WithOptional(e => e.CLTPATHWAY)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLTRULE>()
                .Property(e => e.CLTRULE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTRULE>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTRULE>()
                .Property(e => e.RULELOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTRULE>()
                .Property(e => e.RULEMAX)
                .HasPrecision(12, 4);

            modelBuilder.Entity<CLTRULE>()
                .Property(e => e.SERVAUTH)
                .IsUnicode(false);

            modelBuilder.Entity<CLTRULE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTRULE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.REQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.SERV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.SERVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.REQUIRED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.DETDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.CHANGED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.DNOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSERV>()
                .Property(e => e.DELEGATED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.HISTORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.ACTDONE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.REASON2)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSTATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.SUBCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.STRVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.MEMOVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.REFSTRVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.CLTSUBCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUBCAT>()
                .Property(e => e.PRIMARYSUBCAT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPER>()
                .Property(e => e.CLTVISITOR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPER>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPER>()
                .Property(e => e.SUPER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPER>()
                .Property(e => e.SUPERTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.REQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.CLTVISITOR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.SUPER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.REQMNT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSUPREQ>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.SYNCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.ERRLAST)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCH>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHERR>()
                .Property(e => e.SYNCHERR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHERR>()
                .Property(e => e.SYNCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHERR>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHERR>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHERR>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHERR>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHERR>()
                .Property(e => e.ERRORS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHREC>()
                .Property(e => e.SYNCRECORD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHREC>()
                .Property(e => e.SYNCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHREC>()
                .Property(e => e.TABLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHREC>()
                .Property(e => e.KEYFIELDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHREC>()
                .Property(e => e.NEW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTSYNCHREC>()
                .Property(e => e.OLD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVISITOR>()
                .Property(e => e.CLTVISITOR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVISITOR>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVISITOR>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVISITOR>()
                .HasOptional(e => e.CLIENT)
                .WithRequired(e => e.CLTVISITOR)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CLTVISITOR>()
                .HasMany(e => e.CLNTRESORCs)
                .WithRequired(e => e.CLTVISITOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLTVISITOR>()
                .HasMany(e => e.PAYRECORDS)
                .WithOptional(e => e.CLTVISITOR)
                .HasForeignKey(e => e.CLIENT_ID);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.VITALS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.VTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.VSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.VHEIGHT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.VWEIGHT)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.VRESP)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.VTEMP)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.PASEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.PRSEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CLTVITAL>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<CONNOTE>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONNOTE>()
                .Property(e => e.NOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONNOTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CONSUBCAT>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONSUBCAT>()
                .Property(e => e.SUBCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONSUBCAT>()
                .Property(e => e.STRVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CONSUBCAT>()
                .Property(e => e.MEMOVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CONSUBCAT>()
                .Property(e => e.REFSTRVAL)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CLASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CFIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CMIDDLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CPREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CADDRESS1)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CADDRESS2)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCITY)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CPROV)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCOUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CPOSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CWORKPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CWORKEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CHOMEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CPAGERNUM)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CFAX)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CVOICEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CLASTCONTCOMM)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CNEXTCONTCOMM)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CINTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CFORMAL)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CFTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CFSPECIALTY)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CFPRACTICE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CINFORMAL)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CITYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CIRELATION)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCOORD)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CORG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CORGNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CDIVISION)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CSECURITY)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CPOSITION)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCOMMMODE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CGROUPING)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CANNCOMM)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CCONTACTTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CREFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CREFID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.TZID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .HasMany(e => e.Oases)
                .WithOptional(e => e.CONTACT)
                .HasForeignKey(e => e.M0072_CONTACT_ID);

            modelBuilder.Entity<CONTACT>()
                .HasMany(e => e.DEPARTMENTS)
                .WithMany(e => e.CONTACTS)
                .Map(m => m.ToTable("CONDEPTS").MapLeftKey("CCONTACT_ID").MapRightKey("DEPT_ID"));

            modelBuilder.Entity<COORD>()
                .Property(e => e.COORD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<COORD>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<COORD>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<COORD>()
                .Property(e => e.EXT)
                .IsUnicode(false);

            modelBuilder.Entity<COORD>()
                .Property(e => e.COORDTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<COORD>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDDETAIL>()
                .Property(e => e.DASHBRD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDDETAIL>()
                .Property(e => e.METRIC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDDETAIL>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDDETAIL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDDETAIL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDGROUP>()
                .Property(e => e.DASHBRD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDGROUP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.KPI_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.DATAMETHOD)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.DATAQUERY)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.DATACONNECT)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDKPI>()
                .HasMany(e => e.DASHBRDMETRICKPIS)
                .WithRequired(e => e.DASHBRDKPI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.DISPLAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.METRIC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.DISPLABEL)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.DISPFORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.DISPPERCENT)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.DISPVISIBLE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICDISPLAY>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.METRICKPI_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.METRIC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.KPI_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.DATERTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.DRILLDOWNMETRIC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.SCORETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.SCOREFUDGEFACTOR)
                .HasPrecision(20, 4);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.SCOREDISPLAYTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.SCOREIMAGELIST)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.SCORELABEL)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICKPI>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.METRIC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.METRICTITLE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.CHARTTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.SCORETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.SCOREFUDGEFACTOR)
                .HasPrecision(20, 4);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.SCOREDISPLAYTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.SCOREIMAGELIST)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.SCORELABEL)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.DATASORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .Property(e => e.COMMONSTRUCT)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .HasMany(e => e.DASHBRDDETAILS)
                .WithRequired(e => e.DASHBRDMETRIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .HasMany(e => e.DASHBRDMETRICDISPLAYs)
                .WithRequired(e => e.DASHBRDMETRIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .HasMany(e => e.DASHBRDMETRICKPIS)
                .WithOptional(e => e.DASHBRDMETRIC)
                .HasForeignKey(e => e.DRILLDOWNMETRIC_ID);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .HasMany(e => e.DASHBRDMETRICKPIS1)
                .WithRequired(e => e.DASHBRDMETRIC1)
                .HasForeignKey(e => e.METRIC_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .HasMany(e => e.DASHBRDMETRICSCORES)
                .WithRequired(e => e.DASHBRDMETRIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DASHBRDMETRIC>()
                .HasMany(e => e.DASHBRDMETRICSERIES)
                .WithRequired(e => e.DASHBRDMETRIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DASHBRDMETRICSCORE>()
                .Property(e => e.SCORE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSCORE>()
                .Property(e => e.METRIC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSCORE>()
                .Property(e => e.METRICKPI_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSCORE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSCORE>()
                .Property(e => e.STARTRANGE)
                .HasPrecision(20, 4);

            modelBuilder.Entity<DASHBRDMETRICSCORE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSCORE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.SERIES_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.METRIC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.KPI_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRDMETRICSERy>()
                .Property(e => e.SERIESCHARTTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .Property(e => e.DASHBRD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DASHBRD>()
                .HasMany(e => e.DASHBRDDETAILS)
                .WithRequired(e => e.DASHBRD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DASHBRD>()
                .HasMany(e => e.DASHBRDGROUPS)
                .WithRequired(e => e.DASHBRD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DATEDNOTE>()
                .Property(e => e.NOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DATEDNOTE>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<DATEDNOTE>()
                .Property(e => e.CONTENTS)
                .IsUnicode(false);

            modelBuilder.Entity<DATEDNOTE>()
                .Property(e => e.ENTRYBY)
                .IsUnicode(false);

            modelBuilder.Entity<DATEDNOTE>()
                .Property(e => e.NOTESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<DATEDNOTE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DATEDNOTE>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DBCOMPONENT>()
                .Property(e => e.COMPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.PAYROLL)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.PAYTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLIENTSTAT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPSTAT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.PROMPTCONT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.GENFRQUNIT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPFLICT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTFLICT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.ORDFLICT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USEGENLOG)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USEPLUNFIL)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USEPLEMPC)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USECLTDBK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USECLTSTAT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USECLTHOLD)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USECLTDNSD)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.PRI_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.SEC_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.ADDRESS_1)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.ADDRESS_2)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEFSENSORT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.UPTKDUR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEFAGREE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.FACCODE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEFAVACT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEFAVPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEFAVEMP)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.COMPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USEADDR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.USECLP)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPACTLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPAPPLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPHLDLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPPROLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPTRMLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTACTLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTDISLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTHLDLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTASSLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTTRFLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTWTLLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTTRMLOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.NOTESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPHLDNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EMPTRMNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTDISNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTHLDNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTTRFNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTTRMNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.ORDHLDNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.ORDTRMNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLTWTLNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.LBRALLDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX1USE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX1DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX1VAL)
                .HasPrecision(7, 4);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX1GL)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX1NUM)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX2USE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX2DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX2VAL)
                .HasPrecision(7, 4);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX2GL)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.TAX2NUM)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CFTOPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CFPLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CFCLTPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CLASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CFIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.EXTENSION)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOORDERS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOORDERPMT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOSFUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOSDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOTARGET)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOTFUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOTDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.BCCAREPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.BCEXPENSES)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CHKSERVPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.ADMINDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.GVTOPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.GVPLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.GVCLTPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOTTARGET)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOTTFUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.AUTOTTDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CHKDEPTDBLBOOK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CFPLANONETIME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CFPLANUNFILLED)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.CHKORDRULES)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.AVONETIMES)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.AVROTEMPs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.BILLINGs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.CLAIMBATCHes)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.CLNTNOTES)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.CLNTRESORCs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.CLTACTCs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.CLTDEPTs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DEPTAGREEs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DEPTAVROTs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DEPTNUMS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DEPTPERIODs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DEPTSRVREQs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DISTRICTS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DOCTYPEDEPTS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.EDCVARIANCES)
                .WithOptional(e => e.DEPARTMENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.EMPLDEPTs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.EMPLNOTES)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.EMPSUBCATS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.FUNDDEPTs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.KITCHENS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.MEALPLANs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.MEALSCHEDs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.MEALVISITS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.OVERSERVs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.PATHWAYDEPTS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.PORTALUSERDEPTS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.REQDEFS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.ROUTESCHEDs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.SYSAPPSDEPTs)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.USERS)
                .WithOptional(e => e.DEPARTMENT)
                .HasForeignKey(e => e.DEFDEPT);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.AGREE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.USEEMPDBK)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.USEEMPLBR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.USEEMPDNSD)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.USEEMPSTAT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.USEEMPAVL)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.USEEMPLIKDIS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.TKSTATACT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAGREE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAREA>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAREA>()
                .Property(e => e.AREA)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAREA>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTASSESS>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTASSESS>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTASSESS>()
                .Property(e => e.AVIEWONLY)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAVROT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAVROT>()
                .Property(e => e.ROTATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTAVROT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTBILLTABLE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTBILLTABLE>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTBILLTABLE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTNUM>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTNUM>()
                .Property(e => e.NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTNUM>()
                .Property(e => e.AUTOGEN)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTNUM>()
                .Property(e => e.AUTOSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTNUM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTNUM>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTPERIOD>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTPERIOD>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTPERIOD>()
                .Property(e => e.USESCHEDS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTPLAN>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTPLAN>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTPLAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.REF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.TEXTVAL)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.REFNUMBER1)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.REFNUMBER2)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.REFDATA)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTREF>()
                .Property(e => e.ALLOWEDIT)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSCHGROUP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSCHGROUP>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSCHGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSERV>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSERV>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSERV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSRVREQ>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSRVREQ>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSRVREQ>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.STATUSCODE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.RECCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.STATUSNAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.STATUSDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.NOFREEFORM)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.AUTOORDERS)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.RECTYPE2)
                .IsUnicode(false);

            modelBuilder.Entity<DEPTSTATU>()
                .Property(e => e.LOOKUP_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGGROUP>()
                .Property(e => e.DIAGGR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGGROUP>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGGROUP>()
                .Property(e => e.RANGESTART)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGGROUP>()
                .Property(e => e.RANGESTOP)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGGROUP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.DIAGNOS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.CODETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.INTERVENT)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.HCWARNING)
                .IsUnicode(false);

            modelBuilder.Entity<DIAGNOSI>()
                .Property(e => e.HCWARNINGMSG)
                .IsUnicode(false);

            modelBuilder.Entity<DIETTYPE>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DIETTYPE>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<DIETTYPE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DIETTYPE>()
                .Property(e => e.DIETTYPE1)
                .IsUnicode(false);

            modelBuilder.Entity<DIETTYPE>()
                .Property(e => e.DESSERT)
                .IsUnicode(false);

            modelBuilder.Entity<DIETTYPE>()
                .HasMany(e => e.CLTDEPTs)
                .WithOptional(e => e.DIETTYPE)
                .HasForeignKey(e => e.DIETTYPE_ID);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.DISTRICT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.ADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.ADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.PROV)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.CONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.EXT)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.DEFKITCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .HasMany(e => e.EMPDISTs)
                .WithRequired(e => e.DISTRICT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISTRICT>()
                .HasMany(e => e.KITCHDISTs)
                .WithRequired(e => e.DISTRICT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISTRICT>()
                .HasMany(e => e.ROUTES)
                .WithRequired(e => e.DISTRICT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCTYPEDEPT>()
                .Property(e => e.DOCTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPEDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPEDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.DOCTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.SYSDEFINED)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.DOCCLIENT)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.DOCPOINTOFCARE)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.FILEEXTS)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .Property(e => e.DEPTSPECIFIC)
                .IsUnicode(false);

            modelBuilder.Entity<DOCTYPE>()
                .HasMany(e => e.EMPDOCS)
                .WithRequired(e => e.DOCTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCTYPE>()
                .HasMany(e => e.SYSDOCS)
                .WithRequired(e => e.DOCTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONOTSEND>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DONOTSEND>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DONOTSEND>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DONOTSEND>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<DONOTSEND>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DONOTSEND>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.DRORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.ORDERTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.CONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.ORDERCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.GOALCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.POCLINK_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDER>()
                .HasMany(e => e.DRORDERS1)
                .WithOptional(e => e.DRORDER1)
                .HasForeignKey(e => e.POCLINK_ID);

            modelBuilder.Entity<DRORDERSLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOG>()
                .Property(e => e.DRORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOG>()
                .Property(e => e.SENT)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOG>()
                .Property(e => e.DATAEXISTS)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOG>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOG>()
                .Property(e => e.STATREASON)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOG>()
                .HasOptional(e => e.DRORDERSLOGDATA)
                .WithRequired(e => e.DRORDERSLOG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DRORDERSLOGDATA>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DRORDERSLOGDATA>()
                .Property(e => e.XMLDATA)
                .IsUnicode(false);

            modelBuilder.Entity<EBILLFORMAT>()
                .Property(e => e.FORMAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EBILLFORMAT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EBILLFORMAT>()
                .HasMany(e => e.FUNDDEPTs)
                .WithOptional(e => e.EBILLFORMAT)
                .HasForeignKey(e => e.EFORMAT);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.CALL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.CALLMODE)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.CALLSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.PHONESTART)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.PHONESTOP)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.MANUALPSTART)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.MANUALPSTOP)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.CALLSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<EDCCALL>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<EDCEXCEPT>()
                .Property(e => e.EXCEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCEXCEPT>()
                .Property(e => e.CALLVISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCEXCEPT>()
                .Property(e => e.VAR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCEXCEPT>()
                .Property(e => e.RECSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<EDCEXCEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.VAR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.VARENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.VARUSEVISIT)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .Property(e => e.VARCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVARIANCE>()
                .HasMany(e => e.EDCEXCEPTS)
                .WithRequired(e => e.EDCVARIANCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.EDCVISITDET_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.CALLVISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.VALUE)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISITDETAIL>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.CALLVISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.CALL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.CV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.CVMATCH)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.CVSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EDCVISIT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPATTRIB>()
                .Property(e => e.ATTRB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPATTRIB>()
                .Property(e => e.LOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPATTRIB>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPATTRIB>()
                .Property(e => e.DISLIKE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPATTRIB>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPATTRIB>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPATTRIB>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCAT>()
                .Property(e => e.EMPCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCAT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCAT>()
                .Property(e => e.SPLITSHIFT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCAT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCAT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCAT>()
                .Property(e => e.RULESET_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCAT>()
                .Property(e => e.RULESET_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCHANx>()
                .Property(e => e.CHANGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCHANx>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCHANx>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCHANx>()
                .Property(e => e.USERDATA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.CONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.RELATION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.ADDRESS_1)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.ADDRESS_2)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.WORK_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.EXT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.HOME_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.CELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.PAGERNUM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.VOICEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPCONTACT>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDATE>()
                .Property(e => e.EMPDATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDATE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDATE>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDATE>()
                .Property(e => e.DESCR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDIST>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDIST>()
                .Property(e => e.DISTRICT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDIST>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDIST>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.EMPDOC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.DOCTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.DEFDOC)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.REFVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.RECNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOC>()
                .HasOptional(e => e.EMPDOCSX)
                .WithRequired(e => e.EMPDOC)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EMPDOCSX>()
                .Property(e => e.EMPDOC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOCSX>()
                .Property(e => e.COMPRESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOCSX>()
                .Property(e => e.COMPRESSTYPEX)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOCSX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPDOCSX>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.PARENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFOLDER>()
                .HasMany(e => e.EMPFOLDERS1)
                .WithOptional(e => e.EMPFOLDER1)
                .HasForeignKey(e => e.PARENT_ID);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.EMPFRM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.EFVALUETEXT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.EFVALUETEXT2)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.EFVALUEMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.EFVALUENUM)
                .HasPrecision(18, 4);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.EFVALUENUM2)
                .HasPrecision(18, 4);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.EFAUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMAN>()
                .HasMany(e => e.EMPFRMCHANS)
                .WithRequired(e => e.EMPFRMAN)
                .HasForeignKey(e => new { e.EMPFRM_ID, e.QUESTION_ID });

            modelBuilder.Entity<EMPFRMCHAN>()
                .Property(e => e.EMPFRM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMCHAN>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMCHAN>()
                .Property(e => e.CHOICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMCHAN>()
                .Property(e => e.EFCTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMCHAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMCHAN>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOG>()
                .Property(e => e.EMPFRM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOG>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGCHG>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGCHG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGCHG>()
                .Property(e => e.QUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGCHG>()
                .Property(e => e.OLDVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGCHG>()
                .Property(e => e.NEWVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGCHG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGCHG>()
                .HasOptional(e => e.EMPFRMLOGDATA)
                .WithRequired(e => e.EMPFRMLOGCHG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EMPFRMLOGDATA>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGDATA>()
                .Property(e => e.OLDTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRMLOGDATA>()
                .Property(e => e.NEWTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EMPFRM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.PEMPFRM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.PQUESTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EFRMSTATE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EFREFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EFRMTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EFASSESSOR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EFSCORE)
                .HasPrecision(20, 4);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EFRECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.EFCUSTOMSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .Property(e => e.REQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPFRM>()
                .HasMany(e => e.EMPFRMS1)
                .WithOptional(e => e.EMPFRM1)
                .HasForeignKey(e => e.PEMPFRM_ID);

            modelBuilder.Entity<EMPLANG>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLANG>()
                .Property(e => e.LANG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLANG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLANG>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLANG>()
                .Property(e => e.LCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.PAYLEVEL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.DEFPAYREC)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.HRSWORKED)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.HRSPAID)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.AGREE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.EMPCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.USER_IN)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.PROGRAM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.SERVICE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.SECTION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.LOCATION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.PAYROLLNUM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.HRAPPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.RECRUITER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.PROGRESS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.NOTESEXIST)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.TERMNOTES)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.NEWBRANCH)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.NEWDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.APPLPREV)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.PREVHIRED)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.RESCOMNTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.HRWRKDPROB)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.HRWRKYEAR)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.HRSPAIDYR)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.FILENUM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.RECEMPREQ)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.EMPCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.FREQUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.NEXTEVAL)
                .HasPrecision(12, 4);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.AHRSWORKED)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.AHRSPAID)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.CHKCONFLICTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.EMPDATES)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID });

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.EMPLNOTES)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.EMPSERVS)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.EMPSTATES)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID });

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.EMPSUPERS)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID });

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.EMPSUPREQs)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.PAYRECORDS)
                .WithOptional(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID });

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.POSITIONS)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID });

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.SCHGROUPEMPS)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID });

            modelBuilder.Entity<EMPLDEPT>()
                .HasMany(e => e.TIMEDUTies)
                .WithRequired(e => e.EMPLDEPT)
                .HasForeignKey(e => new { e.EMP_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLNOTE>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLNOTE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLNOTE>()
                .Property(e => e.NOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLNOTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.RECINFO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGCHG>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGCHG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGCHG>()
                .Property(e => e.FIELDLABEL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGCHG>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGCHG>()
                .Property(e => e.OLDVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGCHG>()
                .Property(e => e.NEWVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGCHG>()
                .HasOptional(e => e.EMPLOGMEMO)
                .WithRequired(e => e.EMPLOGCHG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EMPLOGMEMO>()
                .Property(e => e.CHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGMEMO>()
                .Property(e => e.OLDMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOGMEMO>()
                .Property(e => e.NEWMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.MIDDLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.HOMEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.WORKPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PAGERNUM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PRILANG)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.MARITAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.AREA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.IS_USER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CURR_ADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CURR_ADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CURR_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CURR_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CURR_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CURR_POST)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PERMADDR_1)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PERMADDR_2)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PERM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PERM_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PERM_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PERM_POST)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.SAMEASPERM)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ALIAS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.WORKEXT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.VOICEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PLACEEMP)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.TITLEEMP)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ADDREMP)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.DIRCHOME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.DIRPHOME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ISSUPER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.TEMPRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ALERT_TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PIN)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.VERIFY_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.VISIT_MODE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.BATCH_MODE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.MAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EDCENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EDCTIMEZONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EDCDAYSAVINGS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ENOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EDCMILEAGE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EDCACTIVITIES)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.OFFERCOMMMODE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.TZID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.AVONETIMES)
                .WithRequired(e => e.EMPLOYEE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.AVROTEMPs)
                .WithRequired(e => e.EMPLOYEE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.EDCCALLS)
                .WithRequired(e => e.EMPLOYEE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.EMPLNOTES)
                .WithRequired(e => e.EMPLOYEE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.OVERSERVs)
                .WithOptional(e => e.EMPLOYEE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.SCHGROUPS)
                .WithOptional(e => e.EMPLOYEE)
                .HasForeignKey(e => e.EMP_ID1);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.SCHGROUPS1)
                .WithOptional(e => e.EMPLOYEE1)
                .HasForeignKey(e => e.EMP_ID2);

            modelBuilder.Entity<EMPLOYEE>()
                .HasOptional(e => e.SUPERVISOR)
                .WithRequired(e => e.EMPLOYEE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.VISITS)
                .WithOptional(e => e.EMPLOYEE)
                .HasForeignKey(e => e.EMP_ID2);

            modelBuilder.Entity<EMPREFNO>()
                .Property(e => e.REFNUM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPREFNO>()
                .Property(e => e.NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPREFNO>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPREFNO>()
                .Property(e => e.NUMVAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPREFNO>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPREFNO>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPROUTE>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPROUTE>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPROUTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPROUTE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.REQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.SERV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.CHANGED)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.DETDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.DNOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSERV>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.HISTORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.ACTDONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.REASON2)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSTATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.RES_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.SUBCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.STRVAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.MEMOVAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.REFSTRVAL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUBCAT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPER>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPER>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPER>()
                .Property(e => e.SUPER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPER>()
                .Property(e => e.SUPERTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.REQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.REQMNT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.SUPER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPSUPREQ>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.EQPRES_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.EQUIP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.MISSING)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.REQUIRED)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPPRE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.REPORT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.APPVERSION)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.DBVERSION)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.COMPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.REGKEY)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.SENT)
                .IsUnicode(false);

            modelBuilder.Entity<ERRORRPT>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.EXP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.STANDALONE)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.PAID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.PAYUNITS)
                .HasPrecision(8, 4);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.BILLED)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.BILLUNITS)
                .HasPrecision(8, 4);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.EXPPAYROLL)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.PAYVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<EXPMILEAGE>()
                .Property(e => e.RECSUBTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<EXPPAYROLL>()
                .Property(e => e.PAYROLL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EXPPAYROLL>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EXPPAYROLL>()
                .Property(e => e.EMPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<EXPPAYROLL>()
                .Property(e => e.CLTNUM)
                .IsUnicode(false);

            modelBuilder.Entity<EXPPAYROLL>()
                .Property(e => e.VALIDKEY)
                .IsFixedLength();

            modelBuilder.Entity<EXPPAYROLL>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.EXPPAYROLL)
                .HasForeignKey(e => e.PAYROLL);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.CONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.ADDRESS_1)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.ADDRESS_2)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.WORK_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.HOME_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.SPECIALTY)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.PRACTICE)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.EXT)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.CELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.PAGERNUM)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.VOICEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.DEPTCONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.REFID)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.REFSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.CONSENTGIVEN)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.BILLINGCONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<FRMCONTACT>()
                .HasMany(e => e.CLIENTS)
                .WithOptional(e => e.FRMCONTACT)
                .HasForeignKey(e => e.PRIDOCTOR);

            modelBuilder.Entity<FRMCONTACT>()
                .HasMany(e => e.CLTMEDS)
                .WithOptional(e => e.FRMCONTACT)
                .HasForeignKey(e => e.DOCTOR);

            modelBuilder.Entity<FRMCONTACT>()
                .HasMany(e => e.CLTMEDS1)
                .WithOptional(e => e.FRMCONTACT1)
                .HasForeignKey(e => e.PHARMACY);

            modelBuilder.Entity<FUNDBATCH>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDBATCH>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDBATCH>()
                .Property(e => e.BATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDBATCH>()
                .HasMany(e => e.FUNDEPTPERs)
                .WithRequired(e => e.FUNDBATCH)
                .HasForeignKey(e => new { e.FUNDER_ID, e.DEPT_ID, e.BATCH_ID });

            modelBuilder.Entity<FUNDCCTYPE>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCCTYPE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCCTYPE>()
                .Property(e => e.DEFVALUE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<FUNDCCTYPE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCCTYPE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.REF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.TEXTVAL)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.DATA_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.PRINTED)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.UNIQNUM)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.NOFREEFORM)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.FORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.FORMULA)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.REFNUMBER1)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.REFNUMBER2)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.NUMREQ)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.ADMINREF)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.REFDATA)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .Property(e => e.ALLOWEDIT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDCLTREF>()
                .HasMany(e => e.USERS)
                .WithOptional(e => e.FUNDCLTREF)
                .HasForeignKey(e => e.FINDOREF);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.NEXT_INV)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFBILL)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFPAY)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INVFORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.STMTFORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.EBILL)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.EFORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.BATCHOPTION)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFRATE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.CHARGETAX1)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.CHANGETAX1)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.TAX1DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.CHARGETAX2)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.CHANGETAX2)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.TAX2DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USEOR)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFORRATE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USECC)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFCCRATE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFCCINVCOM)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USEEB)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFEBRATE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFEBINVCOM)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USERB)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFRBRATE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFRBINVCOM)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.RATETABLE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USEORDSERV)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USEORDHOLD)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USEORDXVIS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.USEORDHRLV)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.BILLING)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.STATACTION)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.STATNOEMP)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.STATPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.TKSTATACT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.NOSTATACT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.NOSTATNOEMP)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.NOSTATPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INVCOMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.SASKRULES)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.CCBILLCYC)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.LVLVISITS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.OVERMID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.OVERMIDHOLS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.DEFMSACODE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INVGROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INVPRINTCOMP)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INVPRINTEMP)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INVEMPTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.RAPBILLVISIT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.FINALCALCTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.RAPBILLVISITV)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.UB04)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.ORSCHEDONLY)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.LINEITEMPOST)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.CNTRBILLING)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.INVGENFLAG)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDDEPT>()
                .HasMany(e => e.FUNDBATCHes)
                .WithRequired(e => e.FUNDDEPT)
                .HasForeignKey(e => new { e.FUNDER_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FUNDDEPT>()
                .HasMany(e => e.FUNDCCTYPEs)
                .WithRequired(e => e.FUNDDEPT)
                .HasForeignKey(e => new { e.FUNDER_ID, e.DEPT_ID });

            modelBuilder.Entity<FUNDDEPT>()
                .HasMany(e => e.FUNDEBTYPEs)
                .WithRequired(e => e.FUNDDEPT)
                .HasForeignKey(e => new { e.FUNDER_ID, e.DEPT_ID });

            modelBuilder.Entity<FUNDDEPT>()
                .HasMany(e => e.FUNDRULES)
                .WithRequired(e => e.FUNDDEPT)
                .HasForeignKey(e => new { e.FUNDER_ID, e.DEPT_ID });

            modelBuilder.Entity<FUNDDEPT>()
                .HasMany(e => e.MEALTABS)
                .WithMany(e => e.FUNDDEPTs)
                .Map(m => m.ToTable("FUNDMEALS").MapLeftKey(new[] { "FUNDER_ID", "DEPT_ID" }).MapRightKey("TABLE_ID"));

            modelBuilder.Entity<FUNDEBTYPE>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEBTYPE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEBTYPE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEBTYPE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.BATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.USERINV)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.EXBILLING)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .Property(e => e.CALCUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDEPTPER>()
                .HasMany(e => e.BILLINGs)
                .WithOptional(e => e.FUNDEPTPER)
                .HasForeignKey(e => e.SRCPERIOD_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FUNDEPTPER>()
                .HasMany(e => e.BILLINGs1)
                .WithOptional(e => e.FUNDEPTPER1)
                .HasForeignKey(e => e.PERIOD_ID);

            modelBuilder.Entity<FUNDEPTPER>()
                .HasMany(e => e.BILLINVs)
                .WithOptional(e => e.FUNDEPTPER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.REF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.TEXTVAL)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.DATA_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.PRINTED)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.REFNUMBER1)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.REFNUMBER2)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.REFDATA)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERREF>()
                .Property(e => e.ALLOWEDIT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.CLASS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.FUNDTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.ADDRESS_1)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.ADDRESS_2)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.C_PREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.C_LAST)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.C_FIRST)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.C_TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.C_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.C_EXT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.SAMEAS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_ADDR_1)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_ADDR_2)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.B_FAX)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BC_PREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BC_LAST)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BC_FIRST)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BC_TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BC_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BC_EXT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.NONPROFIT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PERMIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.DEFFUNDER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PROV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PROVOWNER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.EMPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.EMPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.GLINTFACE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.GLACCT)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.GENGL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.GLIDMODIFY)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.BENGROUP)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PERMTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.DEFINITION)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.DISFUNDTAB)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PPSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.HOSPICEFUNDER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.CATEGORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDER>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.FUNDER)
                .HasForeignKey(e => e.AUTOSFUNDER_ID);

            modelBuilder.Entity<FUNDER>()
                .HasMany(e => e.DEPARTMENTS1)
                .WithOptional(e => e.FUNDER1)
                .HasForeignKey(e => e.AUTOTFUNDER_ID);

            modelBuilder.Entity<FUNDER>()
                .HasMany(e => e.DEPARTMENTS2)
                .WithOptional(e => e.FUNDER2)
                .HasForeignKey(e => e.AUTOTTFUNDER_ID);

            modelBuilder.Entity<FUNDER>()
                .HasMany(e => e.FUNDCLTREFs)
                .WithOptional(e => e.FUNDER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FUNDER>()
                .HasMany(e => e.FUNDERSERVs)
                .WithRequired(e => e.FUNDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FUNDER>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.FUNDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FUNDER>()
                .HasMany(e => e.USERS)
                .WithOptional(e => e.FUNDER)
                .HasForeignKey(e => e.FINDOFUND);

            modelBuilder.Entity<FUNDERSERV>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERSERV>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDERSERV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDORDVAL>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDORDVAL>()
                .Property(e => e.REF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDORDVAL>()
                .Property(e => e.TEXTVAL)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDORDVAL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDORDVAL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDRULE>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDRULE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDRULE>()
                .Property(e => e.DEFVALUE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<FUNDRULE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<FUNDRULE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.GEO_ID)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.AUX_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.LAT)
                .HasPrecision(10, 6);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.LONG)
                .HasPrecision(10, 6);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.ACCURACY)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.SOURCEDET)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<GEODATA>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.PROMPTLOG)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.PROMPTMSG)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<GRPACCESS>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<GRPACCESS>()
                .Property(e => e.ACCESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<GRPACCESS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<GRPASSESS>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<GRPASSESS>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<GRPASSESS>()
                .Property(e => e.VIEWONLY)
                .IsUnicode(false);

            modelBuilder.Entity<GRPASSESS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<GRPASSESS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.HAZARD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.LOCATION)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.HARM_EMP)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.HARM_CLT)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<HAZARD>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<HHRGWEIGHT>()
                .Property(e => e.HHRG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<HHRGWEIGHT>()
                .Property(e => e.HHRG)
                .IsUnicode(false);

            modelBuilder.Entity<HHRGWEIGHT>()
                .Property(e => e.WEIGHT)
                .HasPrecision(9, 4);

            modelBuilder.Entity<HHRGWEIGHT>()
                .Property(e => e.ESTCOST)
                .HasPrecision(12, 2);

            modelBuilder.Entity<HHRGWEIGHT>()
                .Property(e => e.M0110_EPISODE_TIMING)
                .IsUnicode(false);

            modelBuilder.Entity<ICDGEM>()
                .Property(e => e.ICDGEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ICDGEM>()
                .Property(e => e.CODETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ICDGEM>()
                .Property(e => e.ICD9_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<ICDGEM>()
                .Property(e => e.ICD10_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<ICDGEM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ICDGEM>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.RELATION)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.ADDRESS_1)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.ADDRESS_2)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.WORK_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.HOME_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.ABILCARE)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.EXT)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.PAGERNUM)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.VOICEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.DEPTCONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.NOTIFYUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CLTREL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.RELCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.ESTBIRTHDATE)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.MULTICARERS)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.COUNTRYOFBIRTH)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.ETHNICITY)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.PRILANG)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.RESSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.CONSENTGIVEN)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.BILLINGCONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACT>()
                .HasMany(e => e.CLIENTS)
                .WithOptional(e => e.INFCONTACT)
                .HasForeignKey(e => e.PRICONTACT);

            modelBuilder.Entity<INFCONTACT>()
                .HasMany(e => e.MDSHC_G)
                .WithOptional(e => e.INFCONTACT)
                .HasForeignKey(e => e.G_1_PRI_ID);

            modelBuilder.Entity<INFCONTACT>()
                .HasMany(e => e.MDSHC_G1)
                .WithOptional(e => e.INFCONTACT1)
                .HasForeignKey(e => e.G_1_SEC_ID);

            modelBuilder.Entity<INFCONTACTCHAR>()
                .Property(e => e.CONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACTCHAR>()
                .Property(e => e.LOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACTCHAR>()
                .Property(e => e.PRIMARYCHAR)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACTCHAR>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INFCONTACTCHAR>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVALIDPASS>()
                .Property(e => e.INVPASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVALIDPASS>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVALIDPASS>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<INVALIDPASS>()
                .Property(e => e.PASSWRD)
                .IsUnicode(false);

            modelBuilder.Entity<INVALIDPASS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVFORMAT>()
                .Property(e => e.FORMAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVFORMAT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<INVFORMAT>()
                .HasMany(e => e.FUNDDEPTs)
                .WithOptional(e => e.INVFORMAT1)
                .HasForeignKey(e => e.INVFORMAT);

            modelBuilder.Entity<INVGROUP>()
                .Property(e => e.INVGROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVGROUP>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<INVGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVGROUP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVGROUP>()
                .Property(e => e.SPECIALGRP)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INVRUN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.PERTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.RANGEFROM)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.RANGETO)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INVDEST)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INVPATH)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INVPREVIEW)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INVCOMMENT)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.PRTCOMPANY)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.RPLEMP)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.EMPTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.SEPINV)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INVFILE)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INCREFNUM)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVPERIOD>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVRUN>()
                .Property(e => e.INVRUN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<INVRUN>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<INVRUN>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<INVRUN>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHDIST>()
                .Property(e => e.KITCHEN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHDIST>()
                .Property(e => e.DISTRICT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHDIST>()
                .HasMany(e => e.MEALPACKS)
                .WithMany(e => e.KITCHDISTs)
                .Map(m => m.ToTable("KITCHPACKS").MapLeftKey(new[] { "KITCHEN_ID", "DISTRICT_ID" }).MapRightKey("PACKAGE_ID"));

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.KITCHEN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.ADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.ADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.PROV)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.CONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.EXT)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<KITCHEN>()
                .HasMany(e => e.DISTRICTS)
                .WithOptional(e => e.KITCHEN)
                .HasForeignKey(e => e.DEFKITCH_ID);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.AGREE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.STATUS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.EMPGRP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.GROUPTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LABORAGREE>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.LABORAGREE)
                .HasForeignKey(e => e.DEFAGREE);

            modelBuilder.Entity<LBREMPCAT>()
                .Property(e => e.AGREE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBREMPCAT>()
                .Property(e => e.EMPCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBREMPCAT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LBREMPCAT>()
                .HasMany(e => e.EMPLDEPTs)
                .WithOptional(e => e.LBREMPCAT)
                .HasForeignKey(e => new { e.AGREE_ID, e.EMPCAT_ID });

            modelBuilder.Entity<LBRGRP>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBRGRP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBRGRP>()
                .Property(e => e.GROUP_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<LBRPAYTAB>()
                .Property(e => e.AGREE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBRPAYTAB>()
                .Property(e => e.PAYTAB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBRPAYTAB>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.RULE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.VAL)
                .HasPrecision(10, 2);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.MIDNITEACT)
                .IsUnicode(false);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.RULECODE)
                .IsUnicode(false);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.EVENACTION)
                .IsUnicode(false);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LBRRULE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LBRSTAT>()
                .Property(e => e.AGREE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBRSTAT>()
                .Property(e => e.HOLIDAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LBRSTAT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LOGUSER>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LOGUSER>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<LOGUSER>()
                .Property(e => e.RECREASON)
                .IsUnicode(false);

            modelBuilder.Entity<LOGUSER>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LOGUSER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<LOGUSER>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .Property(e => e.USERDEF)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .Property(e => e.USEREDIT)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .Property(e => e.ALLOWVAL)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .Property(e => e.ADMINLOOKUP)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.DEPTSTATUS)
                .WithOptional(e => e.LOOKUP)
                .HasForeignKey(e => e.LOOKUP_ID);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.DEPTSTATUS1)
                .WithOptional(e => e.LOOKUP1)
                .HasForeignKey(e => e.LOOKUP_ID2);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.LOOKUPVALS)
                .WithRequired(e => e.LOOKUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.NOTETYPES)
                .WithOptional(e => e.LOOKUP)
                .HasForeignKey(e => e.LOOKUP_ID);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.NOTETYPES1)
                .WithOptional(e => e.LOOKUP1)
                .HasForeignKey(e => e.SUBJLOOKUP_ID);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.OUTTABLES)
                .WithOptional(e => e.LOOKUP)
                .HasForeignKey(e => e.GOALSTATAB);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.OUTTABLES1)
                .WithOptional(e => e.LOOKUP1)
                .HasForeignKey(e => e.OUTSTATTAB);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.TRXTYPES)
                .WithOptional(e => e.LOOKUP)
                .HasForeignKey(e => e.GLOOKUP_ID);

            modelBuilder.Entity<LOOKUP>()
                .HasMany(e => e.TRXTYPES1)
                .WithOptional(e => e.LOOKUP1)
                .HasForeignKey(e => e.CLOOKUP_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .Property(e => e.LOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .Property(e => e.LOOKVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .Property(e => e.REFVAL)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .Property(e => e.AUXVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ASSESSMDS)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.RFA_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ASSESSMENTS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.CATLOOKUPVAL_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ASSESSOASIS)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.RFA_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ASSESSRAIs)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.RFA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ASSQMDSHCDEPENDS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.MDSQUEST_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ASSSECTS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.OASISGROUP_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ASSSECTS1)
                .WithOptional(e => e.LOOKUPVAL1)
                .HasForeignKey(e => e.MDSGROUP_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.AUTOORDPLANs)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.SERVTYPE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.AUTOORDPLANSERVS)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.SERVTYPE_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.BILLRECVALs)
                .WithRequired(e => e.LOOKUPVAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.CLTATTRIBs)
                .WithRequired(e => e.LOOKUPVAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.CLTLANGs)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.LANG_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.CLTRULES)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.RULELOOKUPVAL_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.CLTSUPERS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.SUPERTYPE);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.CLTSUPREQs)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.REQMNT);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.CLTSUPREQs1)
                .WithOptional(e => e.LOOKUPVAL1)
                .HasForeignKey(e => e.TYPE);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPATTRIBs)
                .WithRequired(e => e.LOOKUPVAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPDATES)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.DESCR_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPLANGs)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.LANG_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPLDEPTs)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.RECRUITER);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPLDEPTs1)
                .WithOptional(e => e.LOOKUPVAL1)
                .HasForeignKey(e => e.PROGRESS);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPSUPERS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.SUPERTYPE);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPSUPREQs)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.REQMNT);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EMPSUPREQs1)
                .WithOptional(e => e.LOOKUPVAL1)
                .HasForeignKey(e => e.TYPE);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.EQUIPPRES)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.EQUIP_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.FUNDERS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.FUNDTYPE);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.FUNDERS1)
                .WithOptional(e => e.LOOKUPVAL1)
                .HasForeignKey(e => e.PERMTYPE);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.FUNDERS2)
                .WithOptional(e => e.LOOKUPVAL2)
                .HasForeignKey(e => e.BENGROUP);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.FUNDERS3)
                .WithOptional(e => e.LOOKUPVAL3)
                .HasForeignKey(e => e.CATEGORY_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.INFCONTACTs)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.PRILANG);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.INFCONTACTCHARS)
                .WithRequired(e => e.LOOKUPVAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.LABORAGREEs)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.EMPGRP_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.LABORAGREEs1)
                .WithOptional(e => e.LOOKUPVAL1)
                .HasForeignKey(e => e.GROUPTYPE);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.LABORAGREEs2)
                .WithOptional(e => e.LOOKUPVAL2)
                .HasForeignKey(e => e.STATUS_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.LABORAGREEs3)
                .WithOptional(e => e.LOOKUPVAL3)
                .HasForeignKey(e => e.GROUP_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.LBRGRPS)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.GROUP_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.LBRGRPS1)
                .WithRequired(e => e.LOOKUPVAL1)
                .HasForeignKey(e => e.GROUP_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.MDS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.STATUSREASON_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.MDSCAPS)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.CAPDOMAIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ORDDATES)
                .WithRequired(e => e.LOOKUPVAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ORDPLANs)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.SERVTYPE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.ORDPLANSERVS)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.SERVTYPE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.PAYRECVALs)
                .WithRequired(e => e.LOOKUPVAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.POSITIONS)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.POS_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.SUPERTYPES)
                .WithRequired(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.WFALERTTASKS)
                .WithOptional(e => e.LOOKUPVAL)
                .HasForeignKey(e => e.DUE4_SUPERTYPE_ID);

            modelBuilder.Entity<LOOKUPVAL>()
                .HasMany(e => e.INFCONTACTs1)
                .WithMany(e => e.LOOKUPVALS)
                .Map(m => m.ToTable("SUPPARRANG").MapLeftKey("LOOKUPVAL_ID").MapRightKey("CONTACT_ID"));

            modelBuilder.Entity<MATCHRULEDEPT>()
                .Property(e => e.MATCHRULEDEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULEDEPT>()
                .Property(e => e.MATCHRULE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULEDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULEDEPT>()
                .Property(e => e.RULEREQ)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULEDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULEDEPT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULEDEPT>()
                .Property(e => e.RULEDATA)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULE>()
                .Property(e => e.MATCHRULE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULE>()
                .Property(e => e.DEFRULEDATA)
                .IsUnicode(false);

            modelBuilder.Entity<MATCHRULE>()
                .Property(e => e.RULEREQ)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .Property(e => e.STATUSREASON_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_A)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_AA)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_B)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_BB)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_C)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_CC)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_D)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_E)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_F)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_G)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_H)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_I)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_J)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_K)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_L)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_M)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_N)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_O)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_P)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_Q)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MD>()
                .HasOptional(e => e.MDSHC_X)
                .WithRequired(e => e.MD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MDSCAP>()
                .Property(e => e.CAP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCAP>()
                .Property(e => e.CAPDOMAIN)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCAP>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCAP>()
                .HasMany(e => e.ASSQMDSHCDEPENDS)
                .WithOptional(e => e.MDSCAP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MDSCHANGE>()
                .Property(e => e.CHANGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCHANGE>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCHANGE>()
                .Property(e => e.QUEST)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCHANGE>()
                .Property(e => e.OLDVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCHANGE>()
                .Property(e => e.NEWVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSCHANGE>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_A>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_A>()
                .Property(e => e.A_2_ASSREASON)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_A>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_A>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_A>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_3A_HEALTHNUM)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_3B_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_4_POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_1_LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_1_FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_1_MIDDLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_2_CASERECORD)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_3A_HEALTHNUMVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_AA>()
                .Property(e => e.AA_4_POSTAL_FLAG)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_B>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_B>()
                .Property(e => e.B_1_MEMORY)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_B>()
                .Property(e => e.B_2_COGSKILLS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_B>()
                .Property(e => e.B_3_DELIRIUM)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_B>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_B>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_B>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_2B_BIRTHEST)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_3_ABORIGINAL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_4_MARITAL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_5_LANG)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_6_EDU)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_7A_GUARDIAN)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_7B_MEDDIR)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_8_PAY)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_1_SEX)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_BB>()
                .Property(e => e.BB_5A_PRILANG)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.C_1_HEARING)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.C_2_EXPRESSION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.C_3_COMP)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.C_4_DECLINE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_C>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CC_2_REFREASON)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CC_3_GOALS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CC_4_LASTHOSP)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CC_5_RESIDENCE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CC_6_ROOMMATE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CC_7_PRIORCARE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CC_8_RESHIST)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_CC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_D>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_D>()
                .Property(e => e.D_1_VISION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_D>()
                .Property(e => e.D_2_VISLIMIT)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_D>()
                .Property(e => e.D_3_VISDECLINE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_D>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_D>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_D>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.E_1_DEPRESSED)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.E_2_MOODDECLINE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.E_3_BEHAVIOR)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.E_4_CHANGES)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_E>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_F>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_F>()
                .Property(e => e.F_1_INVOLVE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_F>()
                .Property(e => e.F_2_CHANGE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_F>()
                .Property(e => e.F_3_ISOLATION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_F>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_F>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_F>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1_PRI_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1E_PRILIVES)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1F_PRIREL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1_PRIHELP)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1_SEC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1E_SECLIVES)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1F_SECREL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1_SECHELP)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_2_CARESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_3A_WEEKDAYS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_3B_WEEKENDS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1AA_LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1AB_FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1A_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1BC_LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1BD_FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_G>()
                .Property(e => e.G_1B_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_1A_MEALS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_1B_HOUSEWORK)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_1C_FINANCES)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_1D_MEDS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_1E_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_1F_SHOPPING)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_1G_TRANSPORT)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_2_ADLSELF)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_3_ADLDECLINE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_4_LOCOMOTION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_5_STAIRS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_6_STAMINA)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.H_7_POTENTIAL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_H>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_I>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_I>()
                .Property(e => e.I_1_BLADDERCONT)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_I>()
                .Property(e => e.I_2_BLADDERDEV)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_I>()
                .Property(e => e.I_3_BOWELCONT)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_I>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_I>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_I>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_1_HEART)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_1_NEURO)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_1_MUSCULO)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_1_SENSES)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_1_MOOD)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_1_INFECTIONS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_1_OTHER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_2A_DIAGCODE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_2B_DIAGCODE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_2C_DIAGCODE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.J_2D_DIAGCODE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_J>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_1_PREVENT)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_2_PROBLEMS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_3_PROBPHYSICAL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_3_PROBMENTAL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_4_PAIN)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_5_FALLS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_6_FALLDANGER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_7_LIFESTYLE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_8_HEALTHSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.K_9_OTHERSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_K>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_L>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_L>()
                .Property(e => e.L_1_WEIGHT)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_L>()
                .Property(e => e.L_2_CONSUMPTION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_L>()
                .Property(e => e.L_3_SWALLOWING)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_L>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_L>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_L>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_M>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_M>()
                .Property(e => e.M_1_ORALSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_M>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_M>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_M>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.N_1_SKINPROB)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.N_2_ULCERS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.N_3_OTHERSKINPROB)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.N_4_PRESSUREULCER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.N_5_WOUNDCARE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_N>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_O>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_O>()
                .Property(e => e.O_1_HOMEENV)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_O>()
                .Property(e => e.O_2_LIVARRANGE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_O>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_O>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_O>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.P_2_SPECIAL)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.P_3_EQUIP)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.P_4_VISITS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.P_5_GOALS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.P_6_CHANGENEED)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.P_7_TRADEOFFS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_P>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.Q_1_NUMMEDS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.Q_2_PHYCHO)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.Q_3_OVERSIGHT)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.Q_4_ADHERENCE)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_Q>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_X>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_X>()
                .Property(e => e.X_70_ASSESSLOC)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_X>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_X>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHC_X>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHCCAP>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHCCAP>()
                .Property(e => e.CAP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHCCAP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSHCCAP>()
                .Property(e => e.TRIGGER_REASON)
                .IsUnicode(false);

            modelBuilder.Entity<MDSLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSLOG>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSLOG>()
                .Property(e => e.ACTION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSLOG>()
                .Property(e => e.SECTION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.MDS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.SECTION)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.QUEST)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.FOLLOWUP)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MDSNOTE>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALDI>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALDI>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALDI>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MEALITEM>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALITEM>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALITEM>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MEALITEM>()
                .Property(e => e.DESSERT)
                .IsUnicode(false);

            modelBuilder.Entity<MEALITEM>()
                .HasMany(e => e.MEALPLANDAYs)
                .WithMany(e => e.MEALITEMS)
                .Map(m => m.ToTable("MEALPLANITEMS").MapLeftKey("ITEM_ID").MapRightKey("DAY_ID"));

            modelBuilder.Entity<MEALPACK>()
                .Property(e => e.PACKAGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPACK>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPACK>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPACK>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPACK>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPACK>()
                .Property(e => e.HOTMEAL)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPACK>()
                .Property(e => e.FROZENMEAL)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPACK>()
                .HasMany(e => e.MEALITEMS)
                .WithMany(e => e.MEALPACKS)
                .Map(m => m.ToTable("MLPKITEMS").MapLeftKey("PACKAGE_ID").MapRightKey("ITEM_ID"));

            modelBuilder.Entity<MEALPLAN>()
                .Property(e => e.PLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPLAN>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPLAN>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPLAN>()
                .Property(e => e.KITCHEN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPLANDAY>()
                .Property(e => e.DAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALPLANDAY>()
                .Property(e => e.PLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.SCHEDTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ONSUN)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ONMON)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ONTUE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ONWED)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ONTHU)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ONFRI)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.ONSAT)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.SCHEDGEN)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.NONOTICE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.PLANNER)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHED>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHEDMEAL>()
                .Property(e => e.VISMEAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHEDMEAL>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHEDMEAL>()
                .Property(e => e.PACKAGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHEDMEAL>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHEDMEAL>()
                .Property(e => e.BILLABLE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHEDMEAL>()
                .Property(e => e.KITCHEN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSCHEDMEAL>()
                .HasMany(e => e.MEALVISITMEALS)
                .WithOptional(e => e.MEALSCHEDMEAL)
                .HasForeignKey(e => e.VISSMEAL_ID);

            modelBuilder.Entity<MEALSORT>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSORT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALSORT>()
                .Property(e => e.SORTORDER)
                .HasPrecision(20, 10);

            modelBuilder.Entity<MEALSORT>()
                .Property(e => e.SORTDONE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALTAB>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALTAB>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISITMEAL>()
                .Property(e => e.VISMEAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISITMEAL>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISITMEAL>()
                .Property(e => e.PACKAGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISITMEAL>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISITMEAL>()
                .Property(e => e.BILLABLE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISITMEAL>()
                .Property(e => e.VISSMEAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISITMEAL>()
                .Property(e => e.KITCHEN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.DAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.VISITTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.NONOTICE)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.PLANNER)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<MEALVISIT>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.MED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.BRANDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.DRUGNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.INSTRUCTIONS)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.DRUGFAMILY)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.WEBURL)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBU>()
                .Property(e => e.MESSAGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBU>()
                .Property(e => e.MESSAGESOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBU>()
                .Property(e => e.MESSAGETARGET)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBU>()
                .Property(e => e.MESSAGEHEADER)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBU>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBU>()
                .Property(e => e.STATEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBU>()
                .HasOptional(e => e.MESSAGEBUSDETAIL)
                .WithRequired(e => e.MESSAGEBU)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MESSAGEBUSDETAIL>()
                .Property(e => e.MESSAGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSDETAIL>()
                .Property(e => e.MESSAGEPAYLOAD)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSDETAIL>()
                .Property(e => e.MESSAGEATTRIBS)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSDETAIL>()
                .Property(e => e.MESSAGERESULTS)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSSUB>()
                .Property(e => e.MESSAGESUB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSSUB>()
                .Property(e => e.MESSAGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSSUB>()
                .Property(e => e.MESSAGETARGET)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSSUB>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSSUB>()
                .Property(e => e.STATEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGEBUSSUB>()
                .Property(e => e.MESSAGERESULTS)
                .IsUnicode(false);

            modelBuilder.Entity<MESSCONT>()
                .Property(e => e.MESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MESSCONT>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<MESSCONT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MESSCONT>()
                .Property(e => e.USESUGG)
                .IsUnicode(false);

            modelBuilder.Entity<MSACODE>()
                .Property(e => e.MSA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MSACODE>()
                .Property(e => e.MSACODE1)
                .IsUnicode(false);

            modelBuilder.Entity<MSACODE>()
                .Property(e => e.MSADESCR)
                .IsUnicode(false);

            modelBuilder.Entity<MSACODE>()
                .Property(e => e.WAGEINDEX)
                .HasPrecision(9, 4);

            modelBuilder.Entity<MSACODE>()
                .Property(e => e.AVAILABLE)
                .IsUnicode(false);

            modelBuilder.Entity<MSACODE>()
                .Property(e => e.RURALMSA)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MonthRevBenchmarks>()
                .Property(e => e.RevBenchmark)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_OnCallContactList>()
                .Property(e => e.OnCallNumber)
                .IsFixedLength();

            modelBuilder.Entity<NND_Report_Summary_DateMaster>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Summary_IntakeCount>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Summary_Master>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Summary_Master>()
                .Property(e => e.Revenue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NOTEPROGRESS>()
                .Property(e => e.PROGRESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTEPROGRESS>()
                .Property(e => e.NOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTEPROGRESS>()
                .Property(e => e.PNSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<NOTEPROGRESS>()
                .Property(e => e.PNCONTENTS)
                .IsUnicode(false);

            modelBuilder.Entity<NOTEPROGRESS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NOTEPROGRESS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.TEMPLATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.RECCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.CONTENTS)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETEMPLATE>()
                .Property(e => e.TEMPREADONLY)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.EDITABLE)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.DELETABLE)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.TRKPROGRESS)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.AUTODELETE)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.TEMPEDIT)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.SUBJLOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .Property(e => e.ALLOWTIME)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPE>()
                .HasMany(e => e.SPCNTTYPEs)
                .WithRequired(e => e.NOTETYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NOTETYPE>()
                .HasMany(e => e.SYSTEMs)
                .WithOptional(e => e.NOTETYPE)
                .HasForeignKey(e => e.SYNCNOTETYPE_ID);

            modelBuilder.Entity<NOTETYPE>()
                .HasMany(e => e.USERNOTES)
                .WithRequired(e => e.NOTETYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NOTETYPETPLATE>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPETPLATE>()
                .Property(e => e.TEMPLATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NOTETYPETPLATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.FORMAT)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.FORMULA)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.UNIQNUM)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.NUMTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.NOFREEFORM)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.NUMREQ)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.ADMINREF)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .Property(e => e.NUMMASK)
                .IsUnicode(false);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.CL_REFNOS)
                .WithRequired(e => e.NUMBER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.DEPTNUMS)
                .WithRequired(e => e.NUMBER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.EMPREFNOS)
                .WithRequired(e => e.NUMBER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.EXPPAYROLLs)
                .WithOptional(e => e.NUMBER)
                .HasForeignKey(e => e.CLTNUM);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.EXPPAYROLLs1)
                .WithOptional(e => e.NUMBER1)
                .HasForeignKey(e => e.EMPNUM);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.SYSTEMs)
                .WithOptional(e => e.NUMBER)
                .HasForeignKey(e => e.CLTNUMBER_ID);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.SYSTEMs1)
                .WithOptional(e => e.NUMBER1)
                .HasForeignKey(e => e.CLTSSN_ID);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.SYSTEMs2)
                .WithOptional(e => e.NUMBER2)
                .HasForeignKey(e => e.MDS_AA2_NUMBER_ID);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.SYSTEMs3)
                .WithOptional(e => e.NUMBER3)
                .HasForeignKey(e => e.MDS_AA3A_NUMBER_ID);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.SYSTEMs4)
                .WithOptional(e => e.NUMBER4)
                .HasForeignKey(e => e.CLPUSERCODE);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.SYSTEMs5)
                .WithOptional(e => e.NUMBER5)
                .HasForeignKey(e => e.CLPUSERPIN);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.USERS)
                .WithOptional(e => e.NUMBER)
                .HasForeignKey(e => e.FINDEREF);

            modelBuilder.Entity<NUMBER>()
                .HasMany(e => e.USERS1)
                .WithOptional(e => e.NUMBER1)
                .HasForeignKey(e => e.FINDCREF);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.NUTR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.FUNCTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.FUNCDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.INFCODE)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.SUPPDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.FURTHEVAL)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.HISTOUTCOM)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.HISTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.DNOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NUTRITION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.OASIS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.OASISVERSION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.OASISVERSION2)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HHA_AGENCY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0010_MEDICARE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0012_MEDICAID_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0014_BRANCH_STATE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0016_BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0020_PAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0040_PAT_FNAME)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0040_PAT_MI)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0040_PAT_LNAME)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0040_PAT_SUFFIX)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0050_PAT_ST)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0060_PAT_ZIP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0063_MEDICARE_NUM)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0064_SSN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0065_MEDICAID_NUM)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0069_PAT_GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0072_PHYSICIAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0072_CONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0080_ASSESSOR_DISCIPLINE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0100_ASSMT_REASON)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0140_ETHNIC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0150_CPAY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0150_CPAY_OTHERTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0175_DC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0175_DC_OTHERTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0190_14_DAY_INP1_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0190_14_DAY_INP2_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0200_REG_CHG_14_DAYS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0210_CHGREG_ICD1)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0210_CHGREG_ICD2)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0210_CHGREG_ICD3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0210_CHGREG_ICD4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0220_PRIOR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0230_PRIMARY_DIAG_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0230_PRIMARY_DIAG_SEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG1_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG1_SEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG2_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG2_SEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG3_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG3_SEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG4_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG4_SEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG5_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0240_OTH_DIAG5_SEVERITY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0250_THH)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0260_OVERALL_PROGNOSIS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0270_REHAB_PROGNOSIS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0280_LIFE_EXPECTANCY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0290_RSK)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0300_CURR_RESIDENCE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0300_CURR_RES_OTHERTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0340_LIV)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0350_AP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0360_PRIMARY_CAREGIVER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0370_FREQ_PRM_ASSTANCE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0380_CA)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0390_VISION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0400_HEARING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0410_SPEECH)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0420_FREQ_PAIN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0430_INTRACT_PAIN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0440_LESION_OPEN_WND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0445_PRESS_ULCER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0450_NBR_PRSULC_STG1)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0450_NBR_PRSULC_STG2)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0450_NBR_PRSULC_STG3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0450_NBR_PRSULC_STG4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0450_UNOBS_PRSULC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0460_STG_PRBLM_ULCER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0464_STAT_PRBLM_PRSULC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0468_STASIS_ULCER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0470_NBR_STASULC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0474_UNOBS_STASULC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0476_STAT_PRB_STASULC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0482_SURG_WOUND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0484_NBR_SURGWND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0486_UNOBS_SURGWND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0488_STAT_PRB_SURGWND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0490_WHEN_DYSPNEIC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0500_RESPTX)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0510_UTI)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0520_UR_INCONT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0530_UR_INCONT_OCCURS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0540_BWL_INCONT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0550_OSTOMY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0560_COG_FUNCTION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0570_WHEN_CONFUSED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0580_WHEN_ANXIOUS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0590_DP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0610_BD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0620_BEH_PROB_FREQ)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0630_REC_PSYCH_NURS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0640_PR_GROOMING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0640_CUR_GROOMING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0650_PR_DRESS_UPPER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0650_CUR_DRESS_UPPER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0660_PR_DRESS_LOWER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0660_CUR_DRESS_LOWER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0670_PR_BATHING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0670_CUR_BATHING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0680_PR_TOILETING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0680_CUR_TOILETING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0690_PR_TRANSFERRING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0690_CUR_TRANSFERRING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0700_PR_AMBULATION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0700_CUR_AMBULATION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0710_PR_FEEDING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0710_CUR_FEEDING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0720_PR_PREP_LT_MEALS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0720_CUR_PREP_LT_MEALS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0730_PR_TRANSPORTATION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0730_CUR_TRANSPORTATION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0740_PR_LAUNDRY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0740_CUR_LAUNDRY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0750_PR_HOUSEKEEPING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0750_CUR_HOUSEKEEPING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0760_PR_SHOPPING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0760_CUR_SHOPPING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0770_PR_PHONE_USE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0770_CUR_PHONE_USE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0780_PR_ORAL_MEDS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0780_CUR_ORAL_MEDS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0790_PR_INHAL_MEDS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0790_CUR_INHAL_MEDS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0800_PR_INJECT_MEDS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0800_CUR_INJECT_MEDS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0810_PAT_MGMT_EQUIP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0820_CG_MGMT_EQUIP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0825_THERAPY_NEED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0830_EC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0840_ECR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0855_INPAT_FACILITY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0870_DSCHG_DISP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0880_AFDC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0890_HOSP_RSN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0895_HOSP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0900_NH)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_AMPUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_BOWEL)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_CONTRACTURE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_HEARING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_PARALYSIS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_ENDURANCE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_AMBULATION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_SPEECH)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_BLIND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_DYSPNEA)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_OTHER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_FL_OTHERTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_COMPBEDREST)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_BEDREST)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_UPASTOLERATED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_TRANSFER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_EXERCISES)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_PARTWEIGHT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_INDEPENDENT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_CRUTCHES)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_CANE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_WHEELCHAIR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_WALKER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_NORESTRICT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_OTHER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_AP_OTHERTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_ORIENTED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_COMATOSE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_FORGETFUL)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_DEPRESSED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_DISORIENTED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_LETHARGIC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_AGITATED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_OTHER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_MS_OTHERTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.POT_PROGNOSIS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.SENT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.SENTUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HOLD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HOLD_USER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HHRG)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HIPPS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.LABORINDEX)
                .HasPrecision(9, 6);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.NLABORINDEX)
                .HasPrecision(9, 6);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.MSACODE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.MSAINDEX)
                .HasPrecision(9, 4);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.PPSAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.COMPLETED)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.DRORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.EXCLCLAIM)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.EXCLCLAIMUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.NOPLANOFCARE)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.STDPPSAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HHRGINDEX)
                .HasPrecision(9, 4);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0245_PMT_ICD1)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0245_PMT_ICD2)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.RURALMSA)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0110_EPISODE_TIMING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0826_THER_NEED_NUM)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0826_THER_NEED_NA)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_A3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_B3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_C3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_D3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_E3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_F3)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_A4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_B4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_C4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_D4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_E4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0246_PMT_DIAG_ICD_F4)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M0102_PHYSN_ORDRD_SOCROC_DT_NA)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1010_14_DAY_INP3_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1010_14_DAY_INP4_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1010_14_DAY_INP5_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1010_14_DAY_INP6_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1012_INP_PRCDR1_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1012_INP_PRCDR2_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1012_INP_PRCDR3_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1012_INP_PRCDR4_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1012_INP_NA_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1012_INP_UK_ICD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1016_CHGREG_ICD5)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1016_CHGREG_ICD6)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1016_CHGREG_ICD_NA)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1032_HOSP_RISK)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1034_PTNT_OVRAL_STUS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1040_INFLNZ_RCVD_AGNCY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1045_INFLNZ_RSN_NOT_RCVD)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1050_PPV_RCVD_AGNCY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1055_PPV_RSN_NOT_RCVD_AGNCY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1100_PTNT_LVG_STUTN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1210_HEARG_ABLTY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1220_UNDRSTG_VERBAL_CNTNT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1240_FRML_PAIN_ASMT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1242_PAIN_FREQ_ACTVTY_MVMT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1300_PRSR_ULCR_RISK_ASMT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1302_RISK_OF_PRSR_ULCR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1306_UNHLD_STG2_PRSR_ULCR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1307_OLDST_STG2_AT_DSCHRG)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1310_PRSR_ULCR_LNGTH)
                .HasPrecision(9, 4);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1312_PRSR_ULCR_WDTH)
                .HasPrecision(9, 4);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1314_PRSR_ULCR_DEPTH)
                .HasPrecision(9, 4);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1320_STUS_PRBLM_PRSR_ULCR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1330_STAS_ULCR_PRSNT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1332_NUM_STAS_ULCR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1334_STUS_PRBLM_STAS_ULCR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1340_SRGCL_WND_PRSNT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1342_STUS_PRBLM_SRGCL_WND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1350_LESION_OPEN_WND)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1500_SYMTM_HRT_FAILR_PTNTS)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1510_HRT_FAILR)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1615_INCNTNT_TIMING)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1730_STDZ_DPRSN_SCRNG)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1730_PHQ2_LACK_INTRST)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1730_PHQ2_DPRSN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1830_CRNT_BATHG)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1840_CUR_TOILTG)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1845_CUR_TOILTG_HYGN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1850_CUR_TRNSFRNG)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1860_CRNT_AMBLTN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HIPPS_VERSION)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.HIPPS_VALIDFLAG)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1900_PRIOR_ADLIADL)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1910_MLT_FCTR_FALL_RISK_ASMT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2000_DRUG_RGMN_RVW)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2002_MDCTN_FLWP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2004_MDCTN_INTRVTN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2010_HIGH_RISK_DRUG_EDCTN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2015_DRUG_EDCTN_INTRVTN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2020_CRNT_MGMT_ORAL_MDCTN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2030_CRNT_MGMT_INJCTN_MDCTN)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2040_PRIOR_MGMT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2100_CARE_TYPE_SRC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2110_ADL_IADL_ASTNC_FREQ)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2250_PLAN_SMRY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2300_EMER_USE_AFTR_LAST_ASMT)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2400_INTRVTN_SMRY)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M2420_DSCHRG_DISP)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.M1309_NBR_NEW_WRS_PRSULC)
                .IsUnicode(false);

            modelBuilder.Entity<OASIS>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCHANGE>()
                .Property(e => e.OASISCHG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCHANGE>()
                .Property(e => e.OASIS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCHANGE>()
                .Property(e => e.HHRG)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCHANGE>()
                .Property(e => e.HIPPS)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCHANGE>()
                .Property(e => e.PPSTOTAL)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OASISCHANGE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCOMM>()
                .Property(e => e.OASIS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCOMM>()
                .Property(e => e.M0NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCOMM>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCOMM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OASISCOMM>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.CALCREASON)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.CALCUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.BILLCALC)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.REVIEWED)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.REVIEWUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.CALCERROR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALC>()
                .HasMany(e => e.ORDCALCINVGRPs)
                .WithRequired(e => e.ORDCALC)
                .HasForeignKey(e => new { e.ORDER_ID, e.PERIOD_ID });

            modelBuilder.Entity<ORDCALCINVGRP>()
                .Property(e => e.INVGRP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALCINVGRP>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALCINVGRP>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALCINVGRP>()
                .Property(e => e.INVGROUPING)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCALCINVGRP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCCRULE>()
                .Property(e => e.ORDRULE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCCRULE>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCCRULE>()
                .Property(e => e.RULEMAX)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ORDCCRULE>()
                .Property(e => e.SERVAUTH)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCCRULE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCCRULE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCHART>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDCHART>()
                .Property(e => e.PROUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ORDCHART>()
                .Property(e => e.CHARTUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ORDDATE>()
                .Property(e => e.ORDDATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDDATE>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDDATE>()
                .Property(e => e.LOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDDATE>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<ORDDATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDDATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDDATE>()
                .Property(e => e.SERVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.DEFRATE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.AUTH_NO)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.HRSLEVEL)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USEOR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USEORORD)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.ORORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.ORCODETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.ORFUNDCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CANEXCEED)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.EXCEEDAMT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USECC)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CCORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CCCODETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CCFUNDRATE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USEEB)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.EBVALUE)
                .HasPrecision(7, 2);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.EBORDER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.EBCODETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.EBFUNDRATE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USERB)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RBVALUE)
                .HasPrecision(7, 2);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RBCODETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RBFUNDRATE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USETAXONE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USETAXTWO)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.ESSERVICE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.STATSERV)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.USEXVISDAY)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CPREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CLAST)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CFIRST)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CEXT)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RFAX)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RCITY)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RPROV)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RCOUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RPOSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SAMEASREG)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BFAX)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BCITY)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BPROV)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BCOUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.BPOSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.LVLVISITS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.GLACCT)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CLTADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.COORDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.COORDPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.COORDEXT)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SAP)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SIP)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.FIP)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.WARVET)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.COPYINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.COPYINVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.MSACODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.RECERTORD)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.KNOWNLUPA)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.HOLDCLAIM)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.BILLINGs)
                .WithOptional(e => e.ORDER)
                .HasForeignKey(e => e.OSOURCEORD);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.BILLINGs1)
                .WithRequired(e => e.ORDER1)
                .HasForeignKey(e => e.SOURCEORD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.BILLINGs2)
                .WithRequired(e => e.ORDER2)
                .HasForeignKey(e => e.TARGETORD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.BILLRECS)
                .WithOptional(e => e.ORDER)
                .HasForeignKey(e => e.ORDER_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.BILLSUMRECs)
                .WithOptional(e => e.ORDER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.CLTACTCs)
                .WithOptional(e => e.ORDER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.CLTDEPTs)
                .WithOptional(e => e.ORDER)
                .HasForeignKey(e => e.DEFORDER);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.CLTSERVS)
                .WithOptional(e => e.ORDER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.MEALSCHEDs)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.MEALVISITS)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.Oases)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.ORDCALCs)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .HasOptional(e => e.ORDCHART)
                .WithRequired(e => e.ORDER);

            modelBuilder.Entity<ORDEXCEED>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEXCEED>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDEXCEED>()
                .Property(e => e.MAXAMT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ORDEXCEED>()
                .Property(e => e.EXCEEDAMT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.ORDPLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.SERVTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.PLANCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.FREQTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.FREQVALUE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.FREQVALUEMIN)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.FREQUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.CUSTOMPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.FREQUNIT)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.SERVAUTH)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.FREQVISITS)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.FREQTIMEDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLAN>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANCANCEL>()
                .Property(e => e.ORDPLANCANCEL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANCANCEL>()
                .Property(e => e.ORDPLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANCANCEL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANCANCEL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANCANCEL>()
                .Property(e => e.REFDATA)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANSERV>()
                .Property(e => e.ORDPLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANSERV>()
                .Property(e => e.SERVTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDPLANSERV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDRULE>()
                .Property(e => e.ORDRULE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDRULE>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDRULE>()
                .Property(e => e.RULEMAX)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ORDRULE>()
                .Property(e => e.SERVAUTH)
                .IsUnicode(false);

            modelBuilder.Entity<ORDRULE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDRULE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDSTATHIST>()
                .Property(e => e.HISTORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDSTATHIST>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDSTATHIST>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDSTATHIST>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDSTATHIST>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ORDSTATHIST>()
                .Property(e => e.ACTDONE)
                .IsUnicode(false);

            modelBuilder.Entity<OUTCOME>()
                .Property(e => e.OUTCOME_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OUTCOME>()
                .Property(e => e.OUTTABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OUTCOME>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<OUTCOME>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<OUTCOME>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OUTCOME>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OUTTABLE>()
                .Property(e => e.OUTTABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OUTTABLE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<OUTTABLE>()
                .Property(e => e.GOALSTATAB)
                .IsUnicode(false);

            modelBuilder.Entity<OUTTABLE>()
                .Property(e => e.OUTSTATTAB)
                .IsUnicode(false);

            modelBuilder.Entity<OUTTABLE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OUTTABLE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OUTTABLE>()
                .HasMany(e => e.ACTIVITies)
                .WithOptional(e => e.OUTTABLE)
                .HasForeignKey(e => e.GOALTAB_ID);

            modelBuilder.Entity<OUTTABLE>()
                .HasMany(e => e.ACTIVITies1)
                .WithOptional(e => e.OUTTABLE1)
                .HasForeignKey(e => e.OUTTABLE_ID);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.OVERSERV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.RULEMAX)
                .HasPrecision(12, 4);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.AMTOVERAGED)
                .HasPrecision(12, 4);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OVERSERV>()
                .Property(e => e.BILLTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.PARTNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.PENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.LOGTRX)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNERXML>()
                .Property(e => e.PARTNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNERXML>()
                .Property(e => e.XML_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNERXML>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .Property(e => e.SHORTDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.ASSSECTS)
                .WithOptional(e => e.PATHCAT)
                .HasForeignKey(e => e.CAT_ID);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.ASSSECTS1)
                .WithOptional(e => e.PATHCAT1)
                .HasForeignKey(e => e.DCAT_ID);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.ASSSECTS2)
                .WithOptional(e => e.PATHCAT2)
                .HasForeignKey(e => e.FCAT_ID);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.CLTPATHFOCUS)
                .WithRequired(e => e.PATHCAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.PATHITEMS)
                .WithRequired(e => e.PATHCAT)
                .HasForeignKey(e => e.CAT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.PATHITEMS1)
                .WithRequired(e => e.PATHCAT1)
                .HasForeignKey(e => e.DCAT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.PATHITEMS2)
                .WithRequired(e => e.PATHCAT2)
                .HasForeignKey(e => e.FCAT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHCAT>()
                .HasMany(e => e.PATHSTEPS)
                .WithOptional(e => e.PATHCAT)
                .HasForeignKey(e => e.FCAT_ID);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.ISORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.LABELTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.FCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.DCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.IREQUIRED)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.COMPLETEONCE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.PRINTPOT)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.RECCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.CLTPATH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.ICOPY)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .Property(e => e.POTLABELTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<PATHITEM>()
                .HasMany(e => e.ASSQPATHDEPENDS)
                .WithOptional(e => e.PATHITEM)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PATHITEM>()
                .HasMany(e => e.CLTPATHITEMSXes)
                .WithRequired(e => e.PATHITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHITEM>()
                .HasMany(e => e.PATHSTEPITEMS)
                .WithRequired(e => e.PATHITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHITEM>()
                .HasMany(e => e.PATHSTEPITEMLINKS)
                .WithRequired(e => e.PATHITEM)
                .HasForeignKey(e => e.CHILDITEM_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHITEM>()
                .HasMany(e => e.PATHSTEPITEMLINKS1)
                .WithRequired(e => e.PATHITEM1)
                .HasForeignKey(e => e.PARENTITEM_ID);

            modelBuilder.Entity<PATHSTEPITEMLINK>()
                .Property(e => e.PARENTITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEMLINK>()
                .Property(e => e.CHILDITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEMLINK>()
                .Property(e => e.STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEMLINK>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.ITEM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.IREQUIRED)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.IDEFAULT)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.ILINKED)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEPITEM>()
                .Property(e => e.ICOPY)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.DEFDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.IGNORECOSTEP)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.FCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHSTEP>()
                .Property(e => e.LOCKVALUE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<PATHSTEP>()
                .HasMany(e => e.CLTPATHCOSTEPS)
                .WithRequired(e => e.PATHSTEP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHSTEP>()
                .HasMany(e => e.CLTPATHITEMS)
                .WithOptional(e => e.PATHSTEP)
                .HasForeignKey(e => e.OSTEP_ID);

            modelBuilder.Entity<PATHSTEP>()
                .HasMany(e => e.CLTPATHVISITS)
                .WithOptional(e => e.PATHSTEP)
                .HasForeignKey(e => e.MERGE_STEP_ID);

            modelBuilder.Entity<PATHSTEP>()
                .HasMany(e => e.CLTPATHVISITS1)
                .WithRequired(e => e.PATHSTEP1)
                .HasForeignKey(e => e.STEP_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHSTEP>()
                .HasMany(e => e.CLTPATHWAYS)
                .WithOptional(e => e.PATHSTEP)
                .HasForeignKey(e => e.MERGESTEP_ID);

            modelBuilder.Entity<PATHSTEP>()
                .HasMany(e => e.PATHSTEPITEMS)
                .WithRequired(e => e.PATHSTEP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHSTEP>()
                .HasMany(e => e.PATHWAYSTEPS)
                .WithRequired(e => e.PATHSTEP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.VCODE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.NOTAPPLICABLE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODE>()
                .HasMany(e => e.PATHVSUBCODES)
                .WithRequired(e => e.PATHVCODE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHVCODETABLE>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODETABLE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODETABLE>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODETABLE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODETABLE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVCODETABLE>()
                .HasMany(e => e.PATHVCODES)
                .WithRequired(e => e.PATHVCODETABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHVCODETABLE>()
                .HasMany(e => e.PATHWAYS)
                .WithRequired(e => e.PATHVCODETABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.VSUBCODE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.VCODE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.SUBCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.SUBDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHVSUBCODE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYDEPT>()
                .Property(e => e.PATHWAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.PATHWAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.CERTBY)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.CERTNOTICE)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.CHANGED)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.DIAGSTART)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.DIAGSTOP)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.ALLOWORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.DYNAMICITEMS)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.MULTIINCOMPLETES)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.SINGLESTEP)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.LINKEDITEMS)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .Property(e => e.LINKEDITEMSAUTOMET)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAY>()
                .HasMany(e => e.CLTPATHWAYS)
                .WithOptional(e => e.PATHWAY)
                .HasForeignKey(e => e.DPATHWAY_ID);

            modelBuilder.Entity<PATHWAY>()
                .HasMany(e => e.CLTPATHWAYS1)
                .WithRequired(e => e.PATHWAY1)
                .HasForeignKey(e => e.PATHWAY_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHWAY>()
                .HasMany(e => e.PATHWAYDEPTS)
                .WithRequired(e => e.PATHWAY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHWAY>()
                .HasMany(e => e.PATHWAYSTEPS)
                .WithRequired(e => e.PATHWAY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATHWAYSTEP>()
                .Property(e => e.PATHWAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYSTEP>()
                .Property(e => e.STEP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYSTEP>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYSTEP>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYSTEP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYSTEP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PATHWAYSTEP>()
                .Property(e => e.SCHANGED)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.LEVEL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.PAYTAB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.LOWHOURS)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.HIGHHOURS)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.EMPINACTIVE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.DEFPAYREC)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYLEVEL>()
                .HasMany(e => e.EMPLDEPTs)
                .WithOptional(e => e.PAYLEVEL)
                .HasForeignKey(e => e.PAYLEVEL_ID);

            modelBuilder.Entity<PAYLEVEL>()
                .HasMany(e => e.PAYRECORDS)
                .WithRequired(e => e.PAYLEVEL)
                .HasForeignKey(e => e.LEVEL_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.LEVEL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.SERVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.COSTCENTRE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.EMPPOS)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.REGRATE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.REGCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.REGUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.STATRATE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.STATCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.STATUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.EMPINACTIVE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.EMPSPEC)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.CLTFUNDER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.MASTERREC)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.MASTACCT)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.PARENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.EXPIRED)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECORD>()
                .HasMany(e => e.BILLRECS)
                .WithOptional(e => e.PAYRECORD)
                .HasForeignKey(e => e.PAYREC_ID);

            modelBuilder.Entity<PAYRECORD>()
                .HasMany(e => e.BILLRECS1)
                .WithOptional(e => e.PAYRECORD1)
                .HasForeignKey(e => e.EMPPAYREC_ID);

            modelBuilder.Entity<PAYRECORD>()
                .HasMany(e => e.EMPLDEPTs)
                .WithOptional(e => e.PAYRECORD)
                .HasForeignKey(e => e.DEFPAYREC);

            modelBuilder.Entity<PAYRECORD>()
                .HasMany(e => e.PAYLEVELS)
                .WithOptional(e => e.PAYRECORD)
                .HasForeignKey(e => e.DEFPAYREC);

            modelBuilder.Entity<PAYRECORD>()
                .HasMany(e => e.PAYRECORDS1)
                .WithOptional(e => e.PAYRECORD1)
                .HasForeignKey(e => e.MASTERREC);

            modelBuilder.Entity<PAYRECORD>()
                .HasMany(e => e.PAYRECORDS11)
                .WithOptional(e => e.PAYRECORD2)
                .HasForeignKey(e => e.PARENT_ID);

            modelBuilder.Entity<PAYRECORD>()
                .HasMany(e => e.PAYRECVALs)
                .WithRequired(e => e.PAYRECORD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PAYVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.LOOKUPVAL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PAYCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PAYRATE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PAYUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.OTFACTOR)
                .HasPrecision(12, 4);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PREMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PREMRATE)
                .HasPrecision(12, 4);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.PREMUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYRECVAL>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYTABLE>()
                .Property(e => e.PAYTAB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYTABLE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PAYTABLE>()
                .Property(e => e.EMPINACTIVE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYTABLE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYTABLE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PAYTABLE>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.PAYTABLE1)
                .HasForeignKey(e => e.PAYTABLE);

            modelBuilder.Entity<PAYTABLE>()
                .HasMany(e => e.PAYLEVELS)
                .WithRequired(e => e.PAYTABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PLANNER>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PLANNER>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.PLANNER)
                .HasForeignKey(e => e.CFPLANNER_ID);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.DEPARTMENTS1)
                .WithOptional(e => e.PLANNER1)
                .HasForeignKey(e => e.GVPLANNER_ID);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.FUNDDEPTs)
                .WithOptional(e => e.PLANNER)
                .HasForeignKey(e => e.STATPLAN);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.FUNDDEPTs1)
                .WithOptional(e => e.PLANNER1)
                .HasForeignKey(e => e.NOSTATPLAN);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.REMINDERS)
                .WithRequired(e => e.PLANNER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.USERPLANS)
                .WithRequired(e => e.PLANNER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.USERS)
                .WithOptional(e => e.PLANNER)
                .HasForeignKey(e => e.DEFPLAN);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.USERS1)
                .WithOptional(e => e.PLANNER1)
                .HasForeignKey(e => e.PLANNER_ID);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.WFALERTTASKS)
                .WithOptional(e => e.PLANNER)
                .HasForeignKey(e => e.PLANNER_ID);

            modelBuilder.Entity<PLANNER>()
                .HasMany(e => e.WFALERTTASKS1)
                .WithOptional(e => e.PLANNER1)
                .HasForeignKey(e => e.DUE4_PLANNER_ID);

            modelBuilder.Entity<PORTALACCESSRIGHT>()
                .Property(e => e.ACCESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALACCESSRIGHT>()
                .Property(e => e.ACCESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUPACCESS>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUPACCESS>()
                .Property(e => e.ACCESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUPACCESS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUP>()
                .Property(e => e.NOTICE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALGROUP>()
                .Property(e => e.PROMPTNOTICE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERCHANx>()
                .Property(e => e.CHANGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERCHANx>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERCHANx>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERCHANx>()
                .Property(e => e.USERDATA)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERDEPT>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSEREVENT>()
                .Property(e => e.USEREVENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSEREVENT>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSEREVENT>()
                .Property(e => e.EVENTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSEREVENT>()
                .Property(e => e.EVENTDETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERGROUP>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERGROUP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERROLE>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERROLE>()
                .Property(e => e.ROLETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERROLE>()
                .Property(e => e.ROLEAUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERROLE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.PREFS)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.CHGPASS)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.PASSNOEXPIRE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.AUTHTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.AUTHWINUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.TIMEZONE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.TIMEZONEDAYSAVINGS)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.USERROLE)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .Property(e => e.TZID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSER>()
                .HasMany(e => e.SYSAPPS)
                .WithRequired(e => e.PORTALUSER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.SESSION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.USERHASH)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.USERTOKEN)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.APPSETTINGS)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PORTALUSERSESSION>()
                .Property(e => e.DATA)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.POS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<PPSDIAG>()
                .Property(e => e.DIAGCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PPSDIAG>()
                .Property(e => e.DG)
                .IsUnicode(false);

            modelBuilder.Entity<PPSDIAG>()
                .Property(e => e.ALLOWPRIMARY)
                .IsUnicode(false);

            modelBuilder.Entity<PPSINDEX>()
                .Property(e => e.PPS_INDEX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PPSINDEX>()
                .Property(e => e.PPR)
                .HasPrecision(12, 2);

            modelBuilder.Entity<PPSINDEX>()
                .Property(e => e.LABOR)
                .HasPrecision(9, 6);

            modelBuilder.Entity<PPSINDEX>()
                .Property(e => e.NONLABOR)
                .HasPrecision(9, 6);

            modelBuilder.Entity<PPSINDEX>()
                .Property(e => e.PPRRURAL)
                .HasPrecision(12, 2);

            modelBuilder.Entity<PROTRANSLATE>()
                .Property(e => e.PTL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PROTRANSLATE>()
                .Property(e => e.PTLSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<PROTRANSLATE>()
                .Property(e => e.PTLFRENCH)
                .IsUnicode(false);

            modelBuilder.Entity<PROTRANSLATE>()
                .Property(e => e.PTLSPANISH)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.RAI_ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.CLTASS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.ASSESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.RFA)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.SUPPLEMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.FOLDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.EXPORT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.CANCELREASON)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_ASSESS>()
                .Property(e => e.EXPORTUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_CHANGE>()
                .Property(e => e.CHANGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_CHANGE>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_CHANGE>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_CHANGE>()
                .Property(e => e.OLDVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_CHANGE>()
                .Property(e => e.NEWVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.RAI_DATA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.RAI_ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.ASSESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.SECTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.QUESTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.DATAVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_DATA>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_LOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_LOG>()
                .Property(e => e.RAI_ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_LOG>()
                .Property(e => e.ASSESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_LOG>()
                .Property(e => e.SECTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_LOG>()
                .Property(e => e.QUESTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_LOG>()
                .Property(e => e.ACTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_LOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.RAI_NOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.RAI_ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.SECTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.QUESTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.FOLLOWUP)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_NOTES>()
                .Property(e => e.ASSESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.RAI_SECTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.RAI_ASSESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.ASSESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.SECTION)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.STATUSUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RAI_SECTION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RATECHART>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RATECHART>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RATECHART>()
                .Property(e => e.PROUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<RATECHART>()
                .Property(e => e.CHARTUNITS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<RATECODE>()
                .Property(e => e.CODE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RATECODE>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<RATECODE>()
                .Property(e => e.CODEVAL)
                .HasPrecision(8, 4);

            modelBuilder.Entity<RATECODE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RATECODE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RATECODE>()
                .HasMany(e => e.PAYRECORDS)
                .WithOptional(e => e.RATECODE)
                .HasForeignKey(e => e.REGRATE);

            modelBuilder.Entity<RATECODE>()
                .HasMany(e => e.PAYRECORDS1)
                .WithOptional(e => e.RATECODE1)
                .HasForeignKey(e => e.STATRATE);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.REMIND_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.DNOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.NOTIFYUSER)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.PRIVATE)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.PRIVUSER)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.REMINDTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REMOTETEAM>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REMOTETEAM>()
                .Property(e => e.USER_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<REMOTETEAM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.TEMPLATE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.REPORTKEY)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.TEMPLATE)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<REPORTTEMPLATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<REQDEF>()
                .Property(e => e.REQDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REQDEF>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<REQDEF>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<REQDEF>()
                .HasMany(e => e.ROUTESDEFS)
                .WithRequired(e => e.REQDEF)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REQDEF>()
                .HasMany(e => e.SERVREQS)
                .WithMany(e => e.REQDEFS)
                .Map(m => m.ToTable("REQDEFSRV").MapLeftKey("REQDEF_ID").MapRightKey("SERV_ID"));

            modelBuilder.Entity<RESOURCE>()
                .Property(e => e.RES_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RESOURCE>()
                .Property(e => e.RESTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RESOURCE>()
                .HasOptional(e => e.EMPLOYEE)
                .WithRequired(e => e.RESOURCE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<RESVI>()
                .Property(e => e.RESVIS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RESVI>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<RESVI>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RESVI>()
                .Property(e => e.ONETIME)
                .IsUnicode(false);

            modelBuilder.Entity<RESVI>()
                .HasMany(e => e.EMPLDEPTs)
                .WithRequired(e => e.RESVI)
                .HasForeignKey(e => e.EMP_ID);

            modelBuilder.Entity<RESVI>()
                .HasOptional(e => e.RESOURCE)
                .WithRequired(e => e.RESVI)
                .WillCascadeOnDelete();

            modelBuilder.Entity<RESVI>()
                .HasMany(e => e.VISITS)
                .WithOptional(e => e.RESVI)
                .HasForeignKey(e => e.EMP_ID);

            modelBuilder.Entity<ROUTEDAY>()
                .Property(e => e.DAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDAY>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDAY>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDAY>()
                .HasMany(e => e.ROUTEDDEFS)
                .WithRequired(e => e.ROUTEDAY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.ROUTEDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.DAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.REQDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.PAYABLE)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.ROUTESDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.VOLHOURS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ROUTEDDEF>()
                .Property(e => e.VOLKMS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<ROUTE>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE>()
                .Property(e => e.DISTRICT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTE>()
                .HasMany(e => e.ROUTESCHEDs)
                .WithRequired(e => e.ROUTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ROUTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ONSUN)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ONMON)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ONTUE)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ONWED)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ONTHU)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ONFRI)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.ONSAT)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .Property(e => e.SCHEDGEN)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESCHED>()
                .HasMany(e => e.ROUTEDAYS)
                .WithOptional(e => e.ROUTESCHED)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ROUTESCHED>()
                .HasMany(e => e.ROUTEDDEFS)
                .WithOptional(e => e.ROUTESCHED)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ROUTESCHED>()
                .HasMany(e => e.ROUTESDEFS)
                .WithRequired(e => e.ROUTESCHED)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROUTESDEF>()
                .Property(e => e.ROUTEDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESDEF>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESDEF>()
                .Property(e => e.REQDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESDEF>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESDEF>()
                .Property(e => e.PAYABLE)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESDEF>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ROUTESDEF>()
                .HasMany(e => e.ROUTEDDEFS)
                .WithOptional(e => e.ROUTESDEF)
                .HasForeignKey(e => e.ROUTESDEF_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RTABLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RFIELDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RFIELDALIAS)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RDATATYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RSELECTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RSEARCHABLE)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RSORTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RAUTOSEARCH)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RMANDATORY)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFIELD>()
                .Property(e => e.RCUSTOM)
                .IsUnicode(false);

            modelBuilder.Entity<RPTFOLDER>()
                .Property(e => e.RFOLDERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<RPTITEM>()
                .Property(e => e.RITEMNAME)
                .IsUnicode(false);

            modelBuilder.Entity<RPTITEM>()
                .Property(e => e.RRUNUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RPTITEM>()
                .Property(e => e.RCHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RPTITEM>()
                .Property(e => e.RINTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RPTJOIN>()
                .Property(e => e.RTABLENAME1)
                .IsUnicode(false);

            modelBuilder.Entity<RPTJOIN>()
                .Property(e => e.RTABLENAME2)
                .IsUnicode(false);

            modelBuilder.Entity<RPTJOIN>()
                .Property(e => e.RJOINTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RPTJOIN>()
                .Property(e => e.RFIELDNAMES1)
                .IsUnicode(false);

            modelBuilder.Entity<RPTJOIN>()
                .Property(e => e.ROPERATORS)
                .IsUnicode(false);

            modelBuilder.Entity<RPTJOIN>()
                .Property(e => e.RFIELDNAMES2)
                .IsUnicode(false);

            modelBuilder.Entity<RPTJOIN>()
                .Property(e => e.RCUSTOM)
                .IsUnicode(false);

            modelBuilder.Entity<RPTTABLE>()
                .Property(e => e.RTABLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<RPTTABLE>()
                .Property(e => e.RTABLEALIAS)
                .IsUnicode(false);

            modelBuilder.Entity<RPTTABLE>()
                .Property(e => e.RCUSTOM)
                .IsUnicode(false);

            modelBuilder.Entity<RPTUSERFOLD>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RPTUSERFOLD>()
                .Property(e => e.RDSGFOLDER)
                .IsUnicode(false);

            modelBuilder.Entity<RPTUSERFOLD>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RULE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.FUNDCCTYPEs)
                .WithRequired(e => e.RULE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.FUNDDEPTs)
                .WithOptional(e => e.RULE)
                .HasForeignKey(e => e.DEFORRULE);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.FUNDDEPTs1)
                .WithOptional(e => e.RULE1)
                .HasForeignKey(e => e.DEFCCRULE);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.FUNDDEPTs2)
                .WithOptional(e => e.RULE2)
                .HasForeignKey(e => e.DEFEBRULE);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.FUNDDEPTs3)
                .WithOptional(e => e.RULE3)
                .HasForeignKey(e => e.DEFRBRULE);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.FUNDEBTYPEs)
                .WithRequired(e => e.RULE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.ORDERS)
                .WithOptional(e => e.RULE)
                .HasForeignKey(e => e.RBRULE);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.ORDERS1)
                .WithOptional(e => e.RULE1)
                .HasForeignKey(e => e.EBRULE);

            modelBuilder.Entity<RULE>()
                .HasMany(e => e.OVERSERVs)
                .WithOptional(e => e.RULE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<RULESET>()
                .Property(e => e.RULESET_ID)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RULESET>()
                .HasMany(e => e.EMPCATS)
                .WithOptional(e => e.RULESET)
                .HasForeignKey(e => e.RULESET_ID);

            modelBuilder.Entity<RULESET>()
                .HasMany(e => e.EMPCATS1)
                .WithOptional(e => e.RULESET1)
                .HasForeignKey(e => e.RULESET_ID2);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.SCHEDTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.TYPEMDATE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHEDULE>()
                .HasMany(e => e.VISITOFFERLISTS)
                .WithOptional(e => e.SCHEDULE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SCHGROUPCLTREVIEW>()
                .Property(e => e.REVIEW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTREVIEW>()
                .Property(e => e.HISTORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTREVIEW>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTREVIEW>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTREVIEW>()
                .Property(e => e.REVIEWER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTREVIEW>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTREVIEW>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLT>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLT>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLT>()
                .HasMany(e => e.SCHGROUPCLTSTATES)
                .WithRequired(e => e.SCHGROUPCLT)
                .HasForeignKey(e => new { e.GROUP_ID, e.CLIENT_ID, e.DEPT_ID });

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.HISTORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.REASON)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.REFSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.REFDETAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.FAILEDADMISSION)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.ACUTECARE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.GOALOFCARE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.GOALNOTMET)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.RATINGTOOL)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.REFONWARD)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.REFONWARDNOTE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.FAILEDADMDETAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPCLTSTATE>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPEMP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPEMP>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPEMP>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPEMP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUPEMP>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.RECCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.SCHEDGROUP)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.SCHEDSUBGROUP)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.EXT)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.ADDR1)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.ADDR2)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.PROV)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.DIRECTIONS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.LOCATION)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.FFLOOR)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.FWARD)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.FUNIT)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.FROOM)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.BUDGETUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.BUDGETYEAR)
                .HasPrecision(12, 2);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.BUDGETMONTH)
                .HasPrecision(12, 2);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.BUDGETWEEK)
                .HasPrecision(12, 2);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.BUDGETDAY)
                .HasPrecision(12, 2);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.EMP_ID1)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.EMP_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.CLTDEFPAY)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.CLTDEFBILL)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.CLTDEFDIR)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<SCHGROUP>()
                .HasMany(e => e.SCHGROUPCLTS)
                .WithRequired(e => e.SCHGROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SCHGROUP>()
                .HasMany(e => e.SCHGROUPEMPS)
                .WithRequired(e => e.SCHGROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.SERVICE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.AUXCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .HasMany(e => e.ACTIVITies)
                .WithRequired(e => e.SERVICE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVREQ>()
                .Property(e => e.SERV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVREQ>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVREQ>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SERVREQ>()
                .Property(e => e.DETDESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SERVREQ>()
                .HasMany(e => e.CLTSERVS)
                .WithRequired(e => e.SERVREQ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVREQ>()
                .HasMany(e => e.EMPSERVS)
                .WithRequired(e => e.SERVREQ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVREQ>()
                .HasMany(e => e.ACTIVITies)
                .WithMany(e => e.SERVREQS)
                .Map(m => m.ToTable("SERVACTS").MapLeftKey("SERV_ID").MapRightKey("ACTIVITY_ID"));

            modelBuilder.Entity<SERVREQTAB>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVREQTAB>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SERVREQTAB>()
                .HasMany(e => e.SERVREQS)
                .WithRequired(e => e.SERVREQTAB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVTABLE>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVTABLE>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<SERVTABLE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SERVTABLE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SERVTABLE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SERVTABLE>()
                .HasMany(e => e.SERVICES)
                .WithRequired(e => e.SERVTABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.CODE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.SHIFTCODE1)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.DEFTIMES)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.DEFDUR)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.DURATION)
                .HasPrecision(9, 4);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.BILLDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.PAYDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SHIFTCODE>()
                .HasMany(e => e.VISITS)
                .WithOptional(e => e.SHIFTCODE1)
                .HasForeignKey(e => e.SHIFTCODE);

            modelBuilder.Entity<SPCNTTYPE>()
                .Property(e => e.NOTE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SPCNTTYPE>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SPCNTTYPE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<STATDEF>()
                .Property(e => e.STATDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<STATDEF>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STATDEF>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<STATHOLID>()
                .Property(e => e.HOLIDAY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<STATHOLID>()
                .Property(e => e.STATDEF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<STATHOLID>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.SUBCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.CAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.LOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.LABELNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.LABELTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.REFNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .Property(e => e.REFTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .HasMany(e => e.CLTSUBCATS)
                .WithRequired(e => e.SUBCATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .HasMany(e => e.CONSUBCATS)
                .WithRequired(e => e.SUBCATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBCATEGORY>()
                .HasMany(e => e.EMPSUBCATS)
                .WithRequired(e => e.SUBCATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUPERTYPE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SUPERTYPE>()
                .Property(e => e.SUPER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SUPERTYPE>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SUPERTYPE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SUPERTYPE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SUPERVISOR>()
                .Property(e => e.SUPER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SUPERVISOR>()
                .HasMany(e => e.CLTSUPERS)
                .WithRequired(e => e.SUPERVISOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUPERVISOR>()
                .HasMany(e => e.EMPSUPERS)
                .WithRequired(e => e.SUPERVISOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.PROCUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.USERHASH)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVER>()
                .Property(e => e.SYNCUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVERLOG>()
                .Property(e => e.SYNCLOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVERLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVERLOG>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVERLOG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVERLOG>()
                .Property(e => e.SYNCLOG)
                .IsUnicode(false);

            modelBuilder.Entity<SYNCSERVERLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.SYSAPP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.APPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.APP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.LICENSE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.APPTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.APPKEY)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.APPSETTINGS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.SYSSETTINGS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.LICENSES)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .Property(e => e.EXTERNALUSERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPP>()
                .HasMany(e => e.SYSAPPSLOGs)
                .WithRequired(e => e.SYSAPP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYSAPPSDEPT>()
                .Property(e => e.SYSAPP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPPSDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPPSDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPPSLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPPSLOG>()
                .Property(e => e.SYSAPP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSAPPSLOG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.SYSDOC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.DOCTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.REFVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.RECNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.AUXCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOC>()
                .HasOptional(e => e.SYSDOCSX)
                .WithRequired(e => e.SYSDOC)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SYSDOCSX>()
                .Property(e => e.SYSDOC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOCSX>()
                .Property(e => e.COMPRESSTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOCSX>()
                .Property(e => e.COMPRESSTYPEX)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOCSX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSDOCSX>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHASH>()
                .Property(e => e.HASHDATA)
                .IsUnicode(false);

            modelBuilder.Entity<SYSNEXTKEY>()
                .Property(e => e.KEYTABLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.REF_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.TEXTVAL)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.REFNUMBER1)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.REFNUMBER2)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.REFDATA)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.ALLOWEDIT)
                .IsUnicode(false);

            modelBuilder.Entity<SYSREF>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.COMPANY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.COMP_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PRI_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.SEC_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.ADDRESS_1)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.ADDRESS_2)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.POSTAL)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.BRANCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DEFEMPDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DEFCLTDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DEPTMODE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX1USE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX1VAL)
                .HasPrecision(7, 4);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX1GL)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX1NUM)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX1DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX2USE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX2VAL)
                .HasPrecision(7, 4);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX2GL)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX2NUM)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TAX2DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DEFCITY)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DEFPROV)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DEF_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.POLLUSERS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DBVERSION)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PROCURA)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.USEPAGER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PAGERSUFFIX)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PAGERNODASH)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CLPUSERCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CLPUSERPIN)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PROMPTLOG)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PROMPTMSG)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DEPTTAX)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CLTNUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CLTSSN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.MCAREPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.MCARENUM)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.MCAIDPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.MCAIDNUM)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.BRCHNUMNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.OASAUTOFILL)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.OASOVERWRITE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.REMOTEDB)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CLASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CFIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EXTENSION)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EXPPASS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.KICKIDLE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.SINGLELOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.RECYCLEPASS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.VALIDUNTIL)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EDCTIMEZONE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EDCDAYSAVINGS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.MDS_AA2_NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.MDS_AA3A_NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EDCSCHEDRETAIN)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.SYNCNOTETYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.CLTAREAREQ)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EMPAREAREQ)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.POSTALMASK)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PHONEMASK)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.DISORDERDEF)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.SYNCAUTOACCEPT)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.SYNCAUTOSYNC)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.AUTHTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EDCEMPADDR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.EDCEMPAUTO)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.WFENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.TZID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEM>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEMLOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEMLOG>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEMLOG>()
                .Property(e => e.LOGCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEMLOG>()
                .Property(e => e.AUX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEMLOG>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<SYSTEMLOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TIMECHANGE>()
                .Property(e => e.CHANGE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMECHANGE>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMECHANGE>()
                .Property(e => e.FIELDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<TIMECHANGE>()
                .Property(e => e.OLDVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<TIMECHANGE>()
                .Property(e => e.NEWVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.EMPCAT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.ON_CALL)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.VNDAY)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.VNEVENING)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.VNNIGHT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.OFFPLAN)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.OFFSUPER)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.ADMIN)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.CHUPDATES)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.PHYCONTACT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.PATCONFER)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.WHCREPORTS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.VHCREPORTS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.CONFHC)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.EDUORIENT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.EDUSPECIAL)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.EDUINSERV)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.EDUOTHER)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.TEAMMEET)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.TRAVELTIME)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.COMMINTER)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.COMMCOMM)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.COMMSTUD)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.VOLCOMM)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.COMMPAID)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.ONCALLWAIT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.PAYHOURS)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.HOMEMAKING)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.OTHERTIME)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMEDUTY>()
                .Property(e => e.ONCALLOUT)
                .HasPrecision(12, 4);

            modelBuilder.Entity<TIMELOG>()
                .Property(e => e.LOG_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMELOG>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMELOG>()
                .Property(e => e.ACTION)
                .IsUnicode(false);

            modelBuilder.Entity<TIMELOG>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .Property(e => e.PERIODOPEN)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .Property(e => e.LSTOPENUSR)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .Property(e => e.LSTCHGUSR)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .Property(e => e.LSTSTATUSR)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<TIMEPERIOD>()
                .HasMany(e => e.DEPTPERIODs)
                .WithRequired(e => e.TIMEPERIOD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.TRANSBATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.BATCHTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.BATCH_ID_1)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.BATCH_ID_2)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.BATCH_ID_3)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.PROPBAG)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSBATCH>()
                .HasMany(e => e.RAI_ASSESS)
                .WithOptional(e => e.TRANSBATCH)
                .HasForeignKey(e => e.EXPORT_ID);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.TRXBATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BNAME)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BTRXTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BTRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BPAYMETHOD)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BGROUPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BCOMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.NUMBER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BCOMPTOTAL)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BREFNUMLOGIC)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BPRINTRECEIPTS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.BPRINTTRXS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCH>()
                .HasMany(e => e.TRXBATCHFUNDERS)
                .WithRequired(e => e.TRXBATCH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRXBATCHFUNDER>()
                .Property(e => e.TRXBATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHFUNDER>()
                .Property(e => e.FUNDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHFUNDER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.TRXBATCHTRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.TRXBATCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.TRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.PAYMETHOD)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.REFNUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.GROUPNUM)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.PMTAMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRX>()
                .Property(e => e.LINEITEMPOST)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.TRXDET_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.TRXBATCHTRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.TRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.BILLINV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.PMTAMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.BILLING_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXBATCHTRXDET>()
                .Property(e => e.RECEIPTNUM)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.TRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.TRXTYPE1)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.SYSDEFINED)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.DGLACCT)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.CGLACCT)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.ARCHIVED)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.ARCHIVEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.GLOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .Property(e => e.CLOOKUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TRXTYPE>()
                .HasMany(e => e.BILLINVs)
                .WithRequired(e => e.TRXTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRXTYPE>()
                .HasMany(e => e.TRXBATCHes)
                .WithOptional(e => e.TRXTYPE)
                .HasForeignKey(e => e.BTRX_ID);

            modelBuilder.Entity<TRXTYPE>()
                .HasMany(e => e.TRXBATCHTRXes)
                .WithRequired(e => e.TRXTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERACCESS>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCESS>()
                .Property(e => e.ACCESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERACCESS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERDEPT>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERDEPT>()
                .HasMany(e => e.USERNOTES)
                .WithRequired(e => e.USERDEPT)
                .HasForeignKey(e => new { e.USER_ID, e.DEPT_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERDEPT>()
                .HasMany(e => e.USERPLANS)
                .WithRequired(e => e.USERDEPT)
                .HasForeignKey(e => new { e.USER_ID, e.DEPT_ID });

            modelBuilder.Entity<USERGROUP>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERGROUP>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERGROUP>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERLOG>()
                .Property(e => e.UL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERLOG>()
                .Property(e => e.LOGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERLOG>()
                .Property(e => e.LOGCMT)
                .IsUnicode(false);

            modelBuilder.Entity<USERNOTE>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERNOTE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERNOTE>()
                .Property(e => e.TYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERNOTE>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERPLAN>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERPLAN>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERPLAN>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERPLAN>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PASSWRD)
                .IsFixedLength();

            modelBuilder.Entity<USER>()
                .Property(e => e.ACTIVE)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.OT_NOTIFY)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.DEFDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PROMPTDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.ADDDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.CHKREMIND)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.NOTEUNFILL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.DURHRSMIN)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PRTBILLDUR)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.UPDBILLDUR)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PRTPAYDUR)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.UPDPAYDUR)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USEDEFPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.DEFPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USEDEFAREA)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.DEFAREA)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.CLTFIND)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FINDCREF)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FINDOFUND)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FINDOREF)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMPFIND)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FINDEREF)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.DEFSCHED)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.ALLPLANS)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PROMPTAVAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.DISP24H)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FWDREMIND)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FWDUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.DEFNOTETYPE)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FORCESYNCH)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.CHGPASS)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PASSNOEXPIRE)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.ADMINUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PROMPTLOG)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PROMPTMSG)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.SYNCAUTOACCEPT)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.SYNCAUTOSYNC)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.AUTHTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.AUTHWINUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.CLTFIND2)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMPFIND2)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FAVORITES)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL_SENDERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL_SENDEREMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL_ACCTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL_ACCTPASS)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL_SERVERADDR)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.ALWAYSONPOC)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FORCESYNCTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL_USESSL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL_USEFORDATEDNOTES)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.TZID)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.CLIENTS)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.CHKOUTUSER_ID);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.CONTACTS)
                .WithOptional(e => e.USER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USER>()
                .HasMany(e => e.INVALIDPASSes)
                .WithOptional(e => e.USER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USER>()
                .HasMany(e => e.REMINDERS)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.PRIVUSER);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.REMINDERS1)
                .WithOptional(e => e.USER1)
                .HasForeignKey(e => e.NOTIFYUSER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USER>()
                .HasMany(e => e.REMOTETEAMS)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.REMOTETEAMS1)
                .WithRequired(e => e.USER1)
                .HasForeignKey(e => e.USER_ID2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.REPORTTEMPLATES)
                .WithOptional(e => e.USER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USER>()
                .HasMany(e => e.RPTUSERFOLDs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.SYNCSERVERs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.USERSTATUS)
                .WithOptional(e => e.USER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USER>()
                .HasMany(e => e.WFALERTTASKS)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.WFALERTTASKS1)
                .WithOptional(e => e.USER1)
                .HasForeignKey(e => e.DUE4_USER_ID);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.STATUS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.KICKOUT)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.USRMESSAGE)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.TEMPUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.CURRLOC)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.ADDINFO)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.LOOKUPUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERSTATU>()
                .Property(e => e.ALWAYSONPOC)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCH>()
                .Property(e => e.SYNCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCH>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCH>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCH>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCHREC>()
                .Property(e => e.SYNCRECORD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCHREC>()
                .Property(e => e.SYNCH_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCHREC>()
                .Property(e => e.TABLENAME)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCHREC>()
                .Property(e => e.KEYFIELDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCHREC>()
                .Property(e => e.NEW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERSYNCHREC>()
                .Property(e => e.OLD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERVIPCLIENT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERVIPCLIENT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERVIPCLIENT>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USERVIPCLIENT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VALIDSUPER>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VALIDSUPER>()
                .Property(e => e.SUPER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VALIDSUPER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VALIDSUPER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VALIDSUPER>()
                .HasMany(e => e.SUPERTYPES)
                .WithRequired(e => e.VALIDSUPER)
                .HasForeignKey(e => new { e.DEPT_ID, e.SUPER_ID });

            modelBuilder.Entity<VALOUTTAB>()
                .Property(e => e.OUTTABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VALOUTTAB>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VALOUTTAB>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFERLIST>()
                .Property(e => e.VOFFERLIST_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFERLIST>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFERLIST>()
                .Property(e => e.OFFERTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFERLIST>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFERLIST>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFERLIST>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFERLIST>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.VOFFER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.VOFFERLIST_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.OFFERSCORE)
                .HasPrecision(12, 2);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.RESPTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VISITOFFER>()
                .Property(e => e.MANUALRESPONSE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.VISITTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.SHIFTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.DURATION)
                .HasPrecision(9, 4);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.BILLDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PAYDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.ESSERVICE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.DIRECT)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PAYABLE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.BILLABLE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.STATREASON)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.NONOTICE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.EMPCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.CLTCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.KEEPONPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.TIMESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.RECSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.CV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PERMVIS)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.REFCON)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PAYCODE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PAYRATE)
                .HasPrecision(8, 4);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PAYUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.EXPPAYROLL)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.EXCLUDETK)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PRICODE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PAYRTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.VREF)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.EMP_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.OFFERSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.VRECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.ORDPLAN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .HasMany(e => e.BILLINGs)
                .WithOptional(e => e.VISIT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VISIT>()
                .HasMany(e => e.CLTSERVS)
                .WithOptional(e => e.VISIT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VISIT>()
                .HasMany(e => e.EXPMILEAGEs)
                .WithOptional(e => e.VISIT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VISIT>()
                .HasMany(e => e.OVERSERVs)
                .WithOptional(e => e.VISIT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VISIT>()
                .HasOptional(e => e.VISITS1)
                .WithMany(e => e.VISITS);

            modelBuilder.Entity<WFACTION>()
                .Property(e => e.WFACTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFACTION>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<WFACTION>()
                .Property(e => e.ACTDATA)
                .IsUnicode(false);

            modelBuilder.Entity<WFACTION>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFACTION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFACTION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFACTION>()
                .HasMany(e => e.WFALERTACTIONS)
                .WithRequired(e => e.WFACTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.WFALERTACTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.WFALERT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.WFACTION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.WFACTDATA)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTACTION>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTDEPT>()
                .Property(e => e.WFALERT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTDEPT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTDEPT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFALERT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFEVENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFCOND)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFCOND_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFCONDCOMPTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFCONDCOMPVALUE)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFCONDCOMPACTION)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.WFCONTDATA)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.RECENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERT>()
                .HasMany(e => e.WFALERTDEPTS)
                .WithRequired(e => e.WFALERT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WFALERT>()
                .HasMany(e => e.WFALERTTASKS)
                .WithRequired(e => e.WFALERT)
                .HasForeignKey(e => e.WFALERT_ID);

            modelBuilder.Entity<WFALERT>()
                .HasMany(e => e.WFALERTTASKS1)
                .WithOptional(e => e.WFALERT1)
                .HasForeignKey(e => e.COMP_WFALERT_ID);

            modelBuilder.Entity<WFALERT>()
                .HasMany(e => e.WFALERTTASKS2)
                .WithOptional(e => e.WFALERT2)
                .HasForeignKey(e => e.DISM_WFALERT_ID);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.WFALERTTASK_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.WFALERT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.NOTIFYUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.NOTIFY_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DUE1_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DUE2_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DUE3_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DUE4_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DUE4_USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DUE4_PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DUE4_SUPERTYPE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.COMP_WFALERT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.DISM_WFALERT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFALERTTASK>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFCONDITION>()
                .Property(e => e.WFCOND_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFCONDITION>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<WFCONDITION>()
                .Property(e => e.CONDDATA)
                .IsUnicode(false);

            modelBuilder.Entity<WFCONDITION>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFCONDITION>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFCONDITION>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFEVENT>()
                .Property(e => e.WFEVENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFEVENT>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<WFEVENT>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFEVENT>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFEVENT>()
                .HasMany(e => e.WFALERTS)
                .WithRequired(e => e.WFEVENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WFTASKDET>()
                .Property(e => e.WFTASK_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASKDET>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASKDET>()
                .Property(e => e.EVENTDATA)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASKDET>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASKDET>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.WFTASK_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.WFALERTTASK_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.CCONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.RECCLASS)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.RECSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.STATUSREASON)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.ACTIVESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.TASKPRIORITY)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.NOTIFYUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.PARENTWFTASK_ID)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .Property(e => e.PROPS)
                .IsUnicode(false);

            modelBuilder.Entity<WFTASK>()
                .HasOptional(e => e.WFTASKDET)
                .WithRequired(e => e.WFTASK)
                .WillCascadeOnDelete();

            modelBuilder.Entity<WFTASK>()
                .HasMany(e => e.WFTASKS1)
                .WithOptional(e => e.WFTASK1)
                .HasForeignKey(e => e.PARENTWFTASK_ID);

            modelBuilder.Entity<XMLTRX>()
                .Property(e => e.XML_ID)
                .IsUnicode(false);

            modelBuilder.Entity<XMLTRX>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<XMLTRX>()
                .Property(e => e.XENABLED)
                .IsUnicode(false);

            modelBuilder.Entity<XMLTRX>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<XMLTRX>()
                .Property(e => e.XMLTAG)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.SystemUser)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.TerritoryName)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.ServiceType)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.ReferralSource)
                .IsUnicode(false);

            modelBuilder.Entity<FROM_NND_Report_Client_Stats>()
                .Property(e => e.Revenue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.PREFS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.CHGPASS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.PASSNOEXPIRE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.AUTHTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.AUTHWINUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.TIMEZONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.TIMEZONEDAYSAVINGS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.USERROLE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_BACKUP_PORTALUSERS>()
                .Property(e => e.TZID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallForwardActive>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallForwardHistory>()
                .Property(e => e.CallForwardNumber)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallForwardHistory>()
                .Property(e => e.Visit_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallForwardSchedule>()
                .Property(e => e.AutoCallForwardDay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallForwardSchedule>()
                .Property(e => e.AutoCallForwardPerson)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallForwardSchedule>()
                .Property(e => e.AutoCallForwardNumber)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallForwardSchedule>()
                .Property(e => e.NightShiftOnCallNumber)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallForwardSchedule>()
                .Property(e => e.NightShiftOnCallPerson)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallForwardSettings>()
                .Property(e => e.CallForwardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallForwardSettings>()
                .Property(e => e.AutoCallForwardDay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallForwardSettings>()
                .Property(e => e.AutoCallForwardPerson)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallForwardSettings>()
                .Property(e => e.AutoCallForwardNumber)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.AssignedUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.Call_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.EMP_LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.EMP_FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.EMP_HOMEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.EMP_CELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.TimeDifference)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.CV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.Dept_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.CLIENTFULLNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.CLIENTHOMEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.CLIENTWORKPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.EDCTimeZone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.CallForwardNumber)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallMeAlert>()
                .Property(e => e.Perm_Cntry)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeInvestigated>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Emp_name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Visit_start)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Visit_stop)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Local_Time)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.CallMe_popup)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Hidden_on)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.CallMe_Start)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.CallMe_Stop)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Telephony_received)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Caring_Consult_Visit)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Dummy_Visit____5_mins_)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Double_Visits)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.EDCTimeZone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.HOMEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.CELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Client_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Client_Home_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.Client_Work_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.CV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeReport_temp>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CallMeTollFrees>()
                .Property(e => e.StateProv)
                .IsFixedLength();

            modelBuilder.Entity<NND_CallMeUserStatus>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CompetitorBenchmarks>()
                .Property(e => e.Year1Rev)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_CompetitorBenchmarks>()
                .Property(e => e.Year2Rev)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_CompetitorBenchmarks>()
                .Property(e => e.Year3Rev)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_CRM_Area>()
                .Property(e => e.PostalZIP)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Area>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Area>()
                .Property(e => e.ProvState)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Area>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Area>()
                .Property(e => e.NPA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Area>()
                .Property(e => e.NXX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_ContactDepts>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.Contact_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.Salutation)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.WorkPhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.ProvState)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Contacts>()
                .Property(e => e.FileStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_ContactTypes>()
                .Property(e => e.ContactTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Departments>()
                .Property(e => e.StateProv)
                .IsFixedLength();

            modelBuilder.Entity<NND_CRM_Departments>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Departments>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<NND_CRM_Departments>()
                .Property(e => e.AltNumber)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.AssignedUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.ClLocation)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.DNType)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.DNCHGUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.DNNote_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.DNContents)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteAlert>()
                .Property(e => e.ClDept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteExcludedDepts>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteExcludedDepts>()
                .Property(e => e.ExcludedBy)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteExcludedUsers>()
                .Property(e => e.CHGUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteExcludedUsers>()
                .Property(e => e.ExcludedBY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNoteInvestigated>()
                .Property(e => e.Note_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DatedNotesRTActiveDepts>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DeptPostalLookup>()
                .Property(e => e.FSAbeforeaddingZIPcodes)
                .IsFixedLength();

            modelBuilder.Entity<NND_DeptPostalLookup>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_DeptPostalLookup>()
                .Property(e => e.FSA)
                .IsFixedLength();

            modelBuilder.Entity<NND_DeptTerritories>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth001)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth002)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth003)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth004)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth005)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth006)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth007)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth008)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth009)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth010)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth011)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth012)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth013)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth014)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth015)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth016)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth017)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth018)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth019)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth020)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth021)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth022)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth023)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth024)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth025)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth026)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth027)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth028)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth029)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth030)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth031)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth032)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth033)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth034)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth035)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth036)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth037)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth038)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth039)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth040)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth041)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth042)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth043)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth044)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth045)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth046)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth047)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth048)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth049)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth050)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth051)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth052)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth053)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth054)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth055)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth056)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth057)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth058)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth059)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth060)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth061)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth062)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth063)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth064)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth065)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth066)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth067)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth068)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth069)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth070)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth071)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth072)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth073)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth074)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth075)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth076)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth077)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth078)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth079)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth080)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth081)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth082)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth083)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth084)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth085)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth086)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth087)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth088)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth089)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth090)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth091)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth092)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth093)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth094)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth095)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth096)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth097)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth098)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth099)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth100)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth101)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth102)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth103)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth104)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth105)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth106)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth107)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth108)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth109)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth110)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth111)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth112)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth113)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth114)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth115)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth116)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth117)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth118)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth119)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth120)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.ActualMonth)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevActuals>()
                .Property(e => e.InactiveTier)
                .IsFixedLength();

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.Tier)
                .IsFixedLength();

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth01)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth02)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth03)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth04)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth05)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth06)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth07)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth08)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth09)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth10)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth11)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FinDashboardRevBenchmarks>()
                .Property(e => e.BenchMonth12)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_FPGroupLocations>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_FPGroups>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_FPGroupUsers>()
                .Property(e => e.User_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_FPGroupUsers>()
                .Property(e => e.AliasName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_HiddenCallMeClientsTracking>()
                .Property(e => e.Action)
                .IsFixedLength();

            modelBuilder.Entity<NND_MSG_CarrierDomains>()
                .Property(e => e.Carrier)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_CarrierDomains>()
                .Property(e => e.domain)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_CarrierDomains>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_CourtesyFollowUp>()
                .Property(e => e.SPOC)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_CourtesyFollowUp>()
                .Property(e => e.CFUBody)
                .IsFixedLength();

            modelBuilder.Entity<NND_MSG_CourtesyFollowUp>()
                .Property(e => e.MSGSentbyUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_CourtesyFollowUp_HideHistory>()
                .Property(e => e.HiddenByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_EMPEmailAddresses>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_EMPEmailAddresses>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_EMPEmailAddresses>()
                .Property(e => e.ByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_ErrorLookup>()
                .Property(e => e.ErrorDescription)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_EventLog>()
                .Property(e => e.EventDescription)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_EventLogCodes>()
                .Property(e => e.EventCategory)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_EventLogCodes>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Feedback>()
                .Property(e => e.MSGCode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Feedback>()
                .Property(e => e.ReplyAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Feedback>()
                .Property(e => e.ReplyMsg)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.EmailID)
                .IsFixedLength();

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.ExchMsgID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.MsgSubject)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.MsgBody2)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.MsgCode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.ManualMatchByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.MsgType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.MsgSeriesCode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.MSGSenderAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.AssignedUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.ProcessCountry)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox>()
                .Property(e => e.MsgBody)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox_HideHistory>()
                .Property(e => e.HiddenByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox_Replies>()
                .Property(e => e.MSGBody)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox_Replies>()
                .Property(e => e.MSGSentByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox_Replies>()
                .Property(e => e.EmpMSGAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Inbox_Replies>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_MatchResult>()
                .Property(e => e.MatchDescription)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_MatchResult>()
                .Property(e => e.MSGCode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.AssignedUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.DayName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.ClientFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.Dur)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.VisitType)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.Planner_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.Visit_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.MsgCode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.PayCode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.AssignUserGroup)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.ClientLastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.AcceptedEmp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.AcceptedByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.CV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Planner>()
                .Property(e => e.VisitStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Reminders>()
                .Property(e => e.Visit_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Reminders>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Reminders>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Reminders>()
                .Property(e => e.MSGBody)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems>()
                .Property(e => e.dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems>()
                .Property(e => e.MSGCode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems>()
                .Property(e => e.SPOC)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems>()
                .Property(e => e.MSGBody)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems>()
                .Property(e => e.MSGSentByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems>()
                .Property(e => e.Client_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems_Recipients>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems_Recipients>()
                .Property(e => e.EmpMsgAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SentItems_Visits>()
                .Property(e => e.Visit_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.ExchangeWebService)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SQLServerName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.TextingUserName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.TextingUserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.MessageProcessingServerName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway1CurrentSMSDeviceName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway2CurrentSMSDeviceName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway3CurrentSMSDeviceName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway1CurrentSMSDeviceID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway2CurrentSMSDeviceID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway3CurrentSMSDeviceID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway1Status)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway2Status)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway3Status)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway1StatusTimeStamp)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway2StatusTimeStamp)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.SMSGateway3StatusTimeStamp)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.TwilioACCOUNTS_IDAC)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_Settings>()
                .Property(e => e.TwilioAUTH_TOKEN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SMS>()
                .Property(e => e.NoProcuraIDCountry)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SMS_Recipients>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_SMS_Recipients>()
                .Property(e => e.EmpMsgAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_UnattachedSentItems>()
                .Property(e => e.MSGBody)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_UnattachedSentItems>()
                .Property(e => e.SentByUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_UnattachedSentItems>()
                .Property(e => e.EmpMSGAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_MSG_UnattachedSentItems>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Client_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.EmailAddr)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.PERM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.PERM_POST)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.PERM_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Home_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.PermAddr_1)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.PERM_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Job_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Technician_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Platinum_Service)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.Revenue)
                .HasPrecision(38, 8);

            modelBuilder.Entity<NND_NPIClientDataUpload>()
                .Property(e => e.RevenueCat)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtFirstname)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtLastname)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtPhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtStreet)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtCity)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtProvince)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtPostal)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.HTStatusCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.HTContactID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.CRMContactID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIDNC>()
                .Property(e => e.txtHTLastUpdate)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.PERM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.PERM_POST)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.PERM_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.PermAddr_1)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.PERM_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.Job_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.Technician_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.Platinum_Service)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.Revenue)
                .HasPrecision(38, 8);

            modelBuilder.Entity<NND_NPIEmployeeDataUpload>()
                .Property(e => e.RevenueCat)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.Client_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.PERM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.PERM_POST)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.PERM_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.PermAddr_1)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.PERM_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.Job_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.Technician_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.Platinum_Service)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.Revenue)
                .HasPrecision(38, 8);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.RevenueCat)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.txtHTLastUpdate)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Clients>()
                .Property(e => e.HTStatusCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.EMAILADDR)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.PERM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.PERM_POST)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.PERM_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.PermAddr_1)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.PERM_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.Job_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.Technician_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.Platinum_Service)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.Revenue)
                .HasPrecision(38, 8);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.RevenueCat)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.txtHTLastUpdate)
                .IsUnicode(false);

            modelBuilder.Entity<NND_NPIListen360Employees>()
                .Property(e => e.HTStatusCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.AssignedUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.DayName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.Dur)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.VisitType)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.Planner_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.Visit_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.ProvState)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.ClientFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.CSCDepartmentGrouping)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.VisitIntakeUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerAlert>()
                .Property(e => e.VisitChgUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_PlannerInvestigated>()
                .Property(e => e.Planner_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.Revenue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.AvgServiceRevenuePerHour)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.Visit_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.Client_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.ClientStateProv)
                .IsFixedLength();

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.CurrentClientStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.VisitCHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.visitINTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.CLTLastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.CLTFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.RevenueStatAdjusted)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.Expenses)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.FunderName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.Funder_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.VisitStatus)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.ServiceTypeDesc)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.BillUnits)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.BillRate)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.BillDur)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.EMPLastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_Client_Counts>()
                .Property(e => e.EMPFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.visit_id)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vstatus)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.visdur)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vbilldur)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vpaydur)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.PayRec_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vpaycode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vpayrate)
                .HasPrecision(8, 4);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vpayrtcode)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vshift)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vpayunits)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vbillable)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vpayable)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vtimestatus)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vreason)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.vnonotice)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.clastname)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.cfirstname)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.cmiddle)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.ccltid)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.carea)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.caddr1)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.caddr2)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.ccity)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.cprov)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.cpost)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.elastname)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.efirstname)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.emiddle)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.eempid)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.earea)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.chomephone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.cworkphone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.cworkext)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.ocoordname)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.bbillunits)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_CSC_Cancelations_Temp>()
                .Property(e => e.bbillrate)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_REPORT_DeptPostalCodes>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_REPORT_DeptPostalCodes>()
                .Property(e => e.FSA)
                .IsFixedLength();

            modelBuilder.Entity<NND_Report_EmployeeUsers>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_EmployeeUsers>()
                .Property(e => e.dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_EmployeeUsers>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_EmployeeUsers>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_EmployeeUsers>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_EmployeeUsers>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_EmployeeUsers>()
                .Property(e => e.EmpCatName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.Revenue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.AvgServiceRevenuePerHour)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.Visit_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.Client_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.ClientStateProv)
                .IsFixedLength();

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.CurrentClientStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.VisitCHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.visitINTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.Emp_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.CLTLastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.CLTFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.RevenueStatAdjusted)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.Expenses)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.FunderName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.Funder_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.PAYABLE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.BILLABLE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.EmpCatName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.CLTIntakeUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.CLTIntakeUserLN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.CLTIntakeUserFN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.DNCLTIntakeUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.DNCLTIntakeUserLN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.DNCLTIntakeUserFN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.NoBIll1stVisitIntakeUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.NoBIll1stVisitIntakeUserLN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.NoBIll1stVisitIntakeUserFN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.C1stVisitWithRevIntakeUser)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.C1stVisitWithRevIntakeUserLN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.C1stVisitWithRevIntakeUserFN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.VisitEmpFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.VisitEmpLastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.DNCLTSubject)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.CLTIntakeUserCatName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.DNCLTIntakeUserCatName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.VisitIntakeUserCatName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars>()
                .Property(e => e.ServiceTypeDesc)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_DatedNotes>()
                .Property(e => e.Note_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_DatedNotes>()
                .Property(e => e.ENTRYBY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_DatedNotes>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_DatedNotes>()
                .Property(e => e.Client_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.CLTFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.CLTLastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.Home_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.EmailAddr)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.Postal_Zip_Valid)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.Home_Phone_Valid)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.Email_Valid)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.DOB_Valid)
                .IsUnicode(false);

            modelBuilder.Entity<NND_Report_StarWars_Prepped>()
                .Property(e => e.Has_Consult_File)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ICEmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.SORTORDER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.CONTACT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ICSalutation)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ICFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ICLastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ICHOmePhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ICWorkPhone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.CELLPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ADDRESS_1)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.ClientFullName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Client_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.SALUTATION)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.EmailAddr)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.PERM_CITY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.PERM_POST)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.PERM_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Home_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.PermAddr_1)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.PERM_CNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Job_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Technician_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Platinum_Service)
                .IsUnicode(false);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.Revenue)
                .HasPrecision(38, 8);

            modelBuilder.Entity<NND_TempNPSContactCount>()
                .Property(e => e.RevenueCat)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.VISIT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.SCHED_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.CLIENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.VISITTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.SHIFTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.DURATION)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.BILLDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PAYDUR)
                .HasPrecision(9, 4);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.ESSERVICE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.DIRECT)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PAYABLE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.BILLABLE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.STATREASON)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.NONOTICE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.EMPCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.CLTCONFIRM)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.KEEPONPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PLANNER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.TIMESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PERIOD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.RECSOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.CV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PERMVIS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.REFCON)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PAYCODE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PAYRATE)
                .HasPrecision(8, 4);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PAYUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.EXPPAYROLL)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.EXCLUDETK)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PRICODE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.PAYRTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.GROUP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.VREF)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.EMP_ID2)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.OFFERSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<NND_VAN_VISITS>()
                .Property(e => e.VRECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Franchise_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Title)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Email_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Mobile_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_City)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Region)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Postal_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Country)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Customer_Company)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Job_Unique_Reference)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Job_Date)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Technician)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Technician_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Platinum_Service)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.RevenueCat)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.CallDate)
                .HasPrecision(3);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.Intakes_Responsibility)
                .IsUnicode(false);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.DEPTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.ENTRYBY)
                .IsUnicode(false);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.Referral)
                .IsUnicode(false);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<tblCaringConsult>()
                .Property(e => e.Dept_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.BILLREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.TABLE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.SERVTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.BILLCODE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.BILLRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.BILLUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.USEEMPPAY)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.REVCODE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.EXPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.STATCODE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.STATRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.STATUNITS)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.STATEMPPAY)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.STATREV)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.STATEXP)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.TRAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.RECTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.LIVEIN)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.USEPAYOVER)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.PAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.ORDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.USETAX1)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.USETAX2)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.EMPPAYREC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.AUXCODE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.REQCODE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.MASTACCT)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.INTAKEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.CHGUSER)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.TRX_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.ESTCOST)
                .HasPrecision(9, 4);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.RATEGROUPER)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.DISCIPLINE)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.PARENT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.EXPIRED)
                .IsUnicode(false);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.CNTRRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.CNTRSTATRATE)
                .HasPrecision(9, 4);

            modelBuilder.Entity<temp_save_Billrecs>()
                .Property(e => e.USECLIENTRATES)
                .IsUnicode(false);
        }
    }
}
