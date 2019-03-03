using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InTheHand;
using InTheHand.Net.Ports;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.IO;

namespace Kinect_Bluetooth
{
    public partial class Form1 : Form
    {
        List<string> bluetoothDevices;
        public Form1()
        {
            bluetoothDevices = new List<string>();
            InitializeComponent();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if(connectionRunning == true)
            {
                UpdateUI("Connection Running");
                return;
            }
            if (ReceiveRadioButton.Checked)
            {
                ConnectAsReceiver();
            }
            else
            {
                StartScan();
            }
        }

        private void StartScan()
        {
            DevicesListBox.DataSource = null;
            DevicesListBox.Items.Clear();
            bluetoothDevices.Clear();
            Thread bluetoothScanThread = new Thread(new ThreadStart(Scan));
            bluetoothScanThread.Start();
        }
        BluetoothDeviceInfo[] bluetoothDeviceInfo;
        private void Scan()
        {
            UpdateUI("Starting Scan ...");
            BluetoothClient bluetoothClient = new BluetoothClient();
            bluetoothDeviceInfo = bluetoothClient.DiscoverDevicesInRange();
            UpdateUI("Scan Complete");
            UpdateUI(bluetoothDeviceInfo.Length.ToString() + " Devices Discovered");
            foreach (BluetoothDeviceInfo deviceInfo in bluetoothDeviceInfo)
            {
                bluetoothDevices.Add(deviceInfo.DeviceName);
            }
            UpdateDevicesList();
        }
        
        private void ConnectAsReceiver()
        {
            Thread bluetoothReceiverThread = new Thread(new ThreadStart(ReceiverConnectThread));
            bluetoothReceiverThread.Start();
        }
        

        Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        bool connectionRunning = false;
        public void ReceiverConnectThread()
        {
            connectionRunning = true;
            UpdateUI("Started ... Waiting for Connection ...");
            BluetoothListener bluetoothListener = new BluetoothListener(mUUID);
            bluetoothListener.Start();
            BluetoothClient bluetoothConnection = bluetoothListener.AcceptBluetoothClient();
            UpdateUI("Device Connected");
            Stream mStream = bluetoothConnection.GetStream();
            while (true)
            {
                try
                {
                    //handle receiver connection
                    byte[] receivedData = new byte[1024];
                    mStream.Read(receivedData, 0, receivedData.Length);
                    UpdateUI("Data Received: " + Encoding.ASCII.GetString(receivedData));
                    byte[] sentData = Encoding.ASCII.GetBytes("Hello World");
                    mStream.Write(sentData, 0, sentData.Length);
                }
                catch(IOException exception)
                {
                    UpdateUI("Bluetooth Disconnected");
                }
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
        private void UpdateDevicesList()
        {
            Func<int> del = delegate ()
            {
                DevicesListBox.DataSource = bluetoothDevices;
                return 0;
            };
            Invoke(del);
        }

        BluetoothDeviceInfo deviceInfo;
        private void DevicesListBox_DoubleClick(object sender, EventArgs e)
        {
            deviceInfo = bluetoothDeviceInfo.ElementAt(DevicesListBox.SelectedIndex);
            UpdateUI(deviceInfo.DeviceName + " was selected ... atempting to connect");
            if (PairDevice())
            {
                UpdateUI("Device Paired ... Starting Connection Thread");
                Thread bluetoothSenderThread = new Thread(new ThreadStart(SenderConnectThread));
                bluetoothSenderThread.Start();
            }
            else
            {
                UpdateUI("Pair Failed");
            }
        }

        private void SenderConnectThread()
        {
            BluetoothClient bluetoothClient = new BluetoothClient();
            UpdateUI("Atempting to Connect");
            bluetoothClient.BeginConnect(deviceInfo.DeviceAddress, mUUID, this.BluetoothSenderConnectCallback, bluetoothClient);
        }

        private void BluetoothSenderConnectCallback(IAsyncResult asyncResult)
        {
            BluetoothClient bluetoothClient = (BluetoothClient)asyncResult.AsyncState;
            bluetoothClient.EndConnect(asyncResult);
            Stream bluetoothStream = bluetoothClient.GetStream();
            bluetoothStream.ReadTimeout = 1000;
            while (true)
            {
                while (!ready) ;
                bluetoothStream.Write(message, 0, message.Length);
                ready = false;
            }
        }

        string myPIN = "1234";
        private bool PairDevice()
        {
            if (!deviceInfo.Authenticated)
            {
                if(!BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, myPIN))
                {
                    return false;
                }
            }
            return true;
        }

        bool ready = false;
        byte[] message;
        private void SendTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                message = Encoding.ASCII.GetBytes(SendTextBox.Text);
                ready = true;
                SendTextBox.Clear();
            }
        }
    }
}
