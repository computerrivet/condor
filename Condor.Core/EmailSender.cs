using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using STrace = System.Diagnostics.Trace;

using SendGrid;

using RazorTemplates.Core;

namespace Condor.Core
{
    /// <summary>
    /// Project specific email sender
    /// </summary>
    public class EmailSender
    {
        public static void Send<TModel>(string templateName, string toEmailAddress, string firstName, string lastName, string subject, TModel model)
        {
            // Create the email object first, then add the properties.
            var mail = new SendGridMessage();

            mail.From = new MailAddress(ConfigurationManager.AppSettings["Condor_Address"], 
                        ConfigurationManager.AppSettings["Condor_Address_DisplayName"]);

            // Create credentials, specifying your user name and password.
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["Condor_Username"], 
                        ConfigurationManager.AppSettings["Condor_Password"]);

            // Create an SMTP transport for sending email.
            var transportWeb = new Web(credentials);

            //recipient address
            mail.AddTo(string.Format("{0} {1} <{2}>", firstName.Replace("\"", ""), lastName.Replace("\"", ""), toEmailAddress));
            mail.Subject = subject;

            var html_template_name = templateName + "_html.cshtml";
            var txt_template_name = templateName + "_txt.cshtml";

            // check the cache and store it if not found
            var html_template = GetTemplate<TModel>(html_template_name);

            mail.Html = EmailTemplateCompiler.Merge<TModel>(html_template, model);

            var txt_template = GetTemplate<TModel>(txt_template_name);

            mail.Text = EmailTemplateCompiler.Merge<TModel>(txt_template, model);

            transportWeb.DeliverAsync(mail).Wait();
        }

        public static void Send<TModel>(string templateName, string[] emailAddresses, string[] names, string subject, TModel model)
        {
          
            // Create the email object first, then add the properties.
            var mail = new SendGridMessage();

            mail.From = new MailAddress(ConfigurationManager.AppSettings["Condor_Address"],
                        ConfigurationManager.AppSettings["Condor_Address_DisplayName"]);

            // Create credentials, specifying your user name and password.
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["Condor_Username"],
                        ConfigurationManager.AppSettings["Condor_Password"]);

            // Create an SMTP transport for sending email.
            var transportWeb = new Web(credentials);

            ////recipient addresses
            var recipients = new List<String>();
            recipients.AddRange(emailAddresses.Select((t, r) => names[r] + " <" + t + ">"));
            mail.AddTo(recipients);

            mail.Subject = subject;

            var html_template_name = templateName + "_html.cshtml";
            var txt_template_name = templateName + "_txt.cshtml";

            // check the cache and store it if not found
            var html_template = GetTemplate<TModel>(html_template_name);

            mail.Html = EmailTemplateCompiler.Merge<TModel>(html_template, model);

            var txt_template = GetTemplate<TModel>(txt_template_name);

            mail.Text = EmailTemplateCompiler.Merge<TModel>(txt_template, model);

            transportWeb.DeliverAsync(mail).Wait();
        }

        /// <summary>
        /// Gets the Email Template with Cache management.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="templateName"></param>
        /// <returns>The template</returns>
        public static ITemplate<TModel> GetTemplate<TModel>(string templateName)
        {
            ITemplate<TModel> template = (ITemplate<TModel>)HttpContext.Current.Cache.Get(templateName);

            if (template == null)
            {
                template = EmailTemplateCompiler.Compile<TModel>(templateName);
                HttpContext.Current.Cache.Add(templateName, template, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                        TimeSpan.FromDays(1), System.Web.Caching.CacheItemPriority.Default, null);
            }

            return template;
        }
    }
}