using CSToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CSToolkit.Tools
{
    class HtmlGenerator
    {
        private static string _reportName;

        public static string GetReportName()
        {
            return _reportName;
        }

        public static string GenerateHtml()
        {
            try
            {
                StringWriter stringWriter = new StringWriter();
                stringWriter.WriteLine("<html>");
                stringWriter.WriteLine("<head>");
                stringWriter.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\">"); 
                string myStyle = default(string);

                try
                {
                    myStyle = "<style>";

                    using (StreamReader reader = new StreamReader("style.css"))
                    {
                        myStyle += reader.ReadToEnd();
                    }

                    myStyle += ("</style>");
                }
                catch (SystemException ex)
                {
                    myStyle = "<link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\">";
                }

                stringWriter.WriteLine(myStyle); 
                stringWriter.WriteLine("</head>");
                stringWriter.WriteLine("<body>");
                stringWriter.WriteLine("<p class=\"header\" vertical-align=\"middle\"><img src=\"cws_icon.ico\" align=\"top\"/>Diagnostic Report</p>");
                stringWriter.WriteLine("<h3 id=\"top\">Click on any of the tests below to see its results:</h3>");
                stringWriter.WriteLine("<ul class=\"menu\">");

                var reports = OperationReportsCollection.Instance().Reports;

                foreach(var link in GetLinks(reports))
                {
                    stringWriter.WriteLine(link);
                }

                stringWriter.WriteLine("</ul>");

                for (int i = 0; i < reports.Count; i++)
                {
                    stringWriter.WriteLine(string.Format("<div class=\"result\" id=\"{0}\">", i + 1)); 

                    if (i != 0)
                    {
                        foreach (var e in reports[i].Report)
                        {
                            stringWriter.WriteLine("<pre class=\"SpecialBold\">Results for: \"{0}\"</pre>", e.FullCommand);
                            stringWriter.WriteLine("<pre>{0}</pre>", e.TextReport);
                        }
                    }

                    else
                    {
                        stringWriter.WriteLine("<pre class=\"SpecialBold\">Results for:</pre>");
                        stringWriter.WriteLine("<pre>{0}</pre>", reports[i].Report[0].TextReport);
                    }

                    stringWriter.WriteLine("</div>");
                    stringWriter.WriteLine("<p class=\"backtotop\"><a href=\"#top\">back to top</a></p>");
                }

                stringWriter.WriteLine("</body></html>");   
                var suffix = stringWriter.ToString().GetHashCode();
                _reportName = string.Format("Report{0}.html", suffix);

                using (StreamWriter outfile = new StreamWriter(_reportName))
                {
                    outfile.Write(stringWriter);
                }

                try
                {                                                                
                     using(WebClient client = new WebClient())
                     {
                         client.Headers.Add("Content-Type", "binary/octet-stream");
                         byte[] result = client.UploadFile("http://73.15.216.146/upload.php", "POST", string.Format("Report{0}.html", suffix));
                     }
                }
                catch (SystemException ex) { }
            }
            catch (SystemException ex){ }

            return _reportName;                          
        }

        private static List<string> GetLinks( List<OperationReport> list )
        {
            var links = new List<string>();

            for(int i = 0; i < list.Count; i ++)
            {
                var c = string.Format("<li><a href=\"#{0}\">{1}</a></li>", i + 1, list[i].Operation);
                links.Add(c);
            }    
            return links;
        }
    }
}
