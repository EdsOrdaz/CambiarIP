using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace CambiarIP
{
    public partial class Form1 : Form
    {
        /*
         *  V1.1
        */
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime exp = DateTime.Parse("2022/01/24");
            DateTime hoy = DateTime.Now;
            int result = DateTime.Compare(hoy, exp);
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

            //Console.WriteLine("Puerta: " + GetGateway().ToString());
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

            return result;
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
                    catch (Exception)
                    {
                        throw;
                    }


                }
            }
        }

        public void Puerta_de_Enlace(string gateway)
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar la puerta de enlace.\n\nError: "+ex.Message, "Cambiar IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
        
        private void dhcpToolStripMenuItem_Click(object sender, EventArgs e)
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
                    catch (Exception)
                    {
                        throw;
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

        private void s253_Click(object sender, EventArgs e)
        {
            Puerta_de_Enlace("172.16.18.253");
            MessageBox.Show("Puerta de enlace cambiada.", "Cmabiar IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1_Load(sender, e);
        }

        private void s252_Click(object sender, EventArgs e)
        {
            Puerta_de_Enlace("172.16.16.252");
            MessageBox.Show("Puerta de enlace cambiada.", "Cmabiar IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1_Load(sender, e);
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
            Puerta_de_Enlace(gateway);
            DNS("8.8.8.8");

            Console.WriteLine(ip);
            Console.WriteLine(mask);
            Console.WriteLine(gateway);

            MessageBox.Show("IP Cambiada.", "Cambias IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
