/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Customization
{
    /// <summary>
    /// Class for Custom Validation
    /// </summary>
    public class ValidationProvider : DataAnnotationsModelValidatorProvider
    {
        /// <summary>
        /// Gets a list of validators.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="context">The context.</param>
        /// <param name="attributes">The list of validation attributes.</param>
        /// <returns>A list of validators.</returns>
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context,
            IEnumerable<Attribute> attributes)
        {
            var mergedAttributes = GetAttributes(metadata, context, attributes);
            return base.GetValidators(metadata, context, mergedAttributes);
        }

        /// <summary>
        /// Returns customized attributes
        /// </summary>
        /// <param name="metadata">ModelMetadata</param>
        /// <param name="context">ControllerContext</param>
        /// <param name="attributes">List of defined attributes which already exsits</param>
        /// <returns>List of Attributes</returns>
        private IEnumerable<Attribute> GetAttributes(ModelMetadata metadata, ControllerContext context,
            IEnumerable<Attribute> attributes)
        {
            if (metadata == null || metadata.ContainerType == null || metadata.PropertyName == null)
            {
                return attributes;
            }
            var ctx = context.HttpContext.Items["Context"] as Common.Models.Context;
            if (ctx == null || ctx.ScreenContext == null || ctx.ScreenContext.Screen == null)
            {
                return attributes;
            }

            //var fullName = metadata.ContainerType.FullName + "." + metadata.PropertyName;
            //var control = ctx.ScreenContext.Screen.Controls.Find(ctl => ctl.Type == fullName);
            //if (control == null || control.Validations.Count == 0)
            //{
            //    return attributes;
            //}

            var list = attributes.ToList();
            //foreach (var validation in control.Validations)
            //{
            //    var definedAttribute = list.FirstOrDefault(attr => attr.GetType() == validation.AttributeType);

            //    if (definedAttribute != null)
            //    {
            //        if (!validation.IsValid(definedAttribute))
            //        {
            //            continue;
            //        }
            //        list.Remove(definedAttribute);
            //    }
            //    list.Add(validation.GetAttribute());
            //}
            return list;
        }
    }
}