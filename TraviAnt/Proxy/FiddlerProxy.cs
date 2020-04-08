using Fiddler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraviAnt.Proxy
{
    public static class FiddlerProxy
    {
        private static SessionStateHandler _beforeResponse;
        private static SessionStateHandler _beforeRequest;

        public static void Start()
        {
            FiddlerApplication.Shutdown();
            FiddlerApplication.OnValidateServerCertificate += FiddlerApplication_OnValidateServerCertificate; 
            SessionStateHandler _bResp;
            if ((_bResp = _beforeResponse) == null)
            {
                _bResp = (_beforeResponse = new SessionStateHandler(BeforeResponse));
                FiddlerApplication.BeforeResponse += _bResp;
            }
            SessionStateHandler _bReq;
            if ((_bReq = _beforeRequest) == null)
            {
                _bReq = (_beforeRequest = new SessionStateHandler(BeforeRequest));
                FiddlerApplication.BeforeRequest += _bReq;
            }
            InstallCert();

            ushort iPort = 7777;

            FiddlerCoreStartupSettings startupSettings =
                new FiddlerCoreStartupSettingsBuilder()
                    .ListenOnPort(iPort)
                    //.RegisterAsSystemProxy()
                    .DecryptSSL()
                    //.AllowRemoteClients()
                    //.ChainToUpstreamGateway()
                    //.MonitorAllConnections()
                    //.HookUsingPACFile()
                    //.CaptureLocalhostTraffic()
                    //.CaptureFTP()
                    .OptimizeThreadPool()
                    //.SetUpstreamGatewayTo("http=CorpProxy:80;https=SecureProxy:443;ftp=ftpGW:20")
                    .Build();

            Fiddler.FiddlerApplication.Startup(startupSettings);
        }

        private static void FiddlerApplication_OnValidateServerCertificate(object sender, ValidateServerCertificateEventArgs e)
        {
            if (e.CertificatePolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                return;
            }
            e.ValidityState = CertificateValidity.ForceValid;
        }

        private static void InstallCert()
        {
            try
            {
                if (!CertMaker.rootCertExists() && !CertMaker.createRootCert())
                {
                    throw new Exception("Could not create Root Certificate!");
                }
                if (!CertMaker.rootCertIsTrusted() && !CertMaker.trustRootCert())
                {
                    throw new Exception("Could not find valid Root Certificate for Fiddler!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Certificate Installer Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void BeforeResponse(Session e)
        {
            e.bBufferResponse = true;
            if (e.uriContains("ajax.php"))
            {
                var body = e.GetResponseBodyAsString();
                body = body.Replace("[]", "null");
                e.utilSetResponseBody(body);
            }
        }

        private static void BeforeRequest(Session e)
        {
            e.bBufferResponse = true;
        }
    }
}
