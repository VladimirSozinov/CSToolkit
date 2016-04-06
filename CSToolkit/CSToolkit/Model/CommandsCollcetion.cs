using System.Collections.Generic;

namespace CSToolkit.Model
{
    class CommandsCollcetion
    {
        private string _example = "http://www.example.com";
        private string _whoami = "http://whoami.scansafe.net/";
        private List<List<SubCommand>> _setCommands;

        public CommandsCollcetion(string proxy1, string proxy2, string host)
        {
            _setCommands = new List<List<SubCommand>>();
            
            var basicInfo = new List<SubCommand>();
            _setCommands.Add(basicInfo);

            var collectingWhoami = new List<SubCommand>();
            collectingWhoami.Add(new SubCommand(@"bin\curl\curl64.exe", string.Format(@"--proxy {0}:8080 {1}", proxy1, _whoami)));
            _setCommands.Add(collectingWhoami);

            var checkingForOpenPort = new List<SubCommand>();
            checkingForOpenPort.Add(new SubCommand(@"bin\nc\nc.exe", string.Format(@"-v -z -w5 {0} 8080", proxy1)));
            checkingForOpenPort.Add(new SubCommand(@"bin\nc\nc.exe", string.Format(@"-v -z -w5 {0} 8080", proxy2)));
            checkingForOpenPort.Add(new SubCommand(@"bin\nc\nc64.exe", string.Format(@"-v -z -w5 {0} 8080", proxy1)));
            checkingForOpenPort.Add(new SubCommand(@"bin\nc\nc64.exe", string.Format(@"-v -z -w5 {0} 8080", proxy2)));
            _setCommands.Add(checkingForOpenPort);

            var collectingSystemInfo = new List<SubCommand>();
            collectingSystemInfo.Add( new SubCommand("ipconfig", "/all"));
            collectingSystemInfo.Add( new SubCommand("systeminfo", ""));
            _setCommands.Add(collectingSystemInfo);

            var executingDnsCheck = new List<SubCommand>();
            executingDnsCheck.Add( new SubCommand("ipconfig", "/flushdns"));
            executingDnsCheck.Add( new SubCommand(@"bin\dns\dig.exe", string.Format(@"+noall +stats +answer {0}", proxy1 )));
            executingDnsCheck.Add( new SubCommand(@"bin\dns\dig.exe", string.Format(@"+noall +stats +answer {0}", proxy2 )));
            executingDnsCheck.Add( new SubCommand(@"bin\dns\dig.exe", string.Format(@"+noall +stats +answer -f bin\dns\website_dns_list.txt")));
            _setCommands.Add(executingDnsCheck);

            var executingTraceroute = new List<SubCommand>();
            executingTraceroute.Add(new SubCommand(@"bin\trace\tracetcp.exe", string.Format(@"{0}:8080 -t 500", proxy1)));
            executingTraceroute.Add(new SubCommand(@"bin\trace\tracetcp.exe", string.Format(@"{0}:8080 -t 500", proxy1)));
            executingTraceroute.Add(new SubCommand(@"bin\trace\tracetcp.exe", string.Format(@"{0}:8080 -t 500", proxy1)));
            executingTraceroute.Add(new SubCommand(@"bin\trace\tracetcp.exe", string.Format(@"{0}:8080 -t 500", proxy2)));
            executingTraceroute.Add(new SubCommand(@"bin\trace\tracetcp.exe", string.Format(@"{0}:8080 -t 500", proxy2)));
            executingTraceroute.Add(new SubCommand(@"bin\trace\tracetcp.exe", string.Format(@"{0}:8080 -t 500", proxy2)));
            executingTraceroute.Add(new SubCommand(@"tracert", string.Format(@"-w 500 {0}", proxy1)));
            executingTraceroute.Add(new SubCommand(@"tracert", string.Format(@"-w 500 {0}", proxy1)));
            executingTraceroute.Add(new SubCommand(@"tracert", string.Format(@"-w 500 {0}", proxy1)));
            executingTraceroute.Add(new SubCommand(@"tracert", string.Format(@"-w 500 {0}", proxy2)));
            executingTraceroute.Add(new SubCommand(@"tracert", string.Format(@"-w 500 {0}", proxy2)));
            executingTraceroute.Add(new SubCommand(@"tracert", string.Format(@"-w 500 {0}", proxy2)));          
            executingTraceroute.Add(new SubCommand(@"bin\nmap\nmap.exe", string.Format(@"-sn --system-dns --traceroute --script bin\nmap\traceroute-geolocation.nse {0}", proxy1)));
            executingTraceroute.Add(new SubCommand(@"bin\nmap\nmap.exe", string.Format(@"-sn --system-dns --traceroute --script bin\nmap\traceroute-geolocation.nse {0}", proxy2)));
            _setCommands.Add(executingTraceroute);

            var executingPing = new List<SubCommand>();
            executingPing.Add(new SubCommand(@"ping", string.Format(@"-t -n 100 {0}", host)));
            executingPing.Add(new SubCommand(@"bin\ping\tcping.exe", string.Format(@"-n 100 -w 500 {0} 80", host)));//1000
            executingPing.Add(new SubCommand(@"bin\ping\tcping.exe", string.Format(@"-n 100 -w 500 {0} 8080", proxy1))); 
            executingPing.Add(new SubCommand(@"bin\ping\tcping.exe", string.Format(@"-n 100 -w 500 {0} 8080", proxy2)));  
            executingPing.Add(new SubCommand(@"bin\ping\http-ping.exe", string.Format(@"-v -c -d -q -n 100 {0}", host)));
            _setCommands.Add(executingPing);

            var executingMtr = new List<SubCommand>();                                                                                                                                              
            executingMtr.Add(new SubCommand(@"bin\mtr\Release_x64\WinMTRCmd.exe", string.Format(@"-c 100 -t 2 --report {0}", proxy1)));
            executingMtr.Add(new SubCommand(@"bin\mtr\Release_x64\WinMTRCmd.exe", string.Format(@"-c 100 -t 2 --report {0}", proxy2)));
            executingMtr.Add(new SubCommand(@"bin\mtr\Release_x64\WinMTRCmd.exe", string.Format(@"-c 100 -t 2 --report {0}", host)));
            _setCommands.Add(executingMtr);

            var executingCurl = new List<SubCommand>();
            executingCurl.Add(new SubCommand(@"bin\curl\curl64.exe", string.Format(@"-w {3}{2}{3} -o NUL -s -x {0}:8080 {1}", proxy1, _example, @"@bin\curl\curl-format.txt", "\"")));
            executingCurl.Add(new SubCommand(@"bin\curl\curl64.exe", string.Format(@"-w {3}{2}{3} -o NUL -s -x {0}:8080 {1}", proxy2, _example, @"@bin\curl\curl-format.txt", "\"")));
            executingCurl.Add(new SubCommand(@"bin\curl\curl32.exe", string.Format(@"-w {3}{2}{3} -o NUL -s -x {0}:8080 {1}", proxy1, _example, @"@bin\curl\curl-format.txt", "\"")));
            executingCurl.Add(new SubCommand(@"bin\curl\curl32.exe", string.Format(@"-w {3}{2}{3} -o NUL -s -x {0}:8080 {1}", proxy2, _example, @"@bin\curl\curl-format.txt", "\"")));

            executingCurl.Add(new SubCommand(@"bin\curl\curl64.exe", string.Format(@"-w {1} -o NUL -s {0}", _example, @"@bin\curl\curl-format.txt")));
            executingCurl.Add(new SubCommand(@"bin\curl\curl64.exe", string.Format(@"-w {1} -o NUL -s {0}", _example, @"@bin\curl\curl-format.txt")));
            executingCurl.Add(new SubCommand(@"bin\curl\curl32.exe", string.Format(@"-w {1} -o NUL -s {0}", _example, @"@bin\curl\curl-format.txt")));
            executingCurl.Add(new SubCommand(@"bin\curl\curl32.exe", string.Format(@"-w {1} -o NUL -s {0}", _example, @"@bin\curl\curl-format.txt")));
           
            executingCurl.Add(new SubCommand(@"bin\curl\curl64.exe", string.Format(@"-I -k {0} --proxy {1}:8080", _example, proxy1)));
            executingCurl.Add(new SubCommand(@"bin\curl\curl64.exe", string.Format(@"-I -k {0} --proxy {1}:8080", _example, proxy2)));
            executingCurl.Add(new SubCommand(@"bin\curl\curl32.exe", string.Format(@"-I -k {0} --proxy {1}:8080", _example, proxy1)));
            executingCurl.Add(new SubCommand(@"bin\curl\curl32.exe", string.Format(@"-I -k {0} --proxy {1}:8080", _example, proxy2)));
            _setCommands.Add(executingCurl);
        }

        public List<List<SubCommand>> GetCommands 
        { 
            get { return _setCommands; }
        }
    }
}
