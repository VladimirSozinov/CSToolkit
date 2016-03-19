using CSToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Tools
{
    class HtmlGenerator
    {
        private static string _pathToHtmlFile;

        public static string GetPathToHtmlFile()
        {
            return _pathToHtmlFile;
        }

        public static string WriteToHtml(List<OperationReport> reports, string directory)
        {
            string reportName = String.Empty;

            try
            {
                StringWriter stringWriter = new StringWriter();
                stringWriter.WriteLine("<html>");
                stringWriter.WriteLine("<head>");
                stringWriter.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\">");
                               
                stringWriter.WriteLine("<style>");
                StreamReader reader = new StreamReader("../../Resources/style.css");
                var myStyle = reader.ReadToEnd();
                stringWriter.WriteLine(myStyle);
                stringWriter.WriteLine("</style>");

                stringWriter.WriteLine("</head>");
                stringWriter.WriteLine("<body>");
                stringWriter.WriteLine("<h1 id=\"top\">Diagnostic report.</h1>");
                stringWriter.WriteLine("<ul class=\"menu\">");

                foreach(var link in GetLinks(reports))
                {
                    stringWriter.WriteLine(link);
                }

                stringWriter.WriteLine("</ul>");

                for (int i = 0; i < reports.Count; i++)
                {
                    stringWriter.WriteLine(string.Format("<div class=\"result\" id=\"{0}\">", i + 1));

                    foreach (var e in reports[i].Report)
                    {
                        stringWriter.WriteLine("<pre>Results for: \"{0}\" {1}</pre>", e.FullCommand, e.TextReport);
                    }

                    stringWriter.WriteLine("</div>");
                    stringWriter.WriteLine("<p class=\"backtotop\"><a href=\"#top\">back to top</a></p>");
                }

                stringWriter.WriteLine("</body></html>");

                var suffix = stringWriter.ToString().GetHashCode();
                var pathToHtmlFile = string.Format("{0}/Report{1}.html", directory, suffix );

                using (StreamWriter outfile = new StreamWriter(pathToHtmlFile))
                {
                    outfile.Write(stringWriter);
                }
                
                _pathToHtmlFile = pathToHtmlFile;
                reportName = string.Format("Report{0}.html", suffix);
            }
            catch (SystemException ex){ }

            return reportName;
        }

        private static List<string> GetLinks( List<OperationReport> list )
        {
            var links = new List<string>();

            for(int i=0; i< list.Count;i++)
            {
                var c = string.Format("<li><a href=\"#{0}\">{1}</a></li>", i + 1, list[i].Operation);
                links.Add(c);
            }

            return links;
        }
    }
}
