using System;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Interface of button class
    /// </summary>
    public interface IButtonProperties
    {
        /// <summary>
        /// Button id variable name
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Button name variable name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Button id default value
        /// </summary>
        string DefaultId { get; }

        /// <summary>
        /// Button name default value
        /// </summary>
        string DefaultName { get; }

        /// <summary>
        /// Button value variable name
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Button default value
        /// </summary>
        string DefaultValue { get; }

        /// <summary>
        /// Button KO parameter name
        /// </summary>
        string KoParameter { get; }

        /// <summary>
        /// Button class variable name
        /// </summary>
        string Class { get; }

        /// <summary>
        /// Button class default value
        /// </summary>
        string DefaultClass { get; }

        /// <summary>
        /// Should the button is required
        /// </summary>
        string IsRequired { get; }

        /// <summary>
        /// Should the button is required default value
        /// </summary>
        bool DefaultIsRequired { get; }

        /// <summary>
        /// Button determinate what security level to validate
        /// </summary>
        string SecurityLevel { get; }

        /// <summary>
        /// Default button security level
        /// </summary>
        SecurityType DefaultSecurityLevel { get; }

        /// <summary>
        /// Button diable flag
        /// </summary>
        string Disabled { get; }

        /// <summary>
        /// JSON object property name for the button
        /// </summary>
        string JsName { get; }

        /// <summary>
        /// JsName default value
        /// </summary>
        string DefaultJsName { get; }
    }

    /// <summary>
    /// To define page item (e.g buttons) names and default values
    /// </summary>
    public static class ViewItemSemantic
    {
        #region Generic button and Identifiers

        /// <summary>
        /// GenericButton parameter number
        /// </summary>
        public static string GenericButton = "GenericButton";
        
        /// <summary>
        /// Identifiter 0 for generic button
        /// </summary>
        public static string GenericButton0Identifier = "EAEB1DFE-826E-423F-8593-581622E3BF0D";

        /// <summary>
        /// Identifiter 1 for generic button
        /// </summary>
        public static string GenericButton1Identifier = "5616BF63-7AB4-490E-A14D-AEE6958EECBC";

        /// <summary>
        /// Identifiter 2 for generic button
        /// </summary>
        public static string GenericButton2Identifier = "2EB627B9-A22E-49FF-96B3-0AE8266261B2";

        /// <summary>
        /// Identifiter 3 for generic button
        /// </summary>
        public static string GenericButton3Identifier = "389FD898-C185-4F1E-BFBD-A806D9A512C2";

        /// <summary>
        /// Identifiter 4 for generic button
        /// </summary>
        public static string GenericButton4Identifier = "C6D5237E-98DC-46D1-99F4-F39AF08C5E51";

        /// <summary>
        /// Identifiter 5 for generic button
        /// </summary>
        public static string GenericButton5Identifier = "E16AF478-8194-4203-BD8D-1F7ED9A5F142";

        /// <summary>
        /// Identifiter 6 for generic button
        /// </summary>
        public static string GenericButton6Identifier = "29C69F7A-BC55-4D93-91EC-16048B8BC135";

        /// <summary>
        /// Identifiter 7 for generic button
        /// </summary>
        public static string GenericButton7Identifier = "8313C1AB-8A8B-4D01-B02A-4F50566E1C7D";

        /// <summary>
        /// Identifiter 8 for generic button
        /// </summary>
        public static string GenericButton8Identifier = "01A91846-04C4-4E6A-9531-CE2D00A4CAEE";

        /// <summary>
        /// Identifiter 9 for generic button
        /// </summary>
        public static string GenericButton9Identifier = "7C1659FA-F424-4082-99D9-52263F24AA15";

        #endregion
        
        #region General
        /// <summary>
        /// Button class for primary
        /// </summary>
        public const string ButtonClassPrimary = "btn-primary";

        /// <summary>
        /// Button class for secondary
        /// </summary>
        public const string ButtonClassSecondary = "btn-secondary";

        /// <summary>
        /// Button class for right
        /// </summary>
        public const string ButtonClassRight = "right";

        /// <summary>
        /// Button class for alpha
        /// </summary>
        public const string ButtonClassAlpha = "alpha";

        /// <summary>
        /// Footer type
        /// </summary>
        public const string FooterType = "FooterType";
        #endregion

        /// <summary>
        /// Class to specify Print button properties
        /// </summary>
        public class PrintButtonProperties : IButtonProperties
        {
            private static readonly Lazy<PrintButtonProperties> MInstance = new Lazy<PrintButtonProperties>(() => new PrintButtonProperties());

            private PrintButtonProperties() { }

            /// <summary>
            /// Return singleton instance of PrintButtonProperties
            /// </summary>
            public static PrintButtonProperties Instance { get { return MInstance.Value; } }

            /// <summary>
            /// Print button id variable name
            /// </summary>
            public string Id { get { return "printId"; } }

            /// <summary>
            /// Print button name variable name
            /// </summary>
            public string Name { get { return "printName"; } }

            /// <summary>
            /// Print button id default value
            /// </summary>
            public string DefaultId { get { return "btnPrint"; } }

            /// <summary>
            /// Print button name default value
            /// </summary>
            public string DefaultName { get { return "btnPrint"; } }

            /// <summary>
            /// Print button class variable name
            /// </summary>
            public string Class { get { return "printClass"; } }

            /// <summary>
            /// Print button value variable name
            /// </summary>
            public string Value { get { return "printValue"; } }

            /// <summary>
            /// Print button default value
            /// </summary>
            public string DefaultValue { get { return CommonResx.Print; } }

            /// <summary>
            /// Print button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnPrintKoParameter"; } }

            /// <summary>
            /// Print button class default value
            /// </summary>
            public string DefaultClass { get { return ButtonClassPrimary; } }

            /// <summary>
            /// Print button flag to see if security check is required
            /// </summary>
            public string IsRequired { get { return "printRequired"; } }

            /// <summary>
            /// Should the print button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return true; } }

            /// <summary>
            /// Print button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "printSecurityLevel"; } }

            /// <summary>
            /// Default print button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Inquire; } }

            /// <summary>
            /// Print button diable flag
            /// </summary>
            public string Disabled { get { return "printDisabled"; } }

            /// <summary>
            /// JSON object property name for the print button
            /// </summary>
            public string JsName { get { return "printJsName"; } }

            /// <summary>
            /// Print button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "print"; } }
        }

        /// <summary>
        /// Class to specify Save button properties
        /// </summary>
        public class SaveButtonProperties : IButtonProperties
        {
            private static readonly Lazy<SaveButtonProperties> MInstance = new Lazy<SaveButtonProperties>(() => new SaveButtonProperties());

            private SaveButtonProperties() { }

            /// <summary>
            /// Return singleton instance of DeleteButtonProperties
            /// </summary>
            public static SaveButtonProperties Instance { get { return MInstance.Value; } }

            /// <summary>
            /// Save button id variable name
            /// </summary>
            public string Id { get { return "saveId"; } }

            /// <summary>
            /// Save button name variable name
            /// </summary>
            public string Name { get { return "saveName"; } }

            /// <summary>
            /// Save button id default value
            /// </summary>
            public string DefaultId { get { return "btnSave"; } }

            /// <summary>
            /// Save button name default value
            /// </summary>
            public string DefaultName { get { return "btnSave"; } }

            /// <summary>
            /// Save button value variable name
            /// </summary>
            public string Value { get { return "saveValue"; } }

            /// <summary>
            /// Save button default value
            /// </summary>
            public string DefaultValue { get { return CommonResx.Save; } }

            /// <summary>
            /// Save button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnSaveKoParameter"; } }

            /// <summary>
            /// Save button class variable name
            /// </summary>
            public string Class { get { return "saveClass"; } }

            /// <summary>
            /// Save button class default value
            /// </summary>
            public string DefaultClass { get { return ButtonClassPrimary; } }

            /// <summary>
            /// Should the save button is required
            /// </summary>
            public string IsRequired { get { return "saveRequired"; } }

            /// <summary>
            /// Should the save button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return true; } }

            /// <summary>
            /// Save button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "proceedSecurityLevel"; } }

            /// <summary>
            /// Default save button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Modify; } }

            /// <summary>
            /// Save button disable flag
            /// </summary>
            public string Disabled { get { return "proceedDisabled"; } }

            /// <summary>
            /// JSON object property name for the save button
            /// </summary>
            public string JsName { get { return "saveJsName"; } }

            /// <summary>
            /// Save button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "save"; } }
        }

        /// <summary>
        /// Class to specify Delete button properties
        /// </summary>
        public class DeleteButtonProperties : IButtonProperties
        {
            private static readonly Lazy<DeleteButtonProperties> MInstance = new Lazy<DeleteButtonProperties>(() => new DeleteButtonProperties());

            private DeleteButtonProperties() { }

            /// <summary>
            /// Return singleton instance of DeleteButtonProperties
            /// </summary>
            public static DeleteButtonProperties Instance { get { return MInstance.Value; } }
            
            /// <summary>
            /// Delete button id variable name
            /// </summary>
            public string Id { get { return "deleteId"; } }

            /// <summary>
            /// Delete button name variable name
            /// </summary>
            public string Name { get { return "deleteName"; } }

            /// <summary>
            /// Delete button id default value
            /// </summary>
            public string DefaultId { get { return "btnDelete"; } }

            /// <summary>
            /// Delete button name default value
            /// </summary>
            public string DefaultName { get { return "btnDelete"; } }

            /// <summary>
            /// Delete button value variable name
            /// </summary>
            public string Value { get { return "deleteValue"; } }

            /// <summary>
            /// Delete button default value
            /// </summary>
            public string DefaultValue { get { return CommonResx.Delete; } }

            /// <summary>
            /// Delete button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnDeleteKoParameter"; } }

            /// <summary>
            /// Delete button class variable name
            /// </summary>
            public string Class { get { return "deleteClass"; } }

            /// <summary>
            /// Delete button class default value
            /// </summary>
            public string DefaultClass { get { return ButtonClassPrimary; } }

            /// <summary>
            /// Should the delete button is required
            /// </summary>
            public string IsRequired { get { return "deleteRequired"; } }

            /// <summary>
            /// Should the delete button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return true; } }

            /// <summary>
            /// Delete button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "deleteSecurityLevel"; } }

            /// <summary>
            /// Default delete button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Modify; } }

            /// <summary>
            /// Delete button diable flag
            /// </summary>
            public string Disabled { get { return "deleteDisabled"; } }

            /// <summary>
            /// JSON object property name for the delete button
            /// </summary>
            public string JsName { get { return "deleteJsName"; } }

            /// <summary>
            /// Delete button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "delete"; } }
        }

        /// <summary>
        /// Class to specify Optional button properties
        /// </summary>
        public class OptionalButtonProperties : IButtonProperties
        {
            private static readonly Lazy<OptionalButtonProperties> MInstance = new Lazy<OptionalButtonProperties>(() => new OptionalButtonProperties());

            private OptionalButtonProperties() { }

            /// <summary>
            /// Return singleton instance of OptionalButtonProperties
            /// </summary>
            public static OptionalButtonProperties Instance { get { return MInstance.Value; } }

            /// <summary>
            /// Optional button id variable name
            /// </summary>
            public string Id { get { return "optionalId"; } }

            /// <summary>
            /// Optional button name variable name
            /// </summary>
            public string Name { get { return "optionalName"; } }

            /// <summary>
            /// Optional button id default value
            /// </summary>
            public string DefaultId { get { return "btnOptional"; } }

            /// <summary>
            /// Optional button name default value
            /// </summary>
            public string DefaultName { get { return "btnOptional"; } }

            /// <summary>
            /// Optional button value variable name
            /// </summary>
            public string Value { get { return "optionalValue"; } }

            /// <summary>
            /// Optional button default value
            /// </summary>
            public string DefaultValue { get { return string.Empty; } }

            /// <summary>
            /// Optional button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnOptionalKoParameter"; } }

            /// <summary>
            /// Optional button class variable name
            /// </summary>
            public string Class { get { return "optionalClass"; } }

            /// <summary>
            /// Should the optional button is required
            /// </summary>
            public string IsRequired { get { return "optionalRequired"; } }

            /// <summary>
            /// Should the optional button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return false; } }

            /// <summary>
            /// Optional button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "optionalSecurityLevel"; } }

            /// <summary>
            /// Default optional button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Modify; } }

            /// <summary>
            /// Optional button class default value
            /// </summary>
            public string DefaultClass { get { return ButtonClassPrimary; } }

            /// <summary>
            /// Optional button disable flag
            /// </summary>
            public string Disabled { get { return "optionalDisabled"; } }

            /// <summary>
            /// JSON object property name for the optional button
            /// </summary>
            public string JsName { get { return "optionalJsName"; } }

            /// <summary>
            /// Optional button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "optional"; } }
        }

        /// <summary>
        /// Class to specify Proceed button properties
        /// </summary>
        public class ProceedButtonProperties : IButtonProperties
        {
            private static readonly Lazy<ProceedButtonProperties> MInstance = new Lazy<ProceedButtonProperties>(() => new ProceedButtonProperties());

            private ProceedButtonProperties() { }

            /// <summary>
            /// Return singleton instance of ProceedButtonProperties
            /// </summary>
            public static ProceedButtonProperties Instance { get { return MInstance.Value; } }

            /// <summary>
            /// Proceed button id variable name
            /// </summary>
            public string Id { get { return "proceedId"; } }

            /// <summary>
            /// Proceed button name variable name
            /// </summary>
            public string Name { get { return "proceedName"; } }

            /// <summary>
            /// Proceed button id default value
            /// </summary>
            public string DefaultId { get { return "btnProcess"; } }

            /// <summary>
            /// Proceed button name default value
            /// </summary>
            public string DefaultName { get { return "btnProcess"; } }

            /// <summary>
            /// Proceed button value variable name
            /// </summary>
            public string Value { get { return "proceedValue"; } }

            /// <summary>
            /// Proceed button default value
            /// </summary>
            public string DefaultValue { get { return CommonResx.Proceed; } }

            /// <summary>
            /// Proceed button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnProceedKoParameter"; } }

            /// <summary>
            /// Proceed button class variable name
            /// </summary>
            public string Class { get { return "proceedClass"; } }

            /// <summary>
            /// Should the proceed button is required
            /// </summary>
            public string IsRequired { get { return "proceedRequired"; } }

            /// <summary>
            /// Should the proceed button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return true; } }

            /// <summary>
            /// Proceed button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "proceedSecurityLevel"; } }

            /// <summary>
            /// Default proceed button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Modify; } }

            /// <summary>
            /// Proceed button class default value
            /// </summary>
            public string DefaultClass { get { return ButtonClassPrimary; } }

            /// <summary>
            /// Proceed button disable flag
            /// </summary>
            public string Disabled { get { return "proceedDisabled"; } }

            /// <summary>
            /// JSON object property name for the proceed button
            /// </summary>
            public string JsName { get { return "proceedJsName"; } }

            /// <summary>
            /// Proceed button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "proceed"; } }
        }

        /// <summary>
        /// Class to specify AddLine button properties
        /// </summary>
        public class AddLineButtonProperties : IButtonProperties
        {
            private static readonly Lazy<AddLineButtonProperties> MInstance = new Lazy<AddLineButtonProperties>(() => new AddLineButtonProperties());

            private AddLineButtonProperties() { }

            /// <summary>
            /// Return singleton instance of AddLineButtonProperties
            /// </summary>
            public static AddLineButtonProperties Instance { get { return MInstance.Value; } }

            /// <summary>
            /// AddLine button id variable name
            /// </summary>
            public string Id { get { return "addLineId"; } }

            /// <summary>
            /// AddLine button name variable name
            /// </summary>
            public string Name { get { return "addLineName"; } }

            /// <summary>
            /// AddLine button id default value
            /// </summary>
            public string DefaultId { get { return "btnAddDetail"; } }

            /// <summary>
            /// AddLine button name default value
            /// </summary>
            public string DefaultName { get { return "btnAddDetail"; } }

            /// <summary>
            /// AddLine button value variable name
            /// </summary>
            public string Value { get { return "addLineValue"; } }

            /// <summary>
            /// AddLine button default value
            /// </summary>
            public string DefaultValue { get { return CommonResx.AddLine; } }

            /// <summary>
            /// AddLine button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnAddLineKoParameter"; } }

            /// <summary>
            /// AddLine button class variable name
            /// </summary>
            public string Class { get { return "addLineClass"; } }

            /// <summary>
            /// AddLine button class default value
            /// </summary>
            public string DefaultClass { get { return "toolBar_icon add_icon"; } }

            /// <summary>
            /// Should the addline button is required
            /// </summary>
            public string IsRequired { get { return "addLineRequired"; } }

            /// <summary>
            /// Should the addline button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return true; } }

            /// <summary>
            /// AddLine button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "addLineSecurityLevel"; } }

            /// <summary>
            /// Default addline button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Modify; } }

            /// <summary>
            /// AddLine button diable flag
            /// </summary>
            public string Disabled { get { return "addLineDisabled"; } }

            /// <summary>
            /// JSON object property name for the addLine button
            /// </summary>
            public string JsName { get { return "addLineJsName"; } }


            /// <summary>
            /// AddLine button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "addLine"; } }
        }

        /// <summary>
        /// Class to specify AddLine button properties
        /// </summary>
        public class DeleteLineButtonProperties : IButtonProperties
        {
            private static readonly Lazy<DeleteLineButtonProperties> MInstance = new Lazy<DeleteLineButtonProperties>(() => new DeleteLineButtonProperties());

            private DeleteLineButtonProperties() { }

            /// <summary>
            /// Return singleton instance of DeleteLineButtonProperties
            /// </summary>
            public static DeleteLineButtonProperties Instance { get { return MInstance.Value; } }

            /// <summary>
            /// DeleteLine button id variable name
            /// </summary>
            public string Id { get { return "deleteLineId"; } }

            /// <summary>
            /// DeleteLine button name variable name
            /// </summary>
            public string Name { get {return "deleteLineName"; } }

            /// <summary>
            /// DeleteLine button id default value
            /// </summary>
            public string DefaultId { get { return "btnDeleteDetail"; } }

            /// <summary>
            /// DeleteLine button name default value
            /// </summary>
            public string DefaultName { get { return "btnDeleteDetail"; } }

            /// <summary>
            /// DeleteLine button value variable name
            /// </summary>
            public string Value { get { return "deleteLineValue"; } }

            /// <summary>
            /// DeleteLine button default value
            /// </summary>
            public string DefaultValue { get { return CommonResx.DeleteLine; } }

            /// <summary>
            /// DeleteLine button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnDeleteLineKoParameter"; } }

            /// <summary>
            /// DeleteLine button class variable name
            /// </summary>
            public string Class { get { return "deleteLineClass"; } }

            /// <summary>
            /// DeleteLine button class default value
            /// </summary>
            public string DefaultClass { get { return "toolBar_icon delete_icon"; } }

            /// <summary>
            /// Should the deleteline button is required
            /// </summary>
            public string IsRequired { get { return "deleteLineRequired"; } }

            /// <summary>
            /// Should the deleteline button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return true; } }

            /// <summary>
            /// DeleteLine button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "deleteLineSecurityLevel"; } }

            /// <summary>
            /// Default deleteline button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Modify; } }

            /// <summary>
            /// DeleteLine button diable flag
            /// </summary>
            public string Disabled { get { return "deleteLinedisabled"; } }

            /// <summary>
            /// JSON object property name for the deleteLine button
            /// </summary>
            public string JsName { get { return "deleteLineJsName"; } }

            /// <summary>
            /// DeleteLine button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "deleteLine"; } }
        }

        /// <summary>
        /// Class to specify Generic button properties
        /// </summary>
        public class GenericButtonProperties : IButtonProperties
        {
            private static readonly Lazy<GenericButtonProperties> MInstance = new Lazy<GenericButtonProperties>(() => new GenericButtonProperties());

            private GenericButtonProperties() { }

            /// <summary>
            /// Return singleton instance of GenericButtonProperties
            /// </summary>
            public static GenericButtonProperties Instance { get { return MInstance.Value; } }

            /// <summary>
            /// Optional button id variable name
            /// </summary>
            public string Id { get { return "genericId"; } }

            /// <summary>
            /// Optional button name variable name
            /// </summary>
            public string Name { get { return "genericName"; } }

            /// <summary>
            /// Optional button id default value
            /// </summary>
            public string DefaultId { get { return "btnGeneric"; } }

            /// <summary>
            /// Optional button name default value
            /// </summary>
            public string DefaultName { get { return "btnGeneric"; } }

            /// <summary>
            /// Optional button value variable name
            /// </summary>
            public string Value { get { return "genericValue"; } }

            /// <summary>
            /// Optional button default value
            /// </summary>
            public string DefaultValue { get { return string.Empty; } }

            /// <summary>
            /// Optional button KO parameter name
            /// </summary>
            public string KoParameter { get { return "btnGenericKoParameter"; } }

            /// <summary>
            /// Optional button class variable name
            /// </summary>
            public string Class { get { return "genericClass"; } }

            /// <summary>
            /// Should the optional button is required
            /// </summary>
            public string IsRequired { get { return "genericRequired"; } }

            /// <summary>
            /// Should the optional button is required default value
            /// </summary>
            public bool DefaultIsRequired { get { return false; } }

            /// <summary>
            /// Optional button determinate what security level to validate
            /// </summary>
            public string SecurityLevel { get { return "genericSecurityLevel"; } }

            /// <summary>
            /// Default optional button security level
            /// </summary>
            public SecurityType DefaultSecurityLevel { get { return SecurityType.Modify; } }

            /// <summary>
            /// Optional button class default value
            /// </summary>
            public string DefaultClass { get { return ButtonClassPrimary; } }

            /// <summary>
            /// Optional button disable flag
            /// </summary>
            public string Disabled { get { return "genericDisabled"; } }

            /// <summary>
            /// JSON object property name for the optional button
            /// </summary>
            public string JsName { get { return "genericJsName"; } }

            /// <summary>
            /// Generic button JsName default value
            /// </summary>
            public string DefaultJsName { get { return "generic"; } }
        }
    }
}
