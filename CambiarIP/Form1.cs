using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Windows.Forms;

namespace CambiarIP
{
    public partial class Form1 : Form
    {
        /*
         *  V1.4
        */
        private static String version = "V1.4";
        private static DateTime expira = DateTime.Parse("2022/01/28");

        public Form1()
        {
            InitializeComponent();
        }
        String ip_anterior = "";
        String mask_anterior = "";
        String puerta_anterior = "";

        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!IsUserAdministrator())
            {
                MessageBox.Show("Debe iniciarse en modo Administrador.", "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            this.Text = "Cambiar IP - " + version;
            DateTime hoy = DateTime.Now;
            int result = DateTime.Compare(hoy, expira);
            if (result > 0)
            {
                MessageBox.Show("ERROR", "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //---------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------

            IPHostEntry host;
            string localIP = "";
            string mascara = "";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();

                    foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        //Obtener mascara
                        foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                        {
                            if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                if (localIP.Equals(unicastIPAddressInformation.Address.ToString()))
                                {
                                    mascara = unicastIPAddressInformation.IPv4Mask.ToString();
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
            }


            //Console.WriteLine("IP: " + localIP); 
            String[] ip_separada = localIP.Split('.');
            ip1.Text = ip_separada[0];
            ip2.Text = ip_separada[1];
            ip3.Text = ip_separada[2];
            ip4.Text = ip_separada[3];

            //Console.WriteLine("Mascara: " + mascara);
            String[] mask_separada = mascara.Split('.');
            mask1.Text = mask_separada[0];
            mask2.Text = mask_separada[1];
            mask3.Text = mask_separada[2];
            mask4.Text = mask_separada[3];

            String[] puerta_enlace = GetGateway().ToString().Split('.');
            gate1.Text = puerta_enlace[0];
            gate2.Text = puerta_enlace[1];
            gate3.Text = puerta_enlace[2];
            gate4.Text = puerta_enlace[3];
        }

        public static IPAddress GetGateway()
        {
            IPAddress result = null;
            var cards = NetworkInterface.GetAllNetworkInterfaces().ToList();
            if (cards.Any())
            {
                foreach (var card in cards)
                {
                    var props = card.GetIPProperties();
                    if (props == null)
                        continue;

                    var gateways = props.GatewayAddresses;
                    if (!gateways.Any())
                        continue;

                    var gateway =
                        gateways.FirstOrDefault(g => g.Address.AddressFamily.ToString() == "InterNetwork");
                    if (gateway == null)
                        continue;

                    result = gateway.Address;
                    break;
                };
            }
            if (result == null)
            {
                return System.Net.IPAddress.Parse("0.0.0.0");

            }
            else
            {
                return result;
            }
        }

        public void IP(string ip_address, string subnet_mask)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP =
                            objMO.GetMethodParameters("EnableStatic");

                        newIP["IPAddress"] = new string[] { ip_address };
                        newIP["SubnetMask"] = new string[] { subnet_mask };

                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al cambiar IP y Mascara\n\nError: " + error.Message, "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }

        public void Puerta_de_Enlace(string gateway, bool mostrarmsj = false, String msj = "")
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setGateway;
                        ManagementBaseObject newGateway = objMO.GetMethodParameters("SetGateways");

                        newGateway["DefaultIPGateway"] = new string[] { gateway };
                        setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
                        if (mostrarmsj == true)
                        {
                            MessageBox.Show(msj + "\n\nAdaptador: " + (string)objMO["Caption"], "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar la puerta de enlace.\n\nError: " + ex.Message, "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void DNS(string DNS)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject newDNS =
                            objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                        ManagementBaseObject setDNS =
                            objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void presionar_tecla(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;//set to false if you need that textbox gets enter key
            }
        }

        private void ping_Click(object sender, EventArgs e)
        {
            string command = "/C ping 8.8.8.8 -t";
            Process.Start("cmd.exe", command);
        }

        private void Activar_Click(object sender, EventArgs e)
        {
            String ip = ip1.Text + "." + ip2.Text + "." + ip3.Text + "." + ip4.Text;
            String mask = mask1.Text + "." + mask2.Text + "." + mask3.Text + "." + mask4.Text;
            String gateway = gate1.Text + "." + gate2.Text + "." + gate3.Text + "." + gate4.Text;

            IP(ip, mask);
            DNS("8.8.8.8");
            Puerta_de_Enlace(gateway, true, "IP Cambiada");
        }

        private void actializarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Visible = false;
                    ctrl.Text = "";
                }
            }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Visible = true;
                }
            }
            Form1_Load(sender, e);
        }

        private void certificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Certificate UNNE|*.crt";
            //choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            String sFileName = "";

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                sFileName = choofdlog.FileName;
            }

            try
            {
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                store.Add(new X509Certificate2(X509Certificate2.CreateFromCertFile(sFileName)));
                store.Close();
                MessageBox.Show("Certificado instalado.", "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al instalar el certificado.\n\nError: " + error.Message, "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void activarDHCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setGateway;
                        ManagementBaseObject newGateway = objMO.GetMethodParameters("SetGateways");
                        newGateway["DefaultIPGateway"] = null;
                        newGateway["GatewayCostMetric"] = new int[] { 1 };
                        setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);

                        objMO.InvokeMethod("SetDNSServerSearchOrder", new object[] { new string[0] });
                        objMO.InvokeMethod("EnableDHCP", new object[] { });
                        Form1_Load(sender, e);
                        MessageBox.Show("Se activo DHCP en el adaptador\n" + (string)objMO["Caption"], "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al activar DHCP.\n\nError: " + error.Message, "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }

        private void IPEdson_Click(object sender, EventArgs e)
        {
            IP("172.16.25.230", "255.255.240.0");
            DNS("8.8.8.8");
            Puerta_de_Enlace("172.16.16.252", true, "IP Cambiada");
            Form1_Load(sender, e);
        }

        private void guardarIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ip_anterior = ip1.Text + "." + ip2.Text + "." + ip3.Text + "." + ip4.Text;
            mask_anterior = mask1.Text + "." + mask2.Text + "." + mask3.Text + "." + mask4.Text;
            puerta_anterior = gate1.Text + "." + gate2.Text + "." + gate3.Text + "." + gate4.Text;

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "IP (*.ip) |*.ip";
                dialog.FileName = Environment.MachineName.ToString();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = dialog.OpenFile())
                    {
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.WriteLine(ip_anterior);
                            sw.WriteLine(mask_anterior);
                            sw.WriteLine(puerta_anterior);
                        }
                    }
                }
                MessageBox.Show("IP Guardada.", "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al guardar la IP.\n\nError: " + error.Message, "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "IP (*.ip) |*.ip";
                dialog.Title = "Selecciona el archivo IP  a cargar";

                String ip = "";
                String mask = "";
                String puerta = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(dialog.FileName))
                    {
                        string line;
                        int l = 0;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (l == 0) { ip = line; }
                            if (l == 1) { mask = line; }
                            if (l == 2) { puerta = line; break; }
                            l++;
                        }
                    }
                }
                IP(ip, mask);
                DNS("8.8.8.8");
                Puerta_de_Enlace(puerta, true, "IP Cargada");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cargar la IP.\n\nError: " + error.Message, "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
