// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using EnvDTE;

namespace Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard
{
    /// <summary> Entry Point for Code Generation Wizard </summary>
    public class CodeGenerationWizard
    {
        /// <summary> Execute the Code Generation Wizard </summary>
        public void Execute(Solution solution)
        {
            using (var form = new Generation())
            {
                // Only display wizard if solution is a valid Sage 300 solution with
                // known Sage 300 projects
                if (form.ValidPrerequisites(solution))
                {
                    // Display wizard modally
                    form.ShowDialog();
                }
            }

        }
    }
}
