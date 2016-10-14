/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.Process;
using Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.Statefull;
using Sage.CA.SBS.ERP.Sage300.AP.Interfaces.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.AP.Interfaces.BusinessRepository.Process;
using Sage.CA.SBS.ERP.Sage300.AP.Models;
using Sage.CA.SBS.ERP.Sage300.AP.Models.Process;
using Sage.CA.SBS.ERP.Sage300.AR.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.AR.BusinessRepository.Statefull;
using Sage.CA.SBS.ERP.Sage300.AR.Models;
using Sage.CA.SBS.ERP.Sage300.AS.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.AS.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Authentication;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table.Entities;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.CS.BusinessRepository.Statefull;
using Sage.CA.SBS.ERP.Sage300.CS.Models;
using Sage.CA.SBS.ERP.Sage300.GL.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.GL.BusinessRepository.Process;
using Sage.CA.SBS.ERP.Sage300.GL.BusinessRepository.Reports;
using Sage.CA.SBS.ERP.Sage300.GL.BusinessRepository.Statefull;
using Sage.CA.SBS.ERP.Sage300.GL.Interfaces.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.GL.Interfaces.BusinessRepository.Process;
using Sage.CA.SBS.ERP.Sage300.GL.Interfaces.BusinessRepository.Reports;
using Sage.CA.SBS.ERP.Sage300.GL.Interfaces.BusinessRepository.Statefull;
using Sage.CA.SBS.ERP.Sage300.GL.Models;
using Sage.CA.SBS.ERP.Sage300.GL.Models.Process;
using Sage.CA.SBS.ERP.Sage300.GL.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.IC.BusinessRepository.Process;
using Sage.CA.SBS.ERP.Sage300.IC.Interfaces.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.IC.Interfaces.BusinessRepository.Process;
using Sage.CA.SBS.ERP.Sage300.IC.Models;
using Sage.CA.SBS.ERP.Sage300.IC.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.IC.Models.Process;
using CSRepository = Sage.CA.SBS.ERP.Sage300.CS.BusinessRepository;
using User = Sage.CA.SBS.ERP.Sage300.AS.Models.User;
using Sage.CA.SBS.ERP.Sage300.Common.Audit.Session;
using Sage.CA.SBS.ERP.Sage300.AP.Interfaces.BusinessRepository.Email;
using Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.Email;
using Sage.CA.SBS.ERP.Sage300.AP.Models.Email;

namespace Sage.CA.SBS.ERP.Sage300.Worker.Bootstrapper
{
    /// <summary>
    /// Class for Bootstrapper methods
    /// </summary>
    public static class Bootstrapper
    {
        #region Public Methods

        private static readonly IUnityContainer UnityContainer;

        /// <summary>
        /// Initialize the container
        /// </summary>
        static Bootstrapper()
        {
            UnityContainer = Initialise();
        }

        /// <summary>
        /// Get the Unity container
        /// </summary>
        public static IUnityContainer Container
        {
            get { return UnityContainer; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialising IUnity Container
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            return container;
        }

        /// <summary>
        /// Builds UnityContainer
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new SageUnityContainer();
            RegisterTypes(container);
            RegisterAzureTypes(container);
            RegisterExporytImportTypes(container);
            RegisterLandlordRepository(container);
            return container;
        }

        /// <summary>
        /// Register Azure types
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterAzureTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType(container, typeof(IBlobContainerFactory), typeof(AzureBlobContainerFactory));
            UnityUtil.RegisterType(container, typeof(ISession), typeof(SessionEntity));
        }

