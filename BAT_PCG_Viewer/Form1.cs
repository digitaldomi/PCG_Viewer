using System;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace TestRealTimeCharts
{
    public partial class Form1 : Form
    {

        //Sampling
        private const int sampling_f = 1000;
        public const double time_step = 1 / (double)sampling_f;

        //Display
        private const int maxSize = 4000;
        private Thread cpuThread;
        private Thread newDataThread;
        private int[] cpuArray = new int[maxSize];
        private int index;
        private int index_max_size = maxSize;
        private int y_max_value = 10000;

        //Recording 
        private bool recording_active = false;
        FileAccess file;
        private double time_stamp = 0;

        //serial data
        static SerialPort _serialPort;
        public const int packetSize = 100; //amount of 24 bit packets
        private int data_offset = 6800;




        public Form1()
        {
            InitializeComponent();
        }

        private void updateChart()
        {
            //var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                //Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);
                if (pcgChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdatePcgChart(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(500);
            }
        }

        private void UpdatePcgChart()
        {
            pcgChart.Series["PCG"].Points.Clear();

            for (int i = 0; i < cpuArray.Length - 1; ++i)
            {
                //pcgChart.Series["PCG"].Points.AddXY(i/index_max_size, ((Int32)(cpuArray[i]<<8))/(256*256));
                pcgChart.Series["PCG"].Points.AddXY(i / index_max_size, cpuArray[i]);

            }
        }

        private void newData()
        {
            //Init com port
            _serialPort = new SerialPort();
            // Allow the user to set the appropriate properties.
            _serialPort.PortName = textBox_ComPort.Text;
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            // Set the read/write timeouts
            _serialPort.ReadTimeout = 250;
            _serialPort.WriteTimeout = 10;
            try
            {
                _serialPort.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error opening port " + textBox_ComPort.Text);
                closeApplication("COM_Init");

            }
          
            Console.WriteLine("Serial Port open:" + _serialPort.PortName);

            _serialPort.DiscardInBuffer();
            var data = new byte[packetSize*3+1]; //3*8bit=24bit per value + first leading byte

            int[] currentDataPacket = new int[packetSize]; ;
            while (true)
            {

                //Console.WriteLine("Data waiting: " + _serialPort.BytesToRead);

                try
                {
                    if (_serialPort.BytesToRead >= packetSize * 3 + 1)
                    {
                        //int counter = 0;

                        _serialPort.Read(data, 0, packetSize * 3 + 1); //Read n  byte





                        if (data[0] == 0xFE)
                        {
                            Console.WriteLine("V");
                            for (int i = 0; i < packetSize; i++)
                            {
                                if (index >= index_max_size)
                                {
                                    index = 0;
                                }

                                cpuArray[index] = (Int32)((((Int32)(data[i * 3 + 3] << 24) ^ (Int32)(data[i * 3 + 2] << 16) ^ (Int32)(data[i * 3 + 1] << 8))) >> 14) + data_offset;



                                if (recording_active == true) //fill array with values, use then to save to file
                                {
                                    currentDataPacket[i] = cpuArray[index];
                                }

                                index++;
                            }

                            if (recording_active)
                            {

                                file.writeToFile(textBox_FileName.Text, currentDataPacket, time_stamp);
                                time_stamp += time_step * packetSize; //update time base

                            }

                            //Console.WriteLine("Valid packet at " + index + ", Value: " + cpuArray[index]);
                            if (_serialPort.BytesToRead > 0)
                            {
                                Console.WriteLine(_serialPort.BytesToRead + " bytes remained and were discarded...");
                                _serialPort.DiscardInBuffer();
                            }

                        }
                        else
                        {
                            Console.WriteLine("X");
                            Console.WriteLine("Hex: {0:X} {0:X} {0:X} {0:X}", data[0], data[1], data[2], data[3]);
                            _serialPort.DiscardInBuffer();
                        }
                        //Console.WriteLine("Read packets: " + counter);
                    }
                    else
                    {
                        //nothing to read...
                    }
                }
                catch (Exception e)
                {
                    closeApplication("COM_Lost");
                }


                Thread.Sleep(20);

            }



            /*
            double time;
            int i;
            while (true)
            {
                time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                for (i = 0; i < 100; i++)
                {
                    if (index >= index_max_size)
                    {
                        index = 0;
                    }
                    time += 1;
                    cpuArray[index] = 500 + (int) (250 * Math.Sin(time/1000*100));
                   
                    index++;
                }
                //Console.WriteLine("1000 new points added");
                Thread.Sleep(100);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cpuThread = new Thread(new ThreadStart(this.updateChart));
            cpuThread.IsBackground = true;
            cpuThread.Start();

            newDataThread = new Thread(new ThreadStart(this.newData));
            newDataThread.IsBackground = true;
            newDataThread.Start();

            button_Recording.Enabled = true;
            button_Start.Enabled = false;
            button_Start.Text = "Running...";

            textBox_ComPort.Enabled = false;

            for(int i = 0; i < cpuArray.Length - 1; i++)
            {
                //pcgChart.Series["PCG"].Points.AddXY(i/index_max_size, ((Int32)(cpuArray[i]<<8))/(256*256));
                pcgChart.Series["PCG"].Points.AddXY(i / index_max_size, 0);

            }

            pcgChart.ChartAreas[0].AxisY.Minimum = -y_max_value;
            pcgChart.ChartAreas[0].AxisY.Maximum = y_max_value;
            pcgChart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            pcgChart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            pcgChart.ChartAreas[0].AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;



        }

        private void button_Recording_Click(object sender, EventArgs e)
        {
            if(file == null)
            {
                file = new FileAccess();
            }

            if (recording_active)
            {
                recording_active = false;
                button_Recording.Text = "Start Recording";
                file = null;
                textBox_FileName.Enabled = true;
            }
            else
            {
                recording_active = true;
                button_Recording.Text = "Stop recording";
                textBox_FileName.Enabled = false;
            }
        }

        private void label_ComPort_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Baud 115200, 8 Bit, 1 Stop Bit, No Handshake", "COM Port Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void closeApplication(String errorSource)
        {
            switch (errorSource)
            {
                case "COM_Lost":
                    MessageBox.Show("Connection to Port " + textBox_ComPort.Text + " lost!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "COM_Init":
                    MessageBox.Show("Connection to Port " + textBox_ComPort.Text + " not possible!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            System.Windows.Forms.Application.Exit();
        }
    }
}