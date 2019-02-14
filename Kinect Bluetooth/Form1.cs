using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.IO;

namespace Kinect_Bluetooth
{
    public partial class Form1 : Form
    {
        List<string> items;
        public Form1()
        {
            items = new List<string>();
            InitializeComponent();
        }

        private void bGo_Click(object sender, EventArgs e)
        {
            if (serverStarted == true)
            {
                UpdateUI("Server already started");
            }
            if (SendRadioButton.Checked)
            {
                StartScan();
            }
            else if (RecieveRadioButton.Checked)
            {
                ConnectAsServer();
            }
            else
            {
                UpdateUI("Pick Send or Recieve");
            }
        }
        
        private void StartScan()
        {
            DevicesListBox.DataSource = null;
            DevicesListBox.Items.Clear();
            items.Clear();
            Thread bluetoothScanThread = new Thread(new ThreadStart(Scan));
            bluetoothScanThread.Start();
        }

        BluetoothDeviceInfo[] bluetoothDeviceInfos;
        private void Scan()
        {
            UpdateUI("Starting Scan...");
            BluetoothClient bluetoothClient = new BluetoothClient();
            bluetoothDeviceInfos = bluetoothClient.DiscoverDevicesInRange();
            UpdateUI("Scan complete");
            UpdateUI(bluetoothDeviceInfos.Length.ToString() + " Devices discovered");
            foreach(BluetoothDeviceInfo d in bluetoothDeviceInfos)
            {
                items.Add(d.DeviceName);
            }
            UpdateDeviceList();
        }
        private void UpdateDeviceList()
        {
            Func<int> del = delegate ()
            {
                DevicesListBox.DataSource = items;
                return 0;
            };
            Invoke(del);
        }

        private void ConnectAsServer()
        {
            Thread bluetoothServerThread = new Thread(new ThreadStart(ServerConnectThread));
            bluetoothServerThread.Start();
        }

        Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        bool serverStarted = false;
        public void ServerConnectThread()
        {
            serverStarted = true;
            UpdateUI("Server started ... Waiting for client");
            BluetoothListener bluetoothListener = new BluetoothListener(mUUID);
            bluetoothListener.Start();
            BluetoothClient bluetoothClient = bluetoothListener.AcceptBluetoothClient();
            UpdateUI("Server is connected ...");
            Stream mStream = bluetoothClient.GetStream();
            while (true)
            {
                try
                {
                    //handle server connection
                    byte[] recieved = new byte[1024];
                    mStream.Read(recieved, 0, recieved.Length);
                    UpdateUI("Recieved: " + Encoding.ASCII.GetString(recieved) + Environment.NewLine);
                    byte[] sent = Encoding.ASCII.GetBytes("Data Sent: " + recieved);
                    mStream.Write(sent, 0, sent.Length);
                }
                catch(IOException exception)
                {
                    UpdateUI("Client has disconnected");
                }
                
            }

        }

        BluetoothDeviceInfo deviceInfo;
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            deviceInfo = bluetoothDeviceInfos.ElementAt(DevicesListBox.SelectedIndex);
            UpdateUI(deviceInfo.DeviceName + " was selected, atempting to connect");
            if(PairDevice())
            {
                UpdateUI("device paired ...");
                UpdateUI("Starting Connect thread");
                Thread bluetoothClientThread = new Thread(new ThreadStart(ClientConnectThread));
                bluetoothClientThread.Start();
            }
            else
            {
                UpdateUI("Pair Failed");
            }
        }

        
        private void ClientConnectThread()
        {
            BluetoothClient bluetoothClient = new BluetoothClient();
            UpdateUI("Atempting connect");
            bluetoothClient.BeginConnect(deviceInfo.DeviceAddress, mUUID, this.BluetoothClientConnectCallback, bluetoothClient);
        }

        void BluetoothClientConnectCallback(IAsyncResult asyncResult)
        {
            BluetoothClient bluetoothClient = (BluetoothClient)asyncResult.AsyncState;
            bluetoothClient.EndConnect(asyncResult);
            Stream stream = bluetoothClient.GetStream();
            if (bluetoothClient.Connected == true)
            {
                UpdateUI("Device Connected");
            }
            else
            {
                UpdateUI("Device not connected ... try pairing");
            }
            if (bluetoothClient.Connected && stream != null)
            {
                byte[] buffer = sendData;
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
            }
            if (ready == true)
            {
                stream.Write(sendData, 0, sendData.Length);
            }
            else
            {
                ready = false;
            }
            //stream.ReadTimeout = 1000; //read for 1 second
            /*while (true)
            {
                while (!ready) ;
                stream.Write(sendData, 0, sendData.Length);
            }*/
        }

        string myPin = "1234";
        private bool PairDevice()
        {
            if (!deviceInfo.Authenticated)
            {
                if(!BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, myPin))
                {
                    return false;
                }
            }
            return true;
        }

        bool ready = false;
        byte[] sendData;
        private void tbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                sendData = Encoding.ASCII.GetBytes("Sent Data: " + SendTextBox.Text); //get text from texbox
                ready = true;
                SendTextBox.Clear(); //clear texbox
            }
        }

        private void UpdateUI(string message)
        {
            Func<int> del = delegate ()
            {
                InfoTextBox.AppendText(message + Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }

    }
}
