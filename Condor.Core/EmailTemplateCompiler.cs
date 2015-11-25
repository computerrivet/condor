using System;
using System.IO;
using System.Reflection;

using RazorTemplates.Core;

namespace TheDrillBookCloud.Lib.Email
{
    /// <summary>
    /// Hooks in the RazorTemplate project
    /// </summary>
    public static class EmailTemplateCompiler
    {
        public static ITemplate<TModel> Compile<TModel>(string templateName)
        {
            Template.Debug = true;
            return Template.WithBaseType<TemplateBase<TModel>>()
                .AddNamespace("TheDrillBookCloud.Lib.Email.Templates.Helpers")
                .Compile<TModel>(GetTemplate(templateName));
        }

        public static string Merge<TModel>(ITemplate<TModel> template, TModel model)
        {
            return template.Render(model);
        }

        public static string GetTemplate(string templateName)
        {
            Stream stream = null;
            try
            {
                using (stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(templateName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch 
            {
                if (stream == null)
                {
                    throw new Exception("Template not found in assembly. Set properties on template for 'Embedded Resource'");
                }
                else
                { throw; }
            }
        }

    }
}