        /// <summary>
        /// Register Azure types
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterExporytImportTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType(container, typeof(IExportImport), typeof(Core.ExportImport.EpPlusExportImport));

        }

        /// <summary>
        /// Register types
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterTypes(IUnityContainer container)
        {
            #region GL
            UnityUtil.RegisterType(container, typeof(IBusinessEntity), typeof(BusinessEntity));
            UnityUtil.RegisterType(container, typeof(ICreateNewYearEntity<CreateNewYear>), typeof(CreateNewYearRepository<CreateNewYear>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(ICreateNewYearEntity<CreateNewYear>), typeof(CreateNewYearRepository<CreateNewYear>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IBatchStatusEntity<BatchStatus>), typeof(BatchStatusRepository<BatchStatus>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IBatchStatusEntity<BatchStatus>), typeof(BatchStatusRepository<BatchStatus>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IPeriodEndMaintenanceEntity<PeriodEndMaintenance>), typeof(PeriodEndMaintenanceRepository<PeriodEndMaintenance>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPeriodEndMaintenanceEntity<PeriodEndMaintenance>), typeof(PeriodEndMaintenanceRepository<PeriodEndMaintenance>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(ICreateRecurringEntriesBatchEntity<CreateRecurringEntriesBatch>), typeof(CreateRecurringEntriesBatchRepository<CreateRecurringEntriesBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(ICreateRecurringEntriesBatchEntity<CreateRecurringEntriesBatch>), typeof(CreateRecurringEntriesBatchRepository<CreateRecurringEntriesBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(GL.Interfaces.BusinessRepository.IOptionsEntity<GL.Models.Options>), typeof(GL.BusinessRepository.OptionsRepository<GL.Models.Options>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(GL.Interfaces.BusinessRepository.IOptionsEntity<GL.Models.Options>), typeof(GL.BusinessRepository.OptionsRepository<GL.Models.Options>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IJournalEntryEntity<JournalBatch, JournalEntry, JournalDetail>), typeof(JournalEntryRepository<JournalBatch, JournalEntry, JournalDetail>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IJournalEntryEntity<JournalBatch, JournalEntry, JournalDetail>), typeof(JournalEntryRepository<JournalBatch, JournalEntry, JournalDetail>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IPostJournalEntity<PostJournal>), typeof(PostJournalRepository<PostJournal>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPostJournalEntity<PostJournal>), typeof(PostJournalRepository<PostJournal>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IBatchListEntity<JournalBatch>), typeof(BatchListRepository<JournalBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IBatchListEntity<JournalBatch>), typeof(BatchListRepository<JournalBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IBatchListingReportRepository<BatchListing>), typeof(BatchListingRepository<BatchListing>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IBatchListingReportRepository<BatchListing>), typeof(BatchListingRepository<BatchListing>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IPostingJournalUpdateClearEntity<PostingJournalUpdateClear>), typeof(PostingJournalUpdateClearRepository<PostingJournalUpdateClear>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPostingJournalUpdateClearEntity<PostingJournalUpdateClear>), typeof(PostingJournalUpdateClearRepository<PostingJournalUpdateClear>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IDataIntegrityEntity<DataIntegrity>), typeof(DataIntegrityRepository<DataIntegrity>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IDataIntegrityEntity<DataIntegrity>), typeof(DataIntegrityRepository<DataIntegrity>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));


            UnityUtil.RegisterType<IExportImportRepository, JournalEntryRepository<JournalBatch, JournalEntry, JournalDetail>>(container, "journalentry", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, SourceCodeRepository<SourceCode>>(container, "sourcecode", new InjectionConstructor(typeof(Context)));
            //UnityUtil.RegisterType<IExportImportRepository, GL.BusinessRepository.SegmentCodeRepository<AccountSegments>>(container, "segmentcode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AccountStructureRepository<AccountStructure>>(container, "accountstructure", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, GL.BusinessRepository.AccountGroupRepository<GL.Models.AccountGroup>>(container, "accountgroup", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, RecurringEntriesRepository<RecurringJournalHeader, RecurringEntryDetails>>(container, "recurringentry", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, OptionalFieldRepository<GL.Models.OptionalFields>>(container, "optionalfields", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AccountRepository<Account>>(container, "account", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.BankOptionsRepository<BankOptions>>(container, "bankoptions", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AccountSegmentRepository<AccountSegments>>(container, "segmentcode", new InjectionConstructor(typeof(Context)));
            #endregion

            #region AR
            UnityUtil.RegisterType<IExportImportRepository, AR.BusinessRepository.OptionalFieldRepository<Sage.CA.SBS.ERP.Sage300.AR.Models.OptionalFieldHeader, Sage.CA.SBS.ERP.Sage300.AR.Models.OptionalFieldDetail>>(container, "aroptionalfield", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AR.BusinessRepository.PaymentCodeRepository<AR.Models.PaymentCodes>>(container, "paymentcode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AR.BusinessRepository.DistributionCodeRepository<AR.Models.DistributionCodes>>(container, "distributioncode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, BillingCyclesRepository<BillingCycles>>(container, "billingcycle", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CommentTypeRepository<CommentType>>(container, "commenttype", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AR.BusinessRepository.AccountSetRepository<AR.Models.AccountSet>>(container, "araccountset", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, DunningMessageRepository<DunningMessage>>(container, "dunningmessage", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AR.BusinessRepository.SalespersonRepository<AR.Models.Salesperson>>(container, "salesperson", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.IProcessYearEndEntity<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.ProcessYearEnd>), typeof(Sage.CA.SBS.ERP.Sage300.AR.BusinessRepository.Process.ProcessYearEndRepository<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.ProcessYearEnd>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.IProcessYearEndEntity<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.ProcessYearEnd>), typeof(Sage.CA.SBS.ERP.Sage300.AR.BusinessRepository.Process.ProcessYearEndRepository<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.ProcessYearEnd>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.ICreateGLBatchEntity<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.CreateGLBatch>), typeof(Sage.CA.SBS.ERP.Sage300.AR.BusinessRepository.Process.CreateGLBatchRepository<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.CreateGLBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.ICreateGLBatchEntity<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.CreateGLBatch>), typeof(Sage.CA.SBS.ERP.Sage300.AR.BusinessRepository.Process.CreateGLBatchRepository<Sage.CA.SBS.ERP.Sage300.AR.Models.Process.CreateGLBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IPostBatchEntity<AR.Models.PostBatch>), typeof(AR.BusinessRepository.PostBatchRepository<AR.Models.PostBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IPostBatchEntity<AR.Models.PostBatch>), typeof(AR.BusinessRepository.PostBatchRepository<AR.Models.PostBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType<IExportImportRepository, AR.BusinessRepository.EmailMessageRepository<AR.Models.EmailMessages>>(container, "emailmessage", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, InterestProfileRepository<InterestProfile, InterestRatesByCurrency>>(container, "interestprofiles", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, TermsCodeRepository<TermsCodeHeader, TermsCodeDetail>>(container, "arterms", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AR.BusinessRepository.OptionalFieldRepository<Sage.CA.SBS.ERP.Sage300.AR.Models.OptionalFieldHeader, Sage.CA.SBS.ERP.Sage300.AR.Models.OptionalFieldDetail>>(container, "aroptionalfield", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IInvoiceBatchListEntity<AR.Models.InvoiceBatch>), typeof(AR.BusinessRepository.InvoiceBatchListRepository<AR.Models.InvoiceBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IInvoiceBatchListEntity<AR.Models.InvoiceBatch>), typeof(AR.BusinessRepository.InvoiceBatchListRepository<AR.Models.InvoiceBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IPostInvoiceEntity<AR.Models.PostInvoice>), typeof(AR.BusinessRepository.PostInvoiceRepository<AR.Models.PostInvoice>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IPostInvoiceEntity<AR.Models.PostInvoice>), typeof(AR.BusinessRepository.PostInvoiceRepository<AR.Models.PostInvoice>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.ISelectCustomerEntity<AR.Models.Process.SelectCustomer>), typeof(AR.BusinessRepository.Process.SelectCustomerRepository<AR.Models.Process.SelectCustomer>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.ISelectCustomerEntity<AR.Models.Process.SelectCustomer>), typeof(AR.BusinessRepository.Process.SelectCustomerRepository<AR.Models.Process.SelectCustomer>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));


            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.IAgedRetainageDocumentEntity<AR.Models.Process.AgedRetainageDocument>), typeof(AR.BusinessRepository.Process.AgedRetainageDocumentRepository<AR.Models.Process.AgedRetainageDocument>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.IAgedRetainageDocumentEntity<AR.Models.Process.AgedRetainageDocument>), typeof(AR.BusinessRepository.Process.AgedRetainageDocumentRepository<AR.Models.Process.AgedRetainageDocument>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IReceiptBatchListEntity<ReceiptEntryBatch>), typeof(ReceiptBatchListRepository<ReceiptEntryBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.IReceiptBatchListEntity<ReceiptEntryBatch>), typeof(ReceiptBatchListRepository<ReceiptEntryBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.IUpdatePrintStatusEntity<AR.Models.Process.UpdatePrintStatus>), typeof(AR.BusinessRepository.Process.UpdatePrintStatusRepository<AR.Models.Process.UpdatePrintStatus>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Process.IUpdatePrintStatusEntity<AR.Models.Process.UpdatePrintStatus>), typeof(AR.BusinessRepository.Process.UpdatePrintStatusRepository<AR.Models.Process.UpdatePrintStatus>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Email.IInvoiceEmailEntity<AR.Models.Email.InvoiceEmail>), typeof(AR.BusinessRepository.Email.InvoiceEmailRepository<AR.Models.Email.InvoiceEmail>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(AR.Interfaces.BusinessRepository.Email.IInvoiceEmailEntity<AR.Models.Email.InvoiceEmail>), typeof(AR.BusinessRepository.Email.InvoiceEmailRepository<AR.Models.Email.InvoiceEmail>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            #endregion

            #region IC

            UnityUtil.RegisterType<IExportImportRepository, IC.BusinessRepository.SegmentCodeRepository<IC.Models.SegmentCode>>(container, "icsegmentcode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, UnitsOfMeasureRepository<UnitsOfMeasure>>(container, "icunitsofmeasure", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, WeightUnitOfMeasureRepository<WeightUnitOfMeasure>>(container, "weightunitsofmeasure", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, IC.BusinessRepository.AccountSetRepository<IC.Models.AccountSet>>(container, "icaccountset", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IC.Interfaces.BusinessRepository.Process.IDayEndProcessingEntity<IC.Models.Process.DayEndProcessing>), typeof(IC.BusinessRepository.Process.DayEndProcessingRepository<IC.Models.Process.DayEndProcessing>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IC.Interfaces.BusinessRepository.Process.IDayEndProcessingEntity<IC.Models.Process.DayEndProcessing>), typeof(IC.BusinessRepository.Process.DayEndProcessingRepository<IC.Models.Process.DayEndProcessing>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(IC.Interfaces.BusinessRepository.Process.ICreateGLBatchEntity<IC.Models.Process.CreateGLBatch>), typeof(IC.BusinessRepository.Process.CreateGLBatchRepository<IC.Models.Process.CreateGLBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IC.Interfaces.BusinessRepository.Process.ICreateGLBatchEntity<IC.Models.Process.CreateGLBatch>), typeof(IC.BusinessRepository.Process.CreateGLBatchRepository<IC.Models.Process.CreateGLBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType<IExportImportRepository, ItemStructureRepository<ItemStructure>>(container, "itemstructure", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, Sage.CA.SBS.ERP.Sage300.IC.BusinessRepository.OptionalFieldRepository<Sage.CA.SBS.ERP.Sage300.IC.Models.OptionalFieldHeader, Sage.CA.SBS.ERP.Sage300.IC.Models.OptionalFieldDetail>>(container, "icoptionalfield", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, Sage.CA.SBS.ERP.Sage300.IC.BusinessRepository.ItemRepository<Sage.CA.SBS.ERP.Sage300.IC.Models.Item, Sage.CA.SBS.ERP.Sage300.IC.Models.ItemUnitOfMeasure>>(container, "item", new InjectionConstructor(typeof(Context)));

            UnityUtil.RegisterType<IExportImportRepository, LocationRepository<Locations>>(container, "location", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CategoryRepository<Category, CategoryTaxAuthority>>(container, "category", new InjectionConstructor(typeof(Context)));

            UnityUtil.RegisterType<IExportImportRepository, Sage.CA.SBS.ERP.Sage300.IC.BusinessRepository.PriceListCodeRepository<Sage.CA.SBS.ERP.Sage300.IC.Models.PriceListCodes, Sage.CA.SBS.ERP.Sage300.IC.Models.PriceListCodesChecks>>(container, "icpricelistcode", new InjectionConstructor(typeof(Context)));

            #endregion

            #region AS
            UnityUtil.RegisterType<IExportImportRepository, UserAuthorizationRepository<User>>(container, "userauthorization", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, SecurityGroupRepository<SecurityGroup>>(container, "securitygroup", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, SecurityGroupSystemRepository<SecurityGroup>>(container, "securitygroupsystem", new InjectionConstructor(typeof(Context)));

            #endregion

            #region AP

            //Invoice Batch List screen
            UnityUtil.RegisterType(container, typeof(IInvoiceBatchListEntity<AP.Models.InvoiceBatch>), typeof(AP.BusinessRepository.InvoiceBatchListRepository<AP.Models.InvoiceBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IInvoiceBatchListEntity<AP.Models.InvoiceBatch>), typeof(AP.BusinessRepository.InvoiceBatchListRepository<AP.Models.InvoiceBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IInvoiceEntity<AP.Models.Invoice>), typeof(AP.BusinessRepository.InvoiceRepository<AP.Models.Invoice>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IInvoiceEntity<AP.Models.Invoice>), typeof(AP.BusinessRepository.InvoiceRepository<AP.Models.Invoice>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IPostInvoiceEntity<AP.Models.PostInvoice>), typeof(AP.BusinessRepository.PostInvoiceRepository<AP.Models.PostInvoice>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPostInvoiceEntity<AP.Models.PostInvoice>), typeof(AP.BusinessRepository.PostInvoiceRepository<AP.Models.PostInvoice>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(ICreateRecurPayBatchEntity<CreateRecurPayBatch>), typeof(CreateRecurPayBatchRepository<CreateRecurPayBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(ICreateRecurPayBatchEntity<CreateRecurPayBatch>), typeof(CreateRecurPayBatchRepository<CreateRecurPayBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            //Email messages
            UnityUtil.RegisterType<IExportImportRepository, Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.EmailMessageRepository<Sage.CA.SBS.ERP.Sage300.AP.Models.EmailMessage>>(container, "emailmessages", new InjectionConstructor(typeof(Context)));

            UnityUtil.RegisterType<IExportImportRepository, AP.BusinessRepository.DistributionCodeRepository<AP.Models.DistributionCode>>(container, "apdistributioncode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AP.BusinessRepository.CPRSCodeRepository<AP.Models.CPRSCode>>(container, "apcprscode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AP.BusinessRepository.PaymentCodeRepository<AP.Models.PaymentCode>>(container, "appaymentcode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, AP.BusinessRepository.AccountSetRepository<AP.Models.AccountSet>>(container, "apaccountset", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, DistributionSetRepository<DistributionSetHeader, DistributionSetDetail>>(container, "apdistributionset", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, VendorRepository<Vendor, VendorOptionalFieldValue>>(container, "vendor", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, TermCodeRepository<TermCodeHeader, TermCodeDetail>>(container, "apterms", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(Sage.CA.SBS.ERP.Sage300.AP.Interfaces.BusinessRepository.Process.IProcessYearEndEntity<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.ProcessYearEnd>), typeof(Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.Process.ProcessYearEndRepository<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.ProcessYearEnd>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(Sage.CA.SBS.ERP.Sage300.AP.Interfaces.BusinessRepository.Process.IProcessYearEndEntity<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.ProcessYearEnd>), typeof(Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.Process.ProcessYearEndRepository<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.ProcessYearEnd>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType(container, typeof(Sage.CA.SBS.ERP.Sage300.AP.Interfaces.BusinessRepository.Process.ICreateGLBatchEntity<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.CreateGLBatch>), typeof(Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.Process.CreateGLBatchRepository<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.CreateGLBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(Sage.CA.SBS.ERP.Sage300.AP.Interfaces.BusinessRepository.Process.ICreateGLBatchEntity<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.CreateGLBatch>), typeof(Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.Process.CreateGLBatchRepository<Sage.CA.SBS.ERP.Sage300.AP.Models.Process.CreateGLBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            UnityUtil.RegisterType<IExportImportRepository, DistributionSetRepository<DistributionSetHeader, DistributionSetDetail>>(container, "apdistributionset", new InjectionConstructor(typeof(Context)));
            
            // Payment Batch List.
            UnityUtil.RegisterType(container, typeof(IPaymentBatchEntity<PaymentAdjustmentBatch>), typeof(PaymentBatchRepository<PaymentAdjustmentBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPaymentBatchEntity<PaymentAdjustmentBatch>), typeof(PaymentBatchRepository<PaymentAdjustmentBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IPaymentBatchListEntity<PaymentAdjustmentBatch>), typeof(PaymentBatchListRepository<PaymentAdjustmentBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPaymentBatchListEntity<PaymentAdjustmentBatch>), typeof(PaymentBatchListRepository<PaymentAdjustmentBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IPostPaymentAdjustmentEntity<PostPaymentAdjustment>), typeof(PostPaymentAdjustmentRepository<PostPaymentAdjustment>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPostPaymentAdjustmentEntity<PostPaymentAdjustment>), typeof(PostPaymentAdjustmentRepository<PostPaymentAdjustment>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(IPostBatchEntity<AP.Models.PostBatch>), typeof(Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.PostBatchRepository<AP.Models.PostBatch>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IPostBatchEntity<AP.Models.PostBatch>), typeof(Sage.CA.SBS.ERP.Sage300.AP.BusinessRepository.PostBatchRepository<AP.Models.PostBatch>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            // AP Transaction and Vendor Report Entries - Starts
            //Processing Report for Aged Payables
            UnityUtil.RegisterType(container, typeof(IAgeDocumentEntity<AgeDocument>), typeof(AgeDocumentRepository<AgeDocument>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IAgeDocumentEntity<AgeDocument>), typeof(AgeDocumentRepository<AgeDocument>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            //Processing Report for Aged Retainage
            UnityUtil.RegisterType(container, typeof(IAgeRetainageDocumentEntity<AgeRetainageDocument>), typeof(AgeRetainageDocumentRepository<AgeRetainageDocument>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IAgeRetainageDocumentEntity<AgeRetainageDocument>), typeof(AgeRetainageDocumentRepository<AgeRetainageDocument>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            
            //Select Vendors
            UnityUtil.RegisterType(container, typeof(ISelectVendorEntity<SelectVendor>), typeof(SelectVendorRepository<SelectVendor>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(ISelectVendorEntity<SelectVendor>), typeof(SelectVendorRepository<SelectVendor>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            // AP Transaction and Vendor Report Entries - Ends

            /*AP Email Report*/
            UnityUtil.RegisterType(container, typeof(ILetterAndLabelEmailEntity<LetterAndLabelEmail>), typeof(LetterAndLabelEmailRepository<LetterAndLabelEmail>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(ILetterAndLabelEmailEntity<LetterAndLabelEmail>), typeof(LetterAndLabelEmailRepository<LetterAndLabelEmail>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            /*AP Email Report*/

			 // AP-CPRS Electronic Filing Process
            UnityUtil.RegisterType(container, typeof(ICPRSElectronicFilingEntity<CPRSElectronicFiling>), typeof(CPRSElectronicFilingRepository<CPRSElectronicFiling>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(ICPRSElectronicFilingEntity<CPRSElectronicFiling>), typeof(CPRSElectronicFilingRepository<CPRSElectronicFiling>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));


            #region Control payments

            UnityUtil.RegisterType(container, typeof(IControlPaymentEntity<ControlPayment>), typeof(ControlPaymentRepository<ControlPayment>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IControlPaymentEntity<ControlPayment>), typeof(ControlPaymentRepository<ControlPayment>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession))); 

            #endregion

            #endregion

            #region CS

            UnityUtil.RegisterType<IExportImportRepository, CSRepository.CurrencyRateTypeRepository<CurrencyRateType>>(container, "currencyratetype", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.CompanyProfileRepository<CompanyProfile>>(container, "companyprofile", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.FiscalCalendarRepository<CS.Models.FiscalCalendar>>(container, "fiscalcalendar", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.BankOptionsRepository<BankOptions>>(container, "bankoptions", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, BankDistributionCodeRepository<BankDistributionCode, BankDistributionCodeTaxDetail>>(container, "bankdistributioncode", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, BankDistributionSetRepository<BankDistributionSetHeader, BankDistributionSetDetail>>(container, "distributionset", new InjectionConstructor(typeof(Context)));   
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.TaxClassRepository<TaxAuthority, TaxClass>>(container, "taxclasses", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.TaxRateRepository<TaxRate>>(container, "taxrates", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.CurrencyCodeRepository<CurrencyCode>>(container, "currencycodes", new InjectionConstructor(typeof(Context)));

            UnityUtil.RegisterType(container, typeof(Sage.CA.SBS.ERP.Sage300.CS.Interfaces.BusinessRepository.IBankClearHistoryEntity<Sage.CA.SBS.ERP.Sage300.CS.Models.BankClearHistory>), typeof(Sage.CA.SBS.ERP.Sage300.CS.BusinessRepository.BankClearHistoryRepository<Sage.CA.SBS.ERP.Sage300.CS.Models.BankClearHistory>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(Sage.CA.SBS.ERP.Sage300.CS.Interfaces.BusinessRepository.IBankClearHistoryEntity<Sage.CA.SBS.ERP.Sage300.CS.Models.BankClearHistory>), typeof(Sage.CA.SBS.ERP.Sage300.CS.BusinessRepository.BankClearHistoryRepository<Sage.CA.SBS.ERP.Sage300.CS.Models.BankClearHistory>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType<IExportImportRepository, BankEntryRepository<BankEntryHeader, BankEntryDetail>>(container, "bankentry", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.TaxGroupRepository<TaxGroup>>(container, "taxgroup", new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IExportImportRepository, CSRepository.TaxAuthorityRepository<TaxAuthority>>(container, "taxauthority", new InjectionConstructor(typeof(Context)));
			UnityUtil.RegisterType(container, typeof(CS.Interfaces.BusinessRepository.IImportOFXStatementEntity<Sage.CA.SBS.ERP.Sage300.CS.Models.ImportOFXStatement>), typeof(Sage.CA.SBS.ERP.Sage300.CS.BusinessRepository.ImportOFXStatementRepository<Sage.CA.SBS.ERP.Sage300.CS.Models.ImportOFXStatement>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(CS.Interfaces.BusinessRepository.IImportOFXStatementEntity<Sage.CA.SBS.ERP.Sage300.CS.Models.ImportOFXStatement>), typeof(Sage.CA.SBS.ERP.Sage300.CS.BusinessRepository.ImportOFXStatementRepository<Sage.CA.SBS.ERP.Sage300.CS.Models.ImportOFXStatement>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            UnityUtil.RegisterType(container, typeof(CS.Interfaces.BusinessRepository.IPostEntriesEntity<PostEntries>), typeof(CS.BusinessRepository.PostEntriesRepository<PostEntries>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(CS.Interfaces.BusinessRepository.IPostEntriesEntity<PostEntries>), typeof(CS.BusinessRepository.PostEntriesRepository<PostEntries>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));
            
            #endregion

            #region Common

            UnityUtil.RegisterType<ISessionRepository<ISession>, SessionRepository<ISession>>(container);

            #endregion

        }

        /// <summary>
        /// Registering Entity Framework services
        /// </summary>
        /// <param name="container">IUnity Container</param>
        private static void RegisterLandlordRepository(IUnityContainer container)
        {
            UnityUtil.RegisterType<ILandlordRepository, LandlordRepository>(container);
        }

        #endregion
    }
}